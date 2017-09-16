using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    public float thrust = 5.0f;

    private Rigidbody2D rb;
    private GameObject target;

	void Start () {
        rb = GetComponent<Rigidbody2D>();		
	}

    void FixedUpdate() {
        rb.AddForce(transform.up * thrust);
    }

    void Update() {
        target = FindClosestEnemy();
        if(!target) {
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    GameObject FindClosestEnemy() {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }
}
