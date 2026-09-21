using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class Effects10 : MonoBehaviour
{
	// Token: 0x060005AB RID: 1451 RVA: 0x0005F509 File Offset: 0x0005D909
	public Effects10()
	{
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0005F511 File Offset: 0x0005D911
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0005F52B File Offset: 0x0005D92B
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x0005F53C File Offset: 0x0005D93C
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			int random = UnityEngine.Random.Range(0, 3);
			if (random == 0)
			{
				this._effects.TriggerBox(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerSquare(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerTouch(this._t.localPosition, null);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008BB RID: 2235
	private Transform _t;

	// Token: 0x040008BC RID: 2236
	private Effects _effects;

	// Token: 0x02000BC4 RID: 3012
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FDC RID: 20444 RVA: 0x0005F557 File Offset: 0x0005D957
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FDD RID: 20445 RVA: 0x0005F560 File Offset: 0x0005D960
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
			random = UnityEngine.Random.Range(0, 3);
			if (random == 0)
			{
				this._effects.TriggerBox(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerSquare(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerTouch(this._t.localPosition, null);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010F2 RID: 4338
		// (get) Token: 0x06004FDE RID: 20446 RVA: 0x0005F6BD File Offset: 0x0005DABD
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010F3 RID: 4339
		// (get) Token: 0x06004FDF RID: 20447 RVA: 0x0005F6C5 File Offset: 0x0005DAC5
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FE0 RID: 20448 RVA: 0x0005F6CD File Offset: 0x0005DACD
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FE1 RID: 20449 RVA: 0x0005F6DD File Offset: 0x0005DADD
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003DF1 RID: 15857
		internal int <random>__1;

		// Token: 0x04003DF2 RID: 15858
		internal Effects10 $this;

		// Token: 0x04003DF3 RID: 15859
		internal object $current;

		// Token: 0x04003DF4 RID: 15860
		internal bool $disposing;

		// Token: 0x04003DF5 RID: 15861
		internal int $PC;
	}
}
