namespace E_School_Diary.Data.Contracts
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }
    }
}
