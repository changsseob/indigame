using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject Follow;

    [Range(20, 80)]
    [Tooltip("Field of View (Detect Angle)")]
    public float Fov = 60; // Field of View

    [Range(50, 500)]
    [Tooltip("Monster Unit Health Point(Now)")]
    public int Hp = 120;

    [Range(50, 500)]
    [Tooltip("Monster Unit Health Point(Max)")]
    public int Hpmax = 120;

    [Tooltip("Monster Unit Speed")]
    [Range(1,10)]
    public float Speed;

    public void Deal(int Damage)
    {
        Hp = Hp - Damage;
        if(Hp < 1)
        {
            Destroy(gameObject); // 자신을 삭제해라.
        }
    }

	// Use this for initialization
	void Start () {
        Hp = Hpmax;
        Follow = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        iTween.MoveTo(this.gameObject, 
        new Vector3( (this.transform.position.x+Random.Range(0,1)), ( this.transform.position.y + Random.Range(0,1) ),0 ),1);
        //몬스터 -> 플레이어
        Vector2 Dir = Follow.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Dir.normalized, 10, 1 << LayerMask.NameToLayer("Player")
            | 1 << LayerMask.NameToLayer("Box"));
        bool RayTest = false;


        if(hit.collider != null)
        {
            if(hit.transform.name == "Player")
            {
                RayTest = true; // 플레이어다.
                transform.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                RayTest = false; // 벽이 가로막는다.
                transform.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (Follow != null)
        {
            Dir = Follow.transform.position - transform.position;
            float Angle = Mathf.Atan2(Dir.y, Dir.x) * 180 / Mathf.PI; // Radian(0~2PI) -> Degree(0~360)
            if(Angle < 0)
            {
                Angle = 360 + Angle;
            }
            Dir = transform.up;
            float Angle2 = Mathf.Atan2(Dir.y, Dir.x) * 180 / Mathf.PI;
            if (Angle2 < 0)
            {
                Angle2 = 360 + Angle2;
            }
            float AngleMinus = Angle2 - Angle;

            bool AngleTest = false;
            if (Mathf.Abs(AngleMinus) > 360 - Fov)
            {
                AngleTest = true;
            }
            if (Mathf.Abs(AngleMinus) < Fov)
            {
                AngleTest = true;
            }

            if(AngleTest)
            { 
                if (RayTest == true)
                {
                    transform.rotation = Quaternion.Euler(0, 0, Angle - 90); // 기준점
                    transform.Translate(0, Time.deltaTime * Speed, 0);
                }
            }
        }
        
        // forward == Blue
        // right == Red
        // up == Green
    }
}