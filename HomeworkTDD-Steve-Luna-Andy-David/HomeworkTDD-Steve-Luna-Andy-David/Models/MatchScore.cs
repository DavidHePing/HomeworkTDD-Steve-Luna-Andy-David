namespace HomeworkTDD_Steve_Luna_Andy_David.Models;

public class MatchScore
{
    public string Score { get; set; }


    public string GetDisplayResult()
    {
        var firstHalf = GetPeriod();
        return $"{HomeScore()}:{AwayScore()} {firstHalf}";
    }

    private string GetPeriod()
    {
        return Score.Contains(";") ? "(Second Half)" : "(First Half)";
    }

    private int HomeScore()
    {
        return Score.Count(x => x == 'H');
    }

    private int AwayScore()
    {
        return Score.Count(x => x == 'A');
    }
}