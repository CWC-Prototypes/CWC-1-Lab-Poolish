using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The Player is an empty game object with the cue stick as it's child.
 * The Player's parent is the cue ball, which means we always know where
 * the cue ball is.
 */

public class PlayerController : MonoBehaviour
{
    public GameObject cueBall;
    public GameObject cueStick;

    public float angleRate = 20.0f;
    public float drawRate = 5.0f;
    public float forceScale = 1.0f;

    public Vector3 offset;

    public float cueAngle;
    public float cueDraw;

    private Rigidbody cueBallRb;

    // Start is called before the first frame update
    void Start()
    {
        // Initial distance from center of cue ball to the
        // center of the cue stick. Used for calculating the
        // force to impart when the cue strikes the ball.
        offset = cueBall.transform.position - transform.position;

        cueBallRb = cueBall.GetComponent<Rigidbody>();
        if (!cueBallRb)
        {
            Debug.Log("Failed to get cueBallRb.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Cue Positioning
         *
         * Left & right arrow keys set cue angle.
         * Up & down arrow keys draw back the cue to set
         * the striking force.
         */
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, inputX * angleRate * Time.deltaTime);
        cueStick.transform.Translate(Vector3.forward * inputZ * drawRate * Time.deltaTime);

        // Shoot when spacebar is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Shoot");
            var forceVector = cueBall.transform.position - cueStick.transform.position;
            cueBallRb.AddForce(forceVector * forceScale, ForceMode.Impulse);
        }
    }
}
