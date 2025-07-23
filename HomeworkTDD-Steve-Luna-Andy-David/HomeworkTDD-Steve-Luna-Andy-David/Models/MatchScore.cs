using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Exceptions;

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
            case MatchEvent.CancelHomeGoal:
                CancelHomeGoal();
                break;
            case MatchEvent.CancelAwayGoal:
                CancelAwayGoal();
                break;
        }
    }


    private void CancelHomeGoal()
    {
        CancelGoal("H", MatchEvent.CancelHomeGoal);
    }
    private void CancelAwayGoal()
    {
        CancelGoal("A", MatchEvent.CancelAwayGoal);
    }

    private void CancelGoal(string score, MatchEvent matchEvent)
    {
        var hasRemoveSemicolon = false;
        var adjustedScore = Score;
        if (Score.Last() == ';')
        {
            adjustedScore = adjustedScore.Remove(adjustedScore.Length - 1);
            hasRemoveSemicolon = true;
        }
        
        if (!adjustedScore.EndsWith(score))
        {
            throw new MatchScoreException
            {
                MatchEvent = matchEvent,
                MatchScores = Score
            };
        }
        
        adjustedScore = adjustedScore.Remove(adjustedScore.Length - 1);
        Score = adjustedScore + (hasRemoveSemicolon ? ";" : "");
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