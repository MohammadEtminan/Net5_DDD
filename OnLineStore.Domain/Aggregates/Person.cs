namespace OnLineStore.Domain.Aggregates
{
    public class Person : Frameworks.Bases.Entity
    {
        #region [- ctor -]
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}