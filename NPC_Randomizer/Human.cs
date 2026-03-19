using System;
using System.Reflection.PortableExecutable;

public class Human : Character
{
    //Properties
    public string[] Magic { get; set; }
    public MAGIC Handler { get; set; } = new MAGIC();
    public Human() : base()
    {
        Handler.DecideTypes();
        Magic = Handler.Magics;
    }
	
}
