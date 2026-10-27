using Oop_CityLIbrarySystemProject.Entities;

namespace Oop_CityLIbrarySystemProject.Contract;

public interface IBorrowable
{
    bool IsAvailable();
    void Borrow(Member member, int loanDays = 14);
    decimal Return();
}
