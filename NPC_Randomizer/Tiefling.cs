using System;

public class Tiefling : Character
{
    private static string[] types = new string[]
    {
        "Desert","Forrest","Dark","Light","Ocean"
    };
    private static readonly string[] SpecialMagics = new string[]
    {
        "Sand",
        "Plant",
        "Water",
        "Light",
        "Dark"

    };



    //Random instance for generating random values
    private static readonly Random random = new();

    //Properties
    public string Type { get; set; }
    public string[] Magic { get; set; }
    public string SpecialMagic { get; set; }

    public MAGIC Handler { get; set; } = new MAGIC();

    public Tiefling() : base()
	{
        //Generate the type
        int index = random.Next(types.Length);
        Type = types[index];

        //Assigns the special magic based on the type
        switch (Type)
        {
            case "Desert":
                SpecialMagic = SpecialMagics[0];
                break;
            case "Forrest":
                SpecialMagic = SpecialMagics[1];
                break;
            case "Ocean":
                SpecialMagic = SpecialMagics[2];
                break;
            case "Dark":
                SpecialMagic = SpecialMagics[3];
                break;
            case "Light":
                SpecialMagic = SpecialMagics[4];
                break;
            default:
                SpecialMagic = "None";
                break;

        }

        //Decides the magic
        var magicList = new List<string>();

        Handler.DecideTypes();
        magicList.Add(SpecialMagic);
        magicList.AddRange(Handler.Magics);

        if (Type == "Dark" && magicList.Contains("Light"))
            magicList.Remove("Light"); 
        else if (Type == "Light" && magicList.Contains("Dark"))
            magicList.Remove("Dark");


        Magic = magicList.ToArray();

        

    }
}
