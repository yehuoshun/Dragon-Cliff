using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class Effects7 : MonoBehaviour
{
	// Token: 0x060005C7 RID: 1479 RVA: 0x00060004 File Offset: 0x0005E404
	public Effects7()
	{
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x0006000C File Offset: 0x0005E40C
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00060026 File Offset: 0x0005E426
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00060038 File Offset: 0x0005E438
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			int random = UnityEngine.Random.Range(0, 4);
			if (random == 0)
			{
				this._effects.TriggerFire(this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerEarth(this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerIce(this._t.localPosition);
			}
			else if (random == 3)
			{
				this._effects.TriggerWater(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008C9 RID: 2249
	private Transform _t;

	// Token: 0x040008CA RID: 2250
	private Effects _effects;

	// Token: 0x02000BCB RID: 3019
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005006 RID: 20486 RVA: 0x00060053 File Offset: 0x0005E453
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06005007 RID: 20487 RVA: 0x0006005C File Offset: 0x0005E45C
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
			random = UnityEngine.Random.Range(0, 4);
			if (random == 0)
			{
				this._effects.TriggerFire(this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerEarth(this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerIce(this._t.localPosition);
			}
			else if (random == 3)
			{
				this._effects.TriggerWater(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x17001100 RID: 4352
		// (get) Token: 0x06005008 RID: 20488 RVA: 0x000601CE File Offset: 0x0005E5CE
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001101 RID: 4353
		// (get) Token: 0x06005009 RID: 20489 RVA: 0x000601D6 File Offset: 0x0005E5D6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600500A RID: 20490 RVA: 0x000601DE File Offset: 0x0005E5DE
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600500B RID: 20491 RVA: 0x000601EE File Offset: 0x0005E5EE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E0F RID: 15887
		internal int <random>__1;

		// Token: 0x04003E10 RID: 15888
		internal Effects7 $this;

		// Token: 0x04003E11 RID: 15889
		internal object $current;

		// Token: 0x04003E12 RID: 15890
		internal bool $disposing;

		// Token: 0x04003E13 RID: 15891
		internal int $PC;
	}
}
