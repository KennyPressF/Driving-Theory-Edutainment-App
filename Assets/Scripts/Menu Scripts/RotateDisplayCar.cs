using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateDisplayCar : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.transform.Rotate((Vector3.up * rotationSpeed) * Time.deltaTime);
    }

}
