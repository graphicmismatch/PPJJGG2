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
    bool disabledTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        disabledTimer = false;
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
        else if(!disabledTimer)
        {
            StartCoroutine(reenable());
        }

    }
    IEnumerator reenable()
    {
        disabledTimer = true;
        yield return new WaitForSeconds(0.5f);
        disabledTimer = false;
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
