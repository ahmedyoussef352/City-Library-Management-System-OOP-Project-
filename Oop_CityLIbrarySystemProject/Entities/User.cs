using Oop_CityLIbrarySystemProject.Contract;

namespace Oop_CityLIbrarySystemProject.Entities;

public abstract class User(string name, string phone) : IDislayable
{
    public string Name { get; protected set; } = name;
    public string Phone { get; protected set; } = phone;

    public abstract string DisplayInformation();

}
