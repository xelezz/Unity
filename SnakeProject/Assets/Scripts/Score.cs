using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int value;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddScore(value);
        }
    }
}
