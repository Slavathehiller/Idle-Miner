using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public int ResType;
    public GameObject fuse_Panel;
    public GameObject forge_Panel;

    public void OnClick()
    {
        if (Stash.ResourceCount[ResType] > 0 && Stash.ResourceCount[ResourceType.Coal] > 0)
        {
            var forge = Industry.Forges[Industry.ChoosenForgeindex].gameObject.GetComponent<Forge>();
            var DoubleLoad = forge.UpgradeLvl >= 5 && Stash.ResourceCount[ResType] > 1 && Stash.ResourceCount[ResourceType.Coal] > 1;
            Stash.ResourceCount[ResType]--;
            Stash.ResourceCount[ResourceType.Coal]--;
            if (DoubleLoad)
            {
                Stash.ResourceCount[ResType]--;
                Stash.ResourceCount[ResourceType.Coal]--;
            }
            forge.StartFuse(ResType + 3, DoubleLoad);
            Industry.ChoosenForgeindex = 0;
            fuse_Panel.SetActive(false);
            forge_Panel.SetActive(true);
        }
    }
}
