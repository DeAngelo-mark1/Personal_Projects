using System;
using System.Runtime.CompilerServices;

public class Character
{

    private static readonly string[] Demeanors = new string[]
    {
        "Friendly", "Respectful", "Empathetic", "Encouraging", "Warm", "Cooperative", "Appreciative", "Professional", "Indifferent", "Reserved", "Cautious", "Observant", "Hostile", "Condescending", "Dismissive", "Sarcastic", "Arrogant", "Cold", "Suspicious", "PassiveAggressive", "Flirtatious", "Authoritative", "Playful", "Submissive", "Inquisitive"
    };
    private static readonly string[] MaleNames = new string[]
    {
        "Aiden",
        "Balthazar",
        "Caleb",
        "Draven",
        "Elias",
        "Finn",
        "Gavriel",
        "Jaxon",
        "Kael",
        "Liam",
        "Mordecai",
        "Nolan",
        "Rorik",
        "Silas",
        "Thalion",
        "Zane",
        "Aric",
        "Brendan",
        "Corvus",
        "Darian",
        "Ethan",
        "Fenris",
        "Gideon",
        "Isaiah",
        "Jareth",
        "Kian",
        "Lorcan",
        "Micah",
        "Oberon",
        "Quinn",
        "Rune",
        "Soren",
        "Talon",
        "Uriah",
        "Valthor",
        "Wyatt"
    };
    private static readonly string[] FemaleNames = new string[]
    {
        "Amelia",
        "Aeloria",
        "Brianna",
        "Celeste",
        "Delphine",
        "Elara",
        "Fiona",
        "Giselle",
        "Hannah",
        "Isolde",
        "Jessa",
        "Kiera",
        "Liora",
        "Maya",
        "Nyx",
        "Olivia",
        "Ravenna",
        "Seraphina",
        "Tara",
        "Veyra",
        "Willow",
        "Zara",
        "Aria",
        "Belladonna",
        "Clara",
        "Elvira",
        "Freya",
        "Ivy",
        "Kaia",
        "Lysandra",
        "Mira",
        "Niamh",
        "Ophelia",
        "Rhea",
        "Sylvia",
        "Ysmeine"
    };

    public string Demeanor { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    private static Random Random = new();

    public Character()
    {
        Demeanor = Demeanors[Random.Next(Demeanors.Length)];

        //result = condition ? valueIfTrue : valueIfFalse;
        Gender = Random.Next(2) == 0 ? "Male" : "Female";
        Name = Gender == "Male"
            ? MaleNames[Random.Next(MaleNames.Length)]
            : FemaleNames[Random.Next(FemaleNames.Length)];
    }
    

   

    
    public Character(string Demeanor, string Name, string Gender)
	{
		this.Demeanor = Demeanor;
        this.Name = Name;
        this.Gender = Gender;
    }

    
   
}
