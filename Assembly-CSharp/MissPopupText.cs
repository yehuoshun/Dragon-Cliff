using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000138 RID: 312
public class MissPopupText : PopupText
{
	// Token: 0x060008AE RID: 2222 RVA: 0x00078085 File Offset: 0x00076485
	public MissPopupText()
	{
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x0007808D File Offset: 0x0007648D
	public override void SetText(PopupTextElement text)
	{
		base.SetText(text);
		this.Text.color = this.NormalColor;
		base.StartCoroutine(this.WaitToDestroy(this.AnimationTime + 1f));
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000780C0 File Offset: 0x000764C0
	private IEnumerator WaitToDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		base.gameObject.PoolDestroy(PoolType.MissPopupText);
		yield break;
	}

	// Token: 0x02000C13 RID: 3091
	[CompilerGenerated]
	private sealed class <WaitToDestroy>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051DC RID: 20956 RVA: 0x000780E2 File Offset: 0x000764E2
		[DebuggerHidden]
		public <WaitToDestroy>c__Iterator0()
		{
		}

		// Token: 0x060051DD RID: 20957 RVA: 0x000780EC File Offset: 0x000764EC
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
				base.gameObject.PoolDestroy(PoolType.MissPopupText);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700117C RID: 4476
		// (get) Token: 0x060051DE RID: 20958 RVA: 0x0007815A File Offset: 0x0007655A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700117D RID: 4477
		// (get) Token: 0x060051DF RID: 20959 RVA: 0x00078162 File Offset: 0x00076562
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051E0 RID: 20960 RVA: 0x0007816A File Offset: 0x0007656A
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051E1 RID: 20961 RVA: 0x0007817A File Offset: 0x0007657A
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FF5 RID: 16373
		internal float time;

		// Token: 0x04003FF6 RID: 16374
		internal MissPopupText $this;

		// Token: 0x04003FF7 RID: 16375
		internal object $current;

		// Token: 0x04003FF8 RID: 16376
		internal bool $disposing;

		// Token: 0x04003FF9 RID: 16377
		internal int $PC;
	}
}
