
#region Deep Copy - Version 1

using System.Text;
using System.Text.Json;

Console.WriteLine("-----Deep Copy - Version 1-----");
Family family1 = new(1, new("Nhung"), new("Linh"));
Family family2 = family1.Clone();

Console.WriteLine("before");
Console.WriteLine(family1);
Console.WriteLine(family2);

Console.WriteLine("\nafter");
family2.Id = 2;
family2.Husband.Name = "Lju";
family2.Wife.Name = "ingl";
Console.WriteLine(family1);
Console.WriteLine(family2);
#endregion

#region Deep Copy - Version 2
Console.WriteLine("----Deep Copy - Version 2");
Family family3 = new(3, new("new3a"), new("new3b"));

string data = JsonSerializer.Serialize(family3, new JsonSerializerOptions {WriteIndented = true});
File.WriteAllText(@"data.json", data, Encoding.UTF8);
Family family4 = JsonSerializer.Deserialize<Family>(data);

Console.WriteLine("before");
Console.WriteLine(family3);
Console.WriteLine(family4);

Console.WriteLine("\nafter");
family4.Id = 4;
family4.Husband.Name = "new4a";
family4.Wife.Name = "new4b";
Console.WriteLine(family3);
Console.WriteLine(family4);
#endregion

class Husband
{
    //Constructors
    public Husband(string name) => Name = name;
    //Properties
    public string Name { get; set; }
    public Husband Clone() => (Husband)MemberwiseClone();
    public override string ToString() => $"Husband: {Name}";
}

class Wife
{
    //Constructors
    public Wife(string name) => Name = name;
    //Properties
    public string Name { get; set; }
    //Methods
    public Wife Clone() => (Wife)MemberwiseClone();
    public override string ToString() => $"Wife: {Name}";
}

class Family
{
    //Constructors
    public Family(int id, Husband husband, Wife wife) => (Id, Husband, Wife) = (id, husband, wife);
    //Properties
    public int Id { get; set; }
    public Husband Husband { get; set; }
    public Wife Wife { get; set; }
    //Methods
    public Family Clone()
    {
        Family family = (Family)MemberwiseClone();
        family.Husband = Husband.Clone();
        family.Wife = Wife.Clone();
        return family;
    }
    public override string ToString() => $"Family: {Id}, {Husband}, {Wife}";
}