using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject carCam;

    public void SwitchToCar(bool inside)
    {
        playerCam.SetActive(!inside);
        carCam.SetActive(inside);
    }

    bool insideCar = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            insideCar = !insideCar;

            playerCam.SetActive(!insideCar);
            carCam.SetActive(insideCar);

            Debug.Log("Camera switched. insideCar = " + insideCar);
        }
    }
}
