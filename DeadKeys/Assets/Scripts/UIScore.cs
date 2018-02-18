using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIScore : MonoBehaviour
{
	public float DisplayScore;
	private Text _thisText;
	public float CatchUpSpeed = 1.0f;

	public UnityEvent OnScoreChange;

	void Awake ()
	{
	    _thisText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
	}
	
	void Update ()
	{
		DisplayScore = Mathf.Lerp(DisplayScore, GameManager.ThisInstance.Score, CatchUpSpeed = Time.deltaTime);
		_thisText.text = "Score: " + Mathf.CeilToInt(DisplayScore).ToString("D6");
	}
}
