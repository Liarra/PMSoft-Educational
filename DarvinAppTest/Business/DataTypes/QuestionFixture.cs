using System;
using DarvinApp.Business.DataTypes;
using NUnit.Framework;

namespace DarvinAppTest.Business.DataTypes
{
    [TestFixture]
    public class QuestionFixture
    {
        [Test]
        public void Question_NullText_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Question(null));
        }

        [Test]
        public void Question_EmptyText_ExpectedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Question(""));
        }

        [TestCase("String")]
        [TestCase("S")]
        [TestCase("StringStringStringStringStringStringStringStringStringStringStringStringStringStringStringString")]
        public void Question_NonEmptyTextText_ExpectedNoException(string text)
        {
            Assert.DoesNotThrow(() => new Question(text));
        }

        [TestCase("String")]
        [TestCase("S")]
        [TestCase("StringStringStringStringStringStringStringStringStringStringStringStringStringStringStringString")]
        public void Question_RightString_ReturnsExactlyThatStringAsTextProperty(string text)
        {
            var question=new Question(text);
            Assert.AreEqual(text,question.Text);
        }
    }
}