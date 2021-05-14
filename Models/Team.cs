namespace GenshinBuildsApi.Models
{
    public class Team
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public Caracter Caracter1 { get; set; }
        public Caracter Caracter2 { get; set; }
        public Caracter Caracter3 { get; set; }
        public Caracter Caracter4 { get; set; }

        public Weapon Weapon1 { get; set; }
        public Weapon Weapon2 { get; set; }
        public Weapon Weapon3 { get; set; }
        public Weapon Weapon4 { get; set; }
    }
}