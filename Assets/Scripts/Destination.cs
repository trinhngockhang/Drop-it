using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public float velocity;
    public bool filled = false;
    public static Destination instance;
    private void Start()
    {
        _makeinstance();
    }
    void _makeinstance()
    {
        if (instance != null) instance = this;
    }
    void Update () {

        _movement();
	}

    void _movement()
    {
        Vector3 temp = transform.position;
        temp.x -= velocity * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "destroypipe")
        {
            if (filled == false) GamePlay.instance.end = true;
            Destroy(gameObject);
        }
    }
}
