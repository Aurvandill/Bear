using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public GameObject TextField;

    public void Update()
    {
        var t = TextField.GetComponent<Text>();

        if (t.text == "")
        {
            var ending = GameObject.Find("GameEndingInfo(Clone)").GetComponent<GameEndingInfo>().Ending;
            t.text = ending;
        }
    }


    public void MainMenu()
    {
        Destroy(GameObject.Find("GameEndingInfo(Clone)"));
        Application.LoadLevel("MainMenu");
    }
}
