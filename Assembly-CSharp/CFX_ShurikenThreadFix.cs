using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000C7 RID: 199
public class CFX_ShurikenThreadFix : MonoBehaviour
{
	// Token: 0x06000612 RID: 1554 RVA: 0x0006143D File Offset: 0x0005F83D
	public CFX_ShurikenThreadFix()
	{
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x00061448 File Offset: 0x0005F848
	private void OnEnable()
	{
		this.systems = base.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in this.systems)
		{
			particleSystem.Stop(true);
			particleSystem.Clear(true);
		}
		base.StartCoroutine("WaitFrame");
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0006149C File Offset: 0x0005F89C
	private IEnumerator WaitFrame()
	{
		yield return null;
		foreach (ParticleSystem particleSystem in this.systems)
		{
			particleSystem.Play(true);
		}
		yield break;
	}

	// Token: 0x04000917 RID: 2327
	private ParticleSystem[] systems;

	// Token: 0x02000BD0 RID: 3024
	[CompilerGenerated]
	private sealed class <WaitFrame>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005024 RID: 20516 RVA: 0x000614B7 File Offset: 0x0005F8B7
		[DebuggerHidden]
		public <WaitFrame>c__Iterator0()
		{
		}

		// Token: 0x06005025 RID: 20517 RVA: 0x000614C0 File Offset: 0x0005F8C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				array = this.systems;
				for (i = 0; i < array.Length; i++)
				{
					ParticleSystem particleSystem = array[i];
					particleSystem.Play(true);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700110A RID: 4362
		// (get) Token: 0x06005026 RID: 20518 RVA: 0x00061566 File Offset: 0x0005F966
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700110B RID: 4363
		// (get) Token: 0x06005027 RID: 20519 RVA: 0x0006156E File Offset: 0x0005F96E
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005028 RID: 20520 RVA: 0x00061576 File Offset: 0x0005F976
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005029 RID: 20521 RVA: 0x00061586 File Offset: 0x0005F986
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E25 RID: 15909
		internal ParticleSystem[] $locvar0;

		// Token: 0x04003E26 RID: 15910
		internal int $locvar1;

		// Token: 0x04003E27 RID: 15911
		internal CFX_ShurikenThreadFix $this;

		// Token: 0x04003E28 RID: 15912
		internal object $current;

		// Token: 0x04003E29 RID: 15913
		internal bool $disposing;

		// Token: 0x04003E2A RID: 15914
		internal int $PC;
	}
}
