using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class PlayerInBattleStatus : MonoBehaviour
{
	// Token: 0x060017B9 RID: 6073 RVA: 0x000B6E70 File Offset: 0x000B5270
	public PlayerInBattleStatus()
	{
	}

	// Token: 0x060017BA RID: 6074 RVA: 0x000B6E78 File Offset: 0x000B5278
	private void Start()
	{
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x000B6E7C File Offset: 0x000B527C
	public IEnumerable SawResourceEncounter()
	{
		yield return new WaitForSeconds(2f);
		this.QuestionMark.SetActive(false);
		yield break;
	}

	// Token: 0x060017BC RID: 6076 RVA: 0x000B6E9F File Offset: 0x000B529F
	public void InCollection()
	{
		this.QuestionMark.SetActive(false);
		this.CannotCollectResource.SetActive(false);
		this.CanCollect.SetActive(true);
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x000B6EC5 File Offset: 0x000B52C5
	public void FinishedEncounter()
	{
		this.QuestionMark.SetActive(false);
		this.CanCollect.SetActive(false);
		this.CannotCollectResource.SetActive(false);
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x000B6EEC File Offset: 0x000B52EC
	public IEnumerable CannotCollectResourcePonit()
	{
		yield return new WaitForSeconds(1f);
		this.CannotCollectResource.SetActive(false);
		yield break;
	}

	// Token: 0x0400178F RID: 6031
	public GameObject CannotCollectResource;

	// Token: 0x04001790 RID: 6032
	public GameObject QuestionMark;

	// Token: 0x04001791 RID: 6033
	public GameObject CanCollect;

	// Token: 0x02000CBF RID: 3263
	[CompilerGenerated]
	private sealed class <SawResourceEncounter>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600544C RID: 21580 RVA: 0x000B6F0F File Offset: 0x000B530F
		[DebuggerHidden]
		public <SawResourceEncounter>c__Iterator0()
		{
		}

		// Token: 0x0600544D RID: 21581 RVA: 0x000B6F18 File Offset: 0x000B5318
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.QuestionMark.SetActive(false);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011E2 RID: 4578
		// (get) Token: 0x0600544E RID: 21582 RVA: 0x000B6F85 File Offset: 0x000B5385
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011E3 RID: 4579
		// (get) Token: 0x0600544F RID: 21583 RVA: 0x000B6F8D File Offset: 0x000B538D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005450 RID: 21584 RVA: 0x000B6F95 File Offset: 0x000B5395
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005451 RID: 21585 RVA: 0x000B6FA5 File Offset: 0x000B53A5
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005452 RID: 21586 RVA: 0x000B6FAC File Offset: 0x000B53AC
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005453 RID: 21587 RVA: 0x000B6FB4 File Offset: 0x000B53B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PlayerInBattleStatus.<SawResourceEncounter>c__Iterator0 <SawResourceEncounter>c__Iterator = new PlayerInBattleStatus.<SawResourceEncounter>c__Iterator0();
			<SawResourceEncounter>c__Iterator.$this = this;
			return <SawResourceEncounter>c__Iterator;
		}

		// Token: 0x040041C3 RID: 16835
		internal PlayerInBattleStatus $this;

		// Token: 0x040041C4 RID: 16836
		internal object $current;

		// Token: 0x040041C5 RID: 16837
		internal bool $disposing;

		// Token: 0x040041C6 RID: 16838
		internal int $PC;
	}

	// Token: 0x02000CC0 RID: 3264
	[CompilerGenerated]
	private sealed class <CannotCollectResourcePonit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005454 RID: 21588 RVA: 0x000B6FE8 File Offset: 0x000B53E8
		[DebuggerHidden]
		public <CannotCollectResourcePonit>c__Iterator1()
		{
		}

		// Token: 0x06005455 RID: 21589 RVA: 0x000B6FF0 File Offset: 0x000B53F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.CannotCollectResource.SetActive(false);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011E4 RID: 4580
		// (get) Token: 0x06005456 RID: 21590 RVA: 0x000B705D File Offset: 0x000B545D
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011E5 RID: 4581
		// (get) Token: 0x06005457 RID: 21591 RVA: 0x000B7065 File Offset: 0x000B5465
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005458 RID: 21592 RVA: 0x000B706D File Offset: 0x000B546D
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005459 RID: 21593 RVA: 0x000B707D File Offset: 0x000B547D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600545A RID: 21594 RVA: 0x000B7084 File Offset: 0x000B5484
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600545B RID: 21595 RVA: 0x000B708C File Offset: 0x000B548C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PlayerInBattleStatus.<CannotCollectResourcePonit>c__Iterator1 <CannotCollectResourcePonit>c__Iterator = new PlayerInBattleStatus.<CannotCollectResourcePonit>c__Iterator1();
			<CannotCollectResourcePonit>c__Iterator.$this = this;
			return <CannotCollectResourcePonit>c__Iterator;
		}

		// Token: 0x040041C7 RID: 16839
		internal PlayerInBattleStatus $this;

		// Token: 0x040041C8 RID: 16840
		internal object $current;

		// Token: 0x040041C9 RID: 16841
		internal bool $disposing;

		// Token: 0x040041CA RID: 16842
		internal int $PC;
	}
}
