using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab = null;

    public Animator anime = null;
    public float pullValue = 0.0f;
    public Transform start_pos = null;
    public Transform end_pos = null;
    public Transform socket_pos = null;

    public Transform pullHand = null;
    public Arrow current = null;

    // Start is called before the first frame update

    public void Awake()
    {
        anime = GetComponent<Animator>();
    }

    public IEnumerator createArrow(float waitingTime)
    {
        //wait for a bit
        yield return new WaitForSeconds(waitingTime);

        //create a new arrow
        GameObject newArrow = Instantiate(arrowPrefab, socket_pos);
        //make that arrow point forward
        newArrow.transform.localPosition = new Vector3(0, 0, 0.425f);
        newArrow.transform.localEulerAngles = Vector3.zero;
        //define the arrow as the current one
        current = newArrow.GetComponent<Arrow>();
    }

    void Start()
    {
        StartCoroutine(createArrow(0.0f));
    }

    // Update is called once per frame
    public void Update()
    {
        if (!current || !pullHand)
            return;

        pullValue = calcPull(pullHand);
        pullValue = Mathf.Clamp(pullValue, 0.0f, 1.0f);

        anime.SetFloat("Blend", pullValue);
    }

    public float calcPull(Transform hand)
    {
        Vector3 dir = end_pos.position - start_pos.position;
        float mag = dir.magnitude;
        dir.Normalize();

        Vector3 diff = hand.position - start_pos.position;
        return Vector3.Dot(diff, dir) / mag;

    }

    public void Pull(Transform hand)
    {
        float dist = Vector3.Distance(hand.position, start_pos.position);

        if(dist > 0.15f)
        {
            return;
        }

        pullHand = hand;
    }

    public void Release()
    {
        if(pullValue > 0.25f)
        {
            fireArrow();
            pullHand = null;
            pullValue = 0.0f;
            anime.SetFloat("Blend", 0.0f);

            if (!current)
                StartCoroutine(createArrow(0.25f));
        }
    }

    public void fireArrow()
    {
        current.Fire(pullValue);
        current = null;
    }
}
