using FluentAssertions;
using FluentAssertions.Primitives;
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
        ShouldUpdateScore("H");
        DisplayScoreMustBe(result, "1:0 (First Half)");
    }
    [Test]
    public void away_goal_when_0_to_0_at_first_half()
    {
        GivenMatchScore("");
        var matchController = new MatchController(_matchRepo);
        var result = matchController.UpdateMatchScores(MatchId, MatchEvent.AwayGoal);
        ShouldUpdateScore("A");
        DisplayScoreMustBe(result, "0:1 (First Half)");
    }

    [Test]
    public void next_period_when_0_to_1_at_first_half()
    {
        GivenMatchScore("A");
        var matchController = new MatchController(_matchRepo);
        var result = matchController.UpdateMatchScores(MatchId, MatchEvent.NextPeriod);
        ShouldUpdateScore("A;");
        DisplayScoreMustBe(result, "0:1 (Second Half)");
    }

    private static AndConstraint<StringAssertions> DisplayScoreMustBe(string result, string displayScore)
    {
        return result.Should().Be(displayScore);
    }

    private void ShouldUpdateScore(string score)
    {
        _matchRepo.Received(1)
            .UpdateMatchScores(Arg.Is<Match>(x => x.MatchId == MatchId && x.MatchScore.Score == score));
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