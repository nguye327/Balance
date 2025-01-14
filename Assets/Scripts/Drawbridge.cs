using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : MonoBehaviour
{
    private bool closed;
    private AudioSource bridgeSounds;
    public AudioClip openSound;
    public GameObject bridge;
    private Vector3 openPos;

    private void Start()
    {
        openPos = new Vector3(0f,-1f,0f);

        if (PlayerPrefs.HasKey(gameObject.name))
        {
            closed = (PlayerPrefs.GetInt(gameObject.name) == 0) ? false : true;
        }
        else
        {
            closed = true;
            PlayerPrefs.SetInt(gameObject.name, 1);
        }
        if (!closed)
            bridge.transform.localPosition = openPos;
    }

    public void Open()
    {
        closed = false;
        PlayerPrefs.SetInt(gameObject.name, 0);
        bridgeSounds.PlayOneShot(openSound);
        InvokeRepeating("Opening", 0f, 0.05f);
    }

    private void Opening()
    {
        if (bridge.transform.localPosition.y > openPos.y)
            bridge.transform.localPosition -= new Vector3(0f, 0.05f, 0f);
        else
            CancelInvoke("Opening");
    }
}
