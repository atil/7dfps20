using UnityEngine;
using System.Collections;

public class ScareTrigger : TriggerBase
{
    public Usher Usher;
    public Transform UsherTarget;
    public AudioSource ScareAudioSource;

    protected override void OnTriggered()
    {
        CoroutineStarter.Run(ScareCoroutine());
    }
    
    private IEnumerator ScareCoroutine()
    {
        Usher.transform.position = UsherTarget.position;
        Usher.transform.rotation = UsherTarget.rotation;
        ScareAudioSource.Play();
        yield return new WaitForSeconds(2f);
        ScareAudioSource.Stop();
        FindObjectOfType<WalkthroughManager>().OnEndWalkthroughTriggered();
    }

}