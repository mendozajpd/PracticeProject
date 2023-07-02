using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherRigidbody != null)
        {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = otherRigidbody;
        }
    }

}
