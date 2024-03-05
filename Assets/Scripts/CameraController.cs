using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _smoothing;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position + _offset, Time.deltaTime * _smoothing);
    }
}
