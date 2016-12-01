using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float distance = 10.0f; //카메라와 대상의 거리.
    public float hozAngle = -90.0f; //카메라의 수평 위치.
    public float verAngle = 45.0f; //카메라의 수직위치.
    public Vector3 offset = Vector3.zero; //카메라의 위치 수정 값.
    public Transform lookAtTarget; //카메라가 바라보는 대상.
    
	void LateUpdate () {
        if (lookAtTarget != null)
        {
            //카메라 바라보는 위치 설정.
            Vector3 lookPosition = lookAtTarget.position + offset;
            //카메라의 상대위치 설정.
            Vector3 relativePos = Quaternion.Euler(verAngle, hozAngle, 0) *
                new Vector3(0, 0, -distance);
            //카메라의 위치를 적용.
            transform.position = lookPosition + relativePos;
            //lookAtTarget을 카메라가 바라보게 한다.
            transform.LookAt(lookAtTarget);
         }
	}
}
