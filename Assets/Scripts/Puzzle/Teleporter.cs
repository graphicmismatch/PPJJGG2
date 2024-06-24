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

    public Animator anim;

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
                var tpPosition =
                    new Vector3(
                        target.transform.position.x,
                        target.transform.position.y + 1,
                        target.transform.position.z
                    );
                cd.otherTransform.position = tpPosition;
                anim.SetTrigger("teleport");
                target.anim.ResetTrigger("teleport");
                target.anim.SetTrigger("teleport");
            }
        }
        else if (!disabledTimer)
        {
            StartCoroutine(reenable());
        }
    }

    IEnumerator reenable()
    {
        disabledTimer = true;
        yield return new WaitForSeconds(2f);
        disabledTimer = false;
        var currentDistance = cd.getDistance();
        anim.ResetTrigger("teleport");
        if (currentDistance > activationDistance)
        {
            if (doTeleport == false)
            {
                doTeleport = true;
            }
        }
    }
}