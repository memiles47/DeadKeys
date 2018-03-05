﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIScore : MonoBehaviour
{
	public float DisplayScore;
	private Text _thisText;
	public float CatchUpSpeed = 1.0f;

	public UnityEvent OnScoreChange;

	public void Awake ()
	{
	    _thisText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
	}
	
	public void Update ()
	{
		DisplayScore = Mathf.Lerp(DisplayScore, GameManager.ThisInstance.Score, CatchUpSpeed = Time.deltaTime);
		_thisText.text = "Score: " + Mathf.CeilToInt(DisplayScore).ToString("D6");
	}
}
