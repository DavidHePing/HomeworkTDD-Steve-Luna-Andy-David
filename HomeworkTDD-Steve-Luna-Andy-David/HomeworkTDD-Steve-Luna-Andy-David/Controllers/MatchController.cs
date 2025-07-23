using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Models;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;

namespace HomeworkTDD_Steve_Luna_Andy_David.Controllers;

public class MatchController(IMatchRepo matchRepo)
{
    public string UpdateMatchScores(int matchId, MatchEvent matchEvent)
    {
        var match = matchRepo.GetMatch(matchId);

        match.MatchScore.UpdateMatchScore(matchEvent);

        matchRepo.UpdateMatchScores(match);
        return match.MatchScore.GetDisplayResult();
    }
}