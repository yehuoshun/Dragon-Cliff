using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000902 RID: 2306
public class LifeRegenEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600403E RID: 16446 RVA: 0x0019CCD9 File Offset: 0x0019B0D9
	public LifeRegenEffectProcess()
	{
	}

	// Token: 0x17000BC4 RID: 3012
	// (get) Token: 0x0600403F RID: 16447 RVA: 0x0019CCE1 File Offset: 0x0019B0E1
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LifeRegen;
		}
	}

	// Token: 0x17000BC5 RID: 3013
	// (get) Token: 0x06004040 RID: 16448 RVA: 0x0019CCE8 File Offset: 0x0019B0E8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06004041 RID: 16449 RVA: 0x0019CD0C File Offset: 0x0019B10C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is LifeRegenData)
		{
			LifeRegenData lifeRegenData = specialEffectData as LifeRegenData;
			lifeRegenData.TriggeredInBattle = false;
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && specialEffectData is LifeRegenData)
		{
			LifeRegenData data = specialEffectData as LifeRegenData;
			if (!data.TriggeredInBattle && effectCarrier.HealthPoints / effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) < LifeRegenTalent.MinimumLife)
			{
				LifeRegenTalent talent = effectCarrier.GetActiveTalents().OfType<LifeRegenTalent>().FirstOrDefault<LifeRegenTalent>();
				if (talent != null)
				{
					double rate = LifeRegenTalent.RegenRate * (double)talent.GetCurrentLevel();
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(rate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill)), null, OutputType.RealDamage, effectCarrier, effectCarrier, "liferegentalent", new int?(LifeRegenTalent.RegenSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x02000F90 RID: 3984
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064D8 RID: 25816 RVA: 0x0019CD45 File Offset: 0x0019B145
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060064D9 RID: 25817 RVA: 0x0019CD50 File Offset: 0x0019B150
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is LifeRegenData)
				{
					LifeRegenData lifeRegenData = specialEffectData as LifeRegenData;
					lifeRegenData.TriggeredInBattle = false;
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(specialEffectData is LifeRegenData))
				{
					goto IL_1FC;
				}
				data = (specialEffectData as LifeRegenData);
				if (data.TriggeredInBattle || effectCarrier.HealthPoints / effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) >= LifeRegenTalent.MinimumLife)
				{
					goto IL_1FC;
				}
				talent = effectCarrier.GetActiveTalents().OfType<LifeRegenTalent>().FirstOrDefault<LifeRegenTalent>();
				if (talent == null)
				{
					goto IL_1FC;
				}
				rate = LifeRegenTalent.RegenRate * (double)talent.GetCurrentLevel();
				enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(rate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill)), null, OutputType.RealDamage, effectCarrier, effectCarrier, "liferegentalent", new int?(LifeRegenTalent.RegenSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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
			IL_1FC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700151F RID: 5407
		// (get) Token: 0x060064DA RID: 25818 RVA: 0x0019CF74 File Offset: 0x0019B374
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001520 RID: 5408
		// (get) Token: 0x060064DB RID: 25819 RVA: 0x0019CF7C File Offset: 0x0019B37C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064DC RID: 25820 RVA: 0x0019CF84 File Offset: 0x0019B384
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

		// Token: 0x060064DD RID: 25821 RVA: 0x0019CFF4 File Offset: 0x0019B3F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064DE RID: 25822 RVA: 0x0019CFFB File Offset: 0x0019B3FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064DF RID: 25823 RVA: 0x0019D004 File Offset: 0x0019B404
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeRegenEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new LifeRegenEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D15 RID: 23829
		internal AdventureEventType evtType;

		// Token: 0x04005D16 RID: 23830
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D17 RID: 23831
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D18 RID: 23832
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D19 RID: 23833
		internal LifeRegenData <data>__1;

		// Token: 0x04005D1A RID: 23834
		internal LifeRegenTalent <talent>__2;

		// Token: 0x04005D1B RID: 23835
		internal double <rate>__3;

		// Token: 0x04005D1C RID: 23836
		internal IEnumerator $locvar0;

		// Token: 0x04005D1D RID: 23837
		internal object <_>__4;

		// Token: 0x04005D1E RID: 23838
		internal IDisposable $locvar1;

		// Token: 0x04005D1F RID: 23839
		internal object $current;

		// Token: 0x04005D20 RID: 23840
		internal bool $disposing;

		// Token: 0x04005D21 RID: 23841
		internal int $PC;
	}
}
