using System;

public class Elf : Character
{
    private static string[] types = new string[]
    {
        "High Elf", "Low Elf"
    };


    //Random instance for generating random values
    private static readonly Random random = new();

    //Properties
    public string Type { get; set; }
    public string[] Magic { get; set; }
    public MAGIC Handler { get; set; } = new MAGIC();

    public Elf() : base()
    {
       int index = random.Next(types.Length);
       Type = types[index];

        Handler.DecideTypes();
        Magic = Handler.Magics;
    }
}
