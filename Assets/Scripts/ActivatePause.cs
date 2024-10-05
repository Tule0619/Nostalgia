using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void OpenPauseMenu()
    {
        Instantiate(pauseMenu);
        this.GetComponent<Button>().interactable = false;

        float wait = 0;
        wait = Time.deltaTime;
        if (wait > 0)
        {
            this.GetComponent<Button>().interactable = true;
        }
        
    }
}
