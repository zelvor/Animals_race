using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    public int waypointIndex = 0;
    public bool moveAllowed = false;
    public bool moveBackAllowed = false;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed){
            Move();
        }
        if (moveBackAllowed){
            MoveBack();
        }
        
    }

    private void Move(){
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,waypoints[waypointIndex].transform.position,moveSpeed * Time.deltaTime);            
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }       

    public void MoveBack(){
        if (waypointIndex >= 2)
        {
            transform.position = Vector2.MoveTowards(transform.position,waypoints[waypointIndex-2].transform.position,moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex-2].transform.position)
            {
                waypointIndex -= 1;
            }
        }
    }
}
