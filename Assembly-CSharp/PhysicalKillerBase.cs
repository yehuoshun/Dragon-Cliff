using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A3D RID: 2621
public class PhysicalKillerBase : UnitStyleConfigurationBase
{
	// Token: 0x0600475C RID: 18268 RVA: 0x001D4846 File Offset: 0x001D2C46
	public PhysicalKillerBase()
	{
	}

	// Token: 0x17000DEA RID: 3562
	// (get) Token: 0x0600475D RID: 18269 RVA: 0x001D484E File Offset: 0x001D2C4E
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x0600475E RID: 18270 RVA: 0x001D4854 File Offset: 0x001D2C54
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 7.5, false).SetValue(AttributeType.Agility, 18.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 7.5, false);
		}
		if (measurement.DifficultyValue <= 900.0)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 8.0, false).SetValue(AttributeType.Agility, 18.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 20.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Strength, 8.0, false).SetValue(AttributeType.Agility, 22.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 21.0, false).SetValue(AttributeType.LifeOnHit, 0.1, false).SetValue(AttributeType.HealingAbsorbRate, 0.2, false);
	}

	// Token: 0x0600475F RID: 18271 RVA: 0x001D497C File Offset: 0x001D2D7C
	private double GetDamageRatio(IBattleUnit target, IBattleUnit dealer)
	{
		return 1.0 + (double)target.BattleEffects.OfType<TargetEffect>().Count((TargetEffect t) => t.SourceUnit == dealer) * 3.0;
	}

	// Token: 0x06004760 RID: 18272 RVA: 0x001D49C8 File Offset: 0x001D2DC8
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating > 1 && measurement.DifficultyValue > 30.0)
		{
			list.Add(new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = 1.0
			});
		}
		return list;
	}

	// Token: 0x06004761 RID: 18273 RVA: 0x001D4A24 File Offset: 0x001D2E24
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> damageTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		if (damageTargets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in damageTargets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), this.GetDamageRatio(t, unit) * 0.8),
				new DamagePotionValue(unit, t, unit.GetOutputType(), this.GetDamageRatio(t, unit) * 0.8)
			}, t, unit, true, false), 4).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
		List<IBattleUnit> markTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
		foreach (IBattleUnit markTarget in markTargets)
		{
			IEnumerator enumerator3 = markTarget.ApplySkillEffect(new TargetEffect("physicalkiller", unit, null, new int?(2)), false).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _2 = enumerator3.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator3 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x17000DEB RID: 3563
	// (get) Token: 0x06004762 RID: 18274 RVA: 0x001D4A50 File Offset: 0x001D2E50
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Sword,
				ResourceCategory.Knife,
				ResourceCategory.Axe,
				ResourceCategory.Spear
			};
		}
	}

	// Token: 0x17000DEC RID: 3564
	// (get) Token: 0x06004763 RID: 18275 RVA: 0x001D4A80 File Offset: 0x001D2E80
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Leather
			};
		}
	}

	// Token: 0x17000DED RID: 3565
	// (get) Token: 0x06004764 RID: 18276 RVA: 0x001D4A9C File Offset: 0x001D2E9C
	public override List<ResourceType> SuitableAccessories
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.FameOne,
				ResourceType.FameTwo,
				ResourceType.FameThree,
				ResourceType.FameFour,
				ResourceType.PhenixOne,
				ResourceType.PhenixTwo,
				ResourceType.DragonSealOne,
				ResourceType.DragonSealTwo,
				ResourceType.DragonSealThree,
				ResourceType.DragonSealFour,
				ResourceType.SoulSealOne,
				ResourceType.SoulSealTwo,
				ResourceType.SoulSealThree,
				ResourceType.SoulSealFour
			};
		}
	}

	// Token: 0x06004765 RID: 18277 RVA: 0x001D4B4C File Offset: 0x001D2F4C
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		int numberOfTargets = (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? UnityEngine.Random.Range(1, 3) : UnityEngine.Random.Range(2, 4);
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(numberOfTargets));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), 2.0)
				}, o, unit, true, false)
			})).ToList<BattleDamage>(), unit);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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

	// Token: 0x0200104F RID: 4175
	[CompilerGenerated]
	private sealed class <GetDamageRatio>c__AnonStorey2
	{
		// Token: 0x06006893 RID: 26771 RVA: 0x001D4B6F File Offset: 0x001D2F6F
		public <GetDamageRatio>c__AnonStorey2()
		{
		}

		// Token: 0x06006894 RID: 26772 RVA: 0x001D4B77 File Offset: 0x001D2F77
		internal bool <>m__0(TargetEffect t)
		{
			return t.SourceUnit == this.dealer;
		}

		// Token: 0x04006278 RID: 25208
		internal IBattleUnit dealer;
	}

	// Token: 0x02001050 RID: 4176
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006895 RID: 26773 RVA: 0x001D4B87 File Offset: 0x001D2F87
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x06006896 RID: 26774 RVA: 0x001D4B90 File Offset: 0x001D2F90
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damageTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (!damageTargets.Any<IBattleUnit>())
				{
					goto IL_158;
				}
				releaseableDamage = new ReleaseableDamage((from t in damageTargets
				select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), this.GetDamageRatio(t, unit) * 0.8),
					new DamagePotionValue(unit, t, unit.GetOutputType(), this.GetDamageRatio(t, unit) * 0.8)
				}, t, unit, true, false), 4).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_4:
				try
				{
					switch (num)
					{
					case 2u:
						Block_12:
						try
						{
							switch (num)
							{
							}
							if (enumerator3.MoveNext())
							{
								_2 = enumerator3.Current;
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
								if ((disposable2 = (enumerator3 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator2.MoveNext())
					{
						markTarget = enumerator2.Current;
						enumerator3 = markTarget.ApplySkillEffect(new TargetEffect("physicalkiller", <HardGradeAttackLogic>c__AnonStorey.unit, null, new int?(2)), false).GetEnumerator();
						num = 4294967293u;
						goto Block_12;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				this.$PC = -1;
				return false;
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
			IL_158:
			markTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(<HardGradeAttackLogic>c__AnonStorey.unit);
			enumerator2 = markTargets.GetEnumerator();
			num = 4294967293u;
			goto Block_4;
		}

		// Token: 0x170015D7 RID: 5591
		// (get) Token: 0x06006897 RID: 26775 RVA: 0x001D4E70 File Offset: 0x001D3270
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015D8 RID: 5592
		// (get) Token: 0x06006898 RID: 26776 RVA: 0x001D4E78 File Offset: 0x001D3278
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006899 RID: 26777 RVA: 0x001D4E80 File Offset: 0x001D3280
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
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600689A RID: 26778 RVA: 0x001D4F54 File Offset: 0x001D3354
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600689B RID: 26779 RVA: 0x001D4F5B File Offset: 0x001D335B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600689C RID: 26780 RVA: 0x001D4F64 File Offset: 0x001D3364
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalKillerBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new PhysicalKillerBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006279 RID: 25209
		internal IBattleUnit unit;

		// Token: 0x0400627A RID: 25210
		internal List<IBattleUnit> <damageTargets>__0;

		// Token: 0x0400627B RID: 25211
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400627C RID: 25212
		internal IEnumerator $locvar0;

		// Token: 0x0400627D RID: 25213
		internal object <_>__2;

		// Token: 0x0400627E RID: 25214
		internal IDisposable $locvar1;

		// Token: 0x0400627F RID: 25215
		internal List<IBattleUnit> <markTargets>__0;

		// Token: 0x04006280 RID: 25216
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04006281 RID: 25217
		internal IBattleUnit <markTarget>__3;

		// Token: 0x04006282 RID: 25218
		internal IEnumerator $locvar3;

		// Token: 0x04006283 RID: 25219
		internal object <_>__4;

		// Token: 0x04006284 RID: 25220
		internal IDisposable $locvar4;

		// Token: 0x04006285 RID: 25221
		internal PhysicalKillerBase $this;

		// Token: 0x04006286 RID: 25222
		internal object $current;

		// Token: 0x04006287 RID: 25223
		internal bool $disposing;

		// Token: 0x04006288 RID: 25224
		internal int $PC;

		// Token: 0x04006289 RID: 25225
		private PhysicalKillerBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey3 $locvar5;

		// Token: 0x02001052 RID: 4178
		private sealed class <HardGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x060068A5 RID: 26789 RVA: 0x001D4FA4 File Offset: 0x001D33A4
			public <HardGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x060068A6 RID: 26790 RVA: 0x001D4FAC File Offset: 0x001D33AC
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), this.<>f__ref$0.$this.GetDamageRatio(t, this.unit) * 0.8),
					new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), this.<>f__ref$0.$this.GetDamageRatio(t, this.unit) * 0.8)
				}, t, this.unit, true, false), 4).ToList<DamageComponentValue>());
			}

			// Token: 0x04006296 RID: 25238
			internal IBattleUnit unit;

			// Token: 0x04006297 RID: 25239
			internal PhysicalKillerBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02001051 RID: 4177
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600689D RID: 26781 RVA: 0x001D506B File Offset: 0x001D346B
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x0600689E RID: 26782 RVA: 0x001D5074 File Offset: 0x001D3474
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				numberOfTargets = ((unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? UnityEngine.Random.Range(1, 3) : UnityEngine.Random.Range(2, 4));
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(numberOfTargets));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_18A;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), 2.0)
					}, o, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
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
			IL_18A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015D9 RID: 5593
		// (get) Token: 0x0600689F RID: 26783 RVA: 0x001D5228 File Offset: 0x001D3628
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015DA RID: 5594
		// (get) Token: 0x060068A0 RID: 26784 RVA: 0x001D5230 File Offset: 0x001D3630
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068A1 RID: 26785 RVA: 0x001D5238 File Offset: 0x001D3638
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

		// Token: 0x060068A2 RID: 26786 RVA: 0x001D52A8 File Offset: 0x001D36A8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068A3 RID: 26787 RVA: 0x001D52AF File Offset: 0x001D36AF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068A4 RID: 26788 RVA: 0x001D52B8 File Offset: 0x001D36B8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalKillerBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new PhysicalKillerBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x0400628A RID: 25226
		internal IBattleUnit unit;

		// Token: 0x0400628B RID: 25227
		internal int <numberOfTargets>__0;

		// Token: 0x0400628C RID: 25228
		internal TargetDefinition <targetDf>__0;

		// Token: 0x0400628D RID: 25229
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x0400628E RID: 25230
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400628F RID: 25231
		internal IEnumerator $locvar0;

		// Token: 0x04006290 RID: 25232
		internal object <_>__2;

		// Token: 0x04006291 RID: 25233
		internal IDisposable $locvar1;

		// Token: 0x04006292 RID: 25234
		internal object $current;

		// Token: 0x04006293 RID: 25235
		internal bool $disposing;

		// Token: 0x04006294 RID: 25236
		internal int $PC;

		// Token: 0x04006295 RID: 25237
		private PhysicalKillerBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey4 $locvar2;

		// Token: 0x02001053 RID: 4179
		private sealed class <NormalGradeAttackLogic>c__AnonStorey4
		{
			// Token: 0x060068A7 RID: 26791 RVA: 0x001D52EC File Offset: 0x001D36EC
			public <NormalGradeAttackLogic>c__AnonStorey4()
			{
			}

			// Token: 0x060068A8 RID: 26792 RVA: 0x001D52F4 File Offset: 0x001D36F4
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), 2.0)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x04006298 RID: 25240
			internal IBattleUnit unit;
		}
	}
}
