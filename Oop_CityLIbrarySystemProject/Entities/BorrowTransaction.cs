using Oop_CityLIbrarySystemProject.Contract;

namespace Oop_CityLIbrarySystemProject.Entities;

public class BorrowTransaction : IDislayable
{
    private static int _counter = 1000;
    private const decimal FinePerDay = 10m;
    public int TransactionId { get; set; }
    public Member Member { get; set; } = null!;
    public BookCopy BookCopy { get; set; } = null!;
    public DateOnly BorrowDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
    public BorrowTransaction(Member member, BookCopy bookCopy, int loanDays)
    {
        TransactionId = ++_counter;
        Member = member;
        BookCopy = bookCopy;
        BorrowDate = DateOnly.FromDateTime(DateTime.Today);
        DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
        ReturnDate = null;
    }
    public bool IsReturned() => ReturnDate.HasValue;
    public void MarkReturned(DateOnly returnDate)
        => ReturnDate = returnDate;
    public decimal CaculateFine()
    {
        DateOnly effective = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
        int overDueDay = effective.DayNumber - DueDate.DayNumber;
        return overDueDay > 0 ? overDueDay * FinePerDay : 0;
    }

    public string DisplayInformation()
    {
        bool isReturned = ReturnDate.HasValue;
        decimal fine = CaculateFine();

        return $"""
           ── Transaction #{TransactionId} ──────────────
           Book     : {BookCopy?.Book?.Title ?? "N/A"}
           Copy ID  : {BookCopy?.CopyId ?? "N/A"}
           Borrowed : {BorrowDate:dd/MM/yyyy}
           Due      : {DueDate:dd/MM/yyyy}
           Returned : {(isReturned ? ReturnDate!.Value.ToString("dd/MM/yyyy") : "Not returned yet")}
           Status   : {(isReturned ? "Completed" : "Active")}
           Fine     : {(fine > 0 ? $"{fine:C}" : "None")}
           """;
    }
}
