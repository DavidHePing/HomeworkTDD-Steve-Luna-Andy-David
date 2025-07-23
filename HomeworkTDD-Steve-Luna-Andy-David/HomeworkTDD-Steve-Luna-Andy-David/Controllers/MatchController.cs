using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;

namespace HomeworkTDD_Steve_Luna_Andy_David.Controllers;

public class MatchController(IMatchRepo matchRepo)
{
    public string UpdateMatchScores(int matchId, MatchEvent matchEvent)
    {
        var match = matchRepo.GetMatch(matchId);

        switch (matchEvent)
        {
            case MatchEvent.HomeGoal:
                match.MatchScore.Score += "H";
                break;
            case MatchEvent.AwayGoal:
                match.MatchScore.Score += "A";
                break;
            case MatchEvent.NextPeriod:
                match.MatchScore.Score += ";";
                break;
        }

        matchRepo.UpdateMatchScores(match);
        return match.MatchScore.GetDisplayResult();
    }
}