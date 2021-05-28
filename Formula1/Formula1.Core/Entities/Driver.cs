using Formula1.Core.Contracts;

namespace Formula1.Core.Entities
{
    public class Driver : ICompetitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Name => ToString();


        public override string ToString() => $"{LastName} {FirstName}";
        
        public override bool Equals(object obj)
        {
            if(obj is Driver)
            {
                Driver other = (Driver)obj;
                return Name == other.Name;
            }
            return false;
        }

    }
}
