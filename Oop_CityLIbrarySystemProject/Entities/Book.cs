using Oop_CityLIbrarySystemProject.Contract;

namespace Oop_CityLIbrarySystemProject.Entities;

public class Book : IDislayable
{
    public string ISBN { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string AuthorName { get; private set; } = null!;
    public string Category { get; private set; } = null!;
    public int PublicationYear { get; private set; }

    #region Constractor
    public Book(string ISBN, string title,
      string authorName, string category,
      int publicationYear)
    {
        this.ISBN = ISBN;
        Title = title;
        AuthorName = authorName;
        Category = category;
        PublicationYear = publicationYear;
    }
    public Book(string ISBN, string title
        ) : this(ISBN, title, "unknown", "general", 0)
    { }
    #endregion

    #region DisplayInformation
    public string DisplayInformation()
    => $"""
       Book Details:
       - ISBN: {ISBN}
       - Title: {Title}
       - Author: {AuthorName}
       - Category: {Category}
       - Publication Year: {(PublicationYear > 0 ? PublicationYear.ToString() : "N/A")}
       """;
    #endregion
}
