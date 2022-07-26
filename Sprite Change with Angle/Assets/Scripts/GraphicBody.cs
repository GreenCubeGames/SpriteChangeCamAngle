using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicBody : MonoBehaviour
{
    Transform localCam;
    public Transform body;

    public bool rotate;

    Vector3 forward;
    Vector3 toOther;

    Vector3 right;
    Vector3 toOtherR;

    public GameObject front, frontSide, side, backSide, back;

    //If not right is left, if not front back.
    public bool isRight;

    private void Start()
    {
        localCam = Camera.main.transform;
        if(body == null)
        body = transform.GetChild(0);
    }

    private void LateUpdate()
    {
        forward = transform.TransformDirection(Vector3.forward).normalized;
        toOther = localCam.position - transform.position;

        right = transform.TransformDirection(Vector3.right).normalized;
        toOtherR = localCam.position - transform.position;

        if (rotate)
        {
            float sum = Vector3.Dot(toOther, forward) / Vector3.Distance(transform.position, localCam.transform.position);

            if (sum >= -.7f && sum <= -.5f)
            {
                front.SetActive(false);
                frontSide.SetActive(false);
                side.SetActive(false);
                backSide.SetActive(true);
                back.SetActive(false);

            }
            else if (sum < -.7 && sum >= -1)
            {
                front.SetActive(false);
                frontSide.SetActive(false);
                side.SetActive(false);
                backSide.SetActive(false);
                back.SetActive(true);
            }
            else if (sum > -.5 && sum <= .5)
            {
                front.SetActive(false);
                frontSide.SetActive(false);
                side.SetActive(true);
                backSide.SetActive(false);
                back.SetActive(false);
            }
            else if (sum > .5 && sum <= .7)
            {
                front.SetActive(false);
                frontSide.SetActive(true);
                side.SetActive(false);
                backSide.SetActive(false);
                back.SetActive(false);
            }
            else
            {
                front.SetActive(true);
                frontSide.SetActive(false);
                side.SetActive(false);
                backSide.SetActive(false);
                back.SetActive(false);
            }
        }
        if (Vector3.Dot(toOtherR, right) > 0)
        {
            isRight = false;
            front.transform.localScale = Vector3.one;
            frontSide.transform.localScale = Vector3.one;
            side.transform.localScale = Vector3.one;
            backSide.transform.localScale = Vector3.one;
            back.transform.localScale = Vector3.one;
        }
        else
        {
            isRight = true;
            //this place mirror the sprite to make it appear as different angle
            front.transform.localScale = new Vector3(-1f, 1f, 1f);
            frontSide.transform.localScale = new Vector3(-1f, 1f, 1f);
            side.transform.localScale = new Vector3(-1f, 1f, 1f);
            backSide.transform.localScale = new Vector3(-1f, 1f, 1f);
            back.transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        body.forward = (localCam.position - transform.position)*-1;
    }
}

