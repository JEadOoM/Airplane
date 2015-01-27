using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int m_score = 0;

	public static int m_hiscore = 0;

	protected Player player;
	public static GameManager instance;

	// Use this for initialization
	void Awake () {
		instance = this;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
		{
			audio.Stop();
			Time.timeScale =0;
		}
	}

	void OnGUI()
	{
		if(Time.timeScale == 0 )
		{
			if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "continue!"))
			{
				Time.timeScale = 1;
				audio.Play();
			}
		

			if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "Exit!"))
		    {
				Application.Quit();
			}
		}

		int playerLife = (int)player.m_life;
		if (playerLife == 0)
		{
			GUI.skin.label.fontSize =  50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "game over!");
			GUI.skin.label.fontSize = 20;

			if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "again"))
			{
				Application.LoadLevel(0);
				
				m_score = 0;
			}
			//Time.timeScale = 0;

			GUI.skin.label.fontSize = 15;


		}
		GUI.Label(new Rect(5,5,100,30), "HP " + playerLife);

		GUI.Label (new Rect (Screen.width *0.25f-100, 5, Screen.width, 30), "record " + m_hiscore);
	
		GUI.Label (new Rect (Screen.width *0.25f-100, 25, Screen.width, 30), "score " + m_score);
	}

	public void AddScore(int poin)
	{
		m_score += poin;

		m_hiscore = Mathf.Max (m_hiscore, m_score);
	}


}
