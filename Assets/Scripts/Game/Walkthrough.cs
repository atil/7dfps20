using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Walkthrough : MonoBehaviour
{
    public Color AmbientColor;
    public Transform PlayerStart;
    public EndWalkthroughTrigger EndTrigger;
    public bool IsUsherLookingAtPlayer;

    public Texture2D[] Posters;

    // TODO: Something with lights

    public void Init()
    {
        RenderSettings.ambientLight = AmbientColor;
        gameObject.SetActive(true);
        Player player = FindObjectOfType<Player>();
        player.ResetAt(PlayerStart);

        Usher usher = FindObjectOfType<Usher>();
        if (usher != null)
        {
            usher.IsLookingAtPlayer = IsUsherLookingAtPlayer;
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
