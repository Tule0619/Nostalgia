using UnityEngine;

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
