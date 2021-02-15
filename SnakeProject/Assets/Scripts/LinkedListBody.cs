using UnityEngine;

public class LinkedListBody : MonoBehaviour
{
    public Node head;

    public class Node
    {
        public GameObject body;
        public int corr;
        public Node next;
        public Vector3 formerPosition = Vector3.zero;

        public Node(GameObject snakeBody)
        {
            body = snakeBody;
        }
    }

    internal void PushBack(GameObject snakeBody)
    {
        if (head == null)
        {
            head = new Node(snakeBody);
        }
        else
        {
            Node temp = GetLastNode();
            temp.next = new Node(snakeBody);
        }
    }

    public Node GetLastNode()
    {
        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        return temp;

    }

    public void LinkedListMovement(Vector3 dir)
    {
        Node currentNode = head;
        Node prevNode = null;
        currentNode.formerPosition = currentNode.body.transform.position;
        currentNode.body.transform.position += dir;

        while (currentNode.next != null)
        {
            prevNode = currentNode;
            currentNode = currentNode.next;
            currentNode.formerPosition = currentNode.body.transform.position;
            currentNode.body.transform.position = prevNode.formerPosition;
        }
    }
}
