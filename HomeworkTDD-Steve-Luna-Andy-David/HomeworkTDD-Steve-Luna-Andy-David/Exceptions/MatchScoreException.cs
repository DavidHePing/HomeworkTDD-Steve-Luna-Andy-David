using HomeworkTDD_Steve_Luna_Andy_David.Enums;

namespace HomeworkTDD_Steve_Luna_Andy_David.Exceptions;

public class MatchScoreException : Exception
{
    public MatchEvent MatchEvent { get; set; }
    public string MatchScores { get; set; }
}