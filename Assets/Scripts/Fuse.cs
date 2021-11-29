using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public int ResType;
    public void OnClick()
    {
        if (Stash.ResourceCount[ResType] > 0 && Stash.ResourceCount[ResourceType.Coal] > 0)
        {
            Stash.ResourceCount[ResType + 3]++;
            Stash.ResourceCount[ResType]--;
            Stash.ResourceCount[ResourceType.Coal]--;
        }
    }
}
