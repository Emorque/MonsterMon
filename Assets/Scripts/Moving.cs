using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public CharacterController player;
    public GameObject eye;
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Vector3 newDirection = eye.transform.localRotation * new Vector3(0.0f, 0.0f, 1.0f);
            player.Move(speed * newDirection);
        }
    }
}
