using System;

[Serializable]
public class Score
{
    public string namePlayer;

    public int score;

    public Score(string namePlayer, int score)
    {
        this.namePlayer = namePlayer;
        this.score = score;
    }
}
