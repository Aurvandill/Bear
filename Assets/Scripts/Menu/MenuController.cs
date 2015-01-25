using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
