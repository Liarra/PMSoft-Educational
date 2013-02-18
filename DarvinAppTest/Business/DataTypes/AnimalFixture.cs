using DarvinApp.Business.DataTypes;
using NUnit.Framework;

namespace DarvinAppTest.Business.DataTypes
{
    [TestFixture]
    public class AnimalFixture
    {
        [Test]
         public void Equals_OnlyEqualNames_ExpectedFalse()
         {
             Animal a1=new Animal(){Name = "Name", Type = AnimalType.Piglets};
             Animal a2=new Animal(){Name = "Name", Type = AnimalType.Others};

             Assert.False(a1.Equals(a2));
         }

        [Test]
         public void Equals_OnlyEqualTYpes_ExpectedFalse()
         {
             Animal a1 = new Animal() { Name = "Name1", Type = AnimalType.Piglets };
             Animal a2 = new Animal() { Name = "Name2", Type = AnimalType.Piglets };

             Assert.False(a1.Equals(a2));
         }

        [Test]
         public void Equals_BothEqual_ExpectedTrue()
         {
             Animal a1 = new Animal() { Name = "Name1", Type = AnimalType.Piglets };
             Animal a2 = new Animal() { Name = "Name1", Type = AnimalType.Piglets };

             Assert.True(a1.Equals(a2));
         }
    }
}