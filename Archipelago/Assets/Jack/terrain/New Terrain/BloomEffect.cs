using UnityEngine;
using System;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BloomEffect : MonoBehaviour
{

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        int width = source.width / 32;
        int height = source.height / 32;
        RenderTextureFormat format = source.format;


        RenderTexture r = RenderTexture.GetTemporary(width, height, 0, format);

        Graphics.Blit(source, r);
        Graphics.Blit(r, destination);
        RenderTexture.ReleaseTemporary(r);
    }
}