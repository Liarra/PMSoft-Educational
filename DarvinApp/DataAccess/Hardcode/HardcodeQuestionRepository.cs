using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;

namespace DarvinApp.DataAccess.Hardcode
{
    public class HardcodeQuestionRepository : IQuestionRepository
    {
        public IList<Question> GetAllQuestions()
        {
            return new List<Question>
                {
                    new Question("Оно принадлежит Императору?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.Emperors
                                },
                        },
                    new Question("Оно приручено?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.Tamed
                                },
                        },
                    new Question("Это молочный поросёнок?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.Piglets
                                },
                        },
                    new Question("Оно сказочное?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.Tale
                                },
                        },
                    new Question("Это бродячая собака?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.StrayDogs
                                },
                        },
                    new Question("Оно бегает как сумасшедшее?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.RunningLikeCrazy
                                },
                        },
                    new Question("Оно разбило цветочную вазу?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.FlowerVaseBreakers
                                },
                        },
                    new Question("Оно похоже издали на муху?")
                        {
                            TypesGettingScoreFromPositiveAnswer = new List<AnimalType>
                                {
                                    AnimalType.LookingLikeFlies
                                },
                        }
                };
        }
    }
}