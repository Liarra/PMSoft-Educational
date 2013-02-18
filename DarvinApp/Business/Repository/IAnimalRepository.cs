using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business.Repository
{
    public interface IAnimalRepository
    {
        void WriteNewAnimal(string name, AnimalType type);
        IList<Animal> GetAllAnimals();
    }
}