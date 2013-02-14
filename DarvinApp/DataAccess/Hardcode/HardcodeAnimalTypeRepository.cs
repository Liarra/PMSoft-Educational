using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;

namespace DarvinApp.DataAccess.Hardcode
{
    public class HardcodeAnimalTypeRepository:IAnimalTypeRepository
    {
        public IList<AnimalType> AnimalTypeList()
        {
            throw new System.NotImplementedException();
        }
    }
}