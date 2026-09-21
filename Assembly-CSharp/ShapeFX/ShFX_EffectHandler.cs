using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ShapeFX
{
	// Token: 0x020000C9 RID: 201
	[RequireComponent(typeof(ParticleSystem))]
	public class ShFX_EffectHandler : MonoBehaviour
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x00061A54 File Offset: 0x0005FE54
		public ShFX_EffectHandler()
		{
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00061AB7 File Offset: 0x0005FEB7
		private void Awake()
		{
			this.ps = base.GetComponent<ParticleSystem>();
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00061AC5 File Offset: 0x0005FEC5
		private void OnEnable()
		{
			if (this.cameraToShake == null)
			{
				this.cameraToShake = Camera.main;
			}
			base.StartCoroutine(this.CR_CheckParticleSystem());
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00061AF0 File Offset: 0x0005FEF0
		private void OnDisable()
		{
			base.StopAllCoroutines();
			if (this.shakeCamera && !ShFX_EffectHandler.DisableCameraShake)
			{
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(this.OnCamPreRender));
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.OnCamPostRender));
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00061B58 File Offset: 0x0005FF58
		private void OnCamPreRender(Camera cam)
		{
			if (this.cameraShaking && cam == this.cameraToShake)
			{
				if (ShFX_EffectHandler.lastShakeFrame < Time.frameCount)
				{
					ShFX_EffectHandler.camOriginalPosition = cam.transform.position;
					ShFX_EffectHandler.lastShakeFrame = Time.frameCount;
					ShFX_EffectHandler.curFrameMaxStrength = -1f;
				}
				if (this.shakeOffset > ShFX_EffectHandler.curFrameMaxStrength)
				{
					ShFX_EffectHandler.curFrameMaxStrength = this.shakeOffset;
					Vector3 vector = Quaternion.AngleAxis(this.shakeAngle, cam.transform.forward) * cam.transform.right;
					cam.transform.position = cam.transform.position + vector.normalized * this.shakeOffset;
				}
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00061C23 File Offset: 0x00060023
		private void OnCamPostRender(Camera cam)
		{
			if (this.cameraShaking && cam == this.cameraToShake)
			{
				cam.transform.position = ShFX_EffectHandler.camOriginalPosition;
			}
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00061C54 File Offset: 0x00060054
		public void DoEndAction()
		{
			ShFX_EffectHandler.EndAction endAction = this.endAction;
			if (endAction != ShFX_EffectHandler.EndAction.DestroyGameObject)
			{
				if (endAction == ShFX_EffectHandler.EndAction.DeactivateGameObject)
				{
					base.gameObject.SetActive(false);
				}
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00061C9C File Offset: 0x0006009C
		public void StartCameraShake()
		{
			this.StopCameraShake();
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(this.OnCamPreRender));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(this.OnCamPostRender));
			this.shakeOffset = 0f;
			this.cameraShaking = true;
			this.shakeCoroutine = base.StartCoroutine(this.CR_ShakeCamera());
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00061D14 File Offset: 0x00060114
		public void StopCameraShake()
		{
			this.cameraShaking = false;
			if (this.shakeCoroutine != null)
			{
				base.StopCoroutine(this.shakeCoroutine);
			}
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(this.OnCamPreRender));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.OnCamPostRender));
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00061D80 File Offset: 0x00060180
		private IEnumerator CR_CheckParticleSystem()
		{
			for (;;)
			{
				while (!this.ps.isPlaying)
				{
					yield return null;
				}
				if (this.soundEffect != null)
				{
					AudioSource.PlayClipAtPoint(this.soundEffect, base.transform.position);
				}
				if (this.shakeCamera && !ShFX_EffectHandler.DisableCameraShake)
				{
					this.StartCameraShake();
				}
				while (this.ps.IsAlive())
				{
					yield return null;
				}
				while (this.cameraShaking)
				{
					yield return null;
				}
				this.DoEndAction();
			}
			yield break;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00061D9C File Offset: 0x0006019C
		private IEnumerator CR_ShakeCamera()
		{
			yield return new WaitForSeconds(this.shakeDelay);
			float t = 0f;
			float sign = 1f;
			float step = 0f;
			float falloff = 0f;
			this.shakeOffset = 0f;
			int repeat = this.shakeRepeat;
			while (t < this.shakeDuration)
			{
				step += Time.deltaTime;
				if (step > this.shakeStep)
				{
					step = 0f;
					if (this.useFalloff)
					{
						float num = Vector3.Distance(this.cameraToShake.transform.position, base.transform.position);
						falloff = 1f - Mathf.Clamp01((num - this.falloffMin) / (this.falloffMax - this.falloffMin));
					}
					if (falloff > 0f || !this.useFalloff)
					{
						this.shakeOffset = Mathf.Lerp((!this.useFalloff) ? this.shakeStrength : (this.shakeStrength * falloff), 0f, Mathf.Clamp01(t / this.shakeDuration)) * sign;
						sign *= -1f;
						if (this.randomShakeAngle && sign > 0f)
						{
							this.shakeAngle = UnityEngine.Random.Range(0f, 180f);
						}
					}
				}
				t += Time.deltaTime;
				yield return null;
				if (t >= this.shakeDuration)
				{
					repeat--;
					if (repeat > 0)
					{
						t -= this.shakeDuration;
					}
				}
			}
			this.shakeOffset = 0f;
			this.StopCameraShake();
			yield break;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00061DB7 File Offset: 0x000601B7
		// Note: this type is marked as 'beforefieldinit'.
		static ShFX_EffectHandler()
		{
		}

		// Token: 0x04000922 RID: 2338
		public static bool DisableCameraShake;

		// Token: 0x04000923 RID: 2339
		[Header("EFFECT")]
		[Tooltip("What to do when the Particle System has finished playing")]
		public ShFX_EffectHandler.EndAction endAction = ShFX_EffectHandler.EndAction.DestroyGameObject;

		// Token: 0x04000924 RID: 2340
		[Header("SOUND")]
		[Tooltip("Sound effect to play with the Particle System")]
		public AudioClip soundEffect;

		// Token: 0x04000925 RID: 2341
		[Header("CAMERA SHAKE")]
		[Tooltip("Perform a simple Camera shake when the effect plays")]
		public bool shakeCamera;

		// Token: 0x04000926 RID: 2342
		[Tooltip("Will use Camera.main if empty")]
		public Camera cameraToShake;

		// Token: 0x04000927 RID: 2343
		[Range(0f, 180f)]
		public float shakeAngle = 90f;

		// Token: 0x04000928 RID: 2344
		public bool randomShakeAngle;

		// Token: 0x04000929 RID: 2345
		public float shakeDuration = 0.5f;

		// Token: 0x0400092A RID: 2346
		public float shakeDelay;

		// Token: 0x0400092B RID: 2347
		[Range(1f, 20f)]
		public int shakeRepeat = 1;

		// Token: 0x0400092C RID: 2348
		[Range(0f, 0.1f)]
		[Tooltip("Will change the camera position every step seconds (every frame if 0)")]
		public float shakeStep = 0.03f;

		// Token: 0x0400092D RID: 2349
		[Range(0.01f, 1f)]
		public float shakeStrength = 0.1f;

		// Token: 0x0400092E RID: 2350
		[Tooltip("Decrease the shake strength as the camera moves further away from the effect")]
		public bool useFalloff;

		// Token: 0x0400092F RID: 2351
		[Tooltip("Distance between effect and camera at which the shake starts to linearly decrease")]
		public float falloffMin = 10f;

		// Token: 0x04000930 RID: 2352
		[Tooltip("Distance between effect and camera over which the shake effects is ignored")]
		public float falloffMax = 20f;

		// Token: 0x04000931 RID: 2353
		private ParticleSystem ps;

		// Token: 0x04000932 RID: 2354
		private static Vector3 camOriginalPosition;

		// Token: 0x04000933 RID: 2355
		private static int lastShakeFrame = -1;

		// Token: 0x04000934 RID: 2356
		private static float curFrameMaxStrength = -1f;

		// Token: 0x04000935 RID: 2357
		private Coroutine shakeCoroutine;

		// Token: 0x04000936 RID: 2358
		private float shakeOffset;

		// Token: 0x04000937 RID: 2359
		private bool cameraShaking;

		// Token: 0x020000CA RID: 202
		public enum EndAction
		{
			// Token: 0x04000939 RID: 2361
			DoNothing,
			// Token: 0x0400093A RID: 2362
			DestroyGameObject,
			// Token: 0x0400093B RID: 2363
			DeactivateGameObject
		}

		// Token: 0x02000BD1 RID: 3025
		[CompilerGenerated]
		private sealed class <CR_CheckParticleSystem>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600502A RID: 20522 RVA: 0x00061DC9 File Offset: 0x000601C9
			[DebuggerHidden]
			public <CR_CheckParticleSystem>c__Iterator0()
			{
			}

			// Token: 0x0600502B RID: 20523 RVA: 0x00061DD4 File Offset: 0x000601D4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					break;
				case 1u:
					break;
				case 2u:
					goto IL_D9;
				case 3u:
					goto IL_10E;
				default:
					return false;
				}
				IL_29:
				if (!this.ps.isPlaying)
				{
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				if (this.soundEffect != null)
				{
					AudioSource.PlayClipAtPoint(this.soundEffect, base.transform.position);
				}
				if (this.shakeCamera && !ShFX_EffectHandler.DisableCameraShake)
				{
					base.StartCameraShake();
				}
				IL_D9:
				if (this.ps.IsAlive())
				{
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				IL_10E:
				if (!this.cameraShaking)
				{
					base.DoEndAction();
					goto IL_29;
				}
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 3;
				}
				return true;
			}

			// Token: 0x1700110C RID: 4364
			// (get) Token: 0x0600502C RID: 20524 RVA: 0x00061F19 File Offset: 0x00060319
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700110D RID: 4365
			// (get) Token: 0x0600502D RID: 20525 RVA: 0x00061F21 File Offset: 0x00060321
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600502E RID: 20526 RVA: 0x00061F29 File Offset: 0x00060329
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x0600502F RID: 20527 RVA: 0x00061F39 File Offset: 0x00060339
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003E2B RID: 15915
			internal ShFX_EffectHandler $this;

			// Token: 0x04003E2C RID: 15916
			internal object $current;

			// Token: 0x04003E2D RID: 15917
			internal bool $disposing;

			// Token: 0x04003E2E RID: 15918
			internal int $PC;
		}

		// Token: 0x02000BD2 RID: 3026
		[CompilerGenerated]
		private sealed class <CR_ShakeCamera>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06005030 RID: 20528 RVA: 0x00061F40 File Offset: 0x00060340
			[DebuggerHidden]
			public <CR_ShakeCamera>c__Iterator1()
			{
			}

			// Token: 0x06005031 RID: 20529 RVA: 0x00061F48 File Offset: 0x00060348
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.$current = new WaitForSeconds(this.shakeDelay);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				case 1u:
					t = 0f;
					sign = 1f;
					step = 0f;
					falloff = 0f;
					this.shakeOffset = 0f;
					repeat = this.shakeRepeat;
					break;
				case 2u:
					if (t >= this.shakeDuration)
					{
						repeat--;
						if (repeat > 0)
						{
							t -= this.shakeDuration;
						}
					}
					break;
				default:
					return false;
				}
				if (t < this.shakeDuration)
				{
					step += Time.deltaTime;
					if (step > this.shakeStep)
					{
						step = 0f;
						if (this.useFalloff)
						{
							float num2 = Vector3.Distance(this.cameraToShake.transform.position, base.transform.position);
							falloff = 1f - Mathf.Clamp01((num2 - this.falloffMin) / (this.falloffMax - this.falloffMin));
						}
						if (falloff > 0f || !this.useFalloff)
						{
							this.shakeOffset = Mathf.Lerp((!this.useFalloff) ? this.shakeStrength : (this.shakeStrength * falloff), 0f, Mathf.Clamp01(t / this.shakeDuration)) * sign;
							sign *= -1f;
							if (this.randomShakeAngle && sign > 0f)
							{
								this.shakeAngle = UnityEngine.Random.Range(0f, 180f);
							}
						}
					}
					t += Time.deltaTime;
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				this.shakeOffset = 0f;
				base.StopCameraShake();
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700110E RID: 4366
			// (get) Token: 0x06005032 RID: 20530 RVA: 0x0006221B File Offset: 0x0006061B
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700110F RID: 4367
			// (get) Token: 0x06005033 RID: 20531 RVA: 0x00062223 File Offset: 0x00060623
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06005034 RID: 20532 RVA: 0x0006222B File Offset: 0x0006062B
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06005035 RID: 20533 RVA: 0x0006223B File Offset: 0x0006063B
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003E2F RID: 15919
			internal float <t>__0;

			// Token: 0x04003E30 RID: 15920
			internal float <sign>__0;

			// Token: 0x04003E31 RID: 15921
			internal float <step>__0;

			// Token: 0x04003E32 RID: 15922
			internal float <falloff>__0;

			// Token: 0x04003E33 RID: 15923
			internal int <repeat>__0;

			// Token: 0x04003E34 RID: 15924
			internal ShFX_EffectHandler $this;

			// Token: 0x04003E35 RID: 15925
			internal object $current;

			// Token: 0x04003E36 RID: 15926
			internal bool $disposing;

			// Token: 0x04003E37 RID: 15927
			internal int $PC;
		}
	}
}
