using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIScore : MonoBehaviour
{
	public float DisplayScore;
	private Text ThisText;
	public float CatchUpSpeed = 1.0f;
	public UnityEvent OnScoreChange;

	// Use this for initialization
	void Awake ()
	{
		ThisText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DisplayScore = Mathf.Lerp(DisplayScore, GameManager.ThisInstance.Score, CatchUpSpeed = Time.deltaTime);
		ThisText.text = "Score " + Mathf.CeilToInt(DisplayScore).ToString("D6");
	}
}
