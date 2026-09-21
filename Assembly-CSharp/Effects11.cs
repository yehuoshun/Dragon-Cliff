using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class Effects11 : MonoBehaviour
{
	// Token: 0x060005AF RID: 1455 RVA: 0x0005F6E4 File Offset: 0x0005DAE4
	public Effects11()
	{
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x0005F6EC File Offset: 0x0005DAEC
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x0005F706 File Offset: 0x0005DB06
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0005F718 File Offset: 0x0005DB18
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				this._effects.TriggerTeleport(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerNuclear(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008BD RID: 2237
	private Transform _t;

	// Token: 0x040008BE RID: 2238
	private Effects _effects;

	// Token: 0x02000BC5 RID: 3013
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FE2 RID: 20450 RVA: 0x0005F733 File Offset: 0x0005DB33
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FE3 RID: 20451 RVA: 0x0005F73C File Offset: 0x0005DB3C
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
				this._effects.TriggerTeleport(this._t.localPosition);
			}
			else
			{
				this._effects.TriggerNuclear(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010F4 RID: 4340
		// (get) Token: 0x06004FE4 RID: 20452 RVA: 0x0005F82D File Offset: 0x0005DC2D
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010F5 RID: 4341
		// (get) Token: 0x06004FE5 RID: 20453 RVA: 0x0005F835 File Offset: 0x0005DC35
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FE6 RID: 20454 RVA: 0x0005F83D File Offset: 0x0005DC3D
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FE7 RID: 20455 RVA: 0x0005F84D File Offset: 0x0005DC4D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003DF6 RID: 15862
		internal Effects11 $this;

		// Token: 0x04003DF7 RID: 15863
		internal object $current;

		// Token: 0x04003DF8 RID: 15864
		internal bool $disposing;

		// Token: 0x04003DF9 RID: 15865
		internal int $PC;
	}
}
