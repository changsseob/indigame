using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour {

	//추후에 이미지 로드되면 GameManager에서 동적으로 load 해주어야 함. ========================
	public List<Toggle> items;
	public List<int> itemUpgradeCount;
	//선택된 토글의 인덱스를 저장하는 변수
	int target=0;
	public Button Upgrade;
	// Use this for initialization
	void Start () {
		Upgrade.gameObject.SetActive(false);
	}


	//토글 체크됐는지 확인하고 강화버튼 나타내기
	public void isChecked(){
		int count =0;
		foreach(Toggle t in items){ //강화조건 추가해야함. =====================
			if(t.isOn){
				Upgrade.gameObject.SetActive(true);
				target = count;
			}
			count++;
		}
	}
	public void Upgrage(){
			items[target].transform.GetChild(1).GetComponent<Text>().text =(itemUpgradeCount[target]+1)+"";
			//강화에 따른 캐릭터 스텟클래스 갱신. ==============================
			
			itemUpgradeCount[target]++;
	}
}
