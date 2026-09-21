using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class Effects4 : MonoBehaviour
{
	// Token: 0x060005BB RID: 1467 RVA: 0x0005FB2C File Offset: 0x0005DF2C
	public Effects4()
	{
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x0005FB34 File Offset: 0x0005DF34
	private void Awake()
	{
		this._t = base.transform;
		this._effects = base.GetComponentInParent<Effects>();
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x0005FB4E File Offset: 0x0005DF4E
	private void Start()
	{
		base.StartCoroutine(this.Test());
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x0005FB60 File Offset: 0x0005DF60
	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.333f);
		for (;;)
		{
			int random = UnityEngine.Random.Range(0, 3);
			if (random == 0)
			{
				this._effects.TriggerSlash((float)UnityEngine.Random.Range(0, 3), this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerClaw(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerSplatterBlood(this._t.localPosition);
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
		}
		yield break;
	}

	// Token: 0x040008C3 RID: 2243
	private Transform _t;

	// Token: 0x040008C4 RID: 2244
	private Effects _effects;

	// Token: 0x02000BC8 RID: 3016
	[CompilerGenerated]
	private sealed class <Test>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06004FF4 RID: 20468 RVA: 0x0005FB7B File Offset: 0x0005DF7B
		[DebuggerHidden]
		public <Test>c__Iterator0()
		{
		}

		// Token: 0x06004FF5 RID: 20469 RVA: 0x0005FB84 File Offset: 0x0005DF84
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
				this._effects.TriggerSlash((float)UnityEngine.Random.Range(0, 3), this._t.localPosition);
			}
			else if (random == 1)
			{
				this._effects.TriggerClaw(UnityEngine.Random.value > 0.5f, this._t.localPosition);
			}
			else if (random == 2)
			{
				this._effects.TriggerSplatterBlood(this._t.localPosition);
			}
			this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x06004FF6 RID: 20470 RVA: 0x0005FCD4 File Offset: 0x0005E0D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x06004FF7 RID: 20471 RVA: 0x0005FCDC File Offset: 0x0005E0DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004FF8 RID: 20472 RVA: 0x0005FCE4 File Offset: 0x0005E0E4
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06004FF9 RID: 20473 RVA: 0x0005FCF4 File Offset: 0x0005E0F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E02 RID: 15874
		internal int <random>__1;

		// Token: 0x04003E03 RID: 15875
		internal Effects4 $this;

		// Token: 0x04003E04 RID: 15876
		internal object $current;

		// Token: 0x04003E05 RID: 15877
		internal bool $disposing;

		// Token: 0x04003E06 RID: 15878
		internal int $PC;
	}
}
