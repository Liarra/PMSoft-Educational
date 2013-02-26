using System;
using DarvinApp.Business;
using DarvinApp.Business.Repository;
using DarvinApp.Presentation;
using DarvinAppTest.DataAccess.Stub;
using GalaSoft.MvvmLight.Messaging;
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
            MainWindowModel victim = createModelWithStubParameters(5);
            Assert.DoesNotThrow(() => victim.YesButtonPushed.Execute(null));
            Assert.DoesNotThrow(() => victim.NoButtonPushed.Execute(null));
        }

        [Test]
        public void Constructor_NullExpert_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                new MainWindowModel(Substitute.For<IQuestionRepository>(), null, 42, Substitute.For<Messenger>()));
        }

        [Test]
        public void Constructor_NullQuestionRepo_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new MainWindowModel(null, Substitute.For<IExpert>(), 42, Substitute.For<Messenger>()));
        }

        [TestCase(5, 1)]
        [TestCase(5, 4)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(2, 0)]
        public void ButtonPushed_ExecutedLessTimesThanQuestionsWereThere_ExpectedRightQuestionSelect(int questions,
                                                                                                     int executions)
        {
            if (executions >= questions)
                throw new ArgumentException("executions must be less than question number");
            var victim = createModelWithStubParameters(questions);

            for (var i = 0; i < executions; i++)
                executeSomeOfTheseButtonActionsPlease(i, victim);

            Assert.NotNull(victim.CurrentQuestion);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void ButtonPushed_ExecutedForAllQuestionsWereThere_ExpectedLastQuestionSelected(int questions)
        {
            var victim = createModelWithStubParameters(questions);

            for (var i = 0; i < questions; i++)
                executeSomeOfTheseButtonActionsPlease(i, victim);


            Assert.NotNull(victim.CurrentQuestion);
        }

        private MainWindowModel createModelWithStubParameters(int questions)
        {
            return new MainWindowModel(new StubQuestionRepository(questions),
                                       Substitute.For<IExpert>(), 42, Substitute.For<Messenger>());
        }

        private void executeSomeOfTheseButtonActionsPlease(int which, MainWindowModel victim)
        {
            if (which%2 == 0)
                victim.YesButtonPushed.Execute(null);
            else
                victim.NoButtonPushed.Execute(null);
        }
    }
}