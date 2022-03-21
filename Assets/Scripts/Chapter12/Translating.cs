using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translating : PostEffectsBase
{
    public Shader motionBlurShader;
    private Material motionBlurMaterial = null;

    public Material material{
    get{
            motionBlurMaterial = CheckShaderAndCreateMaterial(motionBlurShader, motionBlurMaterial);
            return motionBlurMaterial;
        }
    }

    [Range(0.0f, 0.9f)]
    public float blurAmount = 0.5f;

    private RenderTexture accumulationTeture;
    void OnDisable()
    {
        DestroyImmediate(accumulationTeture);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            if (accumulationTeture == null || accumulationTeture.width != src.width || accumulationTeture.height != src.height)
            {
                DestroyImmediate(accumulationTeture);
                accumulationTeture = new RenderTexture(src.width, src.height, 0);
                accumulationTeture.hideFlags = HideFlags.HideAndDontSave;
                Graphics.Blit(src, accumulationTeture);
            }

            accumulationTeture.MarkRestoreExpected();
            material.SetFloat("_BlurAmount", 1.0f - blurAmount);
            Graphics.Blit(src, accumulationTeture, material);
            Graphics.Blit(accumulationTeture, dest);

        }
        else {
            Graphics.Blit(src, dest);
        }
    }
}
