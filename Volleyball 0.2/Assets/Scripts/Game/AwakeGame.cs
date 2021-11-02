using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeGame : MonoBehaviour
{

    public Sprite Dahaka2D;
    public Sprite OmniMan2D;
    public Sprite Pudge2D;
    public Sprite Sokol2D;
    public Sprite Vlad2D;
    public Sprite Wick2D;

    public Sprite TD2D;
    public Sprite Stonk2D;
    public Sprite SmallFin2D;
    public Sprite Nikky2D;
    public Sprite Hamster2D;
    public Sprite Woody2D;

    public Sprite Integra2D;
    public Sprite Albedo2D;
    public Sprite Ruby2D;
    public Sprite Shikamaru2D;
    public Sprite Lust2D;
    public Sprite Kek2D;

    public Sprite Anime2D;
    public Sprite Boysman2D;
    public Sprite Murlocs2D;

    public void Awake()
    {
        Players.Dahaka.Face = Dahaka2D;
        Players.OmniMan.Face = OmniMan2D;
        Players.Pudge.Face = Pudge2D;
        Players.Sokol.Face = Sokol2D;
        Players.Vlad.Face = Vlad2D;
        Players.Wick.Face = Wick2D;

        Players.TD.Face = TD2D;
        Players.Stonk.Face = Stonk2D;
        Players.SmallFin.Face = SmallFin2D;
        Players.Nikky.Face = Nikky2D;
        Players.Hamster.Face = Hamster2D;
        Players.Woody.Face = Woody2D;

        Players.Integra.Face = Integra2D;
        Players.Albedo.Face = Albedo2D;
        Players.Ruby.Face = Ruby2D;
        Players.Shikamaru.Face = Shikamaru2D;
        Players.Lust.Face = Lust2D;
        Players.Kek.Face = Kek2D;

        Players.Anime.Logo = Anime2D;
        Players.Murlocs.Logo = Murlocs2D;
        Players.Boys.Logo = Boysman2D;
    }
}
