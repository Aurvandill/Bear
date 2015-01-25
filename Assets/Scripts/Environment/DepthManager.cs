using UnityEngine;
using System.Collections;

public class DepthManager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("Depth");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if (sr == null)
            return;

        int order = (int)((player.transform.position.y - (sr.bounds.size.y / 2))  * 100 * -1);
        
        player.GetComponent<SpriteRenderer>().sortingOrder = order + 30;


        for (int i = 0; i < gameObjs.Length; i++)
        {
            sr = gameObjs[i].GetComponent<SpriteRenderer>();
            order = (int)((gameObjs[i].transform.position.y - (sr.bounds.size.y / 2)) * 100 * -1);

            gameObjs[i].GetComponent<SpriteRenderer>().sortingOrder = order;
        }
	}
}
