using Oop_CityLIbrarySystemProject.Entities;
using Oop_CityLIbrarySystemProject.Extensions;
using Oop_CityLIbrarySystemProject.Helper;

namespace Oop_CityLIbrarySystemProject.Serviecs;

public class LibraryService(LibraryBranch libraryBranch, DisplayService displayService)
{
    public void HandleBorrow()
    {
        string memberId = ThemeHelper.Prompt("Member Id").NormalizedId();
        var member = libraryBranch.FindMemberById(memberId);
        displayService.ShowAvailableCopies(libraryBranch);

        string copyId = ThemeHelper.Prompt("Copy Id to borrow").NormalizedId();
        var bookCopy = libraryBranch.FindCopyById(copyId);

        bookCopy.Borrow(member);
        displayService.ShowBorrowSuccess(bookCopy, member);
    }
    public void HandleReturn()
    {
        string copyId = ThemeHelper.Prompt("Copy ID to return").NormalizedId();
        BookCopy copy = libraryBranch.FindCopyById(copyId);

        decimal fine = copy.Return();
        displayService.ShowReturnSuccess(copy, fine);
    }

    public void HandleHistory()
    {
        string memberId = ThemeHelper.Prompt("Member ID").NormalizedId();
        Member member = libraryBranch.FindMemberById(memberId);

        displayService.ShowMemberHistory(member);
    }

    public void HandleRegisterMember()
    {
        string name = ThemeHelper.Prompt("Full Name");

        string phone = ThemeHelper.Prompt("Phone Number");

        if (!phone.ContainDigit())
        {
            throw new InvalidOperationException(
                "Phone number must contain at least one digit."
            );
        }

        string email = ThemeHelper.Prompt("Email Address");

        if (!email.IsValidEmail())
        {
            throw new InvalidOperationException(
                "Invalid email format. Must contain '@' and domain."
            );
        }

        Member member = libraryBranch.RegisterMember(
            memberShipDate: DateOnly.FromDateTime(DateTime.Today),
            name: name,
            dateOfBirth: null,
            email: email,
            phone: phone
        );

        displayService.ShowRegistrationSuccess(member);
    }

}
