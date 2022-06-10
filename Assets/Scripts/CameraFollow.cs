using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetObject;

    public Vector3 cameraOffset;

    public Quaternion cameraRotationOffset;

    public float smoothFactor = 0.5f;

    public bool rotateCamera = true;




    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
        cameraRotationOffset = transform.rotation * Quaternion.Inverse(targetObject.transform.rotation);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        if (rotateCamera)
        {
            Quaternion target = targetObject.transform.rotation * cameraRotationOffset;

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothFactor);
        }

    }
}
