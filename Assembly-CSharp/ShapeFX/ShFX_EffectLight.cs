using System;
using UnityEngine;

namespace ShapeFX
{
	// Token: 0x020000CB RID: 203
	[RequireComponent(typeof(Light))]
	[ExecuteInEditMode]
	public class ShFX_EffectLight : MonoBehaviour
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x00062244 File Offset: 0x00060644
		public ShFX_EffectLight()
		{
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x000622C8 File Offset: 0x000606C8
		private float PlaybackSpeed
		{
			get
			{
				return this.playbackSpeed * this.editorPlaybackSpeed;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x000622D7 File Offset: 0x000606D7
		public Light lightComponent
		{
			get
			{
				if (this._light == null)
				{
					this._light = base.GetComponent<Light>();
				}
				return this._light;
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000622FC File Offset: 0x000606FC
		public void PlayLightEffect()
		{
			this.lightComponent.enabled = true;
			this.playbackTime = 0f;
			this.fadeTime = Mathf.Clamp(this.fadeIn, 0f, 2.14748365E+09f);
			this.isPlaying = true;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00062338 File Offset: 0x00060738
		public void StopLightEffect(bool immediate = false)
		{
			if (!this.loop || immediate)
			{
				this.isPlaying = false;
				this.lightComponent.enabled = false;
				this.lightComponent.intensity = 0f;
			}
			else
			{
				this.fadeTime = Mathf.Clamp(-this.fadeOut - 0.0001f, -2.14748365E+09f, 0f);
			}
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x000623A0 File Offset: 0x000607A0
		private void Reset()
		{
			if (this.linkedEffect == null)
			{
				this.linkedEffect = base.GetComponentInParent<ParticleSystem>();
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000623BF File Offset: 0x000607BF
		private void OnEnable()
		{
			if (this.linkedEffect == null)
			{
				this.linkedEffect = base.GetComponentInParent<ParticleSystem>();
			}
			if (this.playOnEnable)
			{
				this.PlayLightEffect();
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x000623EF File Offset: 0x000607EF
		private void OnDisable()
		{
			this.particleSystemPlaying = false;
			this.StopLightEffect(true);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00062400 File Offset: 0x00060800
		private void Update()
		{
			if (this.autoPlayFromParticleSystem)
			{
				if (this.linkedEffect.isPlaying != this.particleSystemPlaying && this.linkedEffect.isPlaying)
				{
					this.PlayLightEffect();
				}
				this.particleSystemPlaying = this.linkedEffect.isPlaying;
			}
			if (this.isPlaying)
			{
				float time = Mathf.Clamp01(this.playbackTime % this.duration / (this.duration + float.Epsilon));
				if (this.useColorGradient)
				{
					this.lightComponent.color = this.colorGradient.Evaluate(time);
				}
				float num = Mathf.Lerp(0f, this.peakIntensity, this.intensityCurve.Evaluate(time));
				if (this.fadeTime > 0f)
				{
					this.fadeTime -= this.deltaTime;
					if (this.fadeTime <= 0f)
					{
						this.fadeTime = 0f;
					}
					else
					{
						num = Mathf.Lerp(num, 0f, this.fadeTime / this.fadeIn);
					}
				}
				else if (this.fadeTime < 0f)
				{
					this.fadeTime += this.deltaTime;
					if (this.fadeTime >= 0f)
					{
						this.fadeTime = 0f;
						this.StopLightEffect(true);
					}
					else
					{
						num = Mathf.Lerp(0f, num, -this.fadeTime / this.fadeOut);
					}
				}
				this.lightComponent.intensity = num;
				this.playbackTime += this.deltaTime;
				if (!this.loop && this.playbackTime > this.duration)
				{
					this.StopLightEffect(true);
				}
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x000625C6 File Offset: 0x000609C6
		private float deltaTime
		{
			get
			{
				return Time.deltaTime * this.PlaybackSpeed;
			}
		}

		// Token: 0x0400093C RID: 2364
		public ParticleSystem linkedEffect;

		// Token: 0x0400093D RID: 2365
		public bool playOnEnable;

		// Token: 0x0400093E RID: 2366
		[Tooltip("Detect when the linked Particle System starts playing to play along with it")]
		public bool autoPlayFromParticleSystem = true;

		// Token: 0x0400093F RID: 2367
		public float delay;

		// Token: 0x04000940 RID: 2368
		public float duration = 1f;

		// Token: 0x04000941 RID: 2369
		public float playbackSpeed = 1f;

		// Token: 0x04000942 RID: 2370
		public bool loop;

		// Token: 0x04000943 RID: 2371
		public float fadeIn;

		// Token: 0x04000944 RID: 2372
		public float fadeOut;

		// Token: 0x04000945 RID: 2373
		[Range(0f, 8f)]
		public float peakIntensity = 2f;

		// Token: 0x04000946 RID: 2374
		public AnimationCurve intensityCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		// Token: 0x04000947 RID: 2375
		public bool useColorGradient;

		// Token: 0x04000948 RID: 2376
		public Gradient colorGradient;

		// Token: 0x04000949 RID: 2377
		[HideInInspector]
		public bool colorFromParticleSystem;

		// Token: 0x0400094A RID: 2378
		[HideInInspector]
		public Color cachedColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x0400094B RID: 2379
		[HideInInspector]
		[NonSerialized]
		public float editorPlaybackSpeed = 1f;

		// Token: 0x0400094C RID: 2380
		[HideInInspector]
		[NonSerialized]
		public bool isPlaying;

		// Token: 0x0400094D RID: 2381
		private Light _light;

		// Token: 0x0400094E RID: 2382
		private float playbackTime;

		// Token: 0x0400094F RID: 2383
		private float fadeTime;

		// Token: 0x04000950 RID: 2384
		private bool particleSystemPlaying;
	}
}
