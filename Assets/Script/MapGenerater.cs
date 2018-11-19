using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerater : MonoBehaviour {

    public Sprite Brick;
    public Sprite BuildTarget;
	// Use this for initialization
	void Start () {
        GameObject Tile = new GameObject("Brick");
        for(int x = 0; x < 40; x++)
        {
            for(int y = 0; y < 40; y++)
            {
                GameObject _Tile = new GameObject("MAP");//new GameObject((y+x*40+1).ToString());
                BoxCollider bc = _Tile.AddComponent<BoxCollider>();
                SpriteRenderer sr = _Tile.AddComponent<SpriteRenderer>();


                _Tile.tag = "MAP";
                sr.sprite = Brick;
                _Tile.transform.parent = Tile.transform;
                _Tile.transform.position = new Vector3(x , y , 0);
                bc.size = new Vector3(1, 1, 1);


                GameObject BT = new GameObject("bulidTarget");
                SpriteRenderer b_sr = BT.AddComponent<SpriteRenderer>();
                b_sr.sprite = BuildTarget;
                BT.transform.parent = _Tile.transform;
                
                BT.transform.position = new Vector3(x , y, 10);
                BT.transform.localScale = new Vector3(1, 1, 1);
                BT.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);

                GameManager.instance.MAP.Add(_Tile);

            }
        }

        Destroy(gameObject);	
	}
}
