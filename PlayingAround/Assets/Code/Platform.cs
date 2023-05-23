using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 MovementVec;
    [SerializeField][Range(0, 1)] float MovementFaktor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        if(period == 0)
        {
            return;
        }

        float cycles = Time.time / period;

        const float tau = 2 * Mathf.PI;
        float rawSinWave = Mathf.Sin(cycles * tau);
        MovementFaktor = (rawSinWave + 1f) / 2f;

        Vector3 rt = MovementVec * MovementFaktor;
        transform.position = startingPosition + rt;
    }
}
