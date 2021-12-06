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
            Stash.ResourceCount[ResType]--;
            Stash.ResourceCount[ResourceType.Coal]--;
            Industry.Forges[Industry.ChoosenForgeindex].gameObject.GetComponent<Forge>().StartFuse(ResType + 3);
            Industry.ChoosenForgeindex = 0;
            fuse_Panel.SetActive(false);
            forge_Panel.SetActive(true);
        }
    }
}
