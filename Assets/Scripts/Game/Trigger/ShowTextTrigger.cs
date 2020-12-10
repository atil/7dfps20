using UnityEngine;
using System.Collections;

public class ShowTextTrigger : TriggerBase
{
    public string TextToShow;
    public float Duration = 3f;

    public float Delay = -1f;

    protected override void OnTriggered()
    {
        if (Delay > 0)
        {
            CoroutineStarter.Run(DelayedShowTextCoroutine());
        }
        else
        {
            FindObjectOfType<Ui>().ShowText(TextToShow, Duration);
        }
    }

    private IEnumerator DelayedShowTextCoroutine()
    {
        yield return new WaitForSeconds(Delay);
        FindObjectOfType<Ui>().ShowText(TextToShow, Duration);
    }
}