﻿using System.Collections.Generic;
using DarvinApp.Business.DataTypes;

namespace DarvinApp.Business
{
    public interface IExpert
    {
        IEnumerable<AnimalType> SupportedTypes { get; }
        bool ReadyToDecide();
        AnimalType Decision();
        void SubmitAnswer(Question questionAnswered, bool answer);
    }
}