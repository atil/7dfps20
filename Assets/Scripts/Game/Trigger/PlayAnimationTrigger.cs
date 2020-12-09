using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationTrigger : TriggerBase
{
    public UnityEngine.GameObject SingleDoor;
    public Usher Usher;

    protected override void OnTriggered()
    {
        if (SingleDoor != null)
        {
            SingleDoor.GetComponent<AnimationPlayer>().Play(true);
        }
        if (Usher != null)
        {
            Usher.GetComponent<AnimationPlayer>().Play(false);
        }
    }
}
