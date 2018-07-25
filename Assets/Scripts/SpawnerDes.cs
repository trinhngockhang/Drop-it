using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDes : MonoBehaviour {
    [SerializeField]
    private GameObject Destination;
    bool first = true;
	void Start () {
        StartCoroutine(Spawner());
	}
	
	IEnumerator Spawner()
    {
        float rand = Random.Range(3f, 5f);
        if (first == true)
        {
            rand = 1f;
            first = false;
        }
        yield return new WaitForSeconds(rand);
        Vector3 temp = Destination.transform.position;
        temp.x = 3;
        Instantiate(Destination, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
