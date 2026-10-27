using Oop_CityLIbrarySystemProject.Contract;
using Oop_CityLIbrarySystemProject.Enums;

namespace Oop_CityLIbrarySystemProject.Entities;

public class BookCopy : IDislayable, IBorrowable
{
    private string v1;
    private string v2;
    private CopyStatus available;
    private Book b1;
    private CopyStatus copyStatus;
    public string CopyId { get; set; } = null!;
    public String Condition { get; set; } = null!;
    public CopyStatus Status { get; set; }
    public Book Book { get; set; } = null!;
    public BorrowTransaction? ActiveBorrowTransaction { get; set; }

    #region Constractor
    public BookCopy(string copyId, string condition, CopyStatus copyStatus, Book book)
    {
        CopyId = copyId;
        Condition = condition;
        Status = copyStatus;
        Book = book;
    }
    #endregion

    #region IBorrowable
    public void Borrow(Member member, int loanDays = 14)
    {
        if (!IsAvailable())
        {
            throw new InvalidOperationException
                ($"Copy {CopyId} is not available (status = {Status})");
        }

        Status = CopyStatus.Borrowed;
        ActiveBorrowTransaction = new BorrowTransaction(member, this, loanDays);
        member.AddBorrowTransaction(ActiveBorrowTransaction);
    }



    public bool IsAvailable()
    => Status == CopyStatus.Available;

    public decimal Return()
    {
        if (ActiveBorrowTransaction == null)
            throw new InvalidOperationException
                ($"No ActiveBorrowTransaction Transaction For This Copy");
        if (Status != CopyStatus.Borrowed)
            throw new InvalidOperationException
                ($"Copy {CopyId} is not Currently Borrowed");

        ActiveBorrowTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
        decimal Fine = ActiveBorrowTransaction.CaculateFine();

        Status = CopyStatus.Available;
        ActiveBorrowTransaction = null;
        return Fine;
    }
    #endregion

    #region DisplayInformation
    public string DisplayInformation()
=> $"| Copy ID: {CopyId} | {Book?.Title ?? "N/A"} | Condition: {Condition} | Status: {Status} | Active Transaction: {(ActiveBorrowTransaction != null ? "Yes" : "No")} |";
    #endregion
}
