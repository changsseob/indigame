using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject Follow;

    void Start()
    {
        // gameObject; 나자신
        // GameObject; 자료형
        Follow = GameObject.Find("Player"); // 검색기능
    }
        void Update ()
    {
            //7, 3 (Left, Bottom)
            //193, 197 (Right, Top)
            //Clamp (범위에서 벗어난 값이면 값을 범위의 끝자락으로 되돌려준다.)
            //Return 해당 범위내에 있으면 값을 그대로 리턴한다. 아니면 끝자락 값을 리턴.
            float x = Mathf.Clamp(Follow.transform.position.x, 7.0f, 193.0f);
            float y = Mathf.Clamp(Follow.transform.position.y, 3.0f, 197.0f);
            transform.position = new Vector3(x, y, -10);
            //맵 밖으로 못 나가게 하는것
    } 
}