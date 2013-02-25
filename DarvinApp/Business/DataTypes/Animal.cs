namespace DarvinApp.Business.DataTypes
{
    public class Animal
    {
        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(null, o)) return false;
            if (ReferenceEquals(this, o)) return true;
            if (o.GetType() != GetType()) return false;
            return Equals((Animal) o);
        }


        protected bool Equals(Animal other)
        {
            return string.Equals(Name, other.Name) && Type == other.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ ((int) Type + 1);
            }
        }
    }
}