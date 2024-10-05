using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NostalgiaBar : MonoBehaviour
{
    public Slider sliderNav;

    public void SetMaxNostalgia(float nostalgia)
    {
        sliderNav.maxValue = nostalgia;
        sliderNav.value = nostalgia;
    }

    public void SetNostalgia(float nostalgia)
    {
        if ((sliderNav.value + nostalgia) >= 0)
        {
            sliderNav.value += nostalgia;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
