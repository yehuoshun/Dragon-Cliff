using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class Effects3 : MonoBehaviour
{
	// Token: 0x060005B7 RID: 1463 RVA: 0x0005F9BF File Offset: 0x0005DDBF
	public Effects3()
	{
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x0005F9C7 File Offset: 0x0005DDC7
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x0005F9E1 File Offset: 0x0005DDE1
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x0005F9F0 File Offset: 0x0005DDF0
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerShield(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerBubble(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008C1 RID: 2241
	private Transform _t;

	// Token: 0x040008C2 RID: 2242
	private Effects _effects;

	// Token: 0x02000BC7 RID: 3015
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FEE RID: 20462 RVA: 0x0005FA0B File Offset: 0x0005DE0B
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FEF RID: 20463 RVA: 0x0005FA14 File Offset: 0x0005DE14
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
				this._effects.TriggerShield(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerBubble(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010F8 RID: 4344
		// (get) Token: 0x06004FF0 RID: 20464 RVA: 0x0005FB05 File Offset: 0x0005DF05
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x06004FF1 RID: 20465 RVA: 0x0005FB0D File Offset: 0x0005DF0D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FF2 RID: 20466 RVA: 0x0005FB15 File Offset: 0x0005DF15
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FF3 RID: 20467 RVA: 0x0005FB25 File Offset: 0x0005DF25
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003DFE RID: 15870
		internal Effects3 $this;

		// Token: 0x04003DFF RID: 15871
		internal object $current;

		// Token: 0x04003E00 RID: 15872
		internal bool $disposing;

		// Token: 0x04003E01 RID: 15873
		internal int $PC;
	}
}
