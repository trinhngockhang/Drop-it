using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip dead, ping,drop;
    public static SoundsManager instance;
    public bool deadB, pingB, dropB;
    private void Awake()
    {
        _makeInstance();
    }

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update () {
        _checkDead();
        _checkDrop();
        _checkPing();
	}

    void _checkDead()
    {
        if (deadB)
        {
            AudioSource.PlayOneShot(dead);
            deadB = false;
        }
    }

    void _checkPing()
    {
        if (pingB)
        {
            AudioSource.PlayOneShot(ping);
            pingB = false;
        }
    }

    void _checkDrop()
    {
        if (dropB)
        {
            AudioSource.PlayOneShot(drop);
            dropB = false;
        }
    }
}
