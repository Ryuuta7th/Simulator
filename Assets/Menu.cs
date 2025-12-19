using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync("SampleScene");
        //sasdsadsadsdasdsa
        Debug.Log("Start");
    }
} 
