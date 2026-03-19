using System;

public class Dwarf : Character
{
	private static Random random = new();
   
    public string[] Magic {  get; set; }
    public MAGIC Handler { get; set; } = new MAGIC();

    public  Dwarf() :base()
	{
        Handler.DecideType();
        Magic = Handler.Magics;
    }
}
