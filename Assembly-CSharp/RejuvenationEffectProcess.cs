using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000918 RID: 2328
public class RejuvenationEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600409F RID: 16543 RVA: 0x001A1A28 File Offset: 0x0019FE28
	public RejuvenationEffectProcess()
	{
	}

	// Token: 0x17000BF1 RID: 3057
	// (get) Token: 0x060040A0 RID: 16544 RVA: 0x001A1A30 File Offset: 0x0019FE30
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Rejuvenation;
		}
	}

	// Token: 0x17000BF2 RID: 3058
	// (get) Token: 0x060040A1 RID: 16545 RVA: 0x001A1A34 File Offset: 0x0019FE34
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x060040A2 RID: 16546 RVA: 0x001A1A3C File Offset: 0x0019FE3C
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is RejuvenationEffectData)
		{
			RejuvenationEffectData data = specialEffectData as RejuvenationEffectData;
			ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.Rate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)
			}, effectCarrier);
			IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x02000FA7 RID: 4007
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006586 RID: 25990 RVA: 0x001A1A66 File Offset: 0x0019FE66
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006587 RID: 25991 RVA: 0x001A1A70 File Offset: 0x0019FE70
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(specialEffectData is RejuvenationEffectData))
				{
					goto IL_157;
				}
				data = (specialEffectData as RejuvenationEffectData);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.Rate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_157:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001547 RID: 5447
		// (get) Token: 0x06006588 RID: 25992 RVA: 0x001A1BF0 File Offset: 0x0019FFF0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001548 RID: 5448
		// (get) Token: 0x06006589 RID: 25993 RVA: 0x001A1BF8 File Offset: 0x0019FFF8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600658A RID: 25994 RVA: 0x001A1C00 File Offset: 0x001A0000
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600658B RID: 25995 RVA: 0x001A1C70 File Offset: 0x001A0070
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600658C RID: 25996 RVA: 0x001A1C77 File Offset: 0x001A0077
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600658D RID: 25997 RVA: 0x001A1C80 File Offset: 0x001A0080
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RejuvenationEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new RejuvenationEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005E33 RID: 24115
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E34 RID: 24116
		internal RejuvenationEffectData <data>__1;

		// Token: 0x04005E35 RID: 24117
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E36 RID: 24118
		internal ReleaseableHeal <releaseableHeal>__1;

		// Token: 0x04005E37 RID: 24119
		internal IEnumerator $locvar0;

		// Token: 0x04005E38 RID: 24120
		internal object <_>__2;

		// Token: 0x04005E39 RID: 24121
		internal IDisposable $locvar1;

		// Token: 0x04005E3A RID: 24122
		internal object $current;

		// Token: 0x04005E3B RID: 24123
		internal bool $disposing;

		// Token: 0x04005E3C RID: 24124
		internal int $PC;
	}
}
