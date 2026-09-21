using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000137 RID: 311
public class HealingPopupText : PopupText
{
	// Token: 0x060008AB RID: 2219 RVA: 0x00077F9A File Offset: 0x0007639A
	public HealingPopupText()
	{
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x00077FA2 File Offset: 0x000763A2
	public override void SetText(PopupTextElement text)
	{
		base.SetText(text);
		base.StartCoroutine(this.WaitToDestroy(this.AnimationTime + 1f));
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00077FC4 File Offset: 0x000763C4
	private IEnumerator WaitToDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		base.gameObject.PoolDestroy(PoolType.HealingPopupText);
		yield break;
	}

	// Token: 0x02000C12 RID: 3090
	[CompilerGenerated]
	private sealed class <WaitToDestroy>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051D6 RID: 20950 RVA: 0x00077FE6 File Offset: 0x000763E6
		[DebuggerHidden]
		public <WaitToDestroy>c__Iterator0()
		{
		}

		// Token: 0x060051D7 RID: 20951 RVA: 0x00077FF0 File Offset: 0x000763F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(time);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.gameObject.PoolDestroy(PoolType.HealingPopupText);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700117A RID: 4474
		// (get) Token: 0x060051D8 RID: 20952 RVA: 0x0007805E File Offset: 0x0007645E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700117B RID: 4475
		// (get) Token: 0x060051D9 RID: 20953 RVA: 0x00078066 File Offset: 0x00076466
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051DA RID: 20954 RVA: 0x0007806E File Offset: 0x0007646E
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051DB RID: 20955 RVA: 0x0007807E File Offset: 0x0007647E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FF0 RID: 16368
		internal float time;

		// Token: 0x04003FF1 RID: 16369
		internal HealingPopupText $this;

		// Token: 0x04003FF2 RID: 16370
		internal object $current;

		// Token: 0x04003FF3 RID: 16371
		internal bool $disposing;

		// Token: 0x04003FF4 RID: 16372
		internal int $PC;
	}
}
