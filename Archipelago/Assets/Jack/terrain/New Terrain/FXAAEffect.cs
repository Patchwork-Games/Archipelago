using UnityEngine;
using System;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class FXAAEffect : MonoBehaviour {

	const int luminancePass = 0;
	const int fxaaPass = 1;

	public enum LuminanceMode { Alpha, Green, Calculate }

	public LuminanceMode luminanceSource;

	[HideInInspector]
	public Shader fxaaShader;

	[NonSerialized]
	Material fxaaMaterial;

	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		if (fxaaMaterial == null) {
			fxaaMaterial = new Material(fxaaShader);
			fxaaMaterial.hideFlags = HideFlags.HideAndDontSave;
		}

		if (luminanceSource == LuminanceMode.Calculate) {
			fxaaMaterial.DisableKeyword("LUMINANCE_GREEN");
			RenderTexture luminanceTex = RenderTexture.GetTemporary(
				source.width, source.height, 0, source.format
			);
			Graphics.Blit(source, luminanceTex, fxaaMaterial, luminancePass);
			Graphics.Blit(luminanceTex, destination, fxaaMaterial, fxaaPass);
			RenderTexture.ReleaseTemporary(luminanceTex);
		}
		else {
			if (luminanceSource == LuminanceMode.Green) {
				fxaaMaterial.EnableKeyword("LUMINANCE_GREEN");
			}
			else {
				fxaaMaterial.DisableKeyword("LUMINANCE_GREEN");
			}
			Graphics.Blit(source, destination, fxaaMaterial, fxaaPass);
		}
	}
}