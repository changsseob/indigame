using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	Vector2 Dir;
	GameObject ShootEffect;
	private void Start()
    {
        ShootEffect = Resources.Load("Hit") as GameObject;
    }
		void update(){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Dir.normalized, Dir.magnitude,
                1 << LayerMask.NameToLayer("Monster") |
                1 << LayerMask.NameToLayer("Box")); // magnitude Dir의 길이값
            if(hit.collider != null)
            {
				StopCoroutine(bulletCourutine(Dir));
				Destroy(this.gameObject);
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
	public void MoveBullet(Vector2 dir){
		Dir = dir;
		StartCoroutine(bulletCourutine(dir));	}
	IEnumerator bulletCourutine(Vector2 dir)
	{
		iTween.MoveTo(this.gameObject,dir, 0.2f);
		yield return new WaitForSeconds(0.2f);
		Destroy(this.gameObject);
	}
	
}
