using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private GameObject Egg;
   
    void Update () {
		
	}
    public void _Drop()
    {   
        Vector3 temp = transform.position;
        Instantiate(Egg, temp, Quaternion.identity);
        SoundsManager.instance.dropB = true;
    }
}
