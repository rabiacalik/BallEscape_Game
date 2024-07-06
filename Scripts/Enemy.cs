using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update() {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rigidbody.AddForce( lookDirection * speed);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
