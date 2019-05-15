using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Player Components")]
    public Vector3 endPoint;


    private void Update()
    {
        #if UNITY_EDITOR
        EditorMovement();
        #endif

        #if UNITY_ANDROID
        AndroidMovement();
        #endif
    }
    void EditorMovement()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                endPoint = hit.point;
                Vector3 lookPos = new Vector3(endPoint.x, 0, hit.point.z);
                Debug.Log(endPoint);
                transform.LookAt(lookPos);
                transform.localEulerAngles += new Vector3(transform.rotation.x, transform.rotation.y + 70, transform.rotation.z);

            }
        }
    }
    void AndroidMovement()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            RaycastHit hit;
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                endPoint = hit.point;
                Vector3 lookPos = new Vector3(endPoint.x, 0, hit.point.z);
                transform.LookAt(lookPos);
                transform.localEulerAngles += new Vector3(transform.rotation.x, transform.rotation.y + 70, transform.rotation.z);

            }

        }
    }
}
