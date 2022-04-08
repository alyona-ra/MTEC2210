using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovements : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 carDirection = Vector3.right;
    //private GameObject player;


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

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (player != null)
        //    {
        //        player.transform.SetParent(null);
        //        player.GetComponent<BoxCollider2D>().enabled = true;
        //    }
        //}
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //player = collision.gameObject;
            //player.GetComponent<BoxCollider2D>().enabled = false;
            //player.transform.position = transform.position;
            //player.transform.SetParent(transform);
        }
    }
}