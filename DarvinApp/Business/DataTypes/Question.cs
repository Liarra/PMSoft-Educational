using System.Collections.Generic;

namespace DarvinApp.Business.DataTypes
{
    public class Question
    {
        public string Text { get; set; }
        private IList<AnimalType> _typesGettingScoreFromPositiveAnswer;
        private IList<AnimalType> _typesLosingScoreFromPositiveAnswer;
    }
}