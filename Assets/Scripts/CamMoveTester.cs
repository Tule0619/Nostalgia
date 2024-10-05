using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveTester : MonoBehaviour
{
    [SerializeField] CameraMove moveScript;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > moveScript.InitialPos)
        {
            moveScript.moveCamDown();
        }
    }
}
