using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093F RID: 2367
public class WarmFlowEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004157 RID: 16727 RVA: 0x001ACC3C File Offset: 0x001AB03C
	public WarmFlowEffectProcess()
	{
	}

	// Token: 0x17000C3D RID: 3133
	// (get) Token: 0x06004158 RID: 16728 RVA: 0x001ACC44 File Offset: 0x001AB044
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.WarmFlow;
		}
	}

	// Token: 0x17000C3E RID: 3134
	// (get) Token: 0x06004159 RID: 16729 RVA: 0x001ACC48 File Offset: 0x001AB048
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x0600415A RID: 16730 RVA: 0x001ACC64 File Offset: 0x001AB064
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts && specialEffectData is WarmFlowData)
		{
			WarmFlowData data = specialEffectData as WarmFlowData;
			IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
			if (WarmFlowEffectProcess.<>f__mg$cache0 == null)
			{
				WarmFlowEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			IEnumerable<IBattleUnit> targets = playerUnits.Where(WarmFlowEffectProcess.<>f__mg$cache0);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				IBattleUnit toHeal = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(target).FirstOrDefault<IBattleUnit>();
				if (toHeal != null)
				{
					IEnumerator enumerator = toHeal.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(toHeal.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, toHeal, toHeal, "warmflow", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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
			data.Counter = 0;
		}
		yield break;
	}

	// Token: 0x0600415B RID: 16731 RVA: 0x001ACC90 File Offset: 0x001AB090
	public override IEnumerable AsAdventureEffectPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IEncounter encounter)
	{
		if (specialEffectData is WarmFlowData)
		{
			WarmFlowData data = specialEffectData as WarmFlowData;
			data.Counter++;
			if (data.Counter >= data.MaxSeconds)
			{
				IEnumerable<IBattleUnit> playerUnits = encounter.PlayerUnits;
				if (WarmFlowEffectProcess.<>f__mg$cache1 == null)
				{
					WarmFlowEffectProcess.<>f__mg$cache1 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				IEnumerable<IBattleUnit> targets = playerUnits.Where(WarmFlowEffectProcess.<>f__mg$cache1);
				IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
				if (target != null)
				{
					IBattleUnit toHeal = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(target).FirstOrDefault<IBattleUnit>();
					if (toHeal != null)
					{
						IEnumerator enumerator = toHeal.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(toHeal.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, toHeal, toHeal, "warmflow", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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
						data.Counter = 0;
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040030E9 RID: 12521
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x040030EA RID: 12522
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache1;

	// Token: 0x02000FE9 RID: 4073
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600672D RID: 26413 RVA: 0x001ACCBA File Offset: 0x001AB0BA
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600672E RID: 26414 RVA: 0x001ACCC4 File Offset: 0x001AB0C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts || !(specialEffectData is WarmFlowData))
				{
					return false;
				}
				data = (specialEffectData as WarmFlowData);
				IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (WarmFlowEffectProcess.<>f__mg$cache0 == null)
				{
					WarmFlowEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				targets = playerUnits.Where(WarmFlowEffectProcess.<>f__mg$cache0);
				target = targets.FirstOrDefault<IBattleUnit>();
				if (target == null)
				{
					goto IL_1D1;
				}
				toHeal = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(target).FirstOrDefault<IBattleUnit>();
				if (toHeal == null)
				{
					goto IL_1D1;
				}
				enumerator = toHeal.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(toHeal.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, toHeal, toHeal, "warmflow", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1D1:
			data.Counter = 0;
			return false;
		}

		// Token: 0x170015A5 RID: 5541
		// (get) Token: 0x0600672F RID: 26415 RVA: 0x001ACED0 File Offset: 0x001AB2D0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015A6 RID: 5542
		// (get) Token: 0x06006730 RID: 26416 RVA: 0x001ACED8 File Offset: 0x001AB2D8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006731 RID: 26417 RVA: 0x001ACEE0 File Offset: 0x001AB2E0
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

		// Token: 0x06006732 RID: 26418 RVA: 0x001ACF50 File Offset: 0x001AB350
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006733 RID: 26419 RVA: 0x001ACF57 File Offset: 0x001AB357
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006734 RID: 26420 RVA: 0x001ACF60 File Offset: 0x001AB360
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			WarmFlowEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new WarmFlowEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x040060F7 RID: 24823
		internal BroadcastEvent evt;

		// Token: 0x040060F8 RID: 24824
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060F9 RID: 24825
		internal WarmFlowData <data>__1;

		// Token: 0x040060FA RID: 24826
		internal IEnumerable<IBattleUnit> <targets>__1;

		// Token: 0x040060FB RID: 24827
		internal IBattleUnit <target>__1;

		// Token: 0x040060FC RID: 24828
		internal IBattleUnit <toHeal>__2;

		// Token: 0x040060FD RID: 24829
		internal IEnumerator $locvar0;

		// Token: 0x040060FE RID: 24830
		internal object <_>__3;

		// Token: 0x040060FF RID: 24831
		internal IDisposable $locvar1;

		// Token: 0x04006100 RID: 24832
		internal object $current;

		// Token: 0x04006101 RID: 24833
		internal bool $disposing;

		// Token: 0x04006102 RID: 24834
		internal int $PC;
	}

	// Token: 0x02000FEA RID: 4074
	[CompilerGenerated]
	private sealed class <AsAdventureEffectPerSecondProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006735 RID: 26421 RVA: 0x001ACFA0 File Offset: 0x001AB3A0
		[DebuggerHidden]
		public <AsAdventureEffectPerSecondProcess>c__Iterator1()
		{
		}

		// Token: 0x06006736 RID: 26422 RVA: 0x001ACFA8 File Offset: 0x001AB3A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (!(specialEffectData is WarmFlowData))
				{
					goto IL_1EF;
				}
				data = (specialEffectData as WarmFlowData);
				data.Counter++;
				if (data.Counter < data.MaxSeconds)
				{
					goto IL_1EF;
				}
				IEnumerable<IBattleUnit> playerUnits = encounter.PlayerUnits;
				if (WarmFlowEffectProcess.<>f__mg$cache1 == null)
				{
					WarmFlowEffectProcess.<>f__mg$cache1 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				targets = playerUnits.Where(WarmFlowEffectProcess.<>f__mg$cache1);
				target = targets.FirstOrDefault<IBattleUnit>();
				if (target == null)
				{
					goto IL_1EF;
				}
				toHeal = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(target).FirstOrDefault<IBattleUnit>();
				if (toHeal == null)
				{
					goto IL_1EF;
				}
				enumerator = toHeal.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(toHeal.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, toHeal, toHeal, "warmflow", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			data.Counter = 0;
			IL_1EF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015A7 RID: 5543
		// (get) Token: 0x06006737 RID: 26423 RVA: 0x001AD1C0 File Offset: 0x001AB5C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015A8 RID: 5544
		// (get) Token: 0x06006738 RID: 26424 RVA: 0x001AD1C8 File Offset: 0x001AB5C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006739 RID: 26425 RVA: 0x001AD1D0 File Offset: 0x001AB5D0
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

		// Token: 0x0600673A RID: 26426 RVA: 0x001AD240 File Offset: 0x001AB640
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600673B RID: 26427 RVA: 0x001AD247 File Offset: 0x001AB647
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600673C RID: 26428 RVA: 0x001AD250 File Offset: 0x001AB650
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			WarmFlowEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1 <AsAdventureEffectPerSecondProcess>c__Iterator = new WarmFlowEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1();
			<AsAdventureEffectPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsAdventureEffectPerSecondProcess>c__Iterator.encounter = encounter;
			return <AsAdventureEffectPerSecondProcess>c__Iterator;
		}

		// Token: 0x04006103 RID: 24835
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04006104 RID: 24836
		internal WarmFlowData <data>__1;

		// Token: 0x04006105 RID: 24837
		internal IEncounter encounter;

		// Token: 0x04006106 RID: 24838
		internal IEnumerable<IBattleUnit> <targets>__2;

		// Token: 0x04006107 RID: 24839
		internal IBattleUnit <target>__2;

		// Token: 0x04006108 RID: 24840
		internal IBattleUnit <toHeal>__3;

		// Token: 0x04006109 RID: 24841
		internal IEnumerator $locvar0;

		// Token: 0x0400610A RID: 24842
		internal object <_>__4;

		// Token: 0x0400610B RID: 24843
		internal IDisposable $locvar1;

		// Token: 0x0400610C RID: 24844
		internal object $current;

		// Token: 0x0400610D RID: 24845
		internal bool $disposing;

		// Token: 0x0400610E RID: 24846
		internal int $PC;
	}
}
