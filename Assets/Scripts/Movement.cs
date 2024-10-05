using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float speed;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        rb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }
}
