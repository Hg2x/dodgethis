using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private Transform rotatingObject;
    [SerializeField] private float rotationX = 0f;
    [SerializeField] private float rotationY = 0f;
    [SerializeField] private float rotationZ = 0f;
    void Update()
    {
        rotatingObject.Rotate(rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime);
    }
}
