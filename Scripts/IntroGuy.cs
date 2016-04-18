using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroGuy : MonoBehaviour {

	public SpriteRenderer Idle;
	public SpriteRenderer Mantis;
	public SpriteRenderer Elephant;
	public SpriteRenderer Crab;
	public SpriteRenderer Fuck;

	public SpriteRenderer Monster;
	public SpriteRenderer Punter;

	public float DelayInSeconds;
	public float DurationInSeconds;

	public float FuckTimeStamp;
	public float MantisTimeStamp;
	public float ElephantTimeStamp;
	public float CrabTimeStamp;
	public float MonsterTimeStamp;
	public float PunterTimeStamp;
	public float NextSceneTimeStamp;

	private float StartTimeStamp;
	private Color FadeInColor;
	private int state;


	// Use this for initialization
	void Start () {
		StartTimeStamp = Time.realtimeSinceStartup;
		FadeInColor = Color.black;
		state = -2;

		Idle.enabled = true;
		Idle.color = FadeInColor;
		Mantis.enabled = false;
		Elephant.enabled = false;
		Crab.enabled = false;
		Fuck.enabled = false;
		Monster.enabled = false;
		Punter.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		float passedTime = Time.realtimeSinceStartup - StartTimeStamp;
		if(passedTime < DelayInSeconds)
			return;

		if(passedTime < DurationInSeconds + DelayInSeconds)
		{
			float alpha = (passedTime - DelayInSeconds) / DurationInSeconds;
			FadeInColor.r = alpha;
			FadeInColor.g = alpha;
			FadeInColor.b = alpha;
			Idle.color = FadeInColor;
		}

		if(state == -2 && passedTime >= FuckTimeStamp)
		{
			SetFuck();
			state++;
		}
		else if(state == -1 && passedTime >= FuckTimeStamp + 0.7f)
		{
			SetIdle();
			state++;
		}
		else if(state == 0 && passedTime >= MantisTimeStamp)
		{
			SetMantis();
			state++;
		}
		else if(state == 1 && passedTime >= ElephantTimeStamp)
		{
			SetElephant();
			state++;
		}
		else if(state == 2 && passedTime >= CrabTimeStamp)
		{
			SetCrab();
			state++;
		}
		else if(state == 3 && passedTime >= CrabTimeStamp + 0.5)
		{
			SetIdle();
			state++;
		}
		else if(state == 4 && passedTime >= MonsterTimeStamp + 0.5)
		{
			Monster.enabled = true;
			state++;
		}
		else if(state == 5 && passedTime >= PunterTimeStamp + 0.5)
		{
			Punter.enabled = true;
			state++;
		}
		else if(state == 6 && passedTime >= NextSceneTimeStamp)
		{
			SceneManager.LoadScene("Title");
		}
	}

	private void SetIdle()
	{
		Idle.enabled = true;
		Idle.color = Color.white;
		Mantis.enabled = false;
		Elephant.enabled = false;
		Crab.enabled = false;
		Fuck.enabled = false;
	}

	private void SetFuck()
	{
		Idle.enabled = false;
		Mantis.enabled = false;
		Elephant.enabled = false;
		Crab.enabled = false;
		Fuck.enabled = true;
	}

	private void SetMantis()
	{
		Idle.enabled = false;
		Mantis.enabled = true;
		Elephant.enabled = false;
		Crab.enabled = false;
		Fuck.enabled = false;
	}

	private void SetElephant()
	{
		Idle.enabled = false;
		Mantis.enabled = false;
		Elephant.enabled = true;
		Crab.enabled = false;
		Fuck.enabled = false;
	}

	private void SetCrab()
	{
		Idle.enabled = false;
		Mantis.enabled = false;
		Elephant.enabled = false;
		Crab.enabled = true;
		Fuck.enabled = false;
	}


}
