using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : NetworkBehaviour
{
    public float JumpSpeed = 400.0f;
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = Vector3.zero;

        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Jump()
    {
        //animation.Play("jump_pose");
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed);
    }
}