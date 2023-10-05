using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string semaphoreTag = "Semaphore";
    private const string carTag = "Car";
    private Rigidbody _rigidbody;
    private RaycastHit closestValidHit;
    private bool countingDown = false;
    private float currentCountDown = float.MaxValue;
    public MoveDirection moveDirection;
    public bool move = false;
    public float speed = 2.5f;
    public float raycastDistance = 1.0f;
    public int maxTimeStopped = 10;
    public bool warnHalfTime = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        closestValidHit = new RaycastHit();
    }

    void Update() {
        if(countingDown) {
            currentCountDown -= Time.deltaTime;
            Debug.Log($"Counting down");
        }

        if((int) currentCountDown == maxTimeStopped/2 && !warnHalfTime) {
            warnHalfTime = true;
            Debug.Log("HalfTime");
        }

        if((int) currentCountDown == 0 && !gameOver) {
            Time.timeScale = 0;
            gameOver = true;
            Debug.Log("Game Over");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.right, raycastDistance);
        closestValidHit = new RaycastHit();
        foreach(RaycastHit hit in hits) {
            if(!hit.transform.IsChildOf(transform) &&
                (closestValidHit.collider == null || closestValidHit.distance > hit.distance)
            ) {
                closestValidHit = hit;
                Debug.Log($"{this.gameObject} raycast hit with {closestValidHit.collider.gameObject}");
            }
        }

        if(closestValidHit.collider != null) {
            if(closestValidHit.transform.tag == semaphoreTag) {
                Debug.Log($"{this.gameObject} hit semaphore");
                _rigidbody.velocity = Vector3.zero;
                move = false;
            }

            if(closestValidHit.transform.tag == carTag) {
                Debug.Log($"{this.gameObject} hit cat");
                _rigidbody.velocity = Vector3.zero;
                move = false;
            }

            if(!countingDown) {
                countingDown = true;
                currentCountDown = maxTimeStopped;
                Debug.Log("Starting count down");
            }
        } else {
            move = true;

            if(countingDown) {
                countingDown = false;
                currentCountDown = float.MaxValue;
                warnHalfTime = false;
                gameOver = false;
                Debug.Log("Stopping count down");
            }
        }

        Debug.DrawRay(transform.position, transform.right * raycastDistance, Color.green);
        if(move)
            Move();
    }

    void Move() {
        Quaternion movementDirection;

        switch (moveDirection)
        {
            case MoveDirection.North:
                movementDirection = Quaternion.Euler(0, MoveDirection.North.ToFloat(), 0);
                break;
            case MoveDirection.East:
                movementDirection = Quaternion.Euler(0, MoveDirection.East.ToFloat(), 0);
                break;
            case MoveDirection.South:
                movementDirection = Quaternion.Euler(0, MoveDirection.South.ToFloat(), 0);
                break;
            default:
                movementDirection = Quaternion.Euler(0, MoveDirection.West.ToFloat(), 0);
                break;
        }

        _rigidbody.velocity = transform.right * speed;
        transform.rotation = movementDirection;
    }
}
