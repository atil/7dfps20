using UnityEngine;
using System.Collections;

public class TeleportUsherTrigger : TriggerBase
{
    public Usher Usher;
    public Transform Target;

    protected override void OnTriggered()
    {
        Usher.SpookState = UsherSpookState.WaitingToBeSeen;
        Usher.transform.position = Target.transform.position;
        Usher.transform.rotation = Target.transform.rotation;
    }
}