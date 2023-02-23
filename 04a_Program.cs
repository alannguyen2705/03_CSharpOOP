#region Shallow Copy

using System.Text;

Console.WriteLine("-----Shallow Copy-----");
Book book1 = new("C# Basic", "Mr.4", "0938527375", "978-0985580155", new(2017, 1, 1));
Book book2 = book1;
Console.WriteLine("Before");
Console.WriteLine(book1);
Console.WriteLine(book2);

book2.Title = "C# Object Oriented Programing";
Console.WriteLine("After: ");
Console.WriteLine(book1);
Console.WriteLine(book2);
#endregion


#region Deep copy - Version 1

Console.WriteLine("-----Deep Copy - Version 1-----");
Book book3 = new("Ong gia va bien ca", "Ernest Hemingway", "0798384666", "978-0985580156", new(1952, 1, 1));
Book book4 = new(book3.Title, book3.Authors, book3.ISBN10, book3.ISBN13, book3.PublicationDate);

Console.WriteLine("Before");
Console.WriteLine(book3);
Console.WriteLine(book4);

Console.WriteLine("After");
book4.Title = "Rung Na Uy";
Console.WriteLine(book3);
Console.WriteLine(book4);
#endregion

#region Deep Copy - Version 2

Console.WriteLine("\n-----Deep Copy - Version 2------");
Book book5 = new("Soi Xich", "Le Kieu Nhu", "0885546554", "978-0965580156", new(2010, 03, 22));
Book book6 = book5.Clone();

Console.WriteLine("Before");
Console.WriteLine(book5);
Console.WriteLine(book6);

Console.WriteLine("After");
book6.Title = "Day Xich";
Console.WriteLine(book5);
Console.WriteLine(book6);

#endregion

class Book
{
    #region Constructors
    public Book() { }
    public Book(string title, string authors, string isbn10, string isbn13, DateTime publicationDate)
        => (Title, Authors, ISBN10, ISBN13, PublicationDate) = (title, authors, isbn10, isbn13, publicationDate);
    #endregion

    #region Properties
    public string Title { get; set; }
    public string Authors { get; set; }
    public string ISBN10 { get; set; }
    public string ISBN13 { get; set; }
    public DateTime PublicationDate { get; set; }
    #endregion

    #region Methods
    public override string ToString()
        => new StringBuilder()
        .AppendLine($"Title: {Title}")
        .AppendLine($"Authors: {Authors}")
        .AppendLine($"ISBN10: {ISBN10}")
        .AppendLine($"ISBN13: {ISBN13}")
        .AppendLine($"Publication Date: {PublicationDate}")
        .ToString();

    public Book Clone() => (Book)MemberwiseClone();
    #endregion
}