using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using DarvinApp.DataAccess.Hardcode;
using NUnit.Framework;

namespace DarvinAppTest.DataAccess.Hardcode
{
    public class HardcodeQuestionRepositoryFixture
    {
       [Test]
       public void GetAllQuestions_ExpecedNonEmptyList()
       {
           var victim=new HardcodeQuestionRepository();

           IList<Question> resultList = victim.GetAllQuestions();
           Assert.NotNull(resultList);
           Assert.IsNotEmpty(resultList);
       }
    }
}