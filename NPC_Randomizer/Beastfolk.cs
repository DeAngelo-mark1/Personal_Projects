using System;

public class Beastfolk : Character
{
    //Fields
	private static string[] types = new string[]
	{
		"More Human","More Beast","Shapeshifter"
	};


    private static readonly string[] Animals = new string[]
    {
        // Mammals
        "AfricanElephant",
        "AmurLeopard",
        "ArcticFox",
        "BengalTiger",
        "BlueWhale",
        "Cheetah",
        "Chimpanzee",
        "CloudedLeopard",
        "Dolphin",
        "GiantPanda",
        "Giraffe",
        "GrayWolf",
        "GrizzlyBear",
        "Hippopotamus",
        "Jaguar",
        "Kangaroo",
        "Koala",
        "Lion",
        "MountainGorilla",
        "Narwhal",
        "Orangutan",
        "PolarBear",
        "RedPanda",
        "Rhinoceros",
        "SnowLeopard",
        "SpermWhale",
        "TasmanianDevil",
        "Wolverine",
        "Zebra",

        // Birds
        "Albatross",
        "BaldEagle",
        "BarnOwl",
        "BlueJay",
        "Condor",
        "Emu",
        "Flamingo",
        "HarpyEagle",
        "Hummingbird",
        "KingPenguin",
        "Macaw",
        "Ostrich",
        "Peacock",
        "PeregrineFalcon",
        "Puffin",
        "ScarletIbis",
        "Toucan",

        // Reptiles
        "Alligator",
        "Anaconda",
        "Chameleon",
        "Cobra",
        "Crocodile",
        "GilaMonster",
        "GreenIguana",
        "KomodoDragon",
        "Rattlesnake",
        "SeaTurtle",
        "ThornyDevil",
        "Tuatara",

        // Amphibians
        "Axolotl",
        "Bullfrog",
        "DartFrog",
        "Salamander",
        "TreeFrog",

        // Fish
        "Angelfish",
        "Barracuda",
        "Clownfish",
        "GreatWhiteShark",
        "MantaRay",
        "MorayEel",
        "Seahorse",
        "Stingray",
        "Swordfish",

        // Invertebrates
        "BlueRingedOctopus",
        "Coral",
        "Cuttlefish",
        "GiantSquid",
        "HoneyBee",
        "Jellyfish",
        "LeafInsect",
        "MantisShrimp",
        "MonarchButterfly",
        "Scorpion",
        "SeaAnemone",
        "Tarantula",

        // Additional Animals
        "AfricanWildDog",
        "Armadillo",
        "Binturong",
        "Capybara",
        "Dugong",
        "Echidna",
        "FennecFox",
        "Kinkajou",
        "Lemur",
        "Manatee",
        "Meerkat",
        "Okapi",
        "Pangolin",
        "Platypus",
        "Quokka",
        "Sloth",
        "Tapir",
        "Wallaby"
    };

    //Random instance for generating random values
    private static readonly Random random = new();

    //Properties
    public string Type { get; set; }
	public string Animal { get; set; }
    public string[] Magic { get; set; } 

    public MAGIC Handler { get; set; } = new MAGIC();



    public Beastfolk() : base() //This is how you call the base class constructor	
    {
        //Generate the type
        int index = random.Next(1, 21);
		if (index <= 10)
		{
			Type = types[0];
		}
		else if ( index <= 19)
		{
			Type = types[1];
		}
		else
		{
			Type = types[2];
		}

        //Generate the animal
        index = random.Next(Animals.Length);
        Animal = Animals[index];

        //Decides the magic
        Handler.DecideTypes();
        Magic = Handler.Magics;
    }
}
