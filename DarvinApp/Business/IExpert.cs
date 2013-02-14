using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business
{
    public interface IExpert
    {
        IList<AnimalType> SupportedTypes { get; set; }
        bool ReadyToDecide();
        AnimalType Decision();
    }
}