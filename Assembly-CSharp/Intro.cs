using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ca.HenrySoftware.Rage;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000B3 RID: 179
[RequireComponent(typeof(AudioSource))]
public class Intro : MonoBehaviour
{
	// Token: 0x060005D3 RID: 1491 RVA: 0x000604AC File Offset: 0x0005E8AC
	public Intro()
	{
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x000604B4 File Offset: 0x0005E8B4
	private void Awake()
	{
		this._source = base.GetComponent<AudioSource>();
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x000604C4 File Offset: 0x0005E8C4
	private void Start()
	{
		int num = 2;
		Camera main = Camera.main;
		if (main != null)
		{
			int a = (int)((float)Screen.width / this.Henry.sprite.rect.width);
			int b = (int)((float)Screen.height / this.Henry.sprite.rect.height);
			int num2 = Mathf.Min(a, b) - 2;
			if (num2 > num)
			{
				num = num2;
			}
		}
		base.StartCoroutine(this.PlayDelayed());
		Ease3.GoScaleTo(this.Henry, new Vector3((float)num, (float)num, 1f), 1f, null, null, EaseType.BounceOut, 0.5f, 1, false, false);
		Ease3.GoRotationTo(this.Henry, new Vector3(0f, 0f, 180f), 1f, null, null, EaseType.BounceOut, 0.5f, 1, false, false);
		Ease3.GoColorTo(this, Color.black.GetVector3(), 1f, null, new Action(this.Fade), EaseType.BounceOut, 0.5f, 1, false, false);
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x000605D6 File Offset: 0x0005E9D6
	private void Done()
	{
		SceneManager.LoadSceneAsync(1);
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x000605E0 File Offset: 0x0005E9E0
	private IEnumerator PlayDelayed()
	{
		yield return new WaitForSeconds(0.8f);
		this._source.Play();
		yield break;
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x000605FC File Offset: 0x0005E9FC
	private void Fade()
	{
		Ease.GoAlpha(this.Fore, 0f, 1f, 1f, null, new Action(this.Done), EaseType.Linear, 1f, 1, false, false);
	}

	// Token: 0x040008CF RID: 2255
	public Image Henry;

	// Token: 0x040008D0 RID: 2256
	public Button Fore;

	// Token: 0x040008D1 RID: 2257
	private AudioSource _source;

	// Token: 0x040008D2 RID: 2258
	private const float _timeAnimation = 1f;

	// Token: 0x040008D3 RID: 2259
	private const float _timeDelay = 0.5f;

	// Token: 0x040008D4 RID: 2260
	private const float _timeDelaySound = 0.8f;

	// Token: 0x02000BCE RID: 3022
	[CompilerGenerated]
	private sealed class <PlayDelayed>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005018 RID: 20504 RVA: 0x0006063A File Offset: 0x0005EA3A
		[DebuggerHidden]
		public <PlayDelayed>c__Iterator0()
		{
		}

		// Token: 0x06005019 RID: 20505 RVA: 0x00060644 File Offset: 0x0005EA44
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(0.8f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this._source.Play();
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001106 RID: 4358
		// (get) Token: 0x0600501A RID: 20506 RVA: 0x000606B0 File Offset: 0x0005EAB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001107 RID: 4359
		// (get) Token: 0x0600501B RID: 20507 RVA: 0x000606B8 File Offset: 0x0005EAB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600501C RID: 20508 RVA: 0x000606C0 File Offset: 0x0005EAC0
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600501D RID: 20509 RVA: 0x000606D0 File Offset: 0x0005EAD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E1C RID: 15900
		internal Intro $this;

		// Token: 0x04003E1D RID: 15901
		internal object $current;

		// Token: 0x04003E1E RID: 15902
		internal bool $disposing;

		// Token: 0x04003E1F RID: 15903
		internal int $PC;
	}
}
