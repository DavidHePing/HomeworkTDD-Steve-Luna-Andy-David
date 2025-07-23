using HomeworkTDD_Steve_Luna_Andy_David.Enums;

namespace HomeworkTDD_Steve_Luna_Andy_David.Models;

public class MatchScore
{
    public string Score { get; set; }


    public string GetDisplayResult()
    {
        return $"{GetHomeScore()}:{GetAwayScore()} {GetPeriod()}";
    }

    private string GetPeriod()
    {
        return Score.Contains(";") ? "(Second Half)" : "(First Half)";
    }

    private int GetHomeScore()
    {
        return Score.Count(x => x == 'H');
    }

    private int GetAwayScore()
    {
        return Score.Count(x => x == 'A');
    }

    public void UpdateMatchScore(MatchEvent matchEvent)
    {
        switch (matchEvent)
        {
            case MatchEvent.HomeGoal:
                HomeScore();
                break;
            case MatchEvent.AwayGoal:
                AwayScore();
                break;
            case MatchEvent.NextPeriod:
                NextPeriod();
                break;
        }
    }

    private void NextPeriod()
    {
        Score += ";";
    }

    private void AwayScore()
    {
        Score += "A";
    }

    private void HomeScore()
    {
        Score += "H";
    }
}