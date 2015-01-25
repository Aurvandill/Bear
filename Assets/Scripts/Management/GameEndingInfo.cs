using UnityEngine;
using System.Collections;

public class GameEndingInfo : MonoBehaviour {

    public string Ending;

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
}
