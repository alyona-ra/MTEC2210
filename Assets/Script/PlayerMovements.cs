using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float speed = 5.0f;
    public GameManager gameManager;
    private AudioSource audioSource;

    public AudioClip hopClip;

    public float moveDuration = 0.5f;
    private float timeElapsed;
    private Vector3 targetPosition;
    private bool readyToMove = true;
    private bool isMoving = false;
    private float moveMultiplier = 0.5f;

    public enum MovementType
    {
        Continuous,
        Discrete,
    }

    public MovementType movementType;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementType == MovementType.Continuous)
        {
            ContinuousMovement();
        }
        else
        {
            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SetTargetPosition("Up");
                    audioSource.PlayOneShot(hopClip);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SetTargetPosition("Down");
                    audioSource.PlayOneShot(hopClip);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SetTargetPosition("Left");
                    audioSource.PlayOneShot(hopClip);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    SetTargetPosition("Right");
                    audioSource.PlayOneShot(hopClip);
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if (targetPosition != transform.position)
            {
                isMoving = true;
                
                DiscreteMovement(transform.position, targetPosition);
            }
            else
            {
                isMoving = false;
            }
        }
    }

    public void SetTargetPosition(string direction)
    {
        if (direction == "Up")
        {
            targetPosition = transform.position + (Vector3.up * moveMultiplier);
        }
        if (direction == "Down")
        {
            targetPosition = transform.position + (Vector3.down * moveMultiplier);
        }
        if (direction == "Left")
        {
            targetPosition = transform.position + (Vector3.left * moveMultiplier);
        }
        if (direction == "Right")
        {
            targetPosition = transform.position + (Vector3.right * moveMultiplier);
        }
    }

    public void ContinuousMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        float xMovement = xMove * speed * Time.deltaTime;
        float yMovement = yMove * speed * Time.deltaTime;

        //transform.position = new Vector3(transform.position.x + xMovement, transform.position.y + yMovement, 0);
        transform.Translate(xMovement, yMovement, 0);

        if (xMove == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //audioSource.clip = hopClip;
        if (xMove != 0 || yMove != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void DiscreteMovement(Vector3 start, Vector3 end)
    {
        timeElapsed += Time.deltaTime;
        transform.position = Vector3.Lerp(start, end, timeElapsed / moveDuration);

        if (timeElapsed >= moveDuration)
        {
            transform.position = targetPosition;
            //isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You Won");
            gameManager.ReloadScene();
        }
    }
}
