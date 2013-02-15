using System.Collections.Generic;
using System.Windows.Input;
using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DarvinApp.Presentation
{
    public class ViewModel:ViewModelBase
    {
        public Question CurrentQuestion { get { return AvailableQuestions[_questionListIndex]; } }
        private int _questionListIndex;
        private IList<Question> AvailableQuestions { get; set; }
        private ICommand _yesButtonPushed, _noButtonPushed;
        private IExpert _expert;

        public ViewModel(IQuestionRepository questionsSource,IExpert expert)
        {
            _questionListIndex = 0;
            AvailableQuestions = questionsSource.GetAllQuestions();
            _expert = expert;
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
            if (AvailableQuestions.Count == 0) return;
            _questionListIndex = ++_questionListIndex%AvailableQuestions.Count;
            RaisePropertyChanged(()=>CurrentQuestion);
        }
    }
}