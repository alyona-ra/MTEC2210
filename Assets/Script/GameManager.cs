using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject car = SpawnCar();
        //    cars.Add(car);
        //}


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

       
        //SpriteRenderer sr = car.GetComponent<SpriteRenderer>();

        car.GetComponent<Renderer>().material.color = carColors[colorIndex];

        return car;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
