using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class Effects6 : MonoBehaviour
{
	// Token: 0x060005C3 RID: 1475 RVA: 0x0005FE96 File Offset: 0x0005E296
	public Effects6()
	{
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x0005FE9E File Offset: 0x0005E29E
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x0005FEB8 File Offset: 0x0005E2B8
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x0005FEC8 File Offset: 0x0005E2C8
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerPoison(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerDark(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008C7 RID: 2247
	private Transform _t;

	// Token: 0x040008C8 RID: 2248
	private Effects _effects;

	// Token: 0x02000BCA RID: 3018
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005000 RID: 20480 RVA: 0x0005FEE3 File Offset: 0x0005E2E3
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06005001 RID: 20481 RVA: 0x0005FEEC File Offset: 0x0005E2EC
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
				this._effects.TriggerPoison(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerDark(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010FE RID: 4350
		// (get) Token: 0x06005002 RID: 20482 RVA: 0x0005FFDD File Offset: 0x0005E3DD
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010FF RID: 4351
		// (get) Token: 0x06005003 RID: 20483 RVA: 0x0005FFE5 File Offset: 0x0005E3E5
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005004 RID: 20484 RVA: 0x0005FFED File Offset: 0x0005E3ED
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005005 RID: 20485 RVA: 0x0005FFFD File Offset: 0x0005E3FD
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E0B RID: 15883
		internal Effects6 $this;

		// Token: 0x04003E0C RID: 15884
		internal object $current;

		// Token: 0x04003E0D RID: 15885
		internal bool $disposing;

		// Token: 0x04003E0E RID: 15886
		internal int $PC;
	}
}
