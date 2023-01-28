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
    public string playerName;
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

    private bool DoubleWaypoint(int position){
        //list of waypoints that doubles the dice
        List<int> doubleList = new List<int> {8, 16, 26, 33, 42, 47};
        if (doubleList.Contains(position)){
            return true;
        }
        return false;
    }

    private bool Minus3Waypoint(int position){
        //list of waypoints that minus 3 from dice
        List<int> minus3List = new List<int> {10, 14, 20, 28, 38, 43, 51};
        if (minus3List.Contains(position)){
            return true;
        }
        return false;
    }

    private bool BonusTurnWaypoint(int position){
        //list of waypoints that gives bonus turn
        List<int> bonusTurnList = new List<int> {12, 24, 32, 36, 45};
        if (bonusTurnList.Contains(position)){
            return true;
        }
        return false;
    }

}
