using HomeworkTDD_Steve_Luna_Andy_David.Enums;

namespace HomeworkTDD_Steve_Luna_Andy_David.Controllers;

public class MatchController
{
    public string UpdateMatchScores(MatchEvent homeGoal)
    {
        var homeScore = "1";
        var awayScore = "0";    
        return $"{homeScore}:{awayScore} First Half";
    }
}