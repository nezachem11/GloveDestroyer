using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faiding : MonoBehaviour
{
    private int Timer = 0;
    private float rand;

    void Start()
    {
        rand = Random.Range(5f, 100f);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Random.Range(-1.0f, 1.0f), 15.0f, Random.Range(-1.0f, 1.0f), ForceMode.Acceleration);

        if (Timer > rand)
        {
            Destroy(gameObject);
        }
        Timer++;
    }
}
