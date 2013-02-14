using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business.Repository
{
    public interface IAnimalRepository
    {
        void WriteNewAnimal(string name, AnimalType type);
        void GetAllAnimals();
    }
}