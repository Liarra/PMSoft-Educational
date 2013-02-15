using System.Collections.Generic;
using System.Windows.Input;
using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DarvinApp.Presentation
{
    public class MainWindowModel : ViewModelBase
    {
        public Question CurrentQuestion
        {
            get { return AvailableQuestions[_questionListIndex]; }
        }

        private int _questionListIndex;
        private IList<Question> AvailableQuestions { get; set; }
        public IExpert Expert { get; set; }
        private ICommand _yesButtonPushed, _noButtonPushed;
        private NamingDialog _namingDialog;

        public NamingDialog NamingDialog
        {
            get { return _namingDialog ?? new NamingDialog(); } 
            set { _namingDialog = value; }
        }

        public MainWindowModel(IQuestionRepository questionsSource, IExpert expert)
        {
            _questionListIndex = 0;
            AvailableQuestions = questionsSource.GetAllQuestions();
            Expert = expert;
        }

        public ICommand YesButtonPushed
        {
            get
            {
                return _yesButtonPushed ??
                       (_yesButtonPushed = new RelayCommand(() =>
                           {
                               Expert.SubmitAnswer(CurrentQuestion, true);
                               SelectNextQuestion();
                           }));
            }
        }

        public ICommand NoButtonPushed
        {
            get
            {
                return _noButtonPushed ??
                       (_noButtonPushed = new RelayCommand(() =>
                           {
                               Expert.SubmitAnswer(CurrentQuestion, false);
                               SelectNextQuestion();
                           }
                   ));
            }
        }


        private void SelectNextQuestion()
        {
            if (AvailableQuestions.Count == 0) return;
            if (_questionListIndex == AvailableQuestions.Count)
            {
                
            }
            _questionListIndex = ++_questionListIndex%AvailableQuestions.Count;
            RaisePropertyChanged(() => CurrentQuestion);
        }
    }
}