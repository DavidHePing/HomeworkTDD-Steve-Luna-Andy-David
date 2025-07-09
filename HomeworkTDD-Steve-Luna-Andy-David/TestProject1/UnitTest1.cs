using FluentAssertions;
using HomeworkTDD_Steve_Luna_Andy_David.Controllers;
using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Models;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;
using NSubstitute;

namespace TestProject1;

public class Tests
{
    private IMatchRepo _matchRepo = null;
    const int MatchId = 123;

    [SetUp]
    public void Setup()
    {
        _matchRepo = Substitute.For<IMatchRepo>();
    }

    [Test]
    public void home_goal_when_0_to_0_at_first_half()
    {
        GivenMatchScore("");
        var matchController = new MatchController(_matchRepo);
        var result = matchController.UpdateMatchScores(MatchId, MatchEvent.HomeGoal);
        _matchRepo.Received(1).UpdateMatchScores(Arg.Is<Match>(x => x.MatchId == MatchId && x.MatchScore.Score == "H"));
        result.Should().Be("1:0 First Half");
    }

    private void GivenMatchScore(string score)
    {
        _matchRepo.GetMatch(MatchId).Returns(new Match
        {
            MatchId = MatchId,
            MatchScore = new MatchScore
            {
                Score = score
            }
        });
    }
}