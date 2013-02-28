using System;
using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using NUnit.Framework;

namespace DarvinAppTest.Business.DataTypes
{
    [TestFixture]
    public class QuestionFixture
    {
        [TestCase("")]
        [TestCase(null)]
        public void Question_NullText_ExpectedArgumentNullException(string invalidText)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Question(invalidText, new List<AnimalType>(), new List<AnimalType>()));
        }

        [TestCase("String")]
        [TestCase("S")]
        [TestCase("StringStringStringStringStringStringStringStringStringStringStringStringStringStringStringString")]
        public void Question_RightString_ReturnsExactlyThatStringAsTextProperty(string text)
        {
            var question = new Question(text, new List<AnimalType>(), new List<AnimalType>());
            Assert.AreEqual(text, question.Text);
        }


        public void Question_NullQuestionLists_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Question("validText", null, new List<AnimalType>()));
            Assert.Throws<ArgumentNullException>(() => new Question("validText", new List<AnimalType>(), null));
        }
    }
}