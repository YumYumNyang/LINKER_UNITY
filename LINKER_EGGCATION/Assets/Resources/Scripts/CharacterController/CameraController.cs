using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float distance = 3;
    private float   rotateSpeedX  = 3;
    private float   rotateSpeedY  = 5;
    private float   limitMinX = -80;
    private float   limitMaxX = 50;
    private float   eulerAngleX = 3;
    private float   eulerAngleY = 3;

    public void ChangeView(int toggleView)
    {
        if(Input.GetKeyDown("v")){
          Debug.Log("ㅂㅓ튼 클릭~~~");
          toggleView = toggleView == 1 ? 3 : 1;
        }
        if (toggleView == 1)
        {
          Vector3 reverseDistance = new Vector3(0.0f, 0.4f, 0.2f); 
          transform.position = player.transform.position + transform.rotation * reverseDistance; 
        }
        else if (toggleView == 3)
        {
          Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); 
          transform.position = player.transform.position - transform.rotation * reverseDistance; 
        }
    }

    public void RotateTo(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX  * rotateSpeedX;
        eulerAngleX -= mouseY  * rotateSpeedY;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)   angle += 360;
        if (angle > 360)    angle -= 360;

        // Mathf.Clamp()를 이용해 angle이 min <= angle <= max를 유지하도록 함.
        return Mathf.Clamp(angle, min, max);
    }
}
