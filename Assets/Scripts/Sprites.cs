using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour
{
    public Sprite Builded_Bridge;
    public Sprite Build_Enabled;
    public Sprite Build_Disabled;
    public Sprite Full_Coal;
    public Sprite Full_Iron;
    public Sprite Full_Gold;
    public Sprite Full_Diamond;
    public Sprite Half_Coal;
    public Sprite Half_Iron;
    public Sprite Half_Gold;
    public Sprite Half_Diamond;
    public Sprite Quarter_Coal;
    public Sprite Quarter_Iron;
    public Sprite Quarter_Gold;
    public Sprite Quarter_Diamond;
    public Sprite Idle_Forge;
    public Sprite Busy_Forge;
    public Sprite Coal;
    public Sprite IronOre;
    public Sprite GoldOre;
    public Sprite Diamond;
    public Sprite IronBar;
    public Sprite GoldBar;
    public Sprite Brilliant;
    public Sprite Upgrade_Enabled;
    public Sprite Upgrade_Disabled;

    public Sprite[] getCartSprites(int resourceNumber) 
    {
        switch (resourceNumber) 
        {
            case 0:
                return new Sprite[3] { Full_Coal, Half_Coal, Quarter_Coal };
            case 1:
                return new Sprite[3] { Full_Iron, Half_Iron, Quarter_Iron };
            case 2:
                return new Sprite[3] { Full_Gold, Half_Gold, Quarter_Gold };
            case 3:
                return new Sprite[3] { Full_Diamond, Half_Diamond, Quarter_Diamond };
            default:
                return null;
        }
        
    }

    public Sprite[] getResourceSprites()
    {
        return new Sprite[7] { Coal, IronOre, GoldOre, Diamond, IronBar, GoldBar, Brilliant};
    }

}
