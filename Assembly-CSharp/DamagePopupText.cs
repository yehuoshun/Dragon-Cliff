using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000135 RID: 309
public class DamagePopupText : PopupText
{
	// Token: 0x060008A5 RID: 2213 RVA: 0x00077D2F File Offset: 0x0007612F
	public DamagePopupText()
	{
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00077D38 File Offset: 0x00076138
	public override void SetText(PopupTextElement text)
	{
		base.SetText(text);
		this.Animator.runtimeAnimatorController = ((!text.IsAdventurer) ? this.EnemyDamageAnim : this.AdventurerDamageAnim);
		if (text.IsMagical)
		{
			this.Text.color = this.MagicalColor;
		}
		else
		{
			this.Text.color = this.NormalColor;
		}
		base.StartCoroutine(this.WaitToDestroy(this.AnimationTime + 1f));
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x00077DC0 File Offset: 0x000761C0
	private IEnumerator WaitToDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		base.gameObject.PoolDestroy(PoolType.DamagePopupText);
		yield break;
	}

	// Token: 0x04000B35 RID: 2869
	public Color CriticalColor;

	// Token: 0x04000B36 RID: 2870
	public Color MagicalColor;

	// Token: 0x04000B37 RID: 2871
	public RuntimeAnimatorController EnemyDamageAnim;

	// Token: 0x04000B38 RID: 2872
	public RuntimeAnimatorController AdventurerDamageAnim;

	// Token: 0x02000C10 RID: 3088
	[CompilerGenerated]
	private sealed class <WaitToDestroy>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051CA RID: 20938 RVA: 0x00077DE2 File Offset: 0x000761E2
		[DebuggerHidden]
		public <WaitToDestroy>c__Iterator0()
		{
		}

		// Token: 0x060051CB RID: 20939 RVA: 0x00077DEC File Offset: 0x000761EC
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
				base.gameObject.PoolDestroy(PoolType.DamagePopupText);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001176 RID: 4470
		// (get) Token: 0x060051CC RID: 20940 RVA: 0x00077E5A File Offset: 0x0007625A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001177 RID: 4471
		// (get) Token: 0x060051CD RID: 20941 RVA: 0x00077E62 File Offset: 0x00076262
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051CE RID: 20942 RVA: 0x00077E6A File Offset: 0x0007626A
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051CF RID: 20943 RVA: 0x00077E7A File Offset: 0x0007627A
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FE6 RID: 16358
		internal float time;

		// Token: 0x04003FE7 RID: 16359
		internal DamagePopupText $this;

		// Token: 0x04003FE8 RID: 16360
		internal object $current;

		// Token: 0x04003FE9 RID: 16361
		internal bool $disposing;

		// Token: 0x04003FEA RID: 16362
		internal int $PC;
	}
}
