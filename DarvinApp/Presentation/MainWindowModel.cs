using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Input;
using DarvinApp.Business;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DarvinApp.Presentation
{
    public class MainWindowModel : ViewModelBase
    {
        private int _questionListIndex;
        private readonly IExpert _expert;
        private readonly IList<Question> _availableQuestions;
        private readonly object _token;

        private ICommand _yesButtonPushed;
        private ICommand _noButtonPushed;

        public Question CurrentQuestion
        {
            get { return _availableQuestions[_questionListIndex]; }
        }

        public MainWindowModel(IQuestionRepository questionsSource, 
                               IExpert expert, object messagingToken)
        {
            if (questionsSource == null)
                throw new ArgumentNullException("questionsSource");
           
            if (expert == null)
                throw new ArgumentNullException("expert");
             
            _questionListIndex = 0;
            _expert = expert;
            _availableQuestions = questionsSource.GetAllQuestions();

            _token = messagingToken;
        }

        private bool animalTypeDictionaryContainsAllSupportedTypes(IExpert expert, ResourceManager animalTypeNames)
        {
            IList<AnimalType> types = expert.SupportedTypes;
            return types.All(t => animalTypeNames.GetObject(t.ToString()) != null);
        }

        public ICommand YesButtonPushed
        {
            get
            {
                return _yesButtonPushed ??
                       (_yesButtonPushed = new RelayCommand(() =>
                           {
                               if (_availableQuestions.Count == 0) return;
                               _expert.SubmitAnswer(CurrentQuestion, true);
                               SelectNextQuestion();
                           }));
            }
        }

        public ICommand NoButtonPushed
        {
            get
            {
                return _noButtonPushed ?? (_noButtonPushed = new RelayCommand(() =>
                    {
                        if (_availableQuestions.Count == 0) return;
                        _expert.SubmitAnswer(CurrentQuestion, false);
                        SelectNextQuestion();
                    }));
            }
        }


        private void SelectNextQuestion()
        {
            if (_expert.ReadyToDecide())
            {
                ShowResultDialog();
                return;
            }

            if (_questionListIndex == _availableQuestions.Count - 1)
            {
                ShowResultDialog();
                return;
            }
            _questionListIndex++;
            RaisePropertyChanged(() => CurrentQuestion);
        }

        private void ShowResultDialog()
        {      
            var animalType = _expert.Decision(); 
            Messenger.Default.Send(new NotificationMessage(animalType.ToString()),_token);
            Messenger.Default.Send(new NotificationMessage("ShowDialog"));
        }
    }
}