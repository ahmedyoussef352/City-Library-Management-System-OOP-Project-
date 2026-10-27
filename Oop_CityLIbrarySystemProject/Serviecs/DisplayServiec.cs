using Oop_CityLIbrarySystemProject.Entities;
using Oop_CityLIbrarySystemProject.Helper;

namespace Oop_CityLIbrarySystemProject.Serviecs;

public class DisplayService
{
    public void ShowBranchInfo(LibraryBranch libraryBranch)
    {
        ThemeHelper.PrintHeader("Library Branch Info");
        Console.WriteLine(libraryBranch.DisplayInformation());
    }

    public void ShowAllUsers(LibraryBranch libraryBranch)
    {
        ThemeHelper.PrintHeader("All Registered Users");
        IReadOnlyList<User> users = libraryBranch.Users;
        foreach (var user in users)
        {
            string header = user is Librarian ? "Librarian Profile" : "Member Profile";
            ThemeHelper.PrintHeader(header);
            Console.WriteLine(user.DisplayInformation());
        }
    }

    public void ShowAvailableCopies(LibraryBranch branch)
    {
        ThemeHelper.PrintHeader("AVAILABLE BOOK COPIES");

        List<BookCopy> available = branch.GetAvaliableBookCopy();

        if (available.Count == 0)
        {
            ThemeHelper.PrintWarning("No available book copies found.");
            return;
        }

        for (int i = 0; i < available.Count; i++)
        {
            Console.WriteLine(available[i].DisplayInformation());
        }
    }

    public void ShowAllCopies(LibraryBranch branch)
    {
        ThemeHelper.PrintHeader("ALL BOOK COPIES");

        if (branch.BookCopies.Count == 0)
        {
            ThemeHelper.PrintWarning("No book copies found.");
            return;
        }

        for (int i = 0; i < branch.BookCopies.Count; i++)
        {
            Console.WriteLine(branch.BookCopies[i].DisplayInformation());
        }
    }

    public void ShowMemberHistory(Member member)
    {
        ThemeHelper.PrintSectionTitle($"Borrowing History for {member.Name}:");
        // Console.WriteLine(member.GetTransactionHistory());
    }
    public void ShowBorrowSuccess(BookCopy copy, Member member)
    {
        ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}]: {copy.Book.Title} borrowed successfully by {member.Name}.");
    }

    public void ShowReturnSuccess(BookCopy copy, decimal fine)
    {
        ThemeHelper.PrintSuccess
        (
            $"Copy [{copy.CopyId}]: {copy.Book.Title} returned."
        );

        if (fine > 0)
            ThemeHelper.PrintWarning($"Late return fine: {fine:F2} EGP");
        else
            ThemeHelper.PrintSuccess("Returned on time. No fine.");
    }

    public void ShowRegistrationSuccess(Member member)
    {
        ThemeHelper.PrintSuccess
        (
            $"Member: {member.Name} - [{member.Id}] registered successfully."
        );
    }

    public void ShowAddCopySuccess(BookCopy copy)
    {
        ThemeHelper.PrintSuccess
        (
            $"Copy [{copy.CopyId}] - {copy.Book.Title}: added."
        );
    }
}
