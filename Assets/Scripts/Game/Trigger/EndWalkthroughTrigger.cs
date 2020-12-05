using UnityEngine;
using System.Collections;

public class EndWalkthroughTrigger : TriggerBase
{
    protected override void OnTriggered()
    {
        FindObjectOfType<WalkthroughManager>().OnEndWalkthroughTriggered();
    }
}