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

    public Sprite[] getResourceSprites(int resourceNumber) 
    {
        switch (resourceNumber) 
        {
            case 0:
                return new Sprite[3] { Full_Coal, Half_Coal, Quarter_Coal };
                break;
            case 1:
                return new Sprite[3] { Full_Iron, Half_Iron, Quarter_Iron };
                break;
            case 2:
                return new Sprite[3] { Full_Gold, Half_Gold, Quarter_Gold };
                break;
            case 3:
                return new Sprite[3] { Full_Diamond, Half_Diamond, Quarter_Diamond };
                break;
            default:
                return null;
        }
        
    }

}
