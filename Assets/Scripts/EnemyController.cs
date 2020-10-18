using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject target;
    public float speed = 1.0f;
    private float bottomBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);

        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
