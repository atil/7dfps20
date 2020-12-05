using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowResEffect : MonoBehaviour
{
    public Material LowResMaterial;

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, LowResMaterial);
    }
}
