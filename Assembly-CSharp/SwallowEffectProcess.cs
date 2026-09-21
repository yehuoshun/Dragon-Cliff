using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000931 RID: 2353
public class SwallowEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004114 RID: 16660 RVA: 0x001A7628 File Offset: 0x001A5A28
	public SwallowEffectProcess()
	{
	}

	// Token: 0x17000C21 RID: 3105
	// (get) Token: 0x06004115 RID: 16661 RVA: 0x001A7630 File Offset: 0x001A5A30
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Swallow;
		}
	}

	// Token: 0x17000C22 RID: 3106
	// (get) Token: 0x06004116 RID: 16662 RVA: 0x001A7634 File Offset: 0x001A5A34
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitCompletesTurn
			};
		}
	}

	// Token: 0x06004117 RID: 16663 RVA: 0x001A7658 File Offset: 0x001A5A58
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitReadyInBattle || evtType == AdventureEventType.UnitCompletesTurn) && triggerUnit == effectCarrier && specialEffectData is SwallowData)
		{
			SwallowData data = specialEffectData as SwallowData;
			List<IBattleUnit> enemies = effectCarrier.GetLiveEnemyTargets(false, false);
			foreach (IBattleUnit battleUnit in enemies)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new EvilThirstEffect(data.SwallowCounts, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamagePercentage, new int?(data.LastingTurns), null, effectCarrier), false).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000FCF RID: 4047
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600668D RID: 26253 RVA: 0x001A7691 File Offset: 0x001A5A91
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600668E RID: 26254 RVA: 0x001A769C File Offset: 0x001A5A9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitReadyInBattle && evtType != AdventureEventType.UnitCompletesTurn) || triggerUnit != effectCarrier || !(specialEffectData is SwallowData))
				{
					goto IL_1CB;
				}
				data = (specialEffectData as SwallowData);
				enemies = effectCarrier.GetLiveEnemyTargets(false, false);
				enumerator = enemies.GetEnumerator();
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
				case 1u:
					Block_7:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new EvilThirstEffect(data.SwallowCounts, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamagePercentage, new int?(data.LastingTurns), null, effectCarrier), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1CB:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001583 RID: 5507
		// (get) Token: 0x0600668F RID: 26255 RVA: 0x001A78B4 File Offset: 0x001A5CB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001584 RID: 5508
		// (get) Token: 0x06006690 RID: 26256 RVA: 0x001A78BC File Offset: 0x001A5CBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006691 RID: 26257 RVA: 0x001A78C4 File Offset: 0x001A5CC4
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
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006692 RID: 26258 RVA: 0x001A7958 File Offset: 0x001A5D58
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006693 RID: 26259 RVA: 0x001A795F File Offset: 0x001A5D5F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006694 RID: 26260 RVA: 0x001A7968 File Offset: 0x001A5D68
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SwallowEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SwallowEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005FAC RID: 24492
		internal AdventureEventType evtType;

		// Token: 0x04005FAD RID: 24493
		internal IBattleUnit triggerUnit;

		// Token: 0x04005FAE RID: 24494
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FAF RID: 24495
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FB0 RID: 24496
		internal SwallowData <data>__1;

		// Token: 0x04005FB1 RID: 24497
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04005FB2 RID: 24498
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005FB3 RID: 24499
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005FB4 RID: 24500
		internal IEnumerator $locvar1;

		// Token: 0x04005FB5 RID: 24501
		internal object <_>__3;

		// Token: 0x04005FB6 RID: 24502
		internal IDisposable $locvar2;

		// Token: 0x04005FB7 RID: 24503
		internal object $current;

		// Token: 0x04005FB8 RID: 24504
		internal bool $disposing;

		// Token: 0x04005FB9 RID: 24505
		internal int $PC;
	}
}
