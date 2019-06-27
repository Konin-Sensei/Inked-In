using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettings : MonoBehaviour
{

    public bool isActive;

    public GameObject settingsMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        settingsMenuUI.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {

			settingsMenuUI.SetActive (true);
			Time.timeScale = 0f;

		} else {
			settingsMenuUI.SetActive (false);
			Time.timeScale = 1f;
        }
    }

    public void onClick(){
        isActive = !isActive;
    }
}