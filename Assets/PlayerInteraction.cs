using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Vehicle nearbyVehicle;

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && nearbyVehicle != null)
        {
            nearbyVehicle.EnterVehicle(GetComponent<PlayerMovement>());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Vehicle vehicle))
        {
            nearbyVehicle = vehicle;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Vehicle vehicle))
        {
            if (vehicle == nearbyVehicle)
                nearbyVehicle = null;
        }
    }
}
