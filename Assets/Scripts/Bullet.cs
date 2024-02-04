using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    new Rigidbody rigidbody;
    Vector3 direction;

    public Vector3 target;
    public float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        direction = target - transform.position;
    }

    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
        }

        Destroy(gameObject);
    }
}
