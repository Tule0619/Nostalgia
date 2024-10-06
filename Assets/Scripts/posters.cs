using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class posters : MonoBehaviour
{
    [SerializeField] Sprite[] textures;
    [SerializeField] UnityEngine.UI.Image poster;
    // Start is called before the first frame update
    public void changePoster()
    {
        poster.sprite = textures[Random.Range(0, textures.Length)];
        Debug.Log("HI!!!! IM RUNNING");
    }
}
