using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000917 RID: 2327
public class ReincarnationEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600409B RID: 16539 RVA: 0x001A1430 File Offset: 0x0019F830
	public ReincarnationEffectProcess()
	{
	}

	// Token: 0x17000BEF RID: 3055
	// (get) Token: 0x0600409C RID: 16540 RVA: 0x001A146B File Offset: 0x0019F86B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BF0 RID: 3056
	// (get) Token: 0x0600409D RID: 16541 RVA: 0x001A1473 File Offset: 0x0019F873
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x0600409E RID: 16542 RVA: 0x001A147C File Offset: 0x0019F87C
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts && specialEffectData is ReincarnationData)
		{
			List<IBattleUnit> healers = (from u in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
			where u.IsAliveInBattle() && u.GetUnitClassStyle() == UnitClassStyle.Healer
			select u).ToList<IBattleUnit>();
			if (healers.Any<IBattleUnit>())
			{
				ReincarnationData data = specialEffectData as ReincarnationData;
				double totalHealValue = healers.Sum((IBattleUnit h) => h.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value) * data.HealRate;
				if (totalHealValue > 0.0)
				{
					IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
					if (ReincarnationEffectProcess.<>f__mg$cache0 == null)
					{
						ReincarnationEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
					}
					ReleaseableHeal releaseableHeal = new ReleaseableHeal((from u in playerUnits.Where(ReincarnationEffectProcess.<>f__mg$cache0)
					select new BattleHeal(u, healers.First<IBattleUnit>(), new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHealValue,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}.ToList<HealComponentValue>(), false)).ToList<BattleHeal>(), healers.First<IBattleUnit>());
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
			}
		}
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.EventTriggeringUnit.IsPlayer && evt.AdditionalData is DamageComponent && specialEffectData is ReincarnationData)
		{
			DamageComponent damageComponent = evt.AdditionalData as DamageComponent;
			if (damageComponent.IsDirectDamage && damageComponent.GetTotalDamageSoFar_WithoutNeutralization() > 0.0)
			{
				ReincarnationData reincarnationData = specialEffectData as ReincarnationData;
				double num = reincarnationData.DamageSuctionRate * damageComponent.GetTotalDamageSoFar_WithoutNeutralization();
				if (num > 0.0)
				{
					IEnumerator enumerator2 = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = evt.EventTriggeringUnit.GetOutputAttributeType(),
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = num
						}
					}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "reinc", new int?(10), null, null, false, true, false), false).GetEnumerator();
					try
					{
						if (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							yield break;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002FAB RID: 12203
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Reincarnation;

	// Token: 0x04002FAC RID: 12204
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.BattleEncounterStarts,
		AdventureEventType.UnitPostReceivesDamage_Single
	};

	// Token: 0x04002FAD RID: 12205
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x02000FA4 RID: 4004
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006579 RID: 25977 RVA: 0x001A14A6 File Offset: 0x0019F8A6
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600657A RID: 25978 RVA: 0x001A14B0 File Offset: 0x0019F8B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts || !(specialEffectData is ReincarnationData))
				{
					goto IL_256;
				}
				<AsAdventureEffectProcess>c__AnonStorey = new ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1();
				<AsAdventureEffectProcess>c__AnonStorey.<>f__ref$0 = this;
				<AsAdventureEffectProcess>c__AnonStorey.healers = (from u in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
				where u.IsAliveInBattle() && u.GetUnitClassStyle() == UnitClassStyle.Healer
				select u).ToList<IBattleUnit>();
				if (!<AsAdventureEffectProcess>c__AnonStorey.healers.Any<IBattleUnit>())
				{
					goto IL_256;
				}
				data = (specialEffectData as ReincarnationData);
				double totalHealValue = <AsAdventureEffectProcess>c__AnonStorey.healers.Sum((IBattleUnit h) => h.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value) * data.HealRate;
				if (totalHealValue <= 0.0)
				{
					goto IL_256;
				}
				IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (ReincarnationEffectProcess.<>f__mg$cache0 == null)
				{
					ReincarnationEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				releaseableHeal = new ReleaseableHeal((from u in playerUnits.Where(ReincarnationEffectProcess.<>f__mg$cache0)
				select new BattleHeal(u, <AsAdventureEffectProcess>c__AnonStorey.healers.First<IBattleUnit>(), new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = totalHealValue,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}.ToList<HealComponentValue>(), false)).ToList<BattleHeal>(), <AsAdventureEffectProcess>c__AnonStorey.healers.First<IBattleUnit>());
				enumerator = releaseableHeal.Release().GetEnumerator();
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
			IL_256:
			if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.EventTriggeringUnit.IsPlayer && evt.AdditionalData is DamageComponent && specialEffectData is ReincarnationData)
			{
				DamageComponent damageComponent = evt.AdditionalData as DamageComponent;
				if (damageComponent.IsDirectDamage && damageComponent.GetTotalDamageSoFar_WithoutNeutralization() > 0.0)
				{
					ReincarnationData reincarnationData = specialEffectData as ReincarnationData;
					double num2 = reincarnationData.DamageSuctionRate * damageComponent.GetTotalDamageSoFar_WithoutNeutralization();
					if (num2 > 0.0)
					{
						IEnumerator enumerator2 = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeModifierType = AttributeModifierType.Skill,
								AttributeType = evt.EventTriggeringUnit.GetOutputAttributeType(),
								Key = string.Empty,
								ModificationType = ModificationType.Addition,
								Value = num2
							}
						}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "reinc", new int?(10), null, null, false, true, false), false).GetEnumerator();
						try
						{
							if (enumerator2.MoveNext())
							{
								object obj = enumerator2.Current;
								return false;
							}
						}
						finally
						{
							IDisposable disposable2;
							if ((disposable2 = (enumerator2 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001545 RID: 5445
		// (get) Token: 0x0600657B RID: 25979 RVA: 0x001A18C8 File Offset: 0x0019FCC8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001546 RID: 5446
		// (get) Token: 0x0600657C RID: 25980 RVA: 0x001A18D0 File Offset: 0x0019FCD0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600657D RID: 25981 RVA: 0x001A18D8 File Offset: 0x0019FCD8
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

		// Token: 0x0600657E RID: 25982 RVA: 0x001A1948 File Offset: 0x0019FD48
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600657F RID: 25983 RVA: 0x001A194F File Offset: 0x0019FD4F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006580 RID: 25984 RVA: 0x001A1958 File Offset: 0x0019FD58
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x06006581 RID: 25985 RVA: 0x001A1998 File Offset: 0x0019FD98
		private static bool <>m__0(IBattleUnit u)
		{
			return u.IsAliveInBattle() && u.GetUnitClassStyle() == UnitClassStyle.Healer;
		}

		// Token: 0x06006582 RID: 25986 RVA: 0x001A19B2 File Offset: 0x0019FDB2
		private static double <>m__1(IBattleUnit h)
		{
			return h.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
		}

		// Token: 0x04005E20 RID: 24096
		internal BroadcastEvent evt;

		// Token: 0x04005E21 RID: 24097
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E22 RID: 24098
		internal ReincarnationData <data>__2;

		// Token: 0x04005E23 RID: 24099
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04005E24 RID: 24100
		internal IEnumerator $locvar0;

		// Token: 0x04005E25 RID: 24101
		internal object <_>__4;

		// Token: 0x04005E26 RID: 24102
		internal IDisposable $locvar1;

		// Token: 0x04005E27 RID: 24103
		internal object $current;

		// Token: 0x04005E28 RID: 24104
		internal bool $disposing;

		// Token: 0x04005E29 RID: 24105
		internal int $PC;

		// Token: 0x04005E2A RID: 24106
		private ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 $locvar4;

		// Token: 0x04005E2B RID: 24107
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x04005E2C RID: 24108
		private ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey2 $locvar5;

		// Token: 0x04005E2D RID: 24109
		private static Func<IBattleUnit, double> <>f__am$cache1;

		// Token: 0x02000FA5 RID: 4005
		private sealed class <AsAdventureEffectProcess>c__AnonStorey1
		{
			// Token: 0x06006583 RID: 25987 RVA: 0x001A19C0 File Offset: 0x0019FDC0
			public <AsAdventureEffectProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04005E2E RID: 24110
			internal List<IBattleUnit> healers;

			// Token: 0x04005E2F RID: 24111
			internal ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000FA6 RID: 4006
		private sealed class <AsAdventureEffectProcess>c__AnonStorey2
		{
			// Token: 0x06006584 RID: 25988 RVA: 0x001A19C8 File Offset: 0x0019FDC8
			public <AsAdventureEffectProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06006585 RID: 25989 RVA: 0x001A19D0 File Offset: 0x0019FDD0
			internal BattleHeal <>m__0(IBattleUnit u)
			{
				return new BattleHeal(u, this.<>f__ref$1.healers.First<IBattleUnit>(), new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.totalHealValue,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}.ToList<HealComponentValue>(), false);
			}

			// Token: 0x04005E30 RID: 24112
			internal double totalHealValue;

			// Token: 0x04005E31 RID: 24113
			internal ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005E32 RID: 24114
			internal ReincarnationEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
