using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    public void Continue()
    {
        Time.timeScale = 1;
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void Exit()
    {
        Application.LoadLevel(0);
    }
}
