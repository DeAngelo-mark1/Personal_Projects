using System;

public class Pixies : Character
{   //Fields
    private string[] FlowerTypes = new string[]
    {
        // Common Garden Flowers
        "AfricanDaisy",
        "Alyssum",
        "Amaryllis",
        "Aster",
        "Begonia",
        "BlackEyedSusan",
        "Calendula",
        "Carnation",
        "Chrysanthemum",
        "Cosmos",
        "Daffodil",
        "Dahlia",
        "Delphinium",
        "Freesia",
        "Gardenia",
        "Geranium",
        "Gladiolus",
        "Hibiscus",
        "Hyacinth",
        "Impatiens",
        "Iris",
        "Lavender",
        "Lilac",
        "Lily",
        "Marigold",
        "MorningGlory",
        "Nasturtium",
        "Pansy",
        "Peony",
        "Petunia",
        "Phlox",
        "Rose",
        "Snapdragon",
        "Sunflower",
        "SweetPea",
        "Tulip",
        "Zinnia",

        // Wildflowers
        "Bluebell",
        "Buttercup",
        "Clover",
        "Cornflower",
        "Dandelion",
        "Fireweed",
        "Foxglove",
        "Goldenrod",
        "Lupine",
        "Milkweed",
        "Poppy",
        "QueenAnnesLace",
        "WildIndigo",
        "Yarrow",

        // Tropical/Exotic Flowers
        "Anthurium",
        "BirdOfParadise",
        "Bougainvillea",
        "Frangipani",
        "Heliconia",
        "Lotus",
        "Orchid",
        "Protea",
        "WaterLily",

        // Bulbous and Perennial Flowers
        "Agapanthus",
        "Allium",
        "Anemone",
        "CannaLily",
        "Columbine",
        "Crocus",
        "Cyclamen",
        "Daylily",
        "Echinacea",
        "Fuchsia",
        "Hellebore",
        "Hosta",
        "Liatris",
        "Salvia",
        "Verbena",

        // Additional Flowers
        "Azalea",
        "Camellia",
        "Clematis",
        "Dianthus",
        "ForgetMeNot",
        "Hollyhock",
        "Hydrangea",
        "Jasmine",
        "Magnolia",
        "Primrose",
        "Ranunculus",
        "Rhododendron",
        "Scabiosa",
        "Sedum",
        "Snowdrop",
        "Vinca",
        "Violet",
        "Wisteria"
    };

    //Random instance for generating random values
    private static readonly Random random = new();

    //Properties
    public string Type {  get; set; }
    public string[] Magic {  get; set; }
    public MAGIC Handler { get; set; } = new MAGIC();

    public Pixies() : base()
	{
        int typeIndex = random.Next(FlowerTypes.Length);
        Type = FlowerTypes[typeIndex];

        var magicList = new List<string>();
        Handler.DecideTypes();

        magicList.AddRange(Handler.Magics);
        magicList.Add("Plant");
        Magic = magicList.ToArray();
    }
}
