using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
    }
}