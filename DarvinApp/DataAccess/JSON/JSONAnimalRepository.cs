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
        public string FileName { get; set; }

        public JsonAnimalRepository(String filename)
        {
            FileName = filename;
            _serializer=new JavaScriptSerializer();
        }

        public void WriteNewAnimal(string name, AnimalType type)
        {
            IList<Animal> animalsAlreadyThere = GetAnimalsArrayFromFile();
            animalsAlreadyThere.Add(new Animal {Name = name, Type = type});
            WriteAnimalsArrayToFile(animalsAlreadyThere);
        }

        public IList<Animal> GetAllAnimals()
        {
            return GetAnimalsArrayFromFile();
        }

        private IList<Animal> GetAnimalsArrayFromFile()
        {
            FileStream fs = new FileStream(FileName,FileMode.OpenOrCreate);
            var reader = new StreamReader(fs);
            String jsonString = reader.ReadToEnd();
            reader.Close();

            var animalList = _serializer.Deserialize<List<Animal>>(jsonString) ?? new List<Animal>();
            return animalList;
        }

        private void WriteAnimalsArrayToFile(IList<Animal> animals)
        {
            var writer = new StreamWriter(new FileStream(FileName,FileMode.Truncate));
            String jsonString = _serializer.Serialize(animals);
            writer.Write(jsonString);
            writer.Flush();
            writer.Close();
        }
    }
}