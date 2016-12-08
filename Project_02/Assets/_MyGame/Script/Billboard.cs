using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    public Transform target;

	void Start () {
        target = Camera.main.gameObject.transform;
	}
	
	void LateUpdate () {
        transform.rotation = Quaternion.LookRotation
            (target.forward, target.up);
	}
}
