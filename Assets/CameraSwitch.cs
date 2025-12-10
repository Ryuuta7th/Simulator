using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineCamera PlayerCam;
    public CinemachineCamera CarCam;

    private bool insideCar = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            insideCar = !insideCar;
            
            Debug.Log("SWITCH CAMERA! InsideCar = " + insideCar);

            if (insideCar)
            {
                PlayerCam.Priority = 10;
                CarCam.Priority = 20;
                Debug.Log("CarCam LIVE!");
            }
            else
            {
                PlayerCam.Priority = 20;
                CarCam.Priority = 10;
                Debug.Log("PlayerCam LIVE!");
            }

            Debug.Log("PlayerCam Pri = " + PlayerCam.Priority + " | CarCam Pri = " + CarCam.Priority);
        }
    }
}
