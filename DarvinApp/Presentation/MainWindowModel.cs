using System;
using System.Collections.Generic;
using System.Windows;
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
        private int _questionListIndex;
        private readonly IExpert _expert;
        private readonly NamingDialog _namingDialog;
        private readonly IAnimalRepository _animalRepository;

        private ICommand _yesButtonPushed;
        private ICommand _noButtonPushed;

        public IList<Question> AvailableQuestions { get; set; }

        public Question CurrentQuestion
        {
            get { return AvailableQuestions[_questionListIndex]; }
        }

        public MainWindowModel(IQuestionRepository questionsSource, IAnimalRepository animalSavingDestination,
                               IExpert expert)
        {
            if (questionsSource == null)
                throw new ArgumentNullException("questionsSource");
            if (animalSavingDestination == null)
                throw new ArgumentNullException("animalSavingDestination");
            if (expert == null)
                throw new ArgumentNullException("expert");

            _questionListIndex = 0;
            _expert = expert;
            _animalRepository = animalSavingDestination;
            AvailableQuestions = questionsSource.GetAllQuestions();

            _namingDialog = new NamingDialog();
        }

        public ICommand YesButtonPushed
        {
            get
            {
                return _yesButtonPushed ??
                       (_yesButtonPushed = new RelayCommand(() =>
                           {
                               if (AvailableQuestions.Count == 0) return;
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
                        if (AvailableQuestions.Count == 0) return;
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

            if (_questionListIndex == AvailableQuestions.Count - 1)
            {
                ShowResultDialog();
                return;
            }
            _questionListIndex++;
            RaisePropertyChanged(() => CurrentQuestion);
        }

        private void ShowResultDialog()
        {
            _namingDialog.TypeLabel.Content = _expert.DecisionString();
            _namingDialog.Closed += (sender, e) => Application.Current.Shutdown(0);

            _namingDialog.SaveAnimalButton.Command = new RelayCommand(() =>
                {
                    AnimalType animalType = _expert.Decision();
                    string animalName = _namingDialog.AnimalNameBox.Text;

                    _animalRepository.WriteNewAnimal(new Animal {Name = animalName,Type = animalType});
                    MessageBox.Show("Животное сохранено");
                    Application.Current.Shutdown(0);
                });
            _namingDialog.ShowDialog();
        }
    }
}