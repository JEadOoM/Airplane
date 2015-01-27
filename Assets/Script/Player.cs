using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public AudioClip m_shootClip;
	public Transform explosionFX;




	public float m_life = 3;
	public float speed = 1;
	float m_rocketRate = 0;
	public Transform m_rocket;


	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (m_life <= 0)
		{
			Instantiate(explosionFX, transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
		float moveh = 0f;
		float movev = 0f;


		if(Input.GetKey(KeyCode.W) || Input.acceleration.y > 0)
		{
			movev -= Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.S) || Input.acceleration.y < 0)
		{
			movev += Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.A) || Input.acceleration.x < 0)
		{
			moveh += Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.D) || Input.acceleration.x > 0)
		{
			moveh -= Time.deltaTime * speed;
		}

		transform.Translate (new Vector3(moveh,0,movev));
		if (transform.position.x < -7)
			transform.position = new Vector3 (-7, 0, transform.position.z);
		if (transform.position.x > 7)
			transform.position = new Vector3 (7, 0, transform.position.z);
		if (transform.position.z < -5)
			transform.position = new Vector3 (transform.position.x, 0, -5);
		if (transform.position.z > 5)
			transform.position = new Vector3 (transform.position.x, 0, 5);

		m_rocketRate -= Time.deltaTime;


		if ((Input.GetKey (KeyCode.Space) || Input.touchCount > 0)&&m_rocketRate <= 0) {
			m_rocketRate = 0.1f;
			Instantiate(m_rocket,transform.position, transform.rotation);

			if(m_shootClip)
				audio.PlayOneShot(m_shootClip);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Untagged") {
			return;
		}
		if (other.tag != "PlayerRocket") 
		{
				
			print(other.tag);
			m_life -=1;
		}
	}
}




















