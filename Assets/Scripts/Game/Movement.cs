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
    public int playerLabel;

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
                //adding sound
                
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
        }
        if (BonusTurnWaypoint(playerStartWaypoint)){
            Debug.Log("Bonus Turn");
            Dice.playerTurn = playerLabel;
        } else {
            Dice.playerTurn = playerLabel + 1;
            if (Dice.playerTurn > GameController.maxPlayers){
                Dice.playerTurn = 1;
            }
        }
        if (Minus3Waypoint(playerStartWaypoint)){
            moveBackAllowed = true;
        }
        
    }

    public void CheckStopMoveBack(){
        if (waypointIndex < playerStartWaypoint - 1){
                moveBackAllowed = false;
                playerStartWaypoint = waypointIndex - 1;
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
