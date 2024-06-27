using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float speed = 5.0f; // 車の移動速度
    public float rotationSpeed = 100.0f; // 車の回転速度
    public float changeDirectionInterval = 3.0f; // 方向を変更する間隔
    private float timeToChangeDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetNewRandomDirection();
    }

    void Update()
    {
        if (Time.time >= timeToChangeDirection)
        {
            SetNewRandomDirection();
        }
    }

    void FixedUpdate()
    {
        MoveCar();
    }

    void SetNewRandomDirection()
    {
        float randomYRotation = Random.Range(-180f, 180f);
        transform.eulerAngles = new Vector3(0, randomYRotation, 0);
        timeToChangeDirection = Time.time + changeDirectionInterval;
    }

    void MoveCar()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // 壁に衝突した場合、反発する方向に回転
            Vector3 reflectDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            float angle = Mathf.Atan2(reflectDirection.z, reflectDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
