using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Sprite Noon;
    public Sprite Night;
    public GameObject Time_SpriteSymbol;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = System.DateTime.Now.ToString();
	}

    public void ChangeSprite(int i)
    {
        if (i == 0)
        {
            Time_SpriteSymbol.GetComponent< SpriteRenderer>().sprite = Noon;
        }
        else
        {
            Time_SpriteSymbol.GetComponent<SpriteRenderer>().sprite = Night;
        }
    }
}
