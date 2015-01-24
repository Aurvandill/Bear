using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public void Play()
    {
        Application.LoadLevel("Forest");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
