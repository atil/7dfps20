using Malee.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class WalkthroughReorderableList : ReorderableArray<Walkthrough>
{
}

public class WalkthroughManager : MonoBehaviour
{
    [Reorderable]
    public WalkthroughReorderableList Walkthroughs;

    public int CurrentWalkthrough = 0;

    public void Init()
    {
        Walkthroughs[CurrentWalkthrough].Init();
    }

    public void OnEndWalkthroughTriggered()
    {
        Walkthroughs[CurrentWalkthrough].Dispose();
        CurrentWalkthrough++;
        Walkthroughs[CurrentWalkthrough].Init();
    }
}
