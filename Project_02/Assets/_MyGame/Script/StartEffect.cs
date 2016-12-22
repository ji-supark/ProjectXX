using UnityEngine;
using System.Collections;

public class StartEffect : MonoBehaviour {

    public GameObject startFX;

	// Use this for initialization
	void Start () {

        Instantiate(startFX, new Vector3(0, 0, 0), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
