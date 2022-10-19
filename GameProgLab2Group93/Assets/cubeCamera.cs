using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCamera : MonoBehaviour
{
  [SerializeField] Transform mainCamera;
  [SerializeField] float distance = 10;
  [SerializeField] float sensitivity = 3;

  Vector3 cameraOffset;

  // Start is called before the first frame update
  void Start()
  {
    cameraOffset = (Vector3.up + Vector3.back).normalized * distance;
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 cameraRotation = new Vector2(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity);
    cameraOffset = Quaternion.Euler(cameraRotation) * cameraOffset;

    mainCamera.position = transform.position + cameraOffset;
    mainCamera.forward = -cameraOffset.normalized;
	}
}
