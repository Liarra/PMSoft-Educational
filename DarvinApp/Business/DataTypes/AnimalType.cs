using System.ComponentModel;

namespace DarvinApp.Business.DataTypes
{
    public enum AnimalType
    {
        [Description("принадлежащие Императору")] Emperors,

        [Description("прирученные")] Tamed,

        [Description("молочные поросята")] Piglets,

        [Description("сказочные")] Tale,

        [Description("бродячие собаки")] StrayDogs,

        [Description("бегающие как сумасшедшие")] RunningLikeCrazy,

        [Description("разбившие цветочную вазу")] FlowerVaseBreakers,

        [Description("похожие издали на мух")] LookingLikeFlies,

        [Description("прочие")] Others
    }
}