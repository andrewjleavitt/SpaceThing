using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    public float thrust = 5.0f;

    private Rigidbody2D rb;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();		
	}

    void FixedUpdate() {
        rb.AddForce(transform.forward * thrust);
    }
}
