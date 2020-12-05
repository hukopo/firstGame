using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		try
		{
			var btn = gameObject.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}
		catch (Exception e)
		{
		}
	}

	void TaskOnClick()
	{
		GameState.LoadFirstLevel();
	}
}
