using System.Collections.Generic;
using System.Windows.Input;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight.Command;

namespace DarvinApp.Presentation
{
    public class ViewModel
    {
        public Question CurrentQuestion { get; set; }
        private int _questionListIndex;
        private IList<Question> AvailableQuestions { get; set; }
        private ICommand _yesButtonPushed, _noButtonPushed;

        public ViewModel(IQuestionRepository questionsSource)
        {
            _questionListIndex = 0;
            AvailableQuestions = questionsSource.GetAllQuestions();
        }

        public ICommand YesButtonPushed
        {
            get { return _yesButtonPushed ?? (_yesButtonPushed = new RelayCommand(SelectNextQuestion)); }
        }

        public ICommand NoButtonPushed
        {
            get { return _noButtonPushed ?? (_noButtonPushed = new RelayCommand(SelectNextQuestion)); }
        }

        private void SelectNextQuestion()
        {
            if(AvailableQuestions.Count==0)return;
            CurrentQuestion = AvailableQuestions[_questionListIndex++];
            _questionListIndex = _questionListIndex%AvailableQuestions.Count;
        }
    }
}