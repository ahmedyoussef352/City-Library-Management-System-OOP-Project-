using Oop_CityLIbrarySystemProject.Contract;
using Oop_CityLIbrarySystemProject.Extensions;

namespace Oop_CityLIbrarySystemProject.Entities;

public class LibraryBranch : IDislayable
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string OpeningHours { get; set; } = null!;
    public Librarian Manager { get; private set; } = null!;
    private List<Member> _members = [];
    private List<BookCopy> _bookCopies = [];
    public IReadOnlyList<Member> members => _members;
    public IReadOnlyList<BookCopy> BookCopies => _bookCopies;
    public LibraryBranch(string id, string name, string address,
        string phone, string openingHours, Librarian manager)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
        OpeningHours = openingHours;
        Manager = manager;
    }

    // Return All User
    public IReadOnlyList<User> Users
    {
        get
        {
            List<User> users = [];
            users.Add(Manager);
            users.AddRange(members);
            return users;
        }
    }

    // Add Memebr
    public Member RegisterMember(DateOnly? memberShipDate, string name, DateOnly? dateOfBirth, string? email, string phone)
    {
        var member = new Member(dateOfBirth: dateOfBirth, email: email,
            memberShipDate: memberShipDate ?? DateOnly.FromDateTime(DateTime.Today), name: name, phone: phone);
        _members.Add(member);
        return member;
    }

    //find member
    public Member FindMemberById(string id)
    {
        string normalized = id.NormalizedId();
        foreach (var member in members)
        {
            if (member.Id.Equals(normalized, StringComparison.OrdinalIgnoreCase))
                return member;
        }
        throw new InvalidOperationException("Member Not Found");
    }

    public void AddBookCopy(BookCopy bookCopy)
        => _bookCopies.Add(bookCopy);

    //find Book Copy
    public BookCopy FindCopyById(string id)
    {
        string normalized = id.NormalizedId();
        foreach (var copy in BookCopies)
        {
            if (copy.CopyId.Equals(normalized, StringComparison.OrdinalIgnoreCase))
                return copy;
        }
        throw new InvalidOperationException("BookCopy Not Found");
    }
    //Get Available BookCopy
    public List<BookCopy> GetAvaliableBookCopy()
    {
        List<BookCopy> AvaliableBookCopy = [];
        foreach (var item in BookCopies)
        {
            if (item.IsAvailable())
                AvaliableBookCopy.Add(item);
        }
        return AvaliableBookCopy;
    }
    public string DisplayInformation()
=> $"""
   ID            : {Id}
   Name          : {Name}
   Address       : {Address}
   Phone         : {Phone}
   Opening Hours : {OpeningHours}
   Manager       : {Manager?.Name ?? "N/A"}
   Total Members : {_members.Count}
   Total Book Copies : {_bookCopies.Count}
   """;
}
