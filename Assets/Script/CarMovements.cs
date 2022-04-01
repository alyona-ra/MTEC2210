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
        Vector3 carMovement = carDirection * speed * Time.deltaTime;
        transform.Translate(carMovement);
        //transform.position = Camera.main.ScreenToWorldPoint(carMovement);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}