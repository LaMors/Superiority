using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCamera : MonoBehaviour
{
    float distance;
    Transform meinCamera;
    Camera CameraSize;

    public float sensitivity;
    public float sensZoom;

    void Start()

    {
        sensitivity = sensitivity * -1;
        sensZoom = sensZoom * -1;

        meinCamera = GetComponent<Transform>();
        CameraSize = GetComponent<Camera>();

    }
    private void LateUpdate()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)   Swipe();
       
        if (Input.touchCount == 2) Zoome();
        else if (distance != 0) distance = 0;
    }

    void Swipe()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition;
        meinCamera.position += new Vector3(Mathf.Sqrt(CameraSize.orthographicSize) * Time.deltaTime * sensitivity * delta.x, Mathf.Sqrt(CameraSize.orthographicSize) * Time.deltaTime * sensitivity * delta.y, 0);
        
    }
    void Zoome()
    {
        Vector2 Finger1 = Input.GetTouch(0).position;
        Vector2 Finger2 = Input.GetTouch(1).position;
        if (distance == 0) distance = Vector2.Distance(Finger1, Finger2);
        float delta = Vector2.Distance(Finger1, Finger2) - distance;

        CameraSize.orthographicSize += delta * Time.deltaTime * sensZoom * Mathf.Sqrt(CameraSize.orthographicSize);
        if (CameraSize.orthographicSize < 15f)
        {
            CameraSize.orthographicSize = 15f;
        }
        if (CameraSize.orthographicSize > 80f)
        {
            CameraSize.orthographicSize = 80f;
        }
        distance = Vector2.Distance(Finger1, Finger2);
    }
}

