using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivatePause : MonoBehaviour
{
    //pause menu prefab to instantiate
    [Tooltip("pause menu prefab to instantiate")]
    [SerializeField] PauseMenu pauseMenu;
    //input system to disable
    [Tooltip("input system to disable")]
    [SerializeField] GameObject inputSys;

    /// <summary>
    /// Opens up the pause menu, sets text and pause menu to disable
    /// </summary>
    public void OpenPauseMenu()
    {
        PauseMenu spawnedPauseMenu = Instantiate(pauseMenu);
        spawnedPauseMenu.SetButton(this);
        inputSys.GetComponent<PlayerInput>().enabled = false;
        this.GetComponent<Button>().interactable = false;
        
        
    }

    /// <summary>
    /// Runs after Pause Menu is closed. Reenables both objects.
    /// </summary>
    public void ClosePauseMenu()
    {
        this.GetComponent<Button>().interactable = true;
        inputSys.GetComponent<PlayerInput>().enabled = true;
    }
}
