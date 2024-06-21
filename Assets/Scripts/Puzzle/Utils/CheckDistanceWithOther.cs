using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CheckDistanceWithOther : MonoBehaviour
{
    [SerializeField, Tooltip("The other transform to check distance")]
    private Transform otherTransform;

    private float _distance;
    private void Update()
    {
        _distance = Vector3.Distance(transform.position, otherTransform.position);
    }

    public float getDistance()
    {
        return _distance;
    }
}
