using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class Effects2 : MonoBehaviour
{
	// Token: 0x060005B3 RID: 1459 RVA: 0x0005F854 File Offset: 0x0005DC54
	public Effects2()
	{
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x0005F85C File Offset: 0x0005DC5C
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x0005F876 File Offset: 0x0005DC76
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x0005F888 File Offset: 0x0005DC88
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerLightning(this._t.localPosition);
			}
			this._effects.TriggerElectric(this._t.localPosition);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008BF RID: 2239
	private Transform _t;

	// Token: 0x040008C0 RID: 2240
	private Effects _effects;

	// Token: 0x02000BC6 RID: 3014
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FE8 RID: 20456 RVA: 0x0005F8A3 File Offset: 0x0005DCA3
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FE9 RID: 20457 RVA: 0x0005F8AC File Offset: 0x0005DCAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(0.333f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				break;
			case 2u:
				break;
			default:
				return false;
			}
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerLightning(this._t.localPosition);
			}
			this._effects.TriggerElectric(this._t.localPosition);
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010F6 RID: 4342
		// (get) Token: 0x06004FEA RID: 20458 RVA: 0x0005F998 File Offset: 0x0005DD98
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010F7 RID: 4343
		// (get) Token: 0x06004FEB RID: 20459 RVA: 0x0005F9A0 File Offset: 0x0005DDA0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FEC RID: 20460 RVA: 0x0005F9A8 File Offset: 0x0005DDA8
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FED RID: 20461 RVA: 0x0005F9B8 File Offset: 0x0005DDB8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003DFA RID: 15866
		internal Effects2 $this;

		// Token: 0x04003DFB RID: 15867
		internal object $current;

		// Token: 0x04003DFC RID: 15868
		internal bool $disposing;

		// Token: 0x04003DFD RID: 15869
		internal int $PC;
	}
}
