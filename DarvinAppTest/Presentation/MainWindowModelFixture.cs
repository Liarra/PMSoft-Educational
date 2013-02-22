using System;
using System.Resources;
using DarvinApp.Business;
using DarvinApp.Business.Repository;
using DarvinApp.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace DarvinAppTest.Presentation
{
    [TestFixture]
    public class MainWindowModelFixture
    {
        [Test]
        public void ButtonPushed_NoQuestions_NoExceptionIsThrown()
        {
            MainWindowModel victim = createModelWithStubParameters();
            Assert.DoesNotThrow(() => victim.YesButtonPushed.Execute(null));
            Assert.DoesNotThrow(() => victim.NoButtonPushed.Execute(null));
        }

        [Test]
        public void Constructor_NullExpert_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                new MainWindowModel(Substitute.For<IQuestionRepository>(), Substitute.For<IAnimalRepository>(), null,Substitute.For<ResourceManager>()));
        }

        [Test]
        public void Constructor_NullQuestionRepo_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new MainWindowModel(null, Substitute.For<IAnimalRepository>(), Substitute.For<IExpert>(), Substitute.For<ResourceManager>()));
        }

        //[TestCase(5, 1)]
        //[TestCase(5, 4)]
        //[TestCase(1, 0)]
        //[TestCase(2, 1)]
        //[TestCase(2, 0)]
        //public void ButtonPushed_ExecutedLessTimesThanQuestionsWereThere_ExpectedRightQuestionSelect(int questions, int executions)
        //{
        //    if (executions >= questions)
        //        throw new ArgumentException("executions must be less than question number");
        //    var victim = createModelWithStubParameters();
        //    var newQuestions=new List<Question>();

        //    for (var i = 0; i < questions; i++)
        //        newQuestions.Add(Substitute.For<Question>(Arg.Any<String>()));

        //    victim.AvailableQuestions = newQuestions;

        //    for (var i = 0; i < executions; i++)
        //        executeSomeOfTheseButtonActionsPlease(i, victim);

        //    Assert.AreEqual(executions, victim.AvailableQuestions.IndexOf(victim.CurrentQuestion));
        //}

        //[TestCase(1)]
        //[TestCase(5)]
        //public void ButtonPushed_ExecutedForAllQuestionsWereThere_ExpectedLastQuestionSelected(int questions)
        //{
        //    var victim = createModelWithStubParameters();
        //    var newQuestions = new List<Question>();


        //    for (var i = 0; i < questions; i++)
        //        newQuestions.Add(Substitute.For<Question>(Arg.Any<String>()));

        //    victim.AvailableQuestions = newQuestions;


        //    for (var i = 0; i < questions; i++)
        //        try
        //        {
        //            executeSomeOfTheseButtonActionsPlease(i,victim);
        //        }
        //        catch (System.Reflection.TargetInvocationException)
        //        {
        //            ;
        //        }

        //    Assert.AreEqual((victim.AvailableQuestions.Count-1), victim.AvailableQuestions.IndexOf(victim.CurrentQuestion));
        //}

        private MainWindowModel createModelWithStubParameters()
        {
            return new MainWindowModel(Substitute.For<IQuestionRepository>(), Substitute.For<IAnimalRepository>(),
                                       Substitute.For<IExpert>(),Substitute.For<ResourceManager>());
        }

        private void executeSomeOfTheseButtonActionsPlease(int which, MainWindowModel victim)
        {
            if (which % 2 == 0)
                victim.YesButtonPushed.Execute(null);
            else
                victim.NoButtonPushed.Execute(null);
        }
    }
}