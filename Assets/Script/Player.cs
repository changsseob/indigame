using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Range(1, 20)]
    [Tooltip("Player Unit Move Speed")]

    public float Speed;
    public GameObject bullet; GameObject temp;
    public GameObject ButtonPanel;

    GameObject ShootEffect;
    bool isShot=true;


    Vector2 Mouse;
    Vector2 player;
    Vector2 Dir;
    private void Start()
    {
        ShootEffect = Resources.Load("Hit") as GameObject;
    }
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //모드설정
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.instance.mode = false;
            isShot = true;
            ButtonPanel.SetActive(true);
            Debug.Log("사격모드");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.instance.mode = true;
            isShot = false;
            ButtonPanel.SetActive(false);
            Debug.Log("빌드모드");

        }

        transform.position = transform.position + new Vector3(h * Time.deltaTime * Speed, v * Time.deltaTime * Speed, 0);

        Mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player = transform.position;
        Dir = Mouse - player;
        

        float Angle = Mathf.Atan2(Dir.y, Dir.x) * 180 / Mathf.PI; // Radian(0~2PI) -> Degree(0~360)
        if(Angle < 0)
        {
            Angle = 360 + Angle;
        }
        if(Mouse.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else{
            GetComponent<SpriteRenderer>().flipX = false;

        }
        //transform.rotation = Quaternion.Euler(0, 0, Angle + 90); // 90을 더한건 기준점을 잡기 위함.






        // 플레이어 -> 몬스터
        if(Input.GetMouseButtonDown(0) && isShot) // 마우스 인풋
        {
            StartCoroutine(bulletGen());   

            //충돌감지
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Dir.normalized, Dir.magnitude,
                1 << LayerMask.NameToLayer("Monster") |
                1 << LayerMask.NameToLayer("Box")); // magnitude Dir의 길이값
            if(hit.collider != null)
            {
                GameObject Eff = Instantiate(ShootEffect);
                Eff.transform.position = hit.point + new Vector2(
                    Random.Range(0.0f, Dir.normalized.x * 0.5f),
                    Random.Range(0.0f, Dir.normalized.x * 0.5f)
                );

                if (hit.transform.name == "Spider")
                {
                    Monster monster = hit.transform.GetComponent<Monster>();
                    monster.Deal(10);
                }
            }
        }
    }
    IEnumerator bulletGen(){
        temp = Instantiate(bullet) as GameObject;
        yield return temp;
        temp.transform.position = this.transform.GetChild(0).transform.position;
        temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, -1);
        temp.GetComponent<bullet>().MoveBullet(Mouse);
    }
    
}