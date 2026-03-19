using System;
using System.Diagnostics.Eventing.Reader;

namespace NPC_Randomizer
{
    public partial class NPC : Form
    {
        public NPC()
        {
            InitializeComponent();
        }
        public MAGIC Handler { get; set; } = new MAGIC();
        private void Create_Click(object sender, EventArgs e)
        {
            int SelectedSpecies = Species.SelectedIndex;

            switch (SelectedSpecies)
            {
                case 0: //Beastfolk
                    Beastfolk beast = new Beastfolk();
                    NDisplay.Text = beast.Name;
                    TDisplay.Text = beast.Type;
                    GDisplay.Text = beast.Gender;
                    DDisplay.Text = beast.Demeanor;
                    ADisplay.Text = beast.Animal;
                    MDisplay.Text = Handler.DisplayTypes("", beast.Magic);
                    break;

                case 1: //Human
                    Human human = new Human();
                    NDisplay.Text = human.Name;
                    TDisplay.Text = "...";
                    GDisplay.Text = human.Gender;
                    DDisplay.Text = human.Demeanor;
                    ADisplay.Text = "...";
                    MDisplay.Text = Handler.DisplayTypes("", human.Magic);
                    break;
                case 2: //Elf
                    Elf elf = new Elf();
                    NDisplay.Text = elf.Name;
                    TDisplay.Text = elf.Type;
                    GDisplay.Text = elf.Gender;
                    DDisplay.Text = elf.Demeanor;
                    ADisplay.Text = "...";
                    MDisplay.Text = Handler.DisplayTypes("", elf.Magic);
                    break;

                case 3: //Tiefling
                    Tiefling tiefling = new Tiefling();
                    NDisplay.Text = tiefling.Name;
                    TDisplay.Text = tiefling.Type;
                    GDisplay.Text = tiefling.Gender;
                    DDisplay.Text = tiefling.Demeanor;
                    ADisplay.Text = "...";
                    MDisplay.Text = Handler.DisplayTypes("", tiefling.Magic);
                    break;
                case 4: //Pixie
                    Pixies pixie = new Pixies();
                    NDisplay.Text = pixie.Name;
                    TDisplay.Text = pixie.Type;
                    GDisplay.Text = pixie.Gender;
                    DDisplay.Text = pixie.Demeanor;
                    ADisplay.Text = "...";
                    MDisplay.Text = Handler.DisplayTypes("", pixie.Magic);
                    break;
                case 5: //Dwarf
                    Dwarf dwarf = new Dwarf();
                    NDisplay.Text = dwarf.Name;
                    TDisplay.Text = "...";
                    GDisplay.Text = dwarf.Gender;
                    DDisplay.Text = dwarf.Demeanor;
                    ADisplay.Text = "...";
                    MDisplay.Text = Handler.DisplayTypes("", dwarf.Magic);
                    break;
            }










        }

        
    }
}
