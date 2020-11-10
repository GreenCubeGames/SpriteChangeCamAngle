using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicBody : MonoBehaviour
{
    Transform localCam;
    public Transform body;

    Vector3 forward;
    Vector3 toOther;

    Vector3 right;
    Vector3 toOtherR;

    public GameObject front;
    public GameObject back;

    //If not right is left, if not front back.
    public bool isRight;

    private void Start()
    {
        localCam = Camera.main.transform;
        //this just assume that body is the first child, you can change it.
        body = transform.GetChild(0);
    }

    private void LateUpdate()
    {
        forward = transform.TransformDirection(Vector3.forward);
        toOther = localCam.position - transform.position;

        right = transform.TransformDirection(Vector3.right);
        toOtherR = localCam.position - transform.position;
        if (Vector3.Dot(toOther, forward) < 0)
        {
            front.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
        }
        if (Vector3.Dot(toOtherR, right) < 0)
        {
            isRight = false;
            front.transform.localScale = Vector3.one;
            back.transform.localScale = Vector3.one;
        }
        else
        {
            isRight = true;
            //this place mirror the sprite to make it appear as different angle
            front.transform.localScale = new Vector3(-1f, 1f, 1f);
            back.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        body.forward = localCam.position - transform.position;
    }
}

