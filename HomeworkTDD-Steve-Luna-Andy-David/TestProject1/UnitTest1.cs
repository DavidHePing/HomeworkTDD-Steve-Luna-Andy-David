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
    private int _matchId;

    [SetUp]
    public void Setup()
    {
        _matchRepo=Substitute.For<IMatchRepo>();
    }

    [Test]
    public void home_goal_when_0_to_0_at_first_half()
    {
        GivenMatchScore("");
        var matchController = new MatchController(_matchRepo);
        _matchId = 123;
        var result = matchController.UpdateMatchScores(_matchId,MatchEvent.HomeGoal);
        
        result.Should().Be("1:0 First Half");
    }

    private void GivenMatchScore(string score)
    {
        _matchRepo.GetMatch(_matchId).Returns(new Match
        {
            MatchScore = score
        });
    }
}