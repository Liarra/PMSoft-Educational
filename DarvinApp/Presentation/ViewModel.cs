using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Presentation
{
    public class ViewModel
    {
        public Question CurrentQuestion { get; set; }
        public IList<Question> AvailableQuestions { get; set; }
        private int _questionListIndex;

        public ViewModel()
        {
            _questionListIndex = 0;
        }

        private void selectNextQuestion()
        {
            CurrentQuestion = AvailableQuestions[_questionListIndex++];
        }
    }
}