using UnityEngine;

public class MainCamera : MonoBehaviour
{

    void Update()
    {
        #region FindPlayer
        Player player = FindObjectOfType<Player>();
        transform.position = player.transform.position + new Vector3(0.0f, 5.0f, -20.0f);
        #endregion FindPlayer
    }
}
