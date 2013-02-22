using System;

namespace DarvinApp.Business.DataTypes
{
    public class Animal
    {
        private readonly string _name;
        private readonly AnimalType _animalType;

        public Animal()
        {
        }

        public Animal(string name, AnimalType animalType)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            _name = name;
            _animalType = animalType;
        }

        public string Name
        {
            get { return _name; }
        }

        public AnimalType Type
        {
            get { return _animalType; }
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(null, o)) return false;
            if (ReferenceEquals(this, o)) return true;
            if (o.GetType() != GetType()) return false;
            return Equals((Animal) o);
        }

        protected bool Equals(Animal other)
        {
            return string.Equals(_name, other._name) && _animalType == other._animalType;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                //Ensure that we'll never get hashCode^0=1
                return (_name.GetHashCode() * 397) ^ ((int)(_animalType) + 1);
            }
        }
    }
}