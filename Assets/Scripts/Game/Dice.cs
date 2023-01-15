﻿using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;
    public static int playerTurn = 1;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    private void OnMouseDown()
    {
        if (!GameController.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        coroutineAllowed = true;

        GameController.diceSideThrown = randomDiceSide + 1;
        if (playerTurn == 1){
            GameController.MovePlayer(1);
        }
        else if (playerTurn == 2)
        {
            GameController.MovePlayer(2);
        }
        playerTurn++;
        if (playerTurn > 2)
            playerTurn = 1;
        coroutineAllowed = true;
    }
}