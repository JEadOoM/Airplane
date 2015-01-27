using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {
	public float m_fireTime = 0.5f;
	public Transform enemyRocket;
	protected Transform player;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}



	//override 重载 virtual 函数
	protected override void UpdateMove ()
	{
		m_fireTime -= Time.deltaTime;
		if (m_fireTime <= 0) {
				
			m_fireTime = 1f;
			if(player)
			{
				Vector3 relativePos = player.position - transform.position;
				Instantiate(enemyRocket, transform.position, Quaternion.LookRotation(-relativePos));
			}
		}
		transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
	}
}
