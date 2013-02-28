using System.Collections.Generic;
using System.Collections.ObjectModel;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;

namespace DarvinApp.DataAccess.Hardcode
{
    public class HardcodeQuestionRepository : IQuestionRepository
    {
        public IEnumerable<Question> GetAllQuestions()
        {
            return new ReadOnlyCollection<Question>(
                new List<Question>
                {
                    new Question("Оно принадлежит Императору?",
                                 new List<AnimalType> {AnimalType.Emperors}, new List<AnimalType>()),

                    new Question("Оно приручено?",
                                 new List<AnimalType> {AnimalType.Tamed}, new List<AnimalType>()),

                    new Question("Это молочный поросёнок?",
                                 new List<AnimalType> {AnimalType.Piglets}, new List<AnimalType>()),

                    new Question("Оно сказочное?",
                                 new List<AnimalType> {AnimalType.Tale}, new List<AnimalType>()),

                    new Question("Это бродячая собака?",
                                 new List<AnimalType> {AnimalType.StrayDogs}, new List<AnimalType>()),

                    new Question("Оно бегает как сумасшедшее?",
                                 new List<AnimalType> {AnimalType.RunningLikeCrazy}, new List<AnimalType>()),

                    new Question("Оно разбило цветочную вазу?",
                                 new List<AnimalType> {AnimalType.FlowerVaseBreakers}, new List<AnimalType>()),

                    new Question("Оно похоже издали на муху?",
                                 new List<AnimalType> {AnimalType.LookingLikeFlies}, new List<AnimalType>())
                });
        }
    }
}