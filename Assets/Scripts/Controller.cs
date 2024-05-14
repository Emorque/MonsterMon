using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Bow bow = null;
    public GameObject oppositeCon = null;
    public OVRInput.Controller controllerType = OVRInput.Controller.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controllerType)){
            bow.Pull(oppositeCon.transform);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controllerType)){
            bow.Release();
        }
    }
}
