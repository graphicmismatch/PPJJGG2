using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static Transform cameraTransform;
    private static Vector3 _orignalPosOfCam;
    public float shakeFrequency;

    private static float timer;
    private static float dur;
    public static bool shaking;
    public static bool indef;

    public static CameraShake cs;
    private void Start()
    {
        cs = this;
        cameraTransform = Camera.main.transform;
    }
    public static void shake(float duration)
    {
        if (shaking)
        {
            dur += duration / 2;
        }
        else
        {
            dur = duration;
            setpos();
            shaking = true;

        }
    }

    public static void shakeIndef()
    {
        if (shaking)
        {
            return ;
        }
        else
        {
            setpos();
            shaking = true;
            indef = true;
        }
    }

    public static void stopShakeIndef()
    {
        if (shaking)
        {
            cs.StopShake();
            timer = 0;
            indef = false;
        }
        else
        {
            setpos();
            shaking = true;
            indef = true;
        }
    }
    private void Update()
    {
        if (shaking)
        {
            timer += Time.deltaTime;
            ShakeM();
            if (!indef)
            {
                if (timer >= dur)
                {
                    StopShake();
                    timer = 0;

                }
            }
        }


    }
    private static void setpos()
    {
        cameraTransform = Camera.main.transform;
        _orignalPosOfCam = cameraTransform.position;
    }
    private void ShakeM()
    {
        
        cameraTransform.position = _orignalPosOfCam + Random.insideUnitSphere * shakeFrequency;
    }

    private void StopShake()
    {
    
        cameraTransform.position = _orignalPosOfCam;
        shaking = false;
    }
}

