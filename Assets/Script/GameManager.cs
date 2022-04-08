using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carSpawnPoints;
    private Camera mainCamera;
    public List<GameObject> cars;
    public Color[] carColors;

    private float timeRemaining;
    public float spawnDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        //InvokeRepeating("SpawnCar", 3, 2);
        timeRemaining = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SpawnCar();
            timeRemaining = spawnDelay;

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject car = SpawnCar();
            cars.Add(car);
        }


        //destroying cars once hey off the screen
        //for (int i = 0; i < cars.Count; i++)
        //{
        //    Vector2 screenPosition = mainCamera.WorldToViewportPoint(cars[i].transform.position);
        //    // Debug.Log("x: " + screenPosition.x);

        //    if (cars[i].GetComponent<CarMovements>().speed > 0)
        //    {
        //        if (screenPosition.x > 1)
        //        {
        //            Destroy(cars[i]);
        //            cars.Remove(cars[i]);
        //        }
        //    } else if (cars[i].GetComponent<CarMovements>().speed < 0)
        //    {
        //        if (screenPosition.x < 0)
        //        {
        //            Destroy(cars[i]);
        //            cars.Remove(cars[i]);
        //        }
        //    }
        //}
    }

    GameObject SpawnCar()
    {

        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawnPos = carSpawnPoints[index].position;
        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity); 

        int dirModifier = (index > 2) ? -1 : 1;

        float newSpeed = Random.Range(3.0f, 6.9f);

        int colorIndex = Mathf.FloorToInt(newSpeed) - 3;
        car.GetComponent<CarMovements>().speed = newSpeed * dirModifier;

        //Color color = new Color(
        //  Random.Range(0f, 1f),
        //  Random.Range(0f, 1f),
        //  Random.Range(0f, 1f)
        //);

        //car.GetComponent<Renderer>().material.color = color;

       
        //SpriteRenderer sr = car.GetComponent<SpriteRenderer>();

        //Color c;

        //if (newSpeed < 4.0f)
        //{
        //    c = carColors[0];
        //}
        //else if (newSpeed >= 4.0f && newSpeed < 5.0f)
        //{
        //    c = carColors[1];
        //}
        //else if (newSpeed >= 5.0f && newSpeed < 6.0f)
        //{
        //    c = carColors[2];
        //}
        //else
        //{
        //    c = carColors[3];
        //}

        car.GetComponent<Renderer>().material.color = carColors[colorIndex];

        return car;
    }
}
