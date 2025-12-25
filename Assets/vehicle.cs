using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform seatPoint;

    private bool isOccupied;
    private PlayerMovement currentPlayer;

    public void EnterVehicle(PlayerMovement player)
    {
        if (isOccupied) return;

        isOccupied = true;
        currentPlayer = player;

        player.gameObject.SetActive(false);
        player.transform.position = seatPoint.position;
    }

    public void ExitVehicle()
    {
        if (!isOccupied) return;

        isOccupied = false;
        currentPlayer.gameObject.SetActive(true);
        currentPlayer.transform.position = transform.position + Vector3.right;

        currentPlayer = null;
    }
}
