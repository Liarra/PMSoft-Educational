namespace DarvinApp.Business.DataTypes
{
    public class Animal
    {
        public string Name { get; set; }
        public AnimalType Type { get; set; }

        public override bool Equals(object o)
        {
            if (o is Animal)
            {
                var anotherAnimal = o as Animal;
                if (Name.Equals(anotherAnimal.Name)
                    &&
                    Type.Equals(anotherAnimal.Type))
                    return true;
            }
            return false;
        }
    }
}