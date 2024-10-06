using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Tooltip("FInal position, used for moveCamUp()")]
    [SerializeField] float finalPos;
    
    float initialPos;
    [Tooltip("Modifies the speed the camera moves, minimum of 0 to work correctly")]
    [SerializeField] public float speed;


    /// <summary>
    /// Get method, returns Speed
    /// </summary>
    public float Speed
    {
        get
        {
            return speed;
        }
    }

    /// <summary>
    /// Get Method, returns the final position
    /// </summary>
    public float FinalPos
    {
        get
        {
            return finalPos;
        }
    }

    /// <summary>
    /// Get method, returns initial position
    /// </summary>
    public float InitialPos
    {
        get
        {
            return initialPos;
        }
    }

    public Vector3 Scale
    {
        get { return transform.localScale; }
    }

    private void Start()
    {
        initialPos = transform.position.y;
    }


    /// <summary>
    /// Moves camera up until it hits finalPos. If overshoots, corrects to finalPos.
    /// </summary>
    /// <returns>y position</returns>
    public float moveCamUp()
    {
        transform.position += new Vector3(0, (finalPos * Time.deltaTime) * speed, 0);
        if (transform.position.y > finalPos)
        {
            transform.position = new Vector3(0, finalPos, 0);

        }
        return transform.position.y;
    }

    /// <summary>
    /// Moves camera down until it hits initialPos. If overshoots, corrects to initialPos.
    /// </summary>
    /// <returns>y position</returns>
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
