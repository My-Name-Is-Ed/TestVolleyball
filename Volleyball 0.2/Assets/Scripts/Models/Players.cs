public class Players
{
    public static Player Dahaka = new Player("Dahaka", 88, 88, 88);
    public static Player OmniMan = new Player("OmniMan", 100, 100, 100);
    public static Player Pudge = new Player("Pudginister", 30, 30, 30);
    public static Player Sokol = new Player("Sokol", 90, 60, 100);
    public static Player Vlad = new Player("Vlad", 85, 85, 50);
    public static Player Wick = new Player("Wick", 95, 86, 80);

    static public Team Boys = new Team()
    {
        NameTeam = "Boys",
        Players = new Player[]
        {
            Dahaka, OmniMan, Pudge, Sokol, Vlad, Wick
        }
    };

    public static Player TD = new Player("Toody", 100, 100, 50);
    public static Player Stonk = new Player("Stonk", 70, 90, 100);
    public static Player SmallFin = new Player("SmallFin", 50, 50, 50);
    public static Player Nikky = new Player("Nikky", 70, 85, 100);
    public static Player Hamster = new Player("Hamster", 1, 1000, 1000);
    public static Player Woody = new Player("Woody", 80, 70, 50);

    static public Team Murlocs = new Team()
    {
        NameTeam = "Murlocs",
        Players = new Player[]
        {
            SmallFin, Stonk, Woody, Nikky, Hamster, TD
        }
    };

    public static Player Integra = new Player("Integra", 100, 80, 20);
    public static Player Albedo = new Player("Albedo", 90, 70, 70);
    public static Player Lust = new Player("Lust", 60, 80, 77);
    public static Player Ruby = new Player("Ruby", 90, 90, 90);
    public static Player Shikamaru = new Player("Shikamaru", 70, 80, 90);
    public static Player Kek = new Player("Kek", 100, 0, 0);

    static public Team Anime = new Team()
    {
        NameTeam = "Anime",
        Players = new Player[]
        {
            Ruby, Albedo, Lust, Integra, Shikamaru, Kek
        }
    };
}