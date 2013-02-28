using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
namespace DarvinAppTest.DataAccess.Stub
{
    public class StubQuestionRepository:IQuestionRepository
    {
        private readonly IList<Question> _questions; 
        public StubQuestionRepository(int questionsNumber)
        {
            _questions = new List<Question>();
            for (int i = 0; i < questionsNumber; i++)
            {
                _questions.Add(new Question("Question" + i, new List<AnimalType>(), new List<AnimalType>()));
            }

        }
        public IEnumerable<Question> GetAllQuestions()
        {
            return _questions;
        }
    }
}