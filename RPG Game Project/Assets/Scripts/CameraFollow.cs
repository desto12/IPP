using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 15f;
    public Vector3 offset;
    public float smoothSpeed = 5f;
    public float scrollSensivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float num = Input.GetAxis("Mouse ScrollWheel");
        distance -= num * scrollSensivity;
        distance = Mathf.Clamp(distance, 1f, 15f);

        Vector3 position = target.position + offset;
        position -= transform.forward * distance;
;       transform.position = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);
    }
}
