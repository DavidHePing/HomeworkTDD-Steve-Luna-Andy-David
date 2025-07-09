using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;

namespace HomeworkTDD_Steve_Luna_Andy_David.Controllers;

public class MatchController(IMatchRepo matchRepo)
{
    public string UpdateMatchScores(int matchId, MatchEvent homeGoal)
    {
        var homeScore = "1";
        var awayScore = "0";    
        return $"{homeScore}:{awayScore} First Half";
    }
}