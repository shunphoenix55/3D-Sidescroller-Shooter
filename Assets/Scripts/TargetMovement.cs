using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform upperPosition;
    public Transform lowerPosition;

    public float loopTime;
    public bool isReversed;

    // Movement speed in units per second.
    private Rigidbody rb;
    private float speed ;
    private float journeyDistance;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        // Distance from the lower position to upper position
        journeyDistance = Vector3.Distance(lowerPosition.transform.position, upperPosition.transform.position);

        speed = journeyDistance / loopTime;

        float currentDistance = Vector3.Distance(rb.transform.position, upperPosition.transform.position);
        if (isReversed)
        {
            currentDistance = journeyDistance - currentDistance;
        }

        // Time to reach the first end point
        float initialTime = currentDistance / speed;
        // Switch after reaching first end point
        StartCoroutine(InitialSwitch(initialTime));

        if (!isReversed)
        {
        rb.velocity = new Vector3(0, speed, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator InitialSwitch(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity *= -1;
        StartCoroutine(SwitchDirection());
    }

    IEnumerator SwitchDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(loopTime);
            rb.velocity *= -1;
        }
    }
}
