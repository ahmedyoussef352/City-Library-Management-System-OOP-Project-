using Oop_CityLIbrarySystemProject.Entities;
using Oop_CityLIbrarySystemProject.Enums;

namespace Oop_CityLIbrarySystemProject.Data;

public static class DataSeeder
{
    public static LibraryBranch Seed()
    {
        Librarian manager = new Librarian(
            id: "LIB-01", name: "Sara Ahmed", phone: "01012345678",
            salary: 8500m,
            hireDate: new DateOnly(2019, 3, 15));

        LibraryBranch branch = new(
            "BR-01", "City Library - Nasr City Branch", "15 Nasr Road",
            "01012345678", "Sat-Thu: 09:00 AM - 09:00 PM", manager);

        branch.RegisterMember(
    memberShipDate: new DateOnly(2023, 1, 20),
    name: "Ahmed Kamal",
    dateOfBirth: new DateOnly(1998, 5, 10),
    email: "ahmed@email.com",
    phone: "01098765432");

        branch.RegisterMember(
            memberShipDate: new DateOnly(2024, 3, 5),
            name: "Nour Hassan",
            dateOfBirth: new DateOnly(2001, 8, 22),
            email: "nour@email.com",
            phone: "01155556677");

        //  branch.RegisterMember("Omar Samir", "01234567890");

        Book b1 = new("978-0-13-468599-1", "Clean Code",
            "Robert C. Martin", "Software Engineering", 2008);

        Book b2 = new("978-0-13-235088-4", "The Pragmatic Programmer",
            "David Thomas", "Software Engineering", 1999);

        // ...
        Book b3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird");

        BookCopy c1 = new BookCopy("COPY-001", "Good", CopyStatus.Available, b1);
        BookCopy c2 = new BookCopy("COPY-002", "Fair", CopyStatus.Available, b1);
        BookCopy c3 = new BookCopy("COPY-003", "Excellent", CopyStatus.Available, b2);
        BookCopy c4 = new BookCopy("COPY-004", "Good", CopyStatus.Available, b3);

        branch.AddBookCopy(c1);
        branch.AddBookCopy(c2);
        branch.AddBookCopy(c3);
        branch.AddBookCopy(c4);

        return branch;
    }
}
