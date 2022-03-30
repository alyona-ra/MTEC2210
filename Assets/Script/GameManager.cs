using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carSpawnPoints;
    private Camera mainCamera;
    public List<GameObject> cars;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject car = SpawnCar();
            cars.Add(car);
        }

        for (int i = 0; i < cars.Count; i++)
        {
            Vector2 screenPosition = mainCamera.WorldToViewportPoint(cars[i].transform.position);
            // Debug.Log("x: " + screenPosition.x);

            if (cars[i].GetComponent<CarMovements>().speed > 0)
            {
                if (screenPosition.x > 1)
                {
                    Destroy(cars[i]);
                    cars.Remove(cars[i]);
                }
            } else if (cars[i].GetComponent<CarMovements>().speed < 0)
            {
                if (screenPosition.x < 0)
                {
                    Destroy(cars[i]);
                    cars.Remove(cars[i]);
                }
            }
        }
    }

    GameObject SpawnCar()
    {

        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawnPos = carSpawnPoints[index].position;
        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity); 

        int dirModifier = (index > 2) ? -1 : 1;

        car.GetComponent<CarMovements>().speed = Random.Range(3.0f, 6.0f) * dirModifier;

        Color color = new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );

        car.GetComponent<Renderer>().material.color = color;

        return car;
    }
}
