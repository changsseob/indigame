using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	//추후에 데이터 조정 필요함 ===================
	public int b_speed=10;
	public int i_speed=10;
	//public int t_speed;

	public int b_zoom=10;
	public int i_zoom=10;
	//public int t_zoom;

	public int b_architect=10;
	public int i_architect=10;
	//public int t_architect;

	public int b_tower_attack_speed=10;
	public int i_tower_attack_speed=10;
	//public int t_tower_attack_speed;

	public int b_health=10;
	public int i_health=10;
	//public int t_health;

	public int b_wall_health=10;
	public int i_wall_health=10;
	//public int t_wall_health;

	public int b_what=10;
	public int i_what=10;
	public List<weaponStat> wear_weapons;
	//public int t_what;
}
