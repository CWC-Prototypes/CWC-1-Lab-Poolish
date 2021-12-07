using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cueBall;
    public GameObject cueStick;
    public float angleRate = 10.0f;
    public float drawRate = 10.0f;

    public Vector3 offset;

    public float cueAngle;
    public float cueDraw;

    // Start is called before the first frame update
    void Start()
    {
        // Initial distance from center of cue ball to the
        // center of the cue stick. Used for calculating the
        // force to impart when the cue strikes the ball.
        offset = cueBall.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Left & right arrow keys set cue angle.
        // Up & down arrow keys draw back the cue to set
        // the striking force.
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, inputX * angleRate * Time.deltaTime);
        cueStick.transform.Translate(Vector3.forward * inputZ * drawRate * Time.deltaTime);
    }
}
