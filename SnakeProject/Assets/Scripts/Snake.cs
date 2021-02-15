using UnityEngine;

public class Snake : MonoBehaviour
{    
    [SerializeField] private float currentMoveSpeed = 0f;
    [SerializeField] private float timerOffset = 0f;
    [SerializeField] private float maxBodyCount = 0f;
    [SerializeField] private float timer = 0f;

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject snakeHead;

    private LinkedListBody linkedList;

    private Vector2 moveDirection = Vector2.zero;

    public void Awake()
    {
        linkedList = GetComponent<LinkedListBody>();
        maxBodyCount--;
        timer = Time.time + timerOffset;
        snakeHead = Instantiate(snakeHead, transform.position, Quaternion.identity);
        snakeHead.transform.parent = gameObject.transform;
        linkedList.PushBack(snakeHead);

    }

    public void Update()
    {
        if (Input.anyKeyDown) { SnakeMovement(); }
        if (Time.time >= timer)
        {
            linkedList.LinkedListMovement(moveDirection);
            timer = Time.time + timerOffset;
        }
    }

    public void SnakeMovement()
    {        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down * currentMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up * currentMoveSpeed;
        }
   
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right * currentMoveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left * currentMoveSpeed;
        }
    }

        private GameObject  InstantiateSnake()
        {
          GameObject snakeHead = Instantiate(body, linkedList.GetLastNode().formerPosition, Quaternion.identity);
            snakeHead.transform.parent = gameObject.transform;
            return snakeHead;
            
        }

    public void GrowBody()
    {
        if(maxBodyCount != 0)
        {
            maxBodyCount--;

            linkedList.PushBack(InstantiateSnake());
        }
    }
}