using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void EndPause()
    {
     
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}
