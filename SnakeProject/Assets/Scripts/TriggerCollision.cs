using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour
{
    public Snake snake;

    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 0f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 0f;

private void Start()
    {
        snake = this.gameObject.GetComponentInParent<Snake>();
    }

    public void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Fruits")
        {

            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            collision.transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.identity);
            snake.GrowBody();
        }
        if (collision.tag == "Body" || collision.tag == "Walls")
        {
            SceneManager.LoadScene(1);
        }
    }
}