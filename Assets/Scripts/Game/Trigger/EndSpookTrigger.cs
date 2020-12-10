using UnityEngine;
using System.Collections;

public class EndSpookTrigger : TriggerBase
{
    public Color AmbientColor;
    public AudioSource AudioSource_MovieStartsNow;
    public AudioSource AudioSource_EndSpook;
    public Usher Usher;
    public Player Player;

    public Light[] Lights;

    protected override void OnTriggered()
    {
        RenderSettings.ambientLight = AmbientColor;
        AudioSource_MovieStartsNow.Play();
        FindObjectOfType<PlayerMotor>().MaxSpeedAlongOneDimension *= 0.2f;
        CoroutineStarter.Run(UsherApproachToPlayerCoroutine());

    }

    private IEnumerator UsherApproachToPlayerCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        foreach (Light light in Lights)
        {
            yield return CoroutineStarter.Run(FlickerAndGoOff(light));
        }

        float maxDist = Vector3.Distance(Player.transform.position, Usher.transform.position);
        AudioSource_EndSpook.Play();

        while (true)
        {
            if (Player == null)
            {
                break; // endgame
            }

            float curDist = Vector3.Distance(Player.transform.position, Usher.transform.position);
            AudioSource_EndSpook.volume = Mathf.Lerp(0f, 1f, 1f - (curDist / maxDist));

            Vector3 toPlayer = (Player.transform.position - Usher.transform.position).normalized;
            Usher.transform.position += toPlayer * 1.3f * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FlickerAndGoOff(Light light)
    {
        float duration = Random.Range(0.5f, 1.5f);

        for (float f = 0f; f < duration; f += Time.deltaTime)
        {
            light.enabled = Random.value > 0.5f;
            yield return null;
        }

        light.enabled = false;
    }
}