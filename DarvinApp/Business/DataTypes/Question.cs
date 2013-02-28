using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DarvinApp.Business.DataTypes
{
    public class Question
    {
        private readonly string _text;
        private readonly IList<AnimalType> _typesGettingScoreFromPositive;
        private readonly IList<AnimalType> _typesLosingScoreFromPositive;

        public Question(string text, IList<AnimalType> typesGettingScoreFromPositive,
                        IList<AnimalType> typesLosingScoreFromPositive)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            _text = text;
            _typesGettingScoreFromPositive = typesGettingScoreFromPositive;
            _typesLosingScoreFromPositive = typesLosingScoreFromPositive;
        }

        public string Text
        {
            get { return _text; }
        }

        public IEnumerable<AnimalType> TypesGettingScoreFromPositiveAnswer
        {
            get { return new ReadOnlyCollection<AnimalType>(_typesGettingScoreFromPositive); }
        }

        public IEnumerable<AnimalType> TypesLosingScoreFromPositiveAnswer
        {
            get { return new ReadOnlyCollection<AnimalType>(_typesLosingScoreFromPositive); }
        }
    }
}