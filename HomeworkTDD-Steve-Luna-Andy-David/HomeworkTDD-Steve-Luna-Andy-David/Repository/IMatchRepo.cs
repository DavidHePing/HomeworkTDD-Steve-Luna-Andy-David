using HomeworkTDD_Steve_Luna_Andy_David.Models;

namespace HomeworkTDD_Steve_Luna_Andy_David.Repository;

public interface IMatchRepo
{
    Match GetMatch(int matchId);
}