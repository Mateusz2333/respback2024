using BackendLab01;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IQuizService
    {
        List<Quiz> GetAllQuizzes();
        Quiz GetQuizById(int id);
    }
}
