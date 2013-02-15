using System.Collections.Generic;

namespace DarvinApp.Business.DataTypes
{
    public class Question
    {
        public Question(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public IList<AnimalType> TypesGettingScoreFromPositiveAnswer { get; set; }
        public IList<AnimalType> TypesLosingScoreFromPositiveAnswer { get; set; }
    }
}