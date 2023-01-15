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

    public int playerStartWaypoint = 0;
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

    public void CheckStopMove(){
        if (waypointIndex > playerStartWaypoint + GameController.diceSideThrown){
            moveAllowed = false;
            playerStartWaypoint = waypointIndex - 1;
        }
        CheckItem();
    }

    public void CheckItem(){
        if (DoubleWaypoint(playerStartWaypoint)){
            Debug.Log("Double");
            moveAllowed = true;
        } else if (BonusTurnWaypoint(playerStartWaypoint)){
            Debug.Log("Bonus");
            Dice.playerTurn--;
        }  else if (Minus3Waypoint(playerStartWaypoint)){
            moveBackAllowed = true;
            if (waypointIndex < playerStartWaypoint - 1){
                playerStartWaypoint = waypointIndex - 1;
                Debug.Log(playerStartWaypoint);
                Debug.Log(waypointIndex);
                moveBackAllowed = false;
            }
        }
    }

    private static bool DoubleWaypoint(int position){
        if (position == 8 || position == 16){
            return true;
        }
        return false;
    }

    private static bool Minus3Waypoint(int position){
        if (position == 20 || position == 28){
            return true;
        }
        return false;
    }

    private static bool BonusTurnWaypoint(int position){
        if (position == 12 || position == 24 || position == 36){
            return true;
        }
        return false;
    }

}
