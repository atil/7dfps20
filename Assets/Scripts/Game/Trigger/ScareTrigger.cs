using UnityEngine;
using System.Collections;

public class ScareTrigger : TriggerBase
{
    public GameObject UsherHead;
    public AudioSource ScareAudioSource;

    protected override void OnTriggered()
    {
        CoroutineStarter.Run(ScareCoroutine());
    }
    
    private IEnumerator ScareCoroutine()
    {
        UsherHead.SetActive(true);
        ScareAudioSource.Play();
        for (float f = 0; f < 2f; f += Time.deltaTime)
        {
            int a = Mathf.RoundToInt(f / 0.2f);
            UsherHead.SetActive(a % 2 == 0);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        ScareAudioSource.Stop();
        FindObjectOfType<WalkthroughManager>().OnEndWalkthroughTriggered();
    }

}