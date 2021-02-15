using UnityEngine;

[RequireComponent(typeof(CarMovement))]
public class PlayerInput : MonoBehaviour
{
    private CarMovement movement;

    #region Input IDs
    private const string driveInputId = "Drive";  
    #endregion Input IDs

    private void Awake()
    {
        movement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        movement.movementInput.Set(0f, Input.GetAxis(driveInputId));
    }
}
