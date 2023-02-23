
#region Deep Copy - Version 1

using System.Text;
using System.Text.Json;

Console.WriteLine("-----Deep Copy - Version 1-----");
CardDetail viettelCard = new(100123, "Viettel", new("10000234567856"), new("012345697854632"));
CardDetail viettelCard2 = viettelCard.Clone();

Console.WriteLine("before");
Console.WriteLine(viettelCard);
Console.WriteLine(viettelCard2);

Console.WriteLine("\nafter");
viettelCard2.Id = 100789;
viettelCard2.Name = "Mobifone";
viettelCard2.Seri.Seri = "0974546546889123";
viettelCard2.Code.Code = "0123145465564";
Console.WriteLine(viettelCard);
Console.WriteLine(viettelCard2);
#endregion

#region Deep Copy - Version 2
Console.WriteLine("----Deep Copy - Version 2");
CardDetail viettelcard3 = new(3, "viettel", new("10000234567856"), new("012345697854632"));

string card = JsonSerializer.Serialize(viettelcard3, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText(@"card.json", card, Encoding.UTF8);
CardDetail viettcard4 = JsonSerializer.Deserialize<CardDetail>(card);

Console.WriteLine("before");
Console.WriteLine(viettelcard3);
Console.WriteLine(viettcard4);

Console.WriteLine("\nafter");
viettcard4.Id = 4;
viettcard4.Name = "Mobifone";
viettcard4.Seri.Seri = "0974546546889123";
viettcard4.Code.Code = "0123145465564";
Console.WriteLine(viettelcard3);
Console.WriteLine(viettcard4);
#endregion

class Serial
{
    //Constructors
    public Serial(string seri) => Seri = seri; 
    //Properties
    public string Seri { get; set; }
    //Methods
    public Serial Clone() => (Serial)MemberwiseClone();
    public override string ToString() => $"Serial: {Seri}";
}


class CodeNumber
{
    //Constructors
    public CodeNumber(string code) => Code = code;
    //Properties
    public string Code { get; set; }
    //Methods
    public CodeNumber Clone() => (CodeNumber)MemberwiseClone();
    public override string ToString() => $"Code number's: {Code}";
}

class CardDetail
{
    //Constructors
    public CardDetail(int id, string name, Serial seri, CodeNumber code) => (Id, Name, Seri, Code) = (id, name, seri, code);
    //Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public Serial Seri { get; set; }
    public CodeNumber Code { get; set; }
    //Methods
    public CardDetail Clone()
    {
        CardDetail viettelCard = (CardDetail)MemberwiseClone();
        viettelCard.Seri = Seri.Clone();
        viettelCard.Code = Code.Clone();
        return viettelCard;
    }
    public override string ToString() => $"Info's card: {Id}, {Name}, {Seri}, {Code}";
}
