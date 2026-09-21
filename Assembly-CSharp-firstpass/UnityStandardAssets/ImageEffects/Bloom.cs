using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001BF RID: 447
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Bloom and Glow/Bloom")]
	public class Bloom : PostEffectsBase
	{
		// Token: 0x06000C1A RID: 3098 RVA: 0x0001BC68 File Offset: 0x0001A068
		public Bloom()
		{
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x0001BD68 File Offset: 0x0001A168
		public override bool CheckResources()
		{
			base.CheckSupport(false);
			this.screenBlend = base.CheckShaderAndCreateMaterial(this.screenBlendShader, this.screenBlend);
			this.lensFlareMaterial = base.CheckShaderAndCreateMaterial(this.lensFlareShader, this.lensFlareMaterial);
			this.blurAndFlaresMaterial = base.CheckShaderAndCreateMaterial(this.blurAndFlaresShader, this.blurAndFlaresMaterial);
			this.brightPassFilterMaterial = base.CheckShaderAndCreateMaterial(this.brightPassFilterShader, this.brightPassFilterMaterial);
			if (!this.isSupported)
			{
				base.ReportAutoDisable();
			}
			return this.isSupported;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0001BDF4 File Offset: 0x0001A1F4
		public void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!this.CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			this.doHdr = false;
			if (this.hdr == Bloom.HDRBloomMode.Auto)
			{
				this.doHdr = (source.format == RenderTextureFormat.ARGBHalf && base.GetComponent<Camera>().hdr);
			}
			else
			{
				this.doHdr = (this.hdr == Bloom.HDRBloomMode.On);
			}
			this.doHdr = (this.doHdr && this.supportHDRTextures);
			Bloom.BloomScreenBlendMode bloomScreenBlendMode = this.screenBlendMode;
			if (this.doHdr)
			{
				bloomScreenBlendMode = Bloom.BloomScreenBlendMode.Add;
			}
			RenderTextureFormat format = (!this.doHdr) ? RenderTextureFormat.Default : RenderTextureFormat.ARGBHalf;
			int width = source.width / 2;
			int height = source.height / 2;
			int width2 = source.width / 4;
			int height2 = source.height / 4;
			float num = 1f * (float)source.width / (1f * (float)source.height);
			float num2 = 0.001953125f;
			RenderTexture temporary = RenderTexture.GetTemporary(width2, height2, 0, format);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0, format);
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				Graphics.Blit(source, temporary2, this.screenBlend, 2);
				RenderTexture temporary3 = RenderTexture.GetTemporary(width2, height2, 0, format);
				Graphics.Blit(temporary2, temporary3, this.screenBlend, 2);
				Graphics.Blit(temporary3, temporary, this.screenBlend, 6);
				RenderTexture.ReleaseTemporary(temporary3);
			}
			else
			{
				Graphics.Blit(source, temporary2);
				Graphics.Blit(temporary2, temporary, this.screenBlend, 6);
			}
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture renderTexture = RenderTexture.GetTemporary(width2, height2, 0, format);
			this.BrightFilter(this.bloomThreshold * this.bloomThresholdColor, temporary, renderTexture);
			if (this.bloomBlurIterations < 1)
			{
				this.bloomBlurIterations = 1;
			}
			else if (this.bloomBlurIterations > 10)
			{
				this.bloomBlurIterations = 10;
			}
			for (int i = 0; i < this.bloomBlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.25f) * this.sepBlurSpread;
				RenderTexture temporary4 = RenderTexture.GetTemporary(width2, height2, 0, format);
				this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(0f, num3 * num2, 0f, 0f));
				Graphics.Blit(renderTexture, temporary4, this.blurAndFlaresMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary4;
				temporary4 = RenderTexture.GetTemporary(width2, height2, 0, format);
				this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
				Graphics.Blit(renderTexture, temporary4, this.blurAndFlaresMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary4;
				if (this.quality > Bloom.BloomQuality.Cheap)
				{
					if (i == 0)
					{
						Graphics.SetRenderTarget(temporary);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(renderTexture, temporary);
					}
					else
					{
						temporary.MarkRestoreExpected();
						Graphics.Blit(renderTexture, temporary, this.screenBlend, 10);
					}
				}
			}
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				Graphics.SetRenderTarget(renderTexture);
				GL.Clear(false, true, Color.black);
				Graphics.Blit(temporary, renderTexture, this.screenBlend, 6);
			}
			if (this.lensflareIntensity > Mathf.Epsilon)
			{
				RenderTexture temporary5 = RenderTexture.GetTemporary(width2, height2, 0, format);
				if (this.lensflareMode == Bloom.LensFlareStyle.Ghosting)
				{
					this.BrightFilter(this.lensflareThreshold, renderTexture, temporary5);
					if (this.quality > Bloom.BloomQuality.Cheap)
					{
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(0f, 1.5f / (1f * (float)temporary.height), 0f, 0f));
						Graphics.SetRenderTarget(temporary);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 4);
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(1.5f / (1f * (float)temporary.width), 0f, 0f, 0f));
						Graphics.SetRenderTarget(temporary5);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 4);
					}
					this.Vignette(0.975f, temporary5, temporary5);
					this.BlendFlares(temporary5, renderTexture);
				}
				else
				{
					float num4 = 1f * Mathf.Cos(this.flareRotation);
					float num5 = 1f * Mathf.Sin(this.flareRotation);
					float num6 = this.hollyStretchWidth * 1f / num * num2;
					this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num4, num5, 0f, 0f));
					this.blurAndFlaresMaterial.SetVector("_Threshhold", new Vector4(this.lensflareThreshold, 1f, 0f, 0f));
					this.blurAndFlaresMaterial.SetVector("_TintColor", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.flareColorA.a * this.lensflareIntensity);
					this.blurAndFlaresMaterial.SetFloat("_Saturation", this.lensFlareSaturation);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 2);
					temporary5.DiscardContents();
					Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 3);
					this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num4 * num6, num5 * num6, 0f, 0f));
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 1);
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth * 2f);
					temporary5.DiscardContents();
					Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 1);
					this.blurAndFlaresMaterial.SetFloat("_StretchWidth", this.hollyStretchWidth * 4f);
					temporary.DiscardContents();
					Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 1);
					for (int j = 0; j < this.hollywoodFlareBlurIterations; j++)
					{
						num6 = this.hollyStretchWidth * 2f / num * num2;
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num6 * num4, num6 * num5, 0f, 0f));
						temporary5.DiscardContents();
						Graphics.Blit(temporary, temporary5, this.blurAndFlaresMaterial, 4);
						this.blurAndFlaresMaterial.SetVector("_Offsets", new Vector4(num6 * num4, num6 * num5, 0f, 0f));
						temporary.DiscardContents();
						Graphics.Blit(temporary5, temporary, this.blurAndFlaresMaterial, 4);
					}
					if (this.lensflareMode == Bloom.LensFlareStyle.Anamorphic)
					{
						this.AddTo(1f, temporary, renderTexture);
					}
					else
					{
						this.Vignette(1f, temporary, temporary5);
						this.BlendFlares(temporary5, temporary);
						this.AddTo(1f, temporary, renderTexture);
					}
				}
				RenderTexture.ReleaseTemporary(temporary5);
			}
			int pass = (int)bloomScreenBlendMode;
			this.screenBlend.SetFloat("_Intensity", this.bloomIntensity);
			this.screenBlend.SetTexture("_ColorBuffer", source);
			if (this.quality > Bloom.BloomQuality.Cheap)
			{
				RenderTexture temporary6 = RenderTexture.GetTemporary(width, height, 0, format);
				Graphics.Blit(renderTexture, temporary6);
				Graphics.Blit(temporary6, destination, this.screenBlend, pass);
				RenderTexture.ReleaseTemporary(temporary6);
			}
			else
			{
				Graphics.Blit(renderTexture, destination, this.screenBlend, pass);
			}
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(renderTexture);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0001C595 File Offset: 0x0001A995
		private void AddTo(float intensity_, RenderTexture from, RenderTexture to)
		{
			this.screenBlend.SetFloat("_Intensity", intensity_);
			to.MarkRestoreExpected();
			Graphics.Blit(from, to, this.screenBlend, 9);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0001C5C0 File Offset: 0x0001A9C0
		private void BlendFlares(RenderTexture from, RenderTexture to)
		{
			this.lensFlareMaterial.SetVector("colorA", new Vector4(this.flareColorA.r, this.flareColorA.g, this.flareColorA.b, this.flareColorA.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorB", new Vector4(this.flareColorB.r, this.flareColorB.g, this.flareColorB.b, this.flareColorB.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorC", new Vector4(this.flareColorC.r, this.flareColorC.g, this.flareColorC.b, this.flareColorC.a) * this.lensflareIntensity);
			this.lensFlareMaterial.SetVector("colorD", new Vector4(this.flareColorD.r, this.flareColorD.g, this.flareColorD.b, this.flareColorD.a) * this.lensflareIntensity);
			to.MarkRestoreExpected();
			Graphics.Blit(from, to, this.lensFlareMaterial);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0001C710 File Offset: 0x0001AB10
		private void BrightFilter(float thresh, RenderTexture from, RenderTexture to)
		{
			this.brightPassFilterMaterial.SetVector("_Threshhold", new Vector4(thresh, thresh, thresh, thresh));
			Graphics.Blit(from, to, this.brightPassFilterMaterial, 0);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0001C739 File Offset: 0x0001AB39
		private void BrightFilter(Color threshColor, RenderTexture from, RenderTexture to)
		{
			this.brightPassFilterMaterial.SetVector("_Threshhold", threshColor);
			Graphics.Blit(from, to, this.brightPassFilterMaterial, 1);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0001C760 File Offset: 0x0001AB60
		private void Vignette(float amount, RenderTexture from, RenderTexture to)
		{
			if (this.lensFlareVignetteMask)
			{
				this.screenBlend.SetTexture("_ColorBuffer", this.lensFlareVignetteMask);
				to.MarkRestoreExpected();
				Graphics.Blit((!(from == to)) ? from : null, to, this.screenBlend, (!(from == to)) ? 3 : 7);
			}
			else if (from != to)
			{
				Graphics.SetRenderTarget(to);
				GL.Clear(false, true, Color.black);
				Graphics.Blit(from, to);
			}
		}

		// Token: 0x040009AD RID: 2477
		public Bloom.TweakMode tweakMode;

		// Token: 0x040009AE RID: 2478
		public Bloom.BloomScreenBlendMode screenBlendMode = Bloom.BloomScreenBlendMode.Add;

		// Token: 0x040009AF RID: 2479
		public Bloom.HDRBloomMode hdr;

		// Token: 0x040009B0 RID: 2480
		private bool doHdr;

		// Token: 0x040009B1 RID: 2481
		public float sepBlurSpread = 2.5f;

		// Token: 0x040009B2 RID: 2482
		public Bloom.BloomQuality quality = Bloom.BloomQuality.High;

		// Token: 0x040009B3 RID: 2483
		public float bloomIntensity = 0.5f;

		// Token: 0x040009B4 RID: 2484
		public float bloomThreshold = 0.5f;

		// Token: 0x040009B5 RID: 2485
		public Color bloomThresholdColor = Color.white;

		// Token: 0x040009B6 RID: 2486
		public int bloomBlurIterations = 2;

		// Token: 0x040009B7 RID: 2487
		public int hollywoodFlareBlurIterations = 2;

		// Token: 0x040009B8 RID: 2488
		public float flareRotation;

		// Token: 0x040009B9 RID: 2489
		public Bloom.LensFlareStyle lensflareMode = Bloom.LensFlareStyle.Anamorphic;

		// Token: 0x040009BA RID: 2490
		public float hollyStretchWidth = 2.5f;

		// Token: 0x040009BB RID: 2491
		public float lensflareIntensity;

		// Token: 0x040009BC RID: 2492
		public float lensflareThreshold = 0.3f;

		// Token: 0x040009BD RID: 2493
		public float lensFlareSaturation = 0.75f;

		// Token: 0x040009BE RID: 2494
		public Color flareColorA = new Color(0.4f, 0.4f, 0.8f, 0.75f);

		// Token: 0x040009BF RID: 2495
		public Color flareColorB = new Color(0.4f, 0.8f, 0.8f, 0.75f);

		// Token: 0x040009C0 RID: 2496
		public Color flareColorC = new Color(0.8f, 0.4f, 0.8f, 0.75f);

		// Token: 0x040009C1 RID: 2497
		public Color flareColorD = new Color(0.8f, 0.4f, 0f, 0.75f);

		// Token: 0x040009C2 RID: 2498
		public Texture2D lensFlareVignetteMask;

		// Token: 0x040009C3 RID: 2499
		public Shader lensFlareShader;

		// Token: 0x040009C4 RID: 2500
		private Material lensFlareMaterial;

		// Token: 0x040009C5 RID: 2501
		public Shader screenBlendShader;

		// Token: 0x040009C6 RID: 2502
		private Material screenBlend;

		// Token: 0x040009C7 RID: 2503
		public Shader blurAndFlaresShader;

		// Token: 0x040009C8 RID: 2504
		private Material blurAndFlaresMaterial;

		// Token: 0x040009C9 RID: 2505
		public Shader brightPassFilterShader;

		// Token: 0x040009CA RID: 2506
		private Material brightPassFilterMaterial;

		// Token: 0x020001C0 RID: 448
		public enum LensFlareStyle
		{
			// Token: 0x040009CC RID: 2508
			Ghosting,
			// Token: 0x040009CD RID: 2509
			Anamorphic,
			// Token: 0x040009CE RID: 2510
			Combined
		}

		// Token: 0x020001C1 RID: 449
		public enum TweakMode
		{
			// Token: 0x040009D0 RID: 2512
			Basic,
			// Token: 0x040009D1 RID: 2513
			Complex
		}

		// Token: 0x020001C2 RID: 450
		public enum HDRBloomMode
		{
			// Token: 0x040009D3 RID: 2515
			Auto,
			// Token: 0x040009D4 RID: 2516
			On,
			// Token: 0x040009D5 RID: 2517
			Off
		}

		// Token: 0x020001C3 RID: 451
		public enum BloomScreenBlendMode
		{
			// Token: 0x040009D7 RID: 2519
			Screen,
			// Token: 0x040009D8 RID: 2520
			Add
		}

		// Token: 0x020001C4 RID: 452
		public enum BloomQuality
		{
			// Token: 0x040009DA RID: 2522
			Cheap,
			// Token: 0x040009DB RID: 2523
			High
		}
	}
}
