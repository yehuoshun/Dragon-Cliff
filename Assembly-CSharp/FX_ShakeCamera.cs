using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A0D RID: 2573
public class FX_ShakeCamera : MonoBehaviour
{
	// Token: 0x0600462F RID: 17967 RVA: 0x001C5FA3 File Offset: 0x001C43A3
	public FX_ShakeCamera()
	{
	}

	// Token: 0x06004630 RID: 17968 RVA: 0x001C5FCA File Offset: 0x001C43CA
	private void Start()
	{
		base.StartCoroutine(this.ShakeAfterTime());
	}

	// Token: 0x06004631 RID: 17969 RVA: 0x001C5FDC File Offset: 0x001C43DC
	private IEnumerator ShakeAfterTime()
	{
		yield return new WaitForSeconds(this.DelayTime);
		CameraEffect.Shake(this.Power);
		if (this.Sound != null)
		{
			this.PlaySoundClipInBattle(this.Sound);
		}
		yield break;
	}

	// Token: 0x04003532 RID: 13618
	public Vector3 Power = (Vector3.up + Vector3.right) * 0.15f;

	// Token: 0x04003533 RID: 13619
	public AudioClip Sound;

	// Token: 0x04003534 RID: 13620
	public float DelayTime;

	// Token: 0x0200103F RID: 4159
	[CompilerGenerated]
	private sealed class <ShakeAfterTime>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006851 RID: 26705 RVA: 0x001C5FF7 File Offset: 0x001C43F7
		[DebuggerHidden]
		public <ShakeAfterTime>c__Iterator0()
		{
		}

		// Token: 0x06006852 RID: 26706 RVA: 0x001C6000 File Offset: 0x001C4400
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(this.DelayTime);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				CameraEffect.Shake(this.Power);
				if (this.Sound != null)
				{
					this.PlaySoundClipInBattle(this.Sound);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170015CB RID: 5579
		// (get) Token: 0x06006853 RID: 26707 RVA: 0x001C609E File Offset: 0x001C449E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015CC RID: 5580
		// (get) Token: 0x06006854 RID: 26708 RVA: 0x001C60A6 File Offset: 0x001C44A6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006855 RID: 26709 RVA: 0x001C60AE File Offset: 0x001C44AE
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06006856 RID: 26710 RVA: 0x001C60BE File Offset: 0x001C44BE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04006210 RID: 25104
		internal FX_ShakeCamera $this;

		// Token: 0x04006211 RID: 25105
		internal object $current;

		// Token: 0x04006212 RID: 25106
		internal bool $disposing;

		// Token: 0x04006213 RID: 25107
		internal int $PC;
	}
}
