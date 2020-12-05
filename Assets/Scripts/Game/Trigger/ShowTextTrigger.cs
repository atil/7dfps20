using UnityEngine;
using System.Collections;

public class ShowTextTrigger : TriggerBase
{
    public string TextToShow;
    public float Duration = 3f;

    protected override void OnTriggered()
    {
        FindObjectOfType<Ui>().ShowText(TextToShow, Duration);
    }
}