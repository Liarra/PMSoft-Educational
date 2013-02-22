using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;

namespace DarvinApp.DataAccess.JSON
{
    public class JsonAnimalRepository : IAnimalRepository
    {
        private readonly JavaScriptSerializer _serializer;
        private readonly string _fileName;

        public JsonAnimalRepository(string filename)
        {
            _fileName = filename;
            _serializer = new JavaScriptSerializer();
        }

        public void WriteNewAnimal(Animal animal)
        {
            if(animal==null)
                throw new ArgumentNullException("animal");
            IList<Animal> animalsAlreadyThere = GetAnimalsArrayFromFile();
            animalsAlreadyThere.Add(animal);
            WriteAnimalsArrayToFile(animalsAlreadyThere);
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return GetAnimalsArrayFromFile();
        }

        private IList<Animal> GetAnimalsArrayFromFile()
        {
            using (Stream fileStream = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(fileStream);
                string jsonString = reader.ReadToEnd();
                var animalList = _serializer.Deserialize<List<Animal>>(jsonString) ?? new List<Animal>{};
                return animalList;
            }
        }

        private void WriteAnimalsArrayToFile(IList<Animal> animals)
        {
            if(animals==null)
                throw new ArgumentNullException("animals");
            using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Truncate)))
            {
                string jsonString = _serializer.Serialize(animals);
                writer.Write(jsonString);
            }
        }
    }
}