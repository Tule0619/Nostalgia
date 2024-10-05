using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float finalPos;
    [SerializeField] float initialPos;
    [SerializeField] public float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float FinalPos
    {
        get
        {
            return finalPos;
        }
    }

    public float InitialPos
    {
        get
        {
            return initialPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.y;
    }

    

    public float moveCamUp()
    {
        transform.position += new Vector3(0, (finalPos * Time.deltaTime) * speed, 0);
        if (transform.position.y > finalPos)
        {
            transform.position = new Vector3(0, finalPos, 0);
        }
        return transform.position.y;
    }

    public float moveCamDown()
    {
        transform.position += new Vector3(0, (finalPos * Time.deltaTime) * -speed, 0);
        if (transform.position.y < initialPos)
        {
            transform.position = new Vector3(0, initialPos, 0);
        }
        return transform.position.y;
    }


}
