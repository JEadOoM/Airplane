using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public Transform m_enemy;

	protected float m_timer = 5f;


	// Use this for initialization
	void Start () {
	
	}
	void OnDrawGizmos()
	{
		Gizmos.DrawIcon (transform.position, "item.png", true);
	}
	
	// Update is called once per frame
	void Update () {
		m_timer -= Time.deltaTime;
		if(m_timer <= 0)
		{
			m_timer = Random.value *15f;
			if(m_timer < 5f)
				m_timer =5f;
			Instantiate(m_enemy, transform.position, Quaternion.identity);
		}
	}
}
