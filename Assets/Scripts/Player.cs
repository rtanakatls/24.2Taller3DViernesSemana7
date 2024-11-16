using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private int currentWeaponIndex;

    private bool cylinderEnabled;
    private bool cubeEnabled;

    [SerializeField] private GameObject cylinderGameObject;
    [SerializeField] private GameObject cubeGameObject;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        SwitchWeapon();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        rb.velocity=new Vector3(horizontal*speed,rb.velocity.y,vertical*speed);
        if (horizontal != 0 || vertical != 0)
        {
            transform.forward = new Vector3(horizontal, 0, vertical);
        }
    }

    private void SwitchWeapon()
    {
        if(Input.mouseScrollDelta.y>0)
        {
            currentWeaponIndex++;
            if (currentWeaponIndex > 2)
            {
                currentWeaponIndex = 0;
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            currentWeaponIndex--;
            if (currentWeaponIndex <0)
            {
                currentWeaponIndex = 2;
            }
        }


        switch (currentWeaponIndex)
        {
            case 0:
                cylinderGameObject.SetActive(false);
                cubeGameObject.SetActive(false);
                break;
            case 1:
                if (cylinderEnabled && !cylinderGameObject.activeSelf)
                {
                    cylinderGameObject.SetActive(true);
                    cubeGameObject.SetActive(false);
                }
                break;
            case 2:
                if (cubeEnabled && !cubeGameObject.activeSelf)
                {
                    cubeGameObject.SetActive(true);
                    cylinderGameObject.SetActive(false);
                }
                break;
        }


        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(cylinderEnabled && !cylinderGameObject.activeSelf)
            {
                cylinderGameObject.SetActive(true);
                cubeGameObject.SetActive(false);
            }
            else if(cubeEnabled && !cubeGameObject.activeSelf)
            {
                cubeGameObject.SetActive(true);
                cylinderGameObject.SetActive(false);
            }

        }
        */
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("CylinderWeapon"))
        {
            Destroy(collision.gameObject);
            cylinderEnabled = true;
        }
        if (collision.gameObject.CompareTag("CubeWeapon")) ;
        {
            Destroy(collision.gameObject);
            cubeEnabled = true;
        }
    }
}
