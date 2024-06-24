using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public AudioSource asr;

    public AudioClip[] clips;
    public int curClip;

    public void switchClip()
    {
        curClip++;
        if (curClip >= clips.Length) { curClip = 0; }
        int samp = asr.timeSamples;
        asr.clip = clips[curClip];
        asr.timeSamples = samp;
        asr.Play();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}