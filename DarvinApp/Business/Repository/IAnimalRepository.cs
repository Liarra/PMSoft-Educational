using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business.Repository
{
    public interface IAnimalRepository
    {
        void WriteNewAnimal(Animal animal);
        IEnumerable<Animal> GetAllAnimals();
    }
}