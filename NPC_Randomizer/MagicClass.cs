using System;
using System.Security.Cryptography;

public class MAGIC
{
    private static readonly string[] MagicTypes = new string[]
    {
        "Fire",
        "Water",
        "Earth",
        "Air",
        "Dark",
        "Light"

    };
    private static int[] D20 = new int[]
        {
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
        };

    public static Random random = new Random();

    public string[] Magics { get; set; }

    public MAGIC()
    {
        DecideTypes();
    }

    public void DecideTypes()
	{
        var MagicList = new List<string>();
        bool hasDark = false;
        bool hasLight = false;


        for (int i = 0; i < MagicTypes.Length; i++)
        {
            int DiceRoll = random.Next(1, 21);

            if (DiceRoll >= 15)
            {
                string magicType = MagicTypes[i];

                if (magicType == "Dark" && hasLight)
                    continue; //If Light is already present, it will just skip to the next iteration
                if (magicType == "Light" && hasDark)
                    continue; //If Dark is already present, it will just skip to the next iteration

                MagicList.Add(magicType);

                if (magicType == "Dark")
                    hasDark = true;
                if (magicType == "Light")
                    hasLight = true;
            }

        }
        Magics = MagicList.ToArray();
    }
    public void DecideType()
    {
        var MagicList = new List<string>();
        for (int i = 0; i < MagicTypes.Length; i++)
        {
            int DiceRoll = random.Next(1, 21);

            if (DiceRoll >= 15)
            {
                MagicList.Add(MagicTypes[i]);
                break;

            }

        }
        Magics = MagicList.ToArray();
    }

    public string DisplayTypes(string Display, string[] magicList)
    {
        if (magicList != null && magicList.Length > 0)
            Display = string.Join(", ", magicList);
        else
            Display = "None";

        return Display;
    }
    
}
