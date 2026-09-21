using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A1F RID: 2591
public class ShakeCameraHandler : MonoBehaviour
{
	// Token: 0x060046AB RID: 18091 RVA: 0x001CF2F0 File Offset: 0x001CD6F0
	public ShakeCameraHandler()
	{
	}

	// Token: 0x060046AC RID: 18092 RVA: 0x001CF34C File Offset: 0x001CD74C
	private void OnEnable()
	{
		this.cameraToShake = TownManager.Instance.Ui.BattleCamera;
		this.StartCameraShake();
	}

	// Token: 0x060046AD RID: 18093 RVA: 0x001CF36C File Offset: 0x001CD76C
	protected void OnDisable()
	{
		base.StopAllCoroutines();
		if (this.shakeCamera && !ShakeCameraHandler.DisableCameraShake)
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(this.OnCamPreRender));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.OnCamPostRender));
		}
	}

	// Token: 0x060046AE RID: 18094 RVA: 0x001CF3D4 File Offset: 0x001CD7D4
	private void OnCamPreRender(Camera cam)
	{
		if (this.cameraShaking && cam == this.cameraToShake)
		{
			if (ShakeCameraHandler.lastShakeFrame < Time.frameCount)
			{
				ShakeCameraHandler.camOriginalPosition = cam.transform.position;
				ShakeCameraHandler.lastShakeFrame = Time.frameCount;
				ShakeCameraHandler.curFrameMaxStrength = -1f;
			}
			if (this.shakeOffset > ShakeCameraHandler.curFrameMaxStrength)
			{
				ShakeCameraHandler.curFrameMaxStrength = this.shakeOffset;
				Vector3 vector = Quaternion.AngleAxis(this.shakeAngle, cam.transform.forward) * cam.transform.right;
				cam.transform.position = cam.transform.position + vector.normalized * this.shakeOffset;
			}
		}
	}

	// Token: 0x060046AF RID: 18095 RVA: 0x001CF49F File Offset: 0x001CD89F
	private void OnCamPostRender(Camera cam)
	{
		if (this.cameraShaking && cam == this.cameraToShake)
		{
			cam.transform.position = ShakeCameraHandler.camOriginalPosition;
		}
	}

	// Token: 0x060046B0 RID: 18096 RVA: 0x001CF4D0 File Offset: 0x001CD8D0
	public void StartCameraShake()
	{
		this.StopCameraShake();
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(this.OnCamPreRender));
		Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(this.OnCamPostRender));
		this.shakeOffset = 0f;
		this.cameraShaking = true;
		this.shakeCoroutine = base.StartCoroutine(this.CR_ShakeCamera());
		if (this.soundEffect != null)
		{
			this.PlaySoundClipInBattle(this.soundEffect);
		}
	}

	// Token: 0x060046B1 RID: 18097 RVA: 0x001CF564 File Offset: 0x001CD964
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

	// Token: 0x060046B2 RID: 18098 RVA: 0x001CF5D0 File Offset: 0x001CD9D0
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

	// Token: 0x060046B3 RID: 18099 RVA: 0x001CF5EB File Offset: 0x001CD9EB
	// Note: this type is marked as 'beforefieldinit'.
	static ShakeCameraHandler()
	{
	}

	// Token: 0x040035CD RID: 13773
	public static bool DisableCameraShake;

	// Token: 0x040035CE RID: 13774
	[Header("SOUND")]
	[Tooltip("Sound effect to play with the Particle System")]
	public AudioClip soundEffect;

	// Token: 0x040035CF RID: 13775
	[Header("CAMERA SHAKE")]
	[Tooltip("Perform a simple Camera shake when the effect plays")]
	public bool shakeCamera;

	// Token: 0x040035D0 RID: 13776
	[Tooltip("Will use Battle Camera if empty")]
	public Camera cameraToShake;

	// Token: 0x040035D1 RID: 13777
	[Range(0f, 180f)]
	public float shakeAngle = 90f;

	// Token: 0x040035D2 RID: 13778
	public bool randomShakeAngle;

	// Token: 0x040035D3 RID: 13779
	public float shakeDuration = 0.5f;

	// Token: 0x040035D4 RID: 13780
	public float shakeDelay;

	// Token: 0x040035D5 RID: 13781
	[Range(1f, 20f)]
	public int shakeRepeat = 1;

	// Token: 0x040035D6 RID: 13782
	[Range(0f, 0.1f)]
	[Tooltip("Will change the camera position every step seconds (every frame if 0)")]
	public float shakeStep = 0.03f;

	// Token: 0x040035D7 RID: 13783
	[Range(0.01f, 5f)]
	public float shakeStrength = 0.7f;

	// Token: 0x040035D8 RID: 13784
	[Tooltip("Decrease the shake strength as the camera moves further away from the effect")]
	public bool useFalloff;

	// Token: 0x040035D9 RID: 13785
	[Tooltip("Distance between effect and camera at which the shake starts to linearly decrease")]
	public float falloffMin = 10f;

	// Token: 0x040035DA RID: 13786
	[Tooltip("Distance between effect and camera over which the shake effects is ignored")]
	public float falloffMax = 20f;

	// Token: 0x040035DB RID: 13787
	private static Vector3 camOriginalPosition;

	// Token: 0x040035DC RID: 13788
	private static int lastShakeFrame = -1;

	// Token: 0x040035DD RID: 13789
	private static float curFrameMaxStrength = -1f;

	// Token: 0x040035DE RID: 13790
	private Coroutine shakeCoroutine;

	// Token: 0x040035DF RID: 13791
	private float shakeOffset;

	// Token: 0x040035E0 RID: 13792
	private bool cameraShaking;

	// Token: 0x02000A20 RID: 2592
	public enum EndAction
	{
		// Token: 0x040035E2 RID: 13794
		DoNothing,
		// Token: 0x040035E3 RID: 13795
		DestroyGameObject,
		// Token: 0x040035E4 RID: 13796
		DeactivateGameObject
	}

	// Token: 0x02001040 RID: 4160
	[CompilerGenerated]
	private sealed class <CR_ShakeCamera>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006857 RID: 26711 RVA: 0x001CF5FD File Offset: 0x001CD9FD
		[DebuggerHidden]
		public <CR_ShakeCamera>c__Iterator0()
		{
		}

		// Token: 0x06006858 RID: 26712 RVA: 0x001CF608 File Offset: 0x001CDA08
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

		// Token: 0x170015CD RID: 5581
		// (get) Token: 0x06006859 RID: 26713 RVA: 0x001CF8DB File Offset: 0x001CDCDB
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015CE RID: 5582
		// (get) Token: 0x0600685A RID: 26714 RVA: 0x001CF8E3 File Offset: 0x001CDCE3
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600685B RID: 26715 RVA: 0x001CF8EB File Offset: 0x001CDCEB
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600685C RID: 26716 RVA: 0x001CF8FB File Offset: 0x001CDCFB
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04006214 RID: 25108
		internal float <t>__0;

		// Token: 0x04006215 RID: 25109
		internal float <sign>__0;

		// Token: 0x04006216 RID: 25110
		internal float <step>__0;

		// Token: 0x04006217 RID: 25111
		internal float <falloff>__0;

		// Token: 0x04006218 RID: 25112
		internal int <repeat>__0;

		// Token: 0x04006219 RID: 25113
		internal ShakeCameraHandler $this;

		// Token: 0x0400621A RID: 25114
		internal object $current;

		// Token: 0x0400621B RID: 25115
		internal bool $disposing;

		// Token: 0x0400621C RID: 25116
		internal int $PC;
	}
}
