using UnityEngine;
using System.Collections;

public class BasicCam : MonoBehaviour
{
	
	public float smoothTime = 0.15f;
	private Vector3 speed = Vector3.zero;
	public Transform target;
	public float distance = 40;
    public float rotationSpeed;

	void Update ()
	{
		if (target != null)
		{
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, smoothTime);
		}
        RotateCam();
	}

    void RotateCam()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * -(rotationSpeed * Time.deltaTime), Space.World);
        }
    }
}