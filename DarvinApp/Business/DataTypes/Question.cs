using System;
using System.Collections.Generic;

namespace DarvinApp.Business.DataTypes
{
    public class Question
    {
        private readonly string _text;
        public Question(string text)
        {
            if(text==null)
                throw new ArgumentNullException("text");
            if(text.Length==0)
                throw new ArgumentException("Question text must not be empty","text");
            _text = text;
            TypesLosingScoreFromPositiveAnswer=new List<AnimalType>();
            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>();
        }

        public string Text { get { return _text; } }
        public IList<AnimalType> TypesGettingScoreFromPositiveAnswer { get; set; }
        public IList<AnimalType> TypesLosingScoreFromPositiveAnswer { get; set; }
    }
}