namespace OnlineStore.Application.Contract.Bases.Dtos
{
    public class PersonBaseDto : Abstracts.Dtos.IPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}