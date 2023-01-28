using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject player;

    public static bool gameOver = false;
    public static int diceSideThrown = 0;
    public static int maxPlayers;
    public static int winnerPlayer;
    public GameObject scoreBoard;
    private bool isPlayingAudio = false;

    void Awake()
    {
        gameOver = false;
        maxPlayers = MenuController.numberOfPlayers;
        for (int i = 0; i < maxPlayers; i++)
        {
            //find player
            player = GameObject.Find("Player " + (i + 1));
            //set player label
            player.GetComponent<Movement>().playerLabel = i + 1;
            player.GetComponent<Movement>().waypointIndex = 0;
            player.GetComponent<Movement>().playerStartWaypoint = 0;
            player.GetComponent<Movement>().moveAllowed = false;
            player.GetComponent<Movement>().moveBackAllowed = false;
            switch (i)
            {
                case 0:
                    player.GetComponent<Movement>().playerName = MenuController.p1NameText;
                    break;
                case 1:
                    player.GetComponent<Movement>().playerName = MenuController.p2NameText;
                    break;
                case 2:
                    player.GetComponent<Movement>().playerName = MenuController.p3NameText;
                    break;
                case 3:
                    player.GetComponent<Movement>().playerName = MenuController.p4NameText;
                    break;
            }
        }   
    
        //disable others
        for (int i = maxPlayers; i < 4; i++)
        {
            GameObject.Find("Player " + (i + 1)).SetActive(false);
        }
    }
    void Update()
    {
        if (gameOver)
        {
            Debug.Log("Game Over");
            Debug.Log("Player " + winnerPlayer + " Wins!");
            //Show Scoreboard
            //add sound
            scoreBoard.SetActive(true);
            if (!isPlayingAudio)
            {
                GetComponent<AudioSource>().Play();
                isPlayingAudio = true;
            }

        }
        else
        {
        for (int i = 0; i < maxPlayers; i++)
        {
            if (GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().moveAllowed)
                GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().CheckStopMove();
            else if (GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().moveBackAllowed)
                GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().CheckStopMoveBack();
            if (GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().waypointIndex >=
                GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().waypoints.Length)
            {
                gameOver = true;
                winnerPlayer = i + 1;
            }
        }
        }
    }


    public static void MovePlayer(int player)
    {   
        GameObject.Find("Player " + player).GetComponent<Movement>().moveAllowed = true;
    }
    
}
