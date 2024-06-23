using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CheckDistanceWithOther : MonoBehaviour
{
    [SerializeField, Tooltip("The other transform to check distance")]
    public Transform otherTransform;
    public bool defaultToPlayer1;
    private float _distance = Int32.MaxValue;
    private void Start()
    {
        if (otherTransform == null)
        {
            if (defaultToPlayer1)
            {
                otherTransform = GameObject.FindGameObjectWithTag("Player1").transform;
            }
            else
            {
                otherTransform = GameObject.FindGameObjectWithTag("Player2").transform;
            }
        }
    }
    private void Update()
    {
        
        _distance = Vector3.Distance(transform.position, otherTransform.position);
    }

    public float getDistance()
    {
        return _distance;
    }
}
