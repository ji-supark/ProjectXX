using UnityEngine;
using System.Collections;

public class AniEvent : MonoBehaviour {
    public Transform makePoint;
    public GameObject obj;

    void MakeGameObject()
    {
        GameObject tempOBJ = Instantiate(obj, makePoint.position, Quaternion.identity) as GameObject;
    }
}
