using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 2000.0f;
    public Transform tip = null;
    public Rigidbody rbArrow = null;
    public bool stopped = true;

    public Vector3 last_pos = Vector3.zero;

    private void Awake()
    {
        rbArrow = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (stopped)
            return;
        //rotating the rigidbody to follow the arrow
        rbArrow.MoveRotation(Quaternion.LookRotation(rbArrow.velocity, transform.up));

        if(Physics.Linecast(last_pos, tip.position))
        {
            Stop();
        }

        last_pos = tip.position;
    }

    public void Stop()
    {
        stopped = true;

        rbArrow.isKinematic = true;
        rbArrow.useGravity = false;
    }

    public void Fire(float pullValue)
    {
        stopped = false;
        rbArrow.isKinematic = false;
        rbArrow.useGravity = true;

        transform.parent = null;
        rbArrow.AddForce(transform.forward * (pullValue * speed));

        Destroy(gameObject, 10.0f);
    }
}
