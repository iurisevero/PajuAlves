using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private RaycastHit closestValidHit;
    private bool countingDown = false;
    private float currentCountDown = Constants.maxCountDown;
    public MoveDirection moveDirection;
    public bool move = false;
    public float speed = 2.5f;
    public float raycastDistance = 1.0f;
    public int maxTimeStopped = 10;
    public int pointsToAdd = 1;
    public bool warnHalfTime = false;
    public bool warnOneQuarter = false;
    public bool onCountDownCoroutine = false;
    public Image countDownBackground, countDownImage, countDownFace;
    public Sprite happySprite, okSprite, angrySprite;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        closestValidHit = new RaycastHit();
        countDownBackground.gameObject.SetActive(false);
    }

    void Update() {
        if(GameController.Instance.gameOver) return;

        if(countingDown) {
            currentCountDown -= Time.deltaTime;
            countDownImage.fillAmount = (100.0f - (currentCountDown * 100.0f / maxTimeStopped))/100.0f;
            // Debug.Log($"Counting down");
        }

        if((int) currentCountDown == maxTimeStopped/2 && !warnHalfTime) {
            warnHalfTime = true;
            countDownImage.color = Color.yellow;
            countDownFace.sprite = okSprite;
            AudioManager.Instance.PlayHornEffect(
                0.5f, UnityEngine.Random.Range(0.5f, 2.0f)
            );
            Debug.Log("HalfTime");
        }

        if((int) currentCountDown == maxTimeStopped/4 && !warnOneQuarter) {
            warnOneQuarter = true;
            countDownImage.color = Color.red;
            countDownFace.sprite = angrySprite;
            AudioManager.Instance.PlayHornEffect(
                0.75f, UnityEngine.Random.Range(0.5f, 2.0f)
            );
            Debug.Log("OneQuarter");
        }

        if(currentCountDown <= 0 && !GameController.Instance.gameOver) {
            GameController.Instance.GameOver();
            Debug.Log("Game Over");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameController.Instance.gameOver) return;
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.right, raycastDistance);
        closestValidHit = new RaycastHit();
        foreach(RaycastHit hit in hits) {
            if(!hit.transform.IsChildOf(transform) &&
                (closestValidHit.collider == null || closestValidHit.distance > hit.distance)
            ) {
                closestValidHit = hit;
                // Debug.Log($"{this.gameObject} raycast hit with {closestValidHit.collider.gameObject}");
            }
        }

        if(closestValidHit.collider != null) {
            if(closestValidHit.transform.tag == Constants.semaphoreTag) {
                // Debug.Log($"{this.gameObject} hit semaphore {closestValidHit.transform.gameObject}");
                if(moveDirection.InvertDirection(
                        closestValidHit.transform.GetComponent<DirectionalCollider>().direction
                    )
                ) {
                    _rigidbody.velocity = Vector3.zero;
                    move = false;
                }
            }

            if(closestValidHit.transform.tag == Constants.carTag) {
                // Debug.Log($"{this.gameObject} hit cat");
                _rigidbody.velocity = Vector3.zero;
                move = false;
            }

            if(!countingDown && !move && !onCountDownCoroutine) {
                onCountDownCoroutine = true;
                StartCoroutine(StartCountingDownCoroutine());
            }
        } else {
            move = true;

            if(countingDown) {
                countingDown = false;
                currentCountDown = Constants.maxCountDown;
                warnHalfTime = false;
                warnOneQuarter = false;
                onCountDownCoroutine = false;
                countDownBackground.gameObject.SetActive(false);
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

    IEnumerator StartCountingDownCoroutine() {
        yield return new WaitForSeconds(1f);
        countingDown = true;
        countDownImage.fillAmount = 0;
        countDownImage.color = Color.green;
        countDownFace.sprite = happySprite;
        countDownBackground.gameObject.SetActive(true);
        currentCountDown = maxTimeStopped;
        Debug.Log("Starting count down");
    }
}
