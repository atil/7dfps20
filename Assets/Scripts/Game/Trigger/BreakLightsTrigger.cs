using UnityEngine;
using System.Collections;

public class BreakLightsTrigger : TriggerBase
{
    public Light LightToBreak;

    protected override void OnTriggered()
    {
        CoroutineStarter.Run(BreakLightCoroutine());

    }
    private IEnumerator BreakLightCoroutine()
    {
        for (float f = 0; f < 5f; f += Time.deltaTime)
        {
            LightToBreak.enabled = Random.value > 0.5f;
            yield return null;
        }

        LightToBreak.enabled = false;
    }
}