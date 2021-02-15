using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : Player
{

    public Text mushroomText;
    
    public void Awake()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
            Player player = FindObjectOfType<Player>();
        #region Trigger
        if (other.CompareTag("Mushroom"))
        {
            player.mushrooms++;
            Destroy(other.gameObject);
        #endregion Trigger
        }

        
        { mushroomText.text = "Mushrooms: " + player.mushrooms + "!"; //Makes mushroom counter apper on screen
        }
    }
}
