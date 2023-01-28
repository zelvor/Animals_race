using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;

    public ScoreManager scoreManager;

    private static GameObject player;

    void Start()
    {
        for (int i = 0; i < GameController.maxPlayers; i++)
        {
            player = GameObject.Find("Player " + (i + 1));
            scoreManager
                .AddScore(new Score(player.GetComponent<Movement>().playerName,
                    player.GetComponent<Movement>().waypointIndex - 1));
        }

        var scores = scoreManager.GetScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform);
            row.rank.text = (i + 1).ToString();
            row.namePlayer.text = scores[i].namePlayer;
            row.score.text = scores[i].score.ToString();
        }
    }
}
