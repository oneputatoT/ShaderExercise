using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PostEffectsBase : MonoBehaviour
{
    protected void CheckResources() {
        bool isSupported = CheckSupport();

        if (isSupported == false) {
            Notsupported();
        }
    }

    //检查当前平台是否支持屏幕特效和渲染纹理
    protected bool CheckSupport() {
        if (SystemInfo.supportsImageEffects == false || SystemInfo.supportsRenderTextures == false) {
            Debug.LogWarning("This platform does nor suppor omage effects or render textures.");
            return false;
        }
        return true;
    }

    protected void Notsupported() {
        enabled = false;
    }

    protected void Start() {
        CheckResources();
    }

    //检查shader和创建材质
    protected Material CheckShaderAndCreateMaterial(Shader shader, Material material) {
        if (shader == null) {
            return null;
        }

        if (shader.isSupported && material && material.shader == shader)
            return material;
        if (!shader.isSupported)
        {
            return null;
        }
        else {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;
            if (material)
                return material;
            else
                return null;
        }
    }
}
