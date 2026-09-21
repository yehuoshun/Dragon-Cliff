using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class Effects9 : MonoBehaviour
{
	// Token: 0x060005CF RID: 1487 RVA: 0x00060337 File Offset: 0x0005E737
	public Effects9()
	{
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x0006033F File Offset: 0x0005E73F
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00060359 File Offset: 0x0005E759
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00060368 File Offset: 0x0005E768
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerWarp(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerExplode((float)UnityEngine.Random.Range(0, 4), this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008CD RID: 2253
	private Transform _t;

	// Token: 0x040008CE RID: 2254
	private Effects _effects;

	// Token: 0x02000BCD RID: 3021
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005012 RID: 20498 RVA: 0x00060383 File Offset: 0x0005E783
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06005013 RID: 20499 RVA: 0x0006038C File Offset: 0x0005E78C
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
				this._effects.TriggerWarp(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerExplode((float)UnityEngine.Random.Range(0, 4), this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x17001104 RID: 4356
		// (get) Token: 0x06005014 RID: 20500 RVA: 0x00060485 File Offset: 0x0005E885
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001105 RID: 4357
		// (get) Token: 0x06005015 RID: 20501 RVA: 0x0006048D File Offset: 0x0005E88D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005016 RID: 20502 RVA: 0x00060495 File Offset: 0x0005E895
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005017 RID: 20503 RVA: 0x000604A5 File Offset: 0x0005E8A5
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E18 RID: 15896
		internal Effects9 $this;

		// Token: 0x04003E19 RID: 15897
		internal object $current;

		// Token: 0x04003E1A RID: 15898
		internal bool $disposing;

		// Token: 0x04003E1B RID: 15899
		internal int $PC;
	}
}
