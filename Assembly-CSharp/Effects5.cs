using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class Effects5 : MonoBehaviour
{
	// Token: 0x060005BF RID: 1471 RVA: 0x0005FCFB File Offset: 0x0005E0FB
	public Effects5()
	{
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x0005FD03 File Offset: 0x0005E103
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x0005FD1D File Offset: 0x0005E11D
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x0005FD2C File Offset: 0x0005E12C
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerSparks(this._t.localPosition);
			}
			else
			{
				int num = (UnityEngine.Random.value <= 0.5f) ? 2 : ((UnityEngine.Random.value <= 0.5f) ? 1 : 0);
				this._effects.TriggerConsume((float)num, this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008C5 RID: 2245
	private Transform _t;

	// Token: 0x040008C6 RID: 2246
	private Effects _effects;

	// Token: 0x02000BC9 RID: 3017
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FFA RID: 20474 RVA: 0x0005FD47 File Offset: 0x0005E147
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FFB RID: 20475 RVA: 0x0005FD50 File Offset: 0x0005E150
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
				this._effects.TriggerSparks(this._t.localPosition);
			}
			else
			{
				int num2 = (UnityEngine.Random.value <= 0.5f) ? 2 : ((UnityEngine.Random.value <= 0.5f) ? 1 : 0);
				this._effects.TriggerConsume((float)num2, this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x06004FFC RID: 20476 RVA: 0x0005FE6F File Offset: 0x0005E26F
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010FD RID: 4349
		// (get) Token: 0x06004FFD RID: 20477 RVA: 0x0005FE77 File Offset: 0x0005E277
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FFE RID: 20478 RVA: 0x0005FE7F File Offset: 0x0005E27F
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FFF RID: 20479 RVA: 0x0005FE8F File Offset: 0x0005E28F
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E07 RID: 15879
		internal Effects5 $this;

		// Token: 0x04003E08 RID: 15880
		internal object $current;

		// Token: 0x04003E09 RID: 15881
		internal bool $disposing;

		// Token: 0x04003E0A RID: 15882
		internal int $PC;
	}
}
