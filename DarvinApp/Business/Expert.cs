using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business
{
    public class Expert : IExpert
    {
 
        private readonly IList<AnimalType> _supportedTypes;
        private readonly Dictionary<AnimalType, int> _scoretable;

        public Expert()
        {
            _supportedTypes =  new ReadOnlyCollection<AnimalType>(new List<AnimalType>
                {
                    AnimalType.Emperors,
                    AnimalType.FlowerVaseBreakers,
                    AnimalType.LookingLikeFlies,
                    AnimalType.Others,
                    AnimalType.Piglets,
                    AnimalType.RunningLikeCrazy,
                    AnimalType.StrayDogs,
                    AnimalType.Tale,
                    AnimalType.Tamed
                });

            _scoretable = new Dictionary<AnimalType, int>();
            FillTheDictionaryWithZeros();
        }

        private void FillTheDictionaryWithZeros()
        {
            foreach (var supportedType in SupportedTypes)
            {
                _scoretable.Add(supportedType, 0);
            }
        }

        public IEnumerable<AnimalType> SupportedTypes
        {
            get { return _supportedTypes; }
        }

        private const int DifferenceNeededToDecide = 1;

        public bool ReadyToDecide()
        {
            int maxScoreInTable = 0;
            int secondScoreInTable = 0;

            foreach (int score in _scoretable.Values)
                if (score >= maxScoreInTable)
                {
                    secondScoreInTable = maxScoreInTable;
                    maxScoreInTable = score;
                }

            if (maxScoreInTable - secondScoreInTable >= DifferenceNeededToDecide) return true;
            return false;
        }

        public AnimalType Decision()
        {
            if (!ReadyToDecide()) return AnimalType.Others;
            int maxScoreInTable = 0;
            var currentWinner = AnimalType.Others;

            foreach (KeyValuePair<AnimalType, int> record in _scoretable)
                if (record.Value > maxScoreInTable)
                {
                    maxScoreInTable = record.Value;
                    currentWinner = record.Key;
                }
            return currentWinner;
        }

        public void SubmitAnswer(Question questionAnswered, bool answer)
        {
            if (questionAnswered == null)
                throw new ArgumentNullException("questionAnswered");
            if (!answer) return;
            foreach (var questionPromotedAnimalType in questionAnswered.TypesGettingScoreFromPositiveAnswer)
                _scoretable[questionPromotedAnimalType]++;

            foreach (var questionReducedAnimalType in questionAnswered.TypesLosingScoreFromPositiveAnswer)
                _scoretable[questionReducedAnimalType]--;
        }
    }
}