using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject xt;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();

    }

    private void CameraFollow()
    {
        transform.position = playerTransform.position + offset;
        xt.transform.position = transform.position;
    }
}
