using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;
    public static int playerTurn = 1;

    public bool isRolling = false;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        playerTurn = 1;
	}

    private void OnMouseDown()
    {
        isRolling = IsMoving();
        if (!GameController.gameOver && coroutineAllowed && !isRolling){
            StartCoroutine("RollTheDice");
            GetComponent<AudioSource>().Play();
        }
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
        GameController.MovePlayer(playerTurn);
        coroutineAllowed = true;
    }

    public bool IsMoving(){
        for (int i = 0; i < GameController.maxPlayers; i++)
        {
            if (GameObject.Find("Player " + (i + 1)).GetComponent<Movement>().moveAllowed)
                return true;
        }
        return false;
    }
}
