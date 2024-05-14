using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_oculus : MonoBehaviour
{
    public CharacterController player;
    public Transform headset;
    public float speed = 2.0f; 

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        var joyStickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);

        // Get the forward direction of the headset
        Vector3 forwardDirection = Vector3.ProjectOnPlane(headset.forward, Vector3.up).normalized;

        // Calculate movement direction in relation to the headset's forward direction
        Vector3 moveDirection = (forwardDirection * joyStickAxis.y + headset.right * joyStickAxis.x).normalized;

        // Move the player in the calculated direction
        player.Move(moveDirection * speed * Time.deltaTime);
    }
}
