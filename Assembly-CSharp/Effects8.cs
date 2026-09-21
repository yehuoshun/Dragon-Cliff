using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class Effects8 : MonoBehaviour
{
	// Token: 0x060005CB RID: 1483 RVA: 0x000601F5 File Offset: 0x0005E5F5
	public Effects8()
	{
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x000601FD File Offset: 0x0005E5FD
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00060217 File Offset: 0x0005E617
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00060228 File Offset: 0x0005E628
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			this._effects.TriggerHeal(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008CB RID: 2251
	private Transform _t;

	// Token: 0x040008CC RID: 2252
	private Effects _effects;

	// Token: 0x02000BCC RID: 3020
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600500C RID: 20492 RVA: 0x00060243 File Offset: 0x0005E643
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x0600500D RID: 20493 RVA: 0x0006024C File Offset: 0x0005E64C
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
			this._effects.TriggerHeal(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x17001102 RID: 4354
		// (get) Token: 0x0600500E RID: 20494 RVA: 0x00060310 File Offset: 0x0005E710
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001103 RID: 4355
		// (get) Token: 0x0600500F RID: 20495 RVA: 0x00060318 File Offset: 0x0005E718
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005010 RID: 20496 RVA: 0x00060320 File Offset: 0x0005E720
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005011 RID: 20497 RVA: 0x00060330 File Offset: 0x0005E730
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E14 RID: 15892
		internal Effects8 $this;

		// Token: 0x04003E15 RID: 15893
		internal object $current;

		// Token: 0x04003E16 RID: 15894
		internal bool $disposing;

		// Token: 0x04003E17 RID: 15895
		internal int $PC;
	}
}
