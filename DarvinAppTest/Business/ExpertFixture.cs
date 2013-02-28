using System;
using System.Collections.Generic;
using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using NSubstitute;
using NUnit.Framework;

namespace DarvinAppTest.Business
{
    [TestFixture]
    public class ExpertFixture
    {
        private Question GetStupidQuestion()
        {
            return new Question("Who, me?", new List<AnimalType>(), new List<AnimalType>());
        }

        [Test]
        public void ReadyToDecide_WithNoQuestionsAnswered_ExpectedFalse()
        {
            var expertToTest = new Expert();
            bool actualReadyToDecide = expertToTest.ReadyToDecide();
            Assert.False(actualReadyToDecide);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void ReadyToDecide_WithAllQuestionsAnsweredNo_ExpectedFalse(int numberOfQuestions)
        {
            var expertToTest = new Expert();

            for (int i = 0; i < numberOfQuestions; i++)
                expertToTest.SubmitAnswer(GetStupidQuestion(), false);

            bool actualReadyToDecide = expertToTest.ReadyToDecide();
            Assert.False(actualReadyToDecide);
        }


        [Test]
        public void Decision_NewlyCreatedObject_ThrownsNoExceptions()
        {
            var expertToTest = new Expert();
            Assert.DoesNotThrow(() => expertToTest.Decision());
        }

        [Test]
        public void Decision_ExpectedNotNullAnimalType()
        {
            var expertToTest = new Expert();
            for (int i = 0; i < 5; i++)
                expertToTest.SubmitAnswer(GetStupidQuestion(), Arg.Any<bool>());
            var decicion = expertToTest.Decision();
            Assert.IsNotNull(decicion);
            Assert.IsInstanceOf<AnimalType>(decicion);
        }

        [TestCase(AnimalType.FlowerVaseBreakers)]
        [TestCase(AnimalType.Emperors)]
        [TestCase(AnimalType.LookingLikeFlies)]
        [TestCase(AnimalType.Piglets)]
        [TestCase(AnimalType.RunningLikeCrazy)]
        [TestCase(AnimalType.StrayDogs)]
        [TestCase(AnimalType.Tale)]
        [TestCase(AnimalType.Tamed)]
        public void Decision_OneSingleTypedQuestionAnswer_ExpectedRighType(AnimalType type)
        {
            var expertToTest = new Expert();
            var questionToAnswer = new Question("123", new List<AnimalType> {type}, new List<AnimalType>());


            expertToTest.SubmitAnswer(questionToAnswer, true);
            Assert.AreEqual(expertToTest.Decision(), type);
        }

        [TestCase(AnimalType.FlowerVaseBreakers, AnimalType.Emperors)]
        [TestCase(AnimalType.Emperors, AnimalType.FlowerVaseBreakers)]
        [TestCase(AnimalType.LookingLikeFlies, AnimalType.Emperors)]
        [TestCase(AnimalType.Piglets, AnimalType.FlowerVaseBreakers)]
        [TestCase(AnimalType.RunningLikeCrazy, AnimalType.Emperors)]
        [TestCase(AnimalType.StrayDogs, AnimalType.FlowerVaseBreakers)]
        [TestCase(AnimalType.Tale, AnimalType.Emperors)]
        [TestCase(AnimalType.Tamed, AnimalType.FlowerVaseBreakers)]
        public void Decision_OneMultiTypedQuestionAnswer_ExpectedOther(AnimalType type1, AnimalType type2)
        {
            var expertToTest = new Expert();
            var questionToAnswer = new Question("123", new List<AnimalType> {type1, type2}, new List<AnimalType>());

            expertToTest.SubmitAnswer(questionToAnswer, true);
            Assert.AreEqual(AnimalType.Others, expertToTest.Decision());
        }

        [Test]
        public void Decision_TwoExclusiveQuestions_ExpectedOthers()
        {
            var expertToTest = new Expert();
            var type1 = Arg.Any<AnimalType>();
            var type2 = Arg.Any<AnimalType>();

            var questionToAnswer1 = new Question("123", new List<AnimalType> {type1}, new List<AnimalType> {type2});
            var questionToAnswer2 = new Question("123", new List<AnimalType> {type2}, new List<AnimalType> {type1});

            expertToTest.SubmitAnswer(questionToAnswer1, true);
            expertToTest.SubmitAnswer(questionToAnswer2, true);
            Assert.AreEqual(AnimalType.Others, expertToTest.Decision());
        }

        [Test]
        public void SubmitAnswer_NullQuestion_ExpectedANE()
        {
            var expertToTest = new Expert();

            Assert.Throws<ArgumentNullException>(() => expertToTest.SubmitAnswer(null, true));
        }
    }
}