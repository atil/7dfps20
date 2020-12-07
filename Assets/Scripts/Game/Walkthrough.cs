using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Walkthrough : MonoBehaviour
{

    [Header("Start")]
    public Transform PlayerStart;
    public bool HasTransitionFlash = true;
    public bool HasGlitch = false;
    public bool HasBackgroundNoise = true;

    [Header("Triggers")]
    public EndWalkthroughTrigger EndTrigger;

    [Header("Usher")]
    public bool IsUsherLookingAtPlayer;
    public bool IsUsherSpookyWhenVisible;

    [Header("Environment")]
    public Color AmbientColor;
    public Texture2D[] Posters;
    public Light[] Lights;

    public void Init()
    {
        gameObject.SetActive(true);

        RenderSettings.ambientLight = AmbientColor;
        Sfx sfx = FindObjectOfType<Sfx>();
        sfx.MusicAudioSource.volume = HasBackgroundNoise ? Sfx.BaseMusicVolume : 0f;

        foreach (TriggerBase tb in GetComponentsInChildren<TriggerBase>())
        {
            tb.ResetTrigger();
        }

        Ui ui = FindObjectOfType<Ui>();
        if (HasTransitionFlash)
        {
            ui.TransitionFlash();
        }
        if (HasGlitch)
        {
            ui.ClearFlash();
            const float glitchDuration = 0.5f;
            ui.Glitch(glitchDuration);
            sfx.Glitch(glitchDuration);
        }

        Player player = FindObjectOfType<Player>();
        player.ResetAt(PlayerStart);
        Usher usher = FindObjectOfType<Usher>();
        if (usher != null)
        {
            usher.IsLookingAtPlayer = IsUsherLookingAtPlayer;
            usher.SpookState = IsUsherSpookyWhenVisible ? UsherSpookState.WaitingToTeleport : UsherSpookState.None;
        }

        GameObject artworkSlots = GameObject.Find("ArtworkSlots");
        if (artworkSlots != null)
        {
            Debug.Assert(artworkSlots.transform.childCount == 4);

            for (int i = 0; i < artworkSlots.transform.childCount; i++)
            {
                Transform slot = artworkSlots.transform.GetChild(i);
                Material slotMaterial = slot.GetComponent<MeshRenderer>().material;
                slotMaterial.SetTexture("_MainTex", Posters[i]);
            }

        }

    }

    public void Dispose()
    {
        gameObject.SetActive(false);
        foreach (Light light in Lights)
        {
            light.enabled = true;
        }
    }

    void OnDrawGizmos()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (PlayerStart != null)
        {
            Gizmos.DrawWireSphere(PlayerStart.position, 1f);
        }
    }
}
