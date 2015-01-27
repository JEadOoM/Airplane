using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float m_speed = 0f;
	public float m_life = 4f;
	public Transform explosionFX;

	protected float m_rotSpeed = 30f;
	protected float m_timer = 1.5f;


	void Awake()
	{

	}

	void Update(){
		if(m_life <= 0)
		{
			Instantiate(explosionFX, transform.position,Quaternion.identity);
			GameManager.instance.AddScore(10);
			Destroy(gameObject);
		}
		UpdateMove ();
	}

	protected virtual void UpdateMove ()
	{
		m_timer -= Time.deltaTime;
		if (m_timer <= 0)
		{
			m_timer = 3f;
			m_rotSpeed = -m_rotSpeed;
		}

		transform.Rotate (Vector3.up, m_rotSpeed * Time.deltaTime);

		transform.Translate (new Vector3(0, 0, -m_speed * Time.deltaTime));

	}

	void OnTriggerEnter(Collider other)
	{

		if(other.tag == "PlayerRocket")
		{
			Rocket rocket = other.GetComponent<Rocket>();

			if(rocket)
			{
				m_life -= rocket.m_power;
				rocket.m_liveTime = 0f;

			}
		}
		else if(other.tag.CompareTo("Player") == 0 ||other.tag == "Bound")
		{
			m_life = 0f;
		}

	}

}











