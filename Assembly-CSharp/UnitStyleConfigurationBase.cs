using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A49 RID: 2633
public abstract class UnitStyleConfigurationBase
{
	// Token: 0x060047B0 RID: 18352 RVA: 0x001D1A23 File Offset: 0x001CFE23
	protected UnitStyleConfigurationBase()
	{
	}

	// Token: 0x17000E0E RID: 3598
	// (get) Token: 0x060047B1 RID: 18353
	public abstract UnitClassStyle CorrespondingStyle { get; }

	// Token: 0x060047B2 RID: 18354
	public abstract UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement);

	// Token: 0x060047B3 RID: 18355 RVA: 0x001D1A2C File Offset: 0x001CFE2C
	protected OutputType GetRandomElement()
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		return allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)];
	}

	// Token: 0x060047B4 RID: 18356 RVA: 0x001D1A54 File Offset: 0x001CFE54
	public static IEnumerable DispelNegativeEffects(IBattleUnit target, int? numberOfDispel)
	{
		if (numberOfDispel != null)
		{
			List<BattleEffectBase> negatives = target.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(numberOfDispel.Value).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in negatives)
			{
				IEnumerator enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
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
		else
		{
			List<BattleEffectBase> negatives2 = target.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase2 in negatives2)
			{
				IEnumerator enumerator4 = target.LooseSkillEffect(battleEffectBase2, EffectWearsOffType.Dispersed).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060047B5 RID: 18357 RVA: 0x001D1A80 File Offset: 0x001CFE80
	public static IEnumerable DispelPositiveEffects(IBattleUnit target, int? numberOfDispel)
	{
		if (numberOfDispel != null)
		{
			List<BattleEffectBase> postives = target.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Take(numberOfDispel.Value).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in postives)
			{
				IEnumerator enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
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
		else
		{
			List<BattleEffectBase> postives2 = target.BattleEffects.GetPositiveEffects().GetDesperseableEffects().ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase2 in postives2)
			{
				IEnumerator enumerator4 = target.LooseSkillEffect(battleEffectBase2, EffectWearsOffType.Dispersed).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060047B6 RID: 18358 RVA: 0x001D1AAC File Offset: 0x001CFEAC
	public static IEnumerable PushTargetProgress(IBattleUnit target, IBattleUnit dealer, double changeRate)
	{
		UnitTurnProgressUpdateEvent pushEvt = new UnitTurnProgressUpdateEvent
		{
			Dealer = dealer,
			ChangePercentage = changeRate,
			CausingSource = dealer
		};
		IEnumerator enumerator = target.ChangeTurnCounterProgress(pushEvt).GetEnumerator();
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
		yield break;
	}

	// Token: 0x060047B7 RID: 18359 RVA: 0x001D1ADD File Offset: 0x001CFEDD
	public virtual List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060047B8 RID: 18360 RVA: 0x001D1AE4 File Offset: 0x001CFEE4
	public UnitPowerGrade GetAbilityGrade(IBattleUnit unit)
	{
		if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 100.0 && unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == 1 && ((this is PhysicalDefenderBase && unit.Level >= 8.0) || (this is PhysicalKillerBase && unit.Level >= 21.0) || (this is PhysicalSupporterBase && unit.Level >= 11.0) || (this is PhysicalWarriorBase && unit.Level >= 15.0) || (this is ProtectorBase && unit.Level >= 7.0) || (this is SpellDefenderBase && unit.Level >= 8.0) || (this is SpellKillerBase && unit.Level >= 18.0) || (this is SpellSupporterBase && unit.Level >= 12.0) || (this is SpellWarriorBase && unit.Level >= 15.0)))
		{
			return UnitPowerGrade.Normal;
		}
		if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating >= 2 || unit.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 100.0 || unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == -1)
		{
			return UnitPowerGrade.Hard;
		}
		return UnitPowerGrade.Easy;
	}

	// Token: 0x060047B9 RID: 18361 RVA: 0x001D1C8C File Offset: 0x001D008C
	public IEnumerable NormalAttack(IBattleUnit unit)
	{
		UnitPowerGrade grade = this.GetAbilityGrade(unit);
		IEnumerator enumerator = unit.SelfEventCallback(unit, AdventureEventType.UnitNormalAttack, unit).GetEnumerator();
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
		if (grade == UnitPowerGrade.Easy)
		{
			TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
			List<IBattleUnit> opponents = targetDf.GetTargets(unit);
			if (opponents.Any<IBattleUnit>())
			{
				ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), 1.5)
					}, o, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				IEnumerator enumerator2 = releaseableDamage.Release().GetEnumerator();
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
		else if (grade == UnitPowerGrade.Normal)
		{
			IEnumerator enumerator3 = this.NormalGradeAttackLogic(unit).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		else
		{
			IEnumerator enumerator4 = this.HardGradeAttackLogic(unit).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x060047BA RID: 18362
	public abstract IEnumerable NormalGradeAttackLogic(IBattleUnit unit);

	// Token: 0x060047BB RID: 18363
	public abstract IEnumerable HardGradeAttackLogic(IBattleUnit unit);

	// Token: 0x17000E0F RID: 3599
	// (get) Token: 0x060047BC RID: 18364
	public abstract List<ResourceCategory> WeaponCategories { get; }

	// Token: 0x17000E10 RID: 3600
	// (get) Token: 0x060047BD RID: 18365
	public abstract List<ResourceCategory> ArmorCategories { get; }

	// Token: 0x17000E11 RID: 3601
	// (get) Token: 0x060047BE RID: 18366
	public abstract List<ResourceType> SuitableAccessories { get; }

	// Token: 0x17000E12 RID: 3602
	// (get) Token: 0x060047BF RID: 18367 RVA: 0x001D1CB6 File Offset: 0x001D00B6
	public virtual List<ResourceType> SuitableGemTypes
	{
		get
		{
			return new List<ResourceType>();
		}
	}

	// Token: 0x060047C0 RID: 18368 RVA: 0x001D1CBD File Offset: 0x001D00BD
	// Note: this type is marked as 'beforefieldinit'.
	static UnitStyleConfigurationBase()
	{
	}

	// Token: 0x04003978 RID: 14712
	public static int FirstStageUnitLevel = 30;

	// Token: 0x04003979 RID: 14713
	public static int SecondStageUnitLevel = 50;

	// Token: 0x02001073 RID: 4211
	[CompilerGenerated]
	private sealed class <DispelNegativeEffects>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600694C RID: 26956 RVA: 0x001D1CCD File Offset: 0x001D00CD
		[DebuggerHidden]
		public <DispelNegativeEffects>c__Iterator0()
		{
		}

		// Token: 0x0600694D RID: 26957 RVA: 0x001D1CD8 File Offset: 0x001D00D8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (numberOfDispel == null)
				{
					negatives2 = target.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().ToList<BattleEffectBase>();
					enumerator3 = negatives2.GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				negatives = target.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(numberOfDispel.Value).ToList<BattleEffectBase>();
				enumerator = negatives.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1A3;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_6:
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
					battleEffectBase = enumerator.Current;
					enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			goto IL_292;
			Block_4:
			try
			{
				IL_1A3:
				switch (num)
				{
				case 2u:
					Block_17:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_2 = enumerator4.Current;
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
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator3.MoveNext())
				{
					battleEffectBase2 = enumerator3.Current;
					enumerator4 = target.LooseSkillEffect(battleEffectBase2, EffectWearsOffType.Dispersed).GetEnumerator();
					num = 4294967293u;
					goto Block_17;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			IL_292:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015FB RID: 5627
		// (get) Token: 0x0600694E RID: 26958 RVA: 0x001D1FB8 File Offset: 0x001D03B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015FC RID: 5628
		// (get) Token: 0x0600694F RID: 26959 RVA: 0x001D1FC0 File Offset: 0x001D03C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006950 RID: 26960 RVA: 0x001D1FC8 File Offset: 0x001D03C8
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006951 RID: 26961 RVA: 0x001D20BC File Offset: 0x001D04BC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006952 RID: 26962 RVA: 0x001D20C3 File Offset: 0x001D04C3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006953 RID: 26963 RVA: 0x001D20CC File Offset: 0x001D04CC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitStyleConfigurationBase.<DispelNegativeEffects>c__Iterator0 <DispelNegativeEffects>c__Iterator = new UnitStyleConfigurationBase.<DispelNegativeEffects>c__Iterator0();
			<DispelNegativeEffects>c__Iterator.numberOfDispel = numberOfDispel;
			<DispelNegativeEffects>c__Iterator.target = target;
			return <DispelNegativeEffects>c__Iterator;
		}

		// Token: 0x040063B5 RID: 25525
		internal int? numberOfDispel;

		// Token: 0x040063B6 RID: 25526
		internal IBattleUnit target;

		// Token: 0x040063B7 RID: 25527
		internal List<BattleEffectBase> <negatives>__1;

		// Token: 0x040063B8 RID: 25528
		internal List<BattleEffectBase>.Enumerator $locvar0;

		// Token: 0x040063B9 RID: 25529
		internal BattleEffectBase <battleEffectBase>__2;

		// Token: 0x040063BA RID: 25530
		internal IEnumerator $locvar1;

		// Token: 0x040063BB RID: 25531
		internal object <_>__3;

		// Token: 0x040063BC RID: 25532
		internal IDisposable $locvar2;

		// Token: 0x040063BD RID: 25533
		internal List<BattleEffectBase> <negatives>__4;

		// Token: 0x040063BE RID: 25534
		internal List<BattleEffectBase>.Enumerator $locvar3;

		// Token: 0x040063BF RID: 25535
		internal BattleEffectBase <battleEffectBase>__5;

		// Token: 0x040063C0 RID: 25536
		internal IEnumerator $locvar4;

		// Token: 0x040063C1 RID: 25537
		internal object <_>__6;

		// Token: 0x040063C2 RID: 25538
		internal IDisposable $locvar5;

		// Token: 0x040063C3 RID: 25539
		internal object $current;

		// Token: 0x040063C4 RID: 25540
		internal bool $disposing;

		// Token: 0x040063C5 RID: 25541
		internal int $PC;
	}

	// Token: 0x02001074 RID: 4212
	[CompilerGenerated]
	private sealed class <DispelPositiveEffects>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006954 RID: 26964 RVA: 0x001D210C File Offset: 0x001D050C
		[DebuggerHidden]
		public <DispelPositiveEffects>c__Iterator1()
		{
		}

		// Token: 0x06006955 RID: 26965 RVA: 0x001D2114 File Offset: 0x001D0514
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (numberOfDispel == null)
				{
					postives2 = target.BattleEffects.GetPositiveEffects().GetDesperseableEffects().ToList<BattleEffectBase>();
					enumerator3 = postives2.GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				postives = target.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Take(numberOfDispel.Value).ToList<BattleEffectBase>();
				enumerator = postives.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1A3;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_6:
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
					battleEffectBase = enumerator.Current;
					enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			goto IL_292;
			Block_4:
			try
			{
				IL_1A3:
				switch (num)
				{
				case 2u:
					Block_17:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_2 = enumerator4.Current;
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
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator3.MoveNext())
				{
					battleEffectBase2 = enumerator3.Current;
					enumerator4 = target.LooseSkillEffect(battleEffectBase2, EffectWearsOffType.Dispersed).GetEnumerator();
					num = 4294967293u;
					goto Block_17;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			IL_292:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015FD RID: 5629
		// (get) Token: 0x06006956 RID: 26966 RVA: 0x001D23F4 File Offset: 0x001D07F4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015FE RID: 5630
		// (get) Token: 0x06006957 RID: 26967 RVA: 0x001D23FC File Offset: 0x001D07FC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006958 RID: 26968 RVA: 0x001D2404 File Offset: 0x001D0804
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006959 RID: 26969 RVA: 0x001D24F8 File Offset: 0x001D08F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600695A RID: 26970 RVA: 0x001D24FF File Offset: 0x001D08FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600695B RID: 26971 RVA: 0x001D2508 File Offset: 0x001D0908
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitStyleConfigurationBase.<DispelPositiveEffects>c__Iterator1 <DispelPositiveEffects>c__Iterator = new UnitStyleConfigurationBase.<DispelPositiveEffects>c__Iterator1();
			<DispelPositiveEffects>c__Iterator.numberOfDispel = numberOfDispel;
			<DispelPositiveEffects>c__Iterator.target = target;
			return <DispelPositiveEffects>c__Iterator;
		}

		// Token: 0x040063C6 RID: 25542
		internal int? numberOfDispel;

		// Token: 0x040063C7 RID: 25543
		internal IBattleUnit target;

		// Token: 0x040063C8 RID: 25544
		internal List<BattleEffectBase> <postives>__1;

		// Token: 0x040063C9 RID: 25545
		internal List<BattleEffectBase>.Enumerator $locvar0;

		// Token: 0x040063CA RID: 25546
		internal BattleEffectBase <battleEffectBase>__2;

		// Token: 0x040063CB RID: 25547
		internal IEnumerator $locvar1;

		// Token: 0x040063CC RID: 25548
		internal object <_>__3;

		// Token: 0x040063CD RID: 25549
		internal IDisposable $locvar2;

		// Token: 0x040063CE RID: 25550
		internal List<BattleEffectBase> <postives>__4;

		// Token: 0x040063CF RID: 25551
		internal List<BattleEffectBase>.Enumerator $locvar3;

		// Token: 0x040063D0 RID: 25552
		internal BattleEffectBase <battleEffectBase>__5;

		// Token: 0x040063D1 RID: 25553
		internal IEnumerator $locvar4;

		// Token: 0x040063D2 RID: 25554
		internal object <_>__6;

		// Token: 0x040063D3 RID: 25555
		internal IDisposable $locvar5;

		// Token: 0x040063D4 RID: 25556
		internal object $current;

		// Token: 0x040063D5 RID: 25557
		internal bool $disposing;

		// Token: 0x040063D6 RID: 25558
		internal int $PC;
	}

	// Token: 0x02001075 RID: 4213
	[CompilerGenerated]
	private sealed class <PushTargetProgress>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600695C RID: 26972 RVA: 0x001D2548 File Offset: 0x001D0948
		[DebuggerHidden]
		public <PushTargetProgress>c__Iterator2()
		{
		}

		// Token: 0x0600695D RID: 26973 RVA: 0x001D2550 File Offset: 0x001D0950
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				pushEvt = new UnitTurnProgressUpdateEvent
				{
					Dealer = dealer,
					ChangePercentage = changeRate,
					CausingSource = dealer
				};
				enumerator = target.ChangeTurnCounterProgress(pushEvt).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015FF RID: 5631
		// (get) Token: 0x0600695E RID: 26974 RVA: 0x001D266C File Offset: 0x001D0A6C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001600 RID: 5632
		// (get) Token: 0x0600695F RID: 26975 RVA: 0x001D2674 File Offset: 0x001D0A74
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006960 RID: 26976 RVA: 0x001D267C File Offset: 0x001D0A7C
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

		// Token: 0x06006961 RID: 26977 RVA: 0x001D26EC File Offset: 0x001D0AEC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006962 RID: 26978 RVA: 0x001D26F3 File Offset: 0x001D0AF3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006963 RID: 26979 RVA: 0x001D26FC File Offset: 0x001D0AFC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitStyleConfigurationBase.<PushTargetProgress>c__Iterator2 <PushTargetProgress>c__Iterator = new UnitStyleConfigurationBase.<PushTargetProgress>c__Iterator2();
			<PushTargetProgress>c__Iterator.dealer = dealer;
			<PushTargetProgress>c__Iterator.changeRate = changeRate;
			<PushTargetProgress>c__Iterator.target = target;
			return <PushTargetProgress>c__Iterator;
		}

		// Token: 0x040063D7 RID: 25559
		internal IBattleUnit dealer;

		// Token: 0x040063D8 RID: 25560
		internal double changeRate;

		// Token: 0x040063D9 RID: 25561
		internal UnitTurnProgressUpdateEvent <pushEvt>__0;

		// Token: 0x040063DA RID: 25562
		internal IBattleUnit target;

		// Token: 0x040063DB RID: 25563
		internal IEnumerator $locvar0;

		// Token: 0x040063DC RID: 25564
		internal object <_>__1;

		// Token: 0x040063DD RID: 25565
		internal IDisposable $locvar1;

		// Token: 0x040063DE RID: 25566
		internal object $current;

		// Token: 0x040063DF RID: 25567
		internal bool $disposing;

		// Token: 0x040063E0 RID: 25568
		internal int $PC;
	}

	// Token: 0x02001076 RID: 4214
	[CompilerGenerated]
	private sealed class <NormalAttack>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006964 RID: 26980 RVA: 0x001D2748 File Offset: 0x001D0B48
		[DebuggerHidden]
		public <NormalAttack>c__Iterator3()
		{
		}

		// Token: 0x06006965 RID: 26981 RVA: 0x001D2750 File Offset: 0x001D0B50
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				grade = base.GetAbilityGrade(unit);
				enumerator = unit.SelfEventCallback(unit, AdventureEventType.UnitNormalAttack, unit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1C6;
			case 3u:
				goto IL_27D;
			case 4u:
				goto IL_328;
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
			if (grade == UnitPowerGrade.Easy)
			{
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
				opponents = targetDf.GetTargets(<NormalAttack>c__AnonStorey.unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_248;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(<NormalAttack>c__AnonStorey.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<NormalAttack>c__AnonStorey.unit, o, <NormalAttack>c__AnonStorey.unit.GetOutputType(), 1.5)
					}, o, <NormalAttack>c__AnonStorey.unit, true, false)
				})).ToList<BattleDamage>(), <NormalAttack>c__AnonStorey.unit);
				enumerator2 = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
			}
			else
			{
				if (grade == UnitPowerGrade.Normal)
				{
					enumerator3 = this.NormalGradeAttackLogic(<NormalAttack>c__AnonStorey.unit).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
				enumerator4 = this.HardGradeAttackLogic(<NormalAttack>c__AnonStorey.unit).GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			}
			try
			{
				IL_1C6:
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
			IL_248:
			goto IL_3AA;
			Block_7:
			try
			{
				IL_27D:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			goto IL_3AA;
			Block_8:
			try
			{
				IL_328:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_3AA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001601 RID: 5633
		// (get) Token: 0x06006966 RID: 26982 RVA: 0x001D2B48 File Offset: 0x001D0F48
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001602 RID: 5634
		// (get) Token: 0x06006967 RID: 26983 RVA: 0x001D2B50 File Offset: 0x001D0F50
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006968 RID: 26984 RVA: 0x001D2B58 File Offset: 0x001D0F58
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006969 RID: 26985 RVA: 0x001D2C84 File Offset: 0x001D1084
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600696A RID: 26986 RVA: 0x001D2C8B File Offset: 0x001D108B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600696B RID: 26987 RVA: 0x001D2C94 File Offset: 0x001D1094
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitStyleConfigurationBase.<NormalAttack>c__Iterator3 <NormalAttack>c__Iterator = new UnitStyleConfigurationBase.<NormalAttack>c__Iterator3();
			<NormalAttack>c__Iterator.$this = this;
			<NormalAttack>c__Iterator.unit = unit;
			return <NormalAttack>c__Iterator;
		}

		// Token: 0x040063E1 RID: 25569
		internal IBattleUnit unit;

		// Token: 0x040063E2 RID: 25570
		internal UnitPowerGrade <grade>__0;

		// Token: 0x040063E3 RID: 25571
		internal IEnumerator $locvar0;

		// Token: 0x040063E4 RID: 25572
		internal object <_>__1;

		// Token: 0x040063E5 RID: 25573
		internal IDisposable $locvar1;

		// Token: 0x040063E6 RID: 25574
		internal TargetDefinition <targetDf>__2;

		// Token: 0x040063E7 RID: 25575
		internal List<IBattleUnit> <opponents>__2;

		// Token: 0x040063E8 RID: 25576
		internal ReleaseableDamage <releaseableDamage>__3;

		// Token: 0x040063E9 RID: 25577
		internal IEnumerator $locvar2;

		// Token: 0x040063EA RID: 25578
		internal object <_>__4;

		// Token: 0x040063EB RID: 25579
		internal IDisposable $locvar3;

		// Token: 0x040063EC RID: 25580
		internal IEnumerator $locvar4;

		// Token: 0x040063ED RID: 25581
		internal object <_>__5;

		// Token: 0x040063EE RID: 25582
		internal IDisposable $locvar5;

		// Token: 0x040063EF RID: 25583
		internal IEnumerator $locvar6;

		// Token: 0x040063F0 RID: 25584
		internal object <_>__6;

		// Token: 0x040063F1 RID: 25585
		internal IDisposable $locvar7;

		// Token: 0x040063F2 RID: 25586
		internal UnitStyleConfigurationBase $this;

		// Token: 0x040063F3 RID: 25587
		internal object $current;

		// Token: 0x040063F4 RID: 25588
		internal bool $disposing;

		// Token: 0x040063F5 RID: 25589
		internal int $PC;

		// Token: 0x040063F6 RID: 25590
		private UnitStyleConfigurationBase.<NormalAttack>c__Iterator3.<NormalAttack>c__AnonStorey4 $locvar8;

		// Token: 0x02001077 RID: 4215
		private sealed class <NormalAttack>c__AnonStorey4
		{
			// Token: 0x0600696C RID: 26988 RVA: 0x001D2CD4 File Offset: 0x001D10D4
			public <NormalAttack>c__AnonStorey4()
			{
			}

			// Token: 0x0600696D RID: 26989 RVA: 0x001D2CDC File Offset: 0x001D10DC
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), 1.5)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x040063F7 RID: 25591
			internal IBattleUnit unit;

			// Token: 0x040063F8 RID: 25592
			internal UnitStyleConfigurationBase.<NormalAttack>c__Iterator3 <>f__ref$3;
		}
	}
}
