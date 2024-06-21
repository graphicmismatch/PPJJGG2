using UnityEngine;
using System;
using System.Collections;
public class Teleporter : MonoBehaviour
{
    public CheckDistanceWithOther cd;
    public float activationDistance;
    public Teleporter target;
    public bool doTeleport;
    public bool disabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var currentDistance = cd.getDistance();

        if (currentDistance < activationDistance)
        {
            if (doTeleport && !disabled)
            {
                target.doTeleport = false;
                cd.otherTransform.position = target.transform.position;

            }

        }
        else
        {
            StartCoroutine(reenable());
        }

    }
    IEnumerator reenable()
    {
        yield return new WaitForEndOfFrame();
        var currentDistance = cd.getDistance();

        if (currentDistance > activationDistance)
        {
            if (doTeleport == false)
            {
                doTeleport = true;
            }

        }
    }
}
