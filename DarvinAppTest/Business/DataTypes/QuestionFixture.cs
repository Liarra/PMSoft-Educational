using System;
using DarvinApp.Business.DataTypes;
using NUnit.Framework;

namespace DarvinAppTest.Business.DataTypes
{
    [TestFixture]
    public class QuestionFixture
    {
        [Test]
        public void Question_NullText_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(() => new Question(null));
        }

        [Test]
        public void Question_EmptyTextText_ExpectedAE()
        {
            Assert.Throws<ArgumentException>(() => new Question(""));
        }

        [TestCase("String")]
        [TestCase("S")]
        [TestCase("StringStringStringStringStringStringStringStringStringStringStringStringStringStringStringString")]
        public void Question_NonEmptyTextText_ExpectedNoException(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Should provide correct string", text);
            Assert.DoesNotThrow(() => new Question(text));
        }

        [TestCase("String")]
        [TestCase("S")]
        [TestCase("StringStringStringStringStringStringStringStringStringStringStringStringStringStringStringString")]
        public void Question_RightString_ReturnsExactlyThatStringAsTextProperty(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Should provide correct string", text);
            var question=new Question(text);
            Assert.AreEqual(text,question.Text);
        }
    }
}