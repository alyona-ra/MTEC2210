using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovements : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 carDirection = Vector3.right;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //You can get Vector (directions) shorthands like this:
        //Vector3.up etc...

        Vector3 carMovement = carDirection * speed * Time.deltaTime;


        //transform.Translate(carDirection * speed * Time.deltaTime);
        transform.Translate(carMovement);
    }
}
