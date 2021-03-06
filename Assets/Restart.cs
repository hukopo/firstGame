﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
	// Start is called before the first frame update
	//public Button yourButton;

	void Start()
	{
		var btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
    private void Update()
    {
		if (Input.GetKeyUp(KeyCode.R) ||
			Input.GetKeyUp(KeyCode.Space) ||
			Input.GetKeyUp(KeyCode.KeypadEnter))
		{
			TaskOnClick();
		}
	}

    void TaskOnClick()
	{
		GameState.Restart();
	}
}
