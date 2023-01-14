using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject player1;
    public static GameObject player2;
    public static bool gameOver = false;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static int diceSideThrown = 0;

    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");

        player1.GetComponent<Movement>().moveAllowed = false;
        player2.GetComponent<Movement>().moveAllowed = false;
        player1.GetComponent<Movement>().moveBackAllowed = false;
        player2.GetComponent<Movement>().moveBackAllowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<Movement>().moveAllowed == true){
            StopMovePlayer1();
        }else{
            if (DoubleWaypoint(player1StartWaypoint)){
                Debug.Log("Double");
                player1.GetComponent<Movement>().moveAllowed = true;
            } else if (BonusTurnWaypoint(player1StartWaypoint)){
                Debug.Log("Bonus");
                Dice.playerTurn = 1;
            }  else if (Minus3Waypoint(player1StartWaypoint)){
                player1.GetComponent<Movement>().moveBackAllowed = true;
                if (player1.GetComponent<Movement>().waypointIndex < player1StartWaypoint - 1){
                    player1StartWaypoint = player1.GetComponent<Movement>().waypointIndex - 1;
                    Debug.Log(player1StartWaypoint);
                    Debug.Log(player1.GetComponent<Movement>().waypointIndex);
                    player1.GetComponent<Movement>().moveBackAllowed = false;
                }
            }
        }



        if (player2.GetComponent<Movement>().moveAllowed == true){
            StopMovePlayer2();
        }
        

        

        //end
        if (player1.GetComponent<Movement>().waypointIndex >=
            player1.GetComponent<Movement>().waypoints.Length)
        {
            gameOver = true;
        }
        if (player2.GetComponent<Movement>().waypointIndex >=
            player2.GetComponent<Movement>().waypoints.Length)
        {
            gameOver = true;
        }      
    }

    private void StopMovePlayer1(){
        if (player1.GetComponent<Movement>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<Movement>().moveAllowed = false;
            player1StartWaypoint = player1.GetComponent<Movement>().waypointIndex - 1;
            
        }
    }

    private void StopMovePlayer2(){
        if (player2.GetComponent<Movement>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<Movement>().moveAllowed = false;
            player2StartWaypoint = player2.GetComponent<Movement>().waypointIndex - 1;
        }
    }

    public static void MovePlayer(int player)
    {
        if (player == 1)
        {
            player1.GetComponent<Movement>().moveAllowed = true;
        }
        else if (player == 2)
        {
            player2.GetComponent<Movement>().moveAllowed = true;
        }
    }


    private static bool DoubleWaypoint(int position){
        if (position == 8){
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
        if (position == 12){
            return true;
        }
        return false;
    }
}
