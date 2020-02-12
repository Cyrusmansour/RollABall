using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform movingPlatform;
    public Transform pos1;
    public Transform pos2;
    public Vector3 newPosition;
    public int currentState;
    public float smooth; //how long it takes to move platform from 1 position to another
    public float resetTime; //when it needs to reset and start heading to new position

    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth*Time.deltaTime); //take current pos, target new pos, move it there over time
    }

    void ChangeTarget()
    {
        if(currentState == 1)
        {
            currentState = 2;
            newPosition = pos2.position;
        }

        else if(currentState == 2)
        {
            currentState = 1;
            newPosition = pos1.position;
        }
         else if(currentState == 0)
        {
            currentState = 2;
            newPosition = pos2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
