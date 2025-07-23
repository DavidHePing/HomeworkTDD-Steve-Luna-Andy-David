using FluentAssertions;
using FluentAssertions.Primitives;
using HomeworkTDD_Steve_Luna_Andy_David.Controllers;
using HomeworkTDD_Steve_Luna_Andy_David.Enums;
using HomeworkTDD_Steve_Luna_Andy_David.Exceptions;
using HomeworkTDD_Steve_Luna_Andy_David.Models;
using HomeworkTDD_Steve_Luna_Andy_David.Repository;
using NSubstitute;

namespace TestProject1;

public class Tests
{
    private IMatchRepo _matchRepo = null;
    private MatchController _matchController;
    const int MatchId = 123;

    [SetUp]
    public void Setup()
    {
        _matchRepo = Substitute.For<IMatchRepo>();
        _matchController = new MatchController(_matchRepo);
    }

    [Test]
    public void home_goal_when_0_to_0_at_first_half()
    {
        GivenMatchScore("");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.HomeGoal);
        ShouldUpdateScore("H");
        DisplayScoreMustBe(result, "1:0 (First Half)");
    }

    [Test]
    public void away_goal_when_0_to_0_at_first_half()
    {
        GivenMatchScore("");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.AwayGoal);
        ShouldUpdateScore("A");
        DisplayScoreMustBe(result, "0:1 (First Half)");
    }

    [Test]
    public void next_period_when_0_to_1_at_first_half()
    {
        GivenMatchScore("A");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.NextPeriod);
        ShouldUpdateScore("A;");
        DisplayScoreMustBe(result, "0:1 (Second Half)");
    }

    [Test]
    public void home_goal_when_1_to_1_at_second_half()
    {
        GivenMatchScore("AH;");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.HomeGoal);
        ShouldUpdateScore("AH;H");
        DisplayScoreMustBe(result, "2:1 (Second Half)");
    }

    [Test]
    public void cancel_home_goal_succeed_when_1_to_1_at_first_half()
    {
        GivenMatchScore("AH");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.CancelHomeGoal);
        ShouldUpdateScore("A");
        DisplayScoreMustBe(result, "0:1 (First Half)");
    }

    [Test]
    public void cancel_home_goal_succeed_when_1_to_1_at_second_half()
    {
        GivenMatchScore("AH;");
        var result = _matchController.UpdateMatchScores(MatchId, MatchEvent.CancelHomeGoal);
        ShouldUpdateScore("A;");
        DisplayScoreMustBe(result, "0:1 (Second Half)");
    }
    [Test]
    public void cancel_home_goal_fail_when_1_to_2_at_first_half()
    {
        GivenMatchScore("AHA");
        var action = () => _matchController.UpdateMatchScores(MatchId, MatchEvent.CancelHomeGoal);
        action.Should().Throw<MatchScoreException>()
            .Where(exception => exception.MatchEvent == MatchEvent.CancelHomeGoal
                                && exception.MatchScores == "AHA");
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