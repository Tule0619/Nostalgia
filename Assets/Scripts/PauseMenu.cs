using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    ActivatePause button;
    

    public void SetButton(ActivatePause button)
    {
        this.button = button;
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void EndPause()
    {
     
        Time.timeScale = 1.0f;
        button.ClosePauseMenu();
        Destroy(gameObject);
    }
}
