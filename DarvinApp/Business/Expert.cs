using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business
{
    public class Expert:IExpert
    {
        public IList<AnimalType> SupportedTypes { get; set; }
        public bool ReadyToDecide()
        {
            throw new System.NotImplementedException();
        }

        public AnimalType Decision()
        {
            throw new System.NotImplementedException();
        }
    }
}