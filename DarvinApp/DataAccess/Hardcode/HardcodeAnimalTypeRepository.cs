using System.Collections.Generic;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;

namespace DarvinApp.DataAccess.Hardcode
{
    public class HardcodeAnimalTypeRepository:IAnimalTypeRepository
    {
        public IList<AnimalType> AnimalTypeList()
        {
            return new List<AnimalType>
                {
                    new AnimalType{Name = "принадлежащие Императору"},
                    new AnimalType{Name = "прирученные"},
                    new AnimalType{Name = "молочные поросята"},

                    new AnimalType{Name = "сказочные"},
                    new AnimalType{Name = "бродячие собаки"},
                    new AnimalType{Name = "бегающие как сумасшедшие"},

                    new AnimalType{Name = "разбившие цветочную вазу"},
                    new AnimalType{Name = "похожие издали на мух"},
                    new AnimalType{Name = "прочие"},
                };
        }
    }
}