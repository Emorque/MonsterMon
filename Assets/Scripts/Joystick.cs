using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public CharacterController player;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        Vector3 position = (transform.right * joystickAxis.x + transform.forward * joystickAxis.y) * speed * Time.deltaTime;
        player.Move(position);
    }
}
