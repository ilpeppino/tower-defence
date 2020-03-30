using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] public Transform _target;
    [SerializeField] public Transform _cannon;
    [SerializeField] public GameObject _cannonProjectile;

    Rigidbody rb;
    GameObject g;


    // Update is called once per frame
    void Update()
    {
        /*        Vector3 lookVector = _target.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion lookRotation = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.05f);*/

        _cannon.transform.LookAt(_target);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            g = Instantiate(_cannonProjectile, _cannon.position, Quaternion.identity);
            rb = g.GetComponent<Rigidbody>();
            FireCannonAtPoint(_target.position);
            
        }

    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, 60f);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        rb.transform.position = transform.position;
        rb.velocity = velocity;
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}
