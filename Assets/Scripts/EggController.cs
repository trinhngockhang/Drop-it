using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggController : MonoBehaviour {
    [SerializeField]
    private GameObject windyLeft, windyRight;
    
    public Rigidbody2D rb;
    public Text vRandom;
    public static EggController instance;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        _makeInstance();
        windyLeft.SetActive(false);
        windyRight.SetActive(false);
        
    }
	void _makeInstance()
    {
        if (instance != null) instance = this;
    }

	// Update is called once per frame
	void FixedUpdate () {
        int x = (int) (GamePlay.instance.randX*10);
        float realX = GamePlay.instance.randX;
        Vector3 temp = new Vector3(realX, 0, 0);
        rb.AddForce(temp);
        Debug.Log(x);
        vRandom.text = x + " km/s";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "enemy")
        {
            SoundsManager.instance.deadB = true;
            Destroy(gameObject);       
            GamePlay.instance.end = true;
        }
        if(collision.gameObject.tag == "target")
        {
            SoundsManager.instance.pingB = true;
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<Destination>().filled == true)
            {
                GamePlay.instance.end = true;
            }
            else
            {
                collision.gameObject.GetComponent<Destination>().filled = true;
                GamePlay.instance.randX = Random.Range(-3.5f, 1.7f);
                GamePlay.instance.score += 1;
                if (GamePlay.instance.randX > 0)
                {
                    windyLeft.SetActive(true);
                    windyRight.SetActive(false);

                }else if(GamePlay.instance.randX <0)
                {
                    windyLeft.SetActive(false);
                    windyRight.SetActive(true);
                }
                else
                {
                    windyLeft.SetActive(false);
                    windyRight.SetActive(false);
                }
            }
            
        }
    }
}
