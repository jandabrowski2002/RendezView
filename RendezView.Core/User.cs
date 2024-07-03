namespace RendezView.Core;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public Contract Contract { get; set; }
    public int ContractId { get; set; }

    public User()
    {
    }

    public User(
        int id,
        string name,
        string surname,
        string email,
        Contract contract)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        Contract = contract;
        ContractId = contract.Id;
    }
}