using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using NSubstitute;
using NUnit.Framework;

namespace DarvinAppTest.Business
{
    public class ExpertFixture
    {
        [Test]
         public void ReadyToDecide_WithNoQuestionsAnswered_ExpectedFalse()
         {
             Expert expertToTest=new Expert();
             bool actualReadyToDecide = expertToTest.ReadyToDecide();
             Assert.False(actualReadyToDecide);
         }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void ReadyToDecide_WithAllQuestionsAnsweredNo_ExpectedFalse(int numberOfQuestions)
        {
            Expert expertToTest = new Expert();

            for (int i = 0; i < numberOfQuestions;i++ )
                expertToTest.SubmitAnswer(Arg.Any<Question>(), false);

            bool actualReadyToDecide = expertToTest.ReadyToDecide();
            Assert.False(actualReadyToDecide);
        }


        [Test]
        public void Decision_NewlyCreatedObject_ThrownsNoExceptions()
        {
            Expert expertToTest = new Expert();
            Assert.DoesNotThrow(()=>expertToTest.Decision());
        }

    }
}