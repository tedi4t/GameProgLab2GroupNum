using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActorBehaviour : MonoBehaviour
{
	[SerializeField] string sceneName;

	private Rigidbody rb;
	private GameObject mainCamera;
	
	// Start is called before the first frame update
	void Start()
  {
		rb = GetComponent<Rigidbody>();
		mainCamera = GameObject.Find("Main Camera");
		Debug.Log(transform.forward);
	}

	// Update is called once per frame
	void FixedUpdate()
  {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 verticalMovement = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z);
		Vector3 horizontalMovement = new Vector3(mainCamera.transform.right.x, 0, mainCamera.transform.right.z);
		Vector3 movement = horizontalInput * horizontalMovement.normalized + verticalInput * verticalMovement.normalized;

		rb.AddForce(movement.normalized, ForceMode.VelocityChange);
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Endpoint")
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}
