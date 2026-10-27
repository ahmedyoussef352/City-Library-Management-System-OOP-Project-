using System.Text;

namespace Oop_CityLIbrarySystemProject.Entities;

public class Member : User
{
    private static int _counter = 1;
    public string Id { get; private set; }
    public DateOnly? DateOfBirth { get; private set; }
    public string? Email { get; private set; }
    public DateOnly MemberShipDate { get; private set; }
    public readonly List<BorrowTransaction> _borrowTransaction = [];
    public IReadOnlyList<BorrowTransaction> BorrowTransactions => _borrowTransaction;

    #region Constractors
    public Member(DateOnly? dateOfBirth, string? email,
        DateOnly memberShipDate, string name, string phone) : base(name, phone)
    {
        Id = $"MEM-{_counter++:D3}";
        Email = email;
        MemberShipDate = memberShipDate;
    }
    public Member(string name, string phone) :
        this(null, null, DateOnly.FromDateTime(DateTime.Today), name, phone)
    {

    }
    #endregion

    #region Add Borrow Transaction
    public void AddBorrowTransaction(BorrowTransaction transaction)
        => _borrowTransaction.Add(transaction);

    public string GetTransactionHistory()
    {
        if (_borrowTransaction.Count == 0)
        {
            return "No Transaction Count";
        }
        var sp = new StringBuilder();
        foreach (var transaction in BorrowTransactions)
        {
            sp.Append(transaction.DisplayInformation());
        }
        return sp.ToString();
    }
    #endregion

    #region DisplayInformation
    public override string DisplayInformation()
    => $"""
       Member ID: {Id}
       Name: {Name}
       Membership Date: {MemberShipDate:yyyy-MM-dd}
       Phone: {Phone}
       Email: {Email ?? "N/A"}
       Date of Birth: {(DateOfBirth.HasValue ? DateOfBirth.Value.ToString("yyyy-MM-dd") : "N/A")}
       Total Borrow Transactions: {_borrowTransaction.Count}
       """;
    #endregion
}

