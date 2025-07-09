using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;

namespace HomeworkTDD_Steve_Luna_Andy_David.Controllers;

public class MatchController(IMatchRepo matchRepo)
{
    public string UpdateMatchScores(int matchId, MatchEvent homeGoal)
    {
        var match = matchRepo.GetMatch(matchId);
        var homeScore = "1";
        var awayScore = "0";
        match.MatchScore.Score = "H";
        matchRepo.UpdateMatchScores(match);
        return $"{homeScore}:{awayScore} First Half";
    }
}