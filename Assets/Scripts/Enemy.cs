using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoint = 100f;
    
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (healthPoint <= 0)
        {
            Destroy(this);
        }
    }
}
