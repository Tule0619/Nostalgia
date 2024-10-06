using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NostalgiaBarTesting : MonoBehaviour
{
    // Reference to the nostalgia bar
    [SerializeField]
    [Tooltip("Reference to the nostalgia bar which will be updated")]
    private NostalgiaBar nostalgia;

    // Timer
    private float timer;

    [SerializeField]
    [Tooltip("The time until it will take for the nostalgia bar to decrease")]
    private float timeUntilDecrease;

    [SerializeField]
    [Tooltip("The rate in which nostalgia will decrease")]
    private float nostalgiaSpeed;

    // Update is called once per frame
    void Update()
    {
        if (!Meter.start) return;
        
        // Update the time
        timer += Time.deltaTime;

        // If enough time has passed, decrease nostalgia
        // and reset the timer.
        if (timer > timeUntilDecrease)
        {
            nostalgia.ChangeNostalgia(-nostalgiaSpeed);
            timer = 0;
        }
    }
}
