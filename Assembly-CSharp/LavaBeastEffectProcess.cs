using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008FD RID: 2301
public class LavaBeastEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004027 RID: 16423 RVA: 0x0019AF5C File Offset: 0x0019935C
	public LavaBeastEffectProcess()
	{
	}

	// Token: 0x17000BBA RID: 3002
	// (get) Token: 0x06004028 RID: 16424 RVA: 0x0019AF6C File Offset: 0x0019936C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BBB RID: 3003
	// (get) Token: 0x06004029 RID: 16425 RVA: 0x0019AF74 File Offset: 0x00199374
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x0600402A RID: 16426 RVA: 0x0019AF98 File Offset: 0x00199398
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		LavaBeastEffectData data = specialEffectData as LavaBeastEffectData;
		if (data != null && (double)UnityEngine.Random.value <= data.FireSeedChancePerSecond)
		{
			List<IBattleUnit> playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
			if (playerUnits.Any<IBattleUnit>())
			{
				IBattleUnit selected = playerUnits[UnityEngine.Random.Range(0, playerUnits.Count)];
				IEnumerator enumerator = FireSeedEffect.AddFireSeed(selected, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600402B RID: 16427 RVA: 0x0019AFC4 File Offset: 0x001993C4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			LavaBeastEffectData lavaBeastEffectData = specialEffectData as LavaBeastEffectData;
			if (lavaBeastEffectData != null)
			{
				lavaBeastEffectData.HaveRevived = false;
			}
		}
		if (evtType == AdventureEventType.UnitPreKilled && triggerUnit == effectCarrier && triggerUnit.HealthPoints <= 0.0)
		{
			LavaBeastEffectData data = specialEffectData as LavaBeastEffectData;
			if (data != null && !data.HaveRevived)
			{
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
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
				data.HaveRevived = true;
				EnemyBattleUnit battleUnit = effectCarrier as EnemyBattleUnit;
				if (battleUnit != null)
				{
					AdventureUnitSkill currentMain = battleUnit.Skills.FirstOrDefault((AdventureUnitSkill sk) => sk.Skill.CommandType == SkillCommandType.Main);
					int skillLevel = (currentMain == null) ? 1 : currentMain.Skill.Level;
					battleUnit.Skills = (from sk in battleUnit.Skills
					where sk.Skill.CommandType != SkillCommandType.Main
					select sk).ToList<AdventureUnitSkill>();
					battleUnit.Skills.Add(data.SecondStageSkill.CreateMonsterSkill(skillLevel).InitializeBattleUnitSkill(battleUnit));
					IEnumerator enumerator2 = battleUnit.DoTurn().GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
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

	// Token: 0x04002F9B RID: 12187
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.LavaBeastEffect;

	// Token: 0x02000F86 RID: 3974
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006494 RID: 25748 RVA: 0x0019AFFD File Offset: 0x001993FD
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006495 RID: 25749 RVA: 0x0019B008 File Offset: 0x00199408
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as LavaBeastEffectData);
				if (data == null || (double)UnityEngine.Random.value > data.FireSeedChancePerSecond)
				{
					goto IL_14C;
				}
				playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
				if (!playerUnits.Any<IBattleUnit>())
				{
					goto IL_14C;
				}
				selected = playerUnits[UnityEngine.Random.Range(0, playerUnits.Count)];
				enumerator = FireSeedEffect.AddFireSeed(selected, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
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
			IL_14C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001511 RID: 5393
		// (get) Token: 0x06006496 RID: 25750 RVA: 0x0019B17C File Offset: 0x0019957C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001512 RID: 5394
		// (get) Token: 0x06006497 RID: 25751 RVA: 0x0019B184 File Offset: 0x00199584
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006498 RID: 25752 RVA: 0x0019B18C File Offset: 0x0019958C
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

		// Token: 0x06006499 RID: 25753 RVA: 0x0019B1FC File Offset: 0x001995FC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600649A RID: 25754 RVA: 0x0019B203 File Offset: 0x00199603
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600649B RID: 25755 RVA: 0x0019B20C File Offset: 0x0019960C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LavaBeastEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new LavaBeastEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005CA0 RID: 23712
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005CA1 RID: 23713
		internal LavaBeastEffectData <data>__0;

		// Token: 0x04005CA2 RID: 23714
		internal IBattleUnit effectCarrier;

		// Token: 0x04005CA3 RID: 23715
		internal List<IBattleUnit> <playerUnits>__1;

		// Token: 0x04005CA4 RID: 23716
		internal IBattleUnit <selected>__2;

		// Token: 0x04005CA5 RID: 23717
		internal IEnumerator $locvar0;

		// Token: 0x04005CA6 RID: 23718
		internal object <_>__3;

		// Token: 0x04005CA7 RID: 23719
		internal IDisposable $locvar1;

		// Token: 0x04005CA8 RID: 23720
		internal object $current;

		// Token: 0x04005CA9 RID: 23721
		internal bool $disposing;

		// Token: 0x04005CAA RID: 23722
		internal int $PC;
	}

	// Token: 0x02000F87 RID: 3975
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600649C RID: 25756 RVA: 0x0019B24C File Offset: 0x0019964C
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x0600649D RID: 25757 RVA: 0x0019B254 File Offset: 0x00199654
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
				{
					LavaBeastEffectData lavaBeastEffectData = specialEffectData as LavaBeastEffectData;
					if (lavaBeastEffectData != null)
					{
						lavaBeastEffectData.HaveRevived = false;
					}
				}
				if (evtType != AdventureEventType.UnitPreKilled || triggerUnit != effectCarrier || triggerUnit.HealthPoints > 0.0)
				{
					goto IL_364;
				}
				data = (specialEffectData as LavaBeastEffectData);
				if (data == null || data.HaveRevived)
				{
					goto IL_364;
				}
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2E0;
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
			data.HaveRevived = true;
			battleUnit = (effectCarrier as EnemyBattleUnit);
			if (battleUnit == null)
			{
				goto IL_364;
			}
			currentMain = battleUnit.Skills.FirstOrDefault((AdventureUnitSkill sk) => sk.Skill.CommandType == SkillCommandType.Main);
			skillLevel = ((currentMain == null) ? 1 : currentMain.Skill.Level);
			battleUnit.Skills = (from sk in battleUnit.Skills
			where sk.Skill.CommandType != SkillCommandType.Main
			select sk).ToList<AdventureUnitSkill>();
			battleUnit.Skills.Add(data.SecondStageSkill.CreateMonsterSkill(skillLevel).InitializeBattleUnitSkill(battleUnit));
			enumerator2 = battleUnit.DoTurn().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2E0:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_364:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001513 RID: 5395
		// (get) Token: 0x0600649E RID: 25758 RVA: 0x0019B5EC File Offset: 0x001999EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001514 RID: 5396
		// (get) Token: 0x0600649F RID: 25759 RVA: 0x0019B5F4 File Offset: 0x001999F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064A0 RID: 25760 RVA: 0x0019B5FC File Offset: 0x001999FC
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060064A1 RID: 25761 RVA: 0x0019B6AC File Offset: 0x00199AAC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064A2 RID: 25762 RVA: 0x0019B6B3 File Offset: 0x00199AB3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064A3 RID: 25763 RVA: 0x0019B6BC File Offset: 0x00199ABC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LavaBeastEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new LavaBeastEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060064A4 RID: 25764 RVA: 0x0019B714 File Offset: 0x00199B14
		private static bool <>m__0(AdventureUnitSkill sk)
		{
			return sk.Skill.CommandType == SkillCommandType.Main;
		}

		// Token: 0x060064A5 RID: 25765 RVA: 0x0019B724 File Offset: 0x00199B24
		private static bool <>m__1(AdventureUnitSkill sk)
		{
			return sk.Skill.CommandType != SkillCommandType.Main;
		}

		// Token: 0x04005CAB RID: 23723
		internal AdventureEventType evtType;

		// Token: 0x04005CAC RID: 23724
		internal IBattleUnit triggerUnit;

		// Token: 0x04005CAD RID: 23725
		internal IBattleUnit effectCarrier;

		// Token: 0x04005CAE RID: 23726
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005CAF RID: 23727
		internal LavaBeastEffectData <data>__1;

		// Token: 0x04005CB0 RID: 23728
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04005CB1 RID: 23729
		internal IEnumerator $locvar0;

		// Token: 0x04005CB2 RID: 23730
		internal object <_>__3;

		// Token: 0x04005CB3 RID: 23731
		internal IDisposable $locvar1;

		// Token: 0x04005CB4 RID: 23732
		internal EnemyBattleUnit <battleUnit>__2;

		// Token: 0x04005CB5 RID: 23733
		internal AdventureUnitSkill <currentMain>__4;

		// Token: 0x04005CB6 RID: 23734
		internal int <skillLevel>__4;

		// Token: 0x04005CB7 RID: 23735
		internal IEnumerator $locvar2;

		// Token: 0x04005CB8 RID: 23736
		internal object <_>__5;

		// Token: 0x04005CB9 RID: 23737
		internal IDisposable $locvar3;

		// Token: 0x04005CBA RID: 23738
		internal object $current;

		// Token: 0x04005CBB RID: 23739
		internal bool $disposing;

		// Token: 0x04005CBC RID: 23740
		internal int $PC;

		// Token: 0x04005CBD RID: 23741
		private static Func<AdventureUnitSkill, bool> <>f__am$cache0;

		// Token: 0x04005CBE RID: 23742
		private static Func<AdventureUnitSkill, bool> <>f__am$cache1;
	}
}
