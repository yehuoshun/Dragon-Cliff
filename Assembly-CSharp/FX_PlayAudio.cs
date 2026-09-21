using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A0C RID: 2572
public class FX_PlayAudio : MonoBehaviour
{
	// Token: 0x0600462C RID: 17964 RVA: 0x001C5EA7 File Offset: 0x001C42A7
	public FX_PlayAudio()
	{
	}

	// Token: 0x0600462D RID: 17965 RVA: 0x001C5EAF File Offset: 0x001C42AF
	private void Start()
	{
		if (this.Delay > 0f)
		{
			base.StartCoroutine(this.DelayPlay());
		}
		else
		{
			this.PlaySoundClipInBattle(this.Clip);
		}
	}

	// Token: 0x0600462E RID: 17966 RVA: 0x001C5EE0 File Offset: 0x001C42E0
	protected IEnumerator DelayPlay()
	{
		yield return new WaitForSeconds(this.Delay);
		this.PlaySoundClipInBattle(this.Clip);
		yield break;
	}

	// Token: 0x04003530 RID: 13616
	public AudioClip Clip;

	// Token: 0x04003531 RID: 13617
	public float Delay;

	// Token: 0x0200103E RID: 4158
	[CompilerGenerated]
	private sealed class <DelayPlay>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600684B RID: 26699 RVA: 0x001C5EFB File Offset: 0x001C42FB
		[DebuggerHidden]
		public <DelayPlay>c__Iterator0()
		{
		}

		// Token: 0x0600684C RID: 26700 RVA: 0x001C5F04 File Offset: 0x001C4304
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(this.Delay);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.PlaySoundClipInBattle(this.Clip);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170015C9 RID: 5577
		// (get) Token: 0x0600684D RID: 26701 RVA: 0x001C5F7C File Offset: 0x001C437C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015CA RID: 5578
		// (get) Token: 0x0600684E RID: 26702 RVA: 0x001C5F84 File Offset: 0x001C4384
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600684F RID: 26703 RVA: 0x001C5F8C File Offset: 0x001C438C
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06006850 RID: 26704 RVA: 0x001C5F9C File Offset: 0x001C439C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400620C RID: 25100
		internal FX_PlayAudio $this;

		// Token: 0x0400620D RID: 25101
		internal object $current;

		// Token: 0x0400620E RID: 25102
		internal bool $disposing;

		// Token: 0x0400620F RID: 25103
		internal int $PC;
	}
}
