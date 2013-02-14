using System.Collections.Generic;
using System.Linq;
using DarvinApp.Business.DataTypes;
using DarvinApp.DataAccess.Hardcode;
using NUnit.Framework;

namespace DarvinAppTest.DataAccess.Hardcode
{
    [TestFixture]
    class HardCodeAnimalTypeRepositoryFixture
    {
        [Test]
         public void AnimalTypeList_ExpectedToBeNotEmpty()
         {
             //Arrange
            var repository=new HardcodeAnimalTypeRepository();

            //AA
            Assert.IsNotEmpty(repository.AnimalTypeList());
         }

        [Test]
        [TestCase("принадлежащие Императору", Result = true)]
        [TestCase("прирученные", Result = true)]
        [TestCase("молочные поросята", Result = true)]
        [TestCase("сказочные", Result = true)]
        [TestCase("бродячие собаки", Result = true)]
        [TestCase("бегающие как сумасшедшие", Result = true)]
        [TestCase("разбившие цветочную вазу", Result = true)]
        [TestCase("похожие издали на мух", Result = true)]
        [TestCase("прочие", Result = true)]
        public bool AnimalTypeList_ExpectedContainAnimalTypeNameInAnyCase(string animalName)
        {
             //Arrange
            var repository=new HardcodeAnimalTypeRepository();
            IList<AnimalType> animalTypes = repository.AnimalTypeList();


            //AA
            return animalTypes.Any(type => type.Name.ToLower().Equals(animalName.ToLower()));
        }
    }

}