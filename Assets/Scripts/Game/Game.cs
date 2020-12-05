using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public WalkthroughManager WalkthroughManager;
    
    void Start()
    {
        WalkthroughManager.Init();
    }
}