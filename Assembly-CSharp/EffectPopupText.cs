using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using TMPro;
using UnityEngine;

// Token: 0x02000136 RID: 310
public class EffectPopupText : MonoBehaviour
{
	// Token: 0x060008A8 RID: 2216 RVA: 0x00077E81 File Offset: 0x00076281
	public EffectPopupText()
	{
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00077E8C File Offset: 0x0007628C
	public virtual void SetText(PopupTextElement text)
	{
		this.Text.text = text.Text;
		float length = base.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
		base.StartCoroutine(this.WaitToDestroy(length + 1f));
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00077ED8 File Offset: 0x000762D8
	private IEnumerator WaitToDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		base.gameObject.PoolDestroy(PoolType.TextPopupText);
		yield break;
	}

	// Token: 0x04000B39 RID: 2873
	public TextMeshProUGUI Text;

	// Token: 0x02000C11 RID: 3089
	[CompilerGenerated]
	private sealed class <WaitToDestroy>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051D0 RID: 20944 RVA: 0x00077EFA File Offset: 0x000762FA
		[DebuggerHidden]
		public <WaitToDestroy>c__Iterator0()
		{
		}

		// Token: 0x060051D1 RID: 20945 RVA: 0x00077F04 File Offset: 0x00076304
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
				base.gameObject.PoolDestroy(PoolType.TextPopupText);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001178 RID: 4472
		// (get) Token: 0x060051D2 RID: 20946 RVA: 0x00077F73 File Offset: 0x00076373
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001179 RID: 4473
		// (get) Token: 0x060051D3 RID: 20947 RVA: 0x00077F7B File Offset: 0x0007637B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051D4 RID: 20948 RVA: 0x00077F83 File Offset: 0x00076383
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051D5 RID: 20949 RVA: 0x00077F93 File Offset: 0x00076393
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FEB RID: 16363
		internal float time;

		// Token: 0x04003FEC RID: 16364
		internal EffectPopupText $this;

		// Token: 0x04003FED RID: 16365
		internal object $current;

		// Token: 0x04003FEE RID: 16366
		internal bool $disposing;

		// Token: 0x04003FEF RID: 16367
		internal int $PC;
	}
}
