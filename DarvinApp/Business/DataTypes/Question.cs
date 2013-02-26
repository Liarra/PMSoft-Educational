using System;
using System.Collections.Generic;

namespace DarvinApp.Business.DataTypes
{
    public class Question
    {
        private readonly string _text;

        public Question(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            _text = text;
            TypesLosingScoreFromPositiveAnswer = new List<AnimalType>();
            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>();
        }

        public string Text
        {
            get { return _text; }
        }

        public IList<AnimalType> TypesGettingScoreFromPositiveAnswer { get; set; }
        public IList<AnimalType> TypesLosingScoreFromPositiveAnswer { get; set; }
    }
}