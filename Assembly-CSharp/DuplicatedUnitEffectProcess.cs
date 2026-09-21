using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D7 RID: 2263
public class DuplicatedUnitEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F80 RID: 16256 RVA: 0x00191A3B File Offset: 0x0018FE3B
	public DuplicatedUnitEffectProcess()
	{
	}

	// Token: 0x17000B70 RID: 2928
	// (get) Token: 0x06003F81 RID: 16257 RVA: 0x00191A43 File Offset: 0x0018FE43
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DuplicatedUnit;
		}
	}

	// Token: 0x17000B71 RID: 2929
	// (get) Token: 0x06003F82 RID: 16258 RVA: 0x00191A4C File Offset: 0x0018FE4C
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

	// Token: 0x06003F83 RID: 16259 RVA: 0x00191A68 File Offset: 0x0018FE68
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			int distinctUnits = (from p in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
			select p.GetUnitType()).Distinct<UnitClass>().Count<UnitClass>();
			int duplicatedNumberOfUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits.Count - distinctUnits;
			if (duplicatedNumberOfUnits > 0 && specialEffectData is DuplicatedUnitData)
			{
				double totalRate = (specialEffectData as DuplicatedUnitData).Rate * (double)duplicatedNumberOfUnits;
				if (totalRate > 0.95)
				{
					totalRate = 0.95;
				}
				IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (DuplicatedUnitEffectProcess.<>f__mg$cache0 == null)
				{
					DuplicatedUnitEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				foreach (IBattleUnit battleUnit in playerUnits.Where(DuplicatedUnitEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>())
				{
					IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(battleUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = battleUnit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Allresistances,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.CritRate,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Resilience,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "duplicatedunitpenalty", new int?(1), null, null, false, false), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x04002F80 RID: 12160
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x02000F56 RID: 3926
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006347 RID: 25415 RVA: 0x00191A92 File Offset: 0x0018FE92
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006348 RID: 25416 RVA: 0x00191A9C File Offset: 0x0018FE9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts)
				{
					goto IL_399;
				}
				distinctUnits = (from p in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
				select p.GetUnitType()).Distinct<UnitClass>().Count<UnitClass>();
				duplicatedNumberOfUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits.Count - distinctUnits;
				if (duplicatedNumberOfUnits <= 0 || !(specialEffectData is DuplicatedUnitData))
				{
					goto IL_399;
				}
				totalRate = (specialEffectData as DuplicatedUnitData).Rate * (double)duplicatedNumberOfUnits;
				if (totalRate > 0.95)
				{
					totalRate = 0.95;
				}
				IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (DuplicatedUnitEffectProcess.<>f__mg$cache0 == null)
				{
					DuplicatedUnitEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				enumerator = playerUnits.Where(DuplicatedUnitEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>().GetEnumerator();
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
				case 1u:
					Block_10:
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
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(battleUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = battleUnit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Allresistances,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.CritRate,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Resilience,
							ModificationType = ModificationType.Multiplication,
							Value = -totalRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "duplicatedunitpenalty", new int?(1), null, null, false, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_399:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014C9 RID: 5321
		// (get) Token: 0x06006349 RID: 25417 RVA: 0x00191E80 File Offset: 0x00190280
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014CA RID: 5322
		// (get) Token: 0x0600634A RID: 25418 RVA: 0x00191E88 File Offset: 0x00190288
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600634B RID: 25419 RVA: 0x00191E90 File Offset: 0x00190290
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

		// Token: 0x0600634C RID: 25420 RVA: 0x00191F24 File Offset: 0x00190324
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600634D RID: 25421 RVA: 0x00191F2B File Offset: 0x0019032B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600634E RID: 25422 RVA: 0x00191F34 File Offset: 0x00190334
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DuplicatedUnitEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new DuplicatedUnitEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x0600634F RID: 25423 RVA: 0x00191F74 File Offset: 0x00190374
		private static UnitClass <>m__0(IBattleUnit p)
		{
			return p.GetUnitType();
		}

		// Token: 0x04005A70 RID: 23152
		internal BroadcastEvent evt;

		// Token: 0x04005A71 RID: 23153
		internal int <distinctUnits>__1;

		// Token: 0x04005A72 RID: 23154
		internal int <duplicatedNumberOfUnits>__1;

		// Token: 0x04005A73 RID: 23155
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A74 RID: 23156
		internal double <totalRate>__2;

		// Token: 0x04005A75 RID: 23157
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005A76 RID: 23158
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x04005A77 RID: 23159
		internal IEnumerator $locvar1;

		// Token: 0x04005A78 RID: 23160
		internal object <_>__4;

		// Token: 0x04005A79 RID: 23161
		internal IDisposable $locvar2;

		// Token: 0x04005A7A RID: 23162
		internal object $current;

		// Token: 0x04005A7B RID: 23163
		internal bool $disposing;

		// Token: 0x04005A7C RID: 23164
		internal int $PC;

		// Token: 0x04005A7D RID: 23165
		private static Func<IBattleUnit, UnitClass> <>f__am$cache0;
	}
}
