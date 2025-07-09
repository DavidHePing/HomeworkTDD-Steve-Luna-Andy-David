using FluentAssertions;
using HomeworkTDD_Steve_Luna_Andy_David.Controllers;
using HomeworkTDD_Steve_Luna_Andy_David.Enums;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void home_goal_when_0_to_0_at_first_half()
    {
        var matchController = new MatchController();
        var result = matchController.UpdateMatchScores(MatchEvent.HomeGoal);
        result.Should().Be("1:0 First Half");
    }
}