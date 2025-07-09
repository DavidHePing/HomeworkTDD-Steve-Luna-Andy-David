namespace HomeworkTDD_Steve_Luna_Andy_David.Models;

public class MatchScore
{
    public string Score { get; set; }

    
    public string GetDisplayResult()
    {
        return $"{HomeScore()}:{AwayScore()} (First Half)";
    }

    private int HomeScore()
    {
        return Score.Count(x=> x == 'H');
    }
    private int AwayScore()
    {
        return Score.Count(x=> x == 'A');
    }
}