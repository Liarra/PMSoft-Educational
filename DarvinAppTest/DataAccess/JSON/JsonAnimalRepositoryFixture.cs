using System.Collections.Generic;
using System.IO;
using DarvinApp.Business.DataTypes;
using DarvinApp.DataAccess.JSON;
using NSubstitute;
using NUnit.Framework;

namespace DarvinAppTest.DataAccess.JSON
{
    [TestFixture]
    public class JsonAnimalRepositoryFixture
    {
        [TestCase("0.txt")]
        public void WriteNewAnimal_NoFile_ExpectedSuccess(string filename)
        {
            var repository = new JsonAnimalRepository(filename);
            var animal = new Animal {Name = "Rat", Type = Arg.Any<AnimalType>()};
            repository.WriteNewAnimal(animal.Name, animal.Type);

            IList<Animal> animals = repository.GetAllAnimals();
            Assert.True(animals.Contains(animal));
        }

        [Test]
        public void GetAllAnimals_NoFile_ExpectedEmptyList()
        {
            string filename = "testfile.txt";
            if (File.Exists(filename))
                File.Delete(filename);

            var repository = new JsonAnimalRepository(filename);
            IList<Animal> animals = repository.GetAllAnimals();

            Assert.True(animals.Count == 0);
        }

        [TestCase(1)]
        public void GetAllAnimals_FilewithN_ExpectedListWithN(int n)
        {
            const string testFileName = "testfile.txt";
            WriteNRecordsToFile(testFileName, n);
            var repository = new JsonAnimalRepository(testFileName);

            IList<Animal> animals = repository.GetAllAnimals();
            Assert.AreEqual(animals.Count, n);
        }

        [TestCase(1)]
        public void WriteNewAnimal_FileWithN_ExpectedNPlus1Records(int n)
        {
            const string testFileName = "testfile.txt";
            WriteNRecordsToFile(testFileName, n);
            var repository = new JsonAnimalRepository(testFileName);
            repository.WriteNewAnimal(Arg.Any<string>(), Arg.Any<AnimalType>());
            IList<Animal> animals = repository.GetAllAnimals();
            Assert.AreEqual(animals.Count, n + 1);
        }

        private void WriteNRecordsToFile(string filename, int records)
        {
            var fs = new FileStream(filename, FileMode.Create);
            var writer = new StreamWriter(fs);
            writer.Write("[");
            for (int i = 0; i < records; i++)
                writer.WriteLine("{\"Name\":\"Rat\",\"Type\":0}");

            writer.Write("]");
            writer.Flush();
            writer.Close();
        }
    }
}