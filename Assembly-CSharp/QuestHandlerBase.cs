using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020004CF RID: 1231
public abstract class QuestHandlerBase
{
	// Token: 0x060024F1 RID: 9457 RVA: 0x0010B044 File Offset: 0x00109444
	protected QuestHandlerBase()
	{
	}

	// Token: 0x1700027D RID: 637
	// (get) Token: 0x060024F2 RID: 9458 RVA: 0x0010B04C File Offset: 0x0010944C
	public virtual GenerationDistribution QuestQualityDistribution
	{
		get
		{
			GenerationDistribution generationDistribution = new GenerationDistribution(0.3, 0.15, 0.1, 0.05);
			double num = GameWorld.instance.PlayerProfile.GetResidentEffects<DivineHeartResidentEffect>().Sum((DivineHeartResidentEffect r) => r.CurrentRate);
			if (num > 10.0)
			{
				num = 10.0;
			}
			return generationDistribution.BoostDrop(num);
		}
	}

	// Token: 0x1700027E RID: 638
	// (get) Token: 0x060024F3 RID: 9459
	public abstract QuestChainIdentifier ChainIdentifier { get; }

	// Token: 0x060024F4 RID: 9460 RVA: 0x0010B0D5 File Offset: 0x001094D5
	public virtual void ProcessGameEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x060024F5 RID: 9461 RVA: 0x0010B0D8 File Offset: 0x001094D8
	public virtual IEnumerable ProcessAdventureEvent(BroadcastEvent evt)
	{
		yield break;
	}

	// Token: 0x060024F6 RID: 9462 RVA: 0x0010B0F4 File Offset: 0x001094F4
	[CompilerGenerated]
	private static double <get_QuestQualityDistribution>m__0(DivineHeartResidentEffect r)
	{
		return r.CurrentRate;
	}

	// Token: 0x04001FB0 RID: 8112
	[CompilerGenerated]
	private static Func<DivineHeartResidentEffect, double> <>f__am$cache0;

	// Token: 0x02000DAF RID: 3503
	[CompilerGenerated]
	private sealed class <ProcessAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600586B RID: 22635 RVA: 0x0010B0FC File Offset: 0x001094FC
		[DebuggerHidden]
		public <ProcessAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x0600586C RID: 22636 RVA: 0x0010B104 File Offset: 0x00109504
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700127E RID: 4734
		// (get) Token: 0x0600586D RID: 22637 RVA: 0x0010B11E File Offset: 0x0010951E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700127F RID: 4735
		// (get) Token: 0x0600586E RID: 22638 RVA: 0x0010B126 File Offset: 0x00109526
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600586F RID: 22639 RVA: 0x0010B12E File Offset: 0x0010952E
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005870 RID: 22640 RVA: 0x0010B130 File Offset: 0x00109530
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005871 RID: 22641 RVA: 0x0010B137 File Offset: 0x00109537
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005872 RID: 22642 RVA: 0x0010B13F File Offset: 0x0010953F
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new QuestHandlerBase.<ProcessAdventureEvent>c__Iterator0();
		}

		// Token: 0x04004856 RID: 18518
		internal object $current;

		// Token: 0x04004857 RID: 18519
		internal bool $disposing;

		// Token: 0x04004858 RID: 18520
		internal int $PC;
	}
}
