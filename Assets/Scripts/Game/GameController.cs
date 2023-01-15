using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject player1;
    public static GameObject player2;
    public static bool gameOver = false;
    public static int diceSideThrown = 0;

    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");

        player1.GetComponent<Movement>().moveAllowed = false;
        player2.GetComponent<Movement>().moveAllowed = false;
        player1.GetComponent<Movement>().moveBackAllowed = false;
        player2.GetComponent<Movement>().moveBackAllowed = false;
        player1.GetComponent<Movement>().waypointIndex = 0;
        player2.GetComponent<Movement>().waypointIndex = 0;
        player1.GetComponent<Movement>().playerStartWaypoint = 0;
        player2.GetComponent<Movement>().playerStartWaypoint = 0;

    }
    void Update()
    {

        player1.GetComponent<Movement>().CheckStopMove();
        player2.GetComponent<Movement>().CheckStopMove();

        
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

}
