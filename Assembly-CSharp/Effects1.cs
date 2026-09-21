using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class Effects1 : MonoBehaviour
{
	// Token: 0x060005A7 RID: 1447 RVA: 0x0005F2AF File Offset: 0x0005D6AF
	public Effects1()
	{
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x0005F2B7 File Offset: 0x0005D6B7
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x0005F2D1 File Offset: 0x0005D6D1
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x0005F2E0 File Offset: 0x0005D6E0
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			int random = UnityEngine.Random.Range(0, 6);
			if (random == 0)
			{
				this._effects.TriggerStar(this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerCircle(this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerGlint(this._t.localPosition);
			}
			else if (random == 3)
			{
				this._effects.TriggerPuff(this._t.localPosition);
			}
			else if (random == 4)
			{
				this._effects.TriggerWeb(this._t.localPosition);
			}
			else if (random == 5)
			{
				this._effects.TriggerBlock(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008B9 RID: 2233
	private Transform _t;

	// Token: 0x040008BA RID: 2234
	private Effects _effects;

	// Token: 0x02000BC3 RID: 3011
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FD6 RID: 20438 RVA: 0x0005F2FB File Offset: 0x0005D6FB
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FD7 RID: 20439 RVA: 0x0005F304 File Offset: 0x0005D704
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
			random = UnityEngine.Random.Range(0, 6);
			if (random == 0)
			{
				this._effects.TriggerStar(this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerCircle(this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerGlint(this._t.localPosition);
			}
			else if (random == 3)
			{
				this._effects.TriggerPuff(this._t.localPosition);
			}
			else if (random == 4)
			{
				this._effects.TriggerWeb(this._t.localPosition);
			}
			else if (random == 5)
			{
				this._effects.TriggerBlock(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010F0 RID: 4336
		// (get) Token: 0x06004FD8 RID: 20440 RVA: 0x0005F4E2 File Offset: 0x0005D8E2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010F1 RID: 4337
		// (get) Token: 0x06004FD9 RID: 20441 RVA: 0x0005F4EA File Offset: 0x0005D8EA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FDA RID: 20442 RVA: 0x0005F4F2 File Offset: 0x0005D8F2
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FDB RID: 20443 RVA: 0x0005F502 File Offset: 0x0005D902
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003DEC RID: 15852
		internal int <random>__1;

		// Token: 0x04003DED RID: 15853
		internal Effects1 $this;

		// Token: 0x04003DEE RID: 15854
		internal object $current;

		// Token: 0x04003DEF RID: 15855
		internal bool $disposing;

		// Token: 0x04003DF0 RID: 15856
		internal int $PC;
	}
}
