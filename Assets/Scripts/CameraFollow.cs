using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
   [SerializeField] private Transform target;
   [SerializeField] private float SmoothTime;
    private Vector3 Currentvelocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetpos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetpos,ref Currentvelocity,SmoothTime);
    }
}

