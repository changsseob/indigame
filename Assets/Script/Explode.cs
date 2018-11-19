using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroyer", 0.3f); // 몇 초후에 자신을 삭제한다.
	}
	
    void Destroyer()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
