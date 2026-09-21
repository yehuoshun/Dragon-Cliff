using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000A44 RID: 2628
public class SpellSupporterBase : UnitStyleConfigurationBase
{
	// Token: 0x06004795 RID: 18325 RVA: 0x001D962C File Offset: 0x001D7A2C
	public SpellSupporterBase()
	{
	}

	// Token: 0x17000E02 RID: 3586
	// (get) Token: 0x06004796 RID: 18326 RVA: 0x001D9634 File Offset: 0x001D7A34
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}

	// Token: 0x06004797 RID: 18327 RVA: 0x001D9638 File Offset: 0x001D7A38
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 5.0, false).SetValue(AttributeType.Agility, 9.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 12.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 6.0, false).SetValue(AttributeType.Agility, 18.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 23.0, false);
	}

	// Token: 0x06004798 RID: 18328 RVA: 0x001D96DC File Offset: 0x001D7ADC
	private List<AttributeModifier> GetRandomResistanceWeaken(int numberOfWeakens, double rate)
	{
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		return (from r in allResistances.Take(numberOfWeakens)
		select new AttributeModifier
		{
			AttributeType = r,
			ModificationType = ModificationType.Multiplication,
			Value = rate,
			AttributeModifierType = AttributeModifierType.Skill,
			Key = string.Empty
		}).ToList<AttributeModifier>();
	}

	// Token: 0x06004799 RID: 18329 RVA: 0x001D9720 File Offset: 0x001D7B20
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
				}, t, unit, true, false)
			})).ToList<BattleDamage>(), unit);
			int numberOfDispel = 3;
			if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating != 1)
			{
				numberOfDispel = 5;
			}
			foreach (IBattleUnit battleUnit in targets)
			{
				if (battleUnit.IsAliveInBattle())
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(numberOfDispel)).GetEnumerator();
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
					IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(unit, this.GetRandomResistanceWeaken(4, -0.3), "spellsupporter", new int?(5), null, new int?(2), true, true), false).GetEnumerator();
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
			}
			IEnumerator enumerator4 = releaseableDamage.Release().GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _3 = enumerator4.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator4 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x17000E03 RID: 3587
	// (get) Token: 0x0600479A RID: 18330 RVA: 0x001D974C File Offset: 0x001D7B4C
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Staff
			};
		}
	}

	// Token: 0x17000E04 RID: 3588
	// (get) Token: 0x0600479B RID: 18331 RVA: 0x001D9768 File Offset: 0x001D7B68
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Robe
			};
		}
	}

	// Token: 0x17000E05 RID: 3589
	// (get) Token: 0x0600479C RID: 18332 RVA: 0x001D9784 File Offset: 0x001D7B84
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

	// Token: 0x0600479D RID: 18333 RVA: 0x001D9834 File Offset: 0x001D7C34
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(2));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), 1.8)
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
			foreach (IBattleUnit battleUnit in opponents)
			{
				List<BattleEffectBase> postives = battleUnit.BattleEffects.GetDesperseableEffects().GetPositiveEffects().Take((unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 4 : 3) : 2).ToList<BattleEffectBase>();
				foreach (BattleEffectBase battleEffectBase in postives)
				{
					IEnumerator enumerator4 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
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
				UnitTurnProgressUpdateEvent push = new UnitTurnProgressUpdateEvent
				{
					Dealer = unit,
					ChangePercentage = ((unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 0.2 : 0.15) : -0.1),
					CausingSource = new NormalAttackSource(unit)
				};
				IEnumerator enumerator5 = battleUnit.ChangeTurnCounterProgress(push).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02001067 RID: 4199
	[CompilerGenerated]
	private sealed class <GetRandomResistanceWeaken>c__AnonStorey2
	{
		// Token: 0x0600690E RID: 26894 RVA: 0x001D9857 File Offset: 0x001D7C57
		public <GetRandomResistanceWeaken>c__AnonStorey2()
		{
		}

		// Token: 0x0600690F RID: 26895 RVA: 0x001D9860 File Offset: 0x001D7C60
		internal AttributeModifier <>m__0(AttributeType r)
		{
			return new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Multiplication,
				Value = this.rate,
				AttributeModifierType = AttributeModifierType.Skill,
				Key = string.Empty
			};
		}

		// Token: 0x0400635D RID: 25437
		internal double rate;
	}

	// Token: 0x02001068 RID: 4200
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006910 RID: 26896 RVA: 0x001D98A0 File Offset: 0x001D7CA0
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x06006911 RID: 26897 RVA: 0x001D98A8 File Offset: 0x001D7CA8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_383;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, t, this.GetRandomElement(), 1.2),
						new DamagePotionValue(unit, t, unit.GetOutputType(), 1.2)
					}, t, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				numberOfDispel = 3;
				if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating != 1)
				{
					numberOfDispel = 5;
				}
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			case 3u:
				goto IL_301;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
					enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<HardGradeAttackLogic>c__AnonStorey.unit, base.GetRandomResistanceWeaken(4, -0.3), "spellsupporter", new int?(5), null, new int?(2), true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				case 2u:
					goto IL_23B;
				}
				IL_2BD:
				while (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					if (battleUnit.IsAliveInBattle())
					{
						enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(numberOfDispel)).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
				}
				goto IL_2E8;
				Block_9:
				try
				{
					IL_23B:
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
				goto IL_2BD;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2E8:
			enumerator4 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_301:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
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
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_383:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015EF RID: 5615
		// (get) Token: 0x06006912 RID: 26898 RVA: 0x001D9CA8 File Offset: 0x001D80A8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015F0 RID: 5616
		// (get) Token: 0x06006913 RID: 26899 RVA: 0x001D9CB0 File Offset: 0x001D80B0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006914 RID: 26900 RVA: 0x001D9CB8 File Offset: 0x001D80B8
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
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
						break;
					case 2u:
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
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006915 RID: 26901 RVA: 0x001D9DE0 File Offset: 0x001D81E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006916 RID: 26902 RVA: 0x001D9DE7 File Offset: 0x001D81E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006917 RID: 26903 RVA: 0x001D9DF0 File Offset: 0x001D81F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellSupporterBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new SpellSupporterBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x0400635E RID: 25438
		internal IBattleUnit unit;

		// Token: 0x0400635F RID: 25439
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04006360 RID: 25440
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x04006361 RID: 25441
		internal int <numberOfDispel>__1;

		// Token: 0x04006362 RID: 25442
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04006363 RID: 25443
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04006364 RID: 25444
		internal IEnumerator $locvar1;

		// Token: 0x04006365 RID: 25445
		internal object <_>__3;

		// Token: 0x04006366 RID: 25446
		internal IDisposable $locvar2;

		// Token: 0x04006367 RID: 25447
		internal IEnumerator $locvar3;

		// Token: 0x04006368 RID: 25448
		internal object <_>__4;

		// Token: 0x04006369 RID: 25449
		internal IDisposable $locvar4;

		// Token: 0x0400636A RID: 25450
		internal IEnumerator $locvar5;

		// Token: 0x0400636B RID: 25451
		internal object <_>__5;

		// Token: 0x0400636C RID: 25452
		internal IDisposable $locvar6;

		// Token: 0x0400636D RID: 25453
		internal SpellSupporterBase $this;

		// Token: 0x0400636E RID: 25454
		internal object $current;

		// Token: 0x0400636F RID: 25455
		internal bool $disposing;

		// Token: 0x04006370 RID: 25456
		internal int $PC;

		// Token: 0x04006371 RID: 25457
		private SpellSupporterBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey3 $locvar7;

		// Token: 0x0200106A RID: 4202
		private sealed class <HardGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x06006920 RID: 26912 RVA: 0x001D9E30 File Offset: 0x001D8230
			public <HardGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06006921 RID: 26913 RVA: 0x001D9E38 File Offset: 0x001D8238
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 1.2),
						new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 1.2)
					}, t, this.unit, true, false)
				});
			}

			// Token: 0x04006389 RID: 25481
			internal IBattleUnit unit;

			// Token: 0x0400638A RID: 25482
			internal SpellSupporterBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02001069 RID: 4201
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006918 RID: 26904 RVA: 0x001D9EC9 File Offset: 0x001D82C9
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x06006919 RID: 26905 RVA: 0x001D9ED4 File Offset: 0x001D82D4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(2));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_45F;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), 1.8)
					}, o, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				goto IL_16D;
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
			enumerator2 = opponents.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_16D:
				switch (num)
				{
				case 2u:
					Block_14:
					try
					{
						switch (num)
						{
						case 2u:
							Block_20:
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
							battleEffectBase = enumerator3.Current;
							enumerator4 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
							num = 4294967293u;
							goto Block_20;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator3).Dispose();
						}
					}
					push = new UnitTurnProgressUpdateEvent
					{
						Dealer = <NormalGradeAttackLogic>c__AnonStorey.unit,
						ChangePercentage = ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 0.2 : 0.15) : -0.1),
						CausingSource = new NormalAttackSource(<NormalGradeAttackLogic>c__AnonStorey.unit)
					};
					enumerator5 = battleUnit.ChangeTurnCounterProgress(push).GetEnumerator();
					num = 4294967293u;
					break;
				case 3u:
					break;
				default:
					goto IL_434;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_3 = enumerator5.Current;
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
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				IL_434:
				if (enumerator2.MoveNext())
				{
					battleUnit = enumerator2.Current;
					postives = battleUnit.BattleEffects.GetDesperseableEffects().GetPositiveEffects().Take((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 4 : 3) : 2).ToList<BattleEffectBase>();
					enumerator3 = postives.GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_45F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015F1 RID: 5617
		// (get) Token: 0x0600691A RID: 26906 RVA: 0x001DA3C8 File Offset: 0x001D87C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015F2 RID: 5618
		// (get) Token: 0x0600691B RID: 26907 RVA: 0x001DA3D0 File Offset: 0x001D87D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600691C RID: 26908 RVA: 0x001DA3D8 File Offset: 0x001D87D8
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
			case 3u:
				try
				{
					switch (num)
					{
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
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600691D RID: 26909 RVA: 0x001DA520 File Offset: 0x001D8920
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600691E RID: 26910 RVA: 0x001DA527 File Offset: 0x001D8927
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600691F RID: 26911 RVA: 0x001DA530 File Offset: 0x001D8930
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellSupporterBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new SpellSupporterBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006372 RID: 25458
		internal TargetDefinition <targetDf>__0;

		// Token: 0x04006373 RID: 25459
		internal IBattleUnit unit;

		// Token: 0x04006374 RID: 25460
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x04006375 RID: 25461
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x04006376 RID: 25462
		internal IEnumerator $locvar0;

		// Token: 0x04006377 RID: 25463
		internal object <_>__2;

		// Token: 0x04006378 RID: 25464
		internal IDisposable $locvar1;

		// Token: 0x04006379 RID: 25465
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x0400637A RID: 25466
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x0400637B RID: 25467
		internal List<BattleEffectBase> <postives>__4;

		// Token: 0x0400637C RID: 25468
		internal List<BattleEffectBase>.Enumerator $locvar3;

		// Token: 0x0400637D RID: 25469
		internal BattleEffectBase <battleEffectBase>__5;

		// Token: 0x0400637E RID: 25470
		internal IEnumerator $locvar4;

		// Token: 0x0400637F RID: 25471
		internal object <_>__6;

		// Token: 0x04006380 RID: 25472
		internal IDisposable $locvar5;

		// Token: 0x04006381 RID: 25473
		internal UnitTurnProgressUpdateEvent <push>__4;

		// Token: 0x04006382 RID: 25474
		internal IEnumerator $locvar6;

		// Token: 0x04006383 RID: 25475
		internal object <_>__7;

		// Token: 0x04006384 RID: 25476
		internal IDisposable $locvar7;

		// Token: 0x04006385 RID: 25477
		internal object $current;

		// Token: 0x04006386 RID: 25478
		internal bool $disposing;

		// Token: 0x04006387 RID: 25479
		internal int $PC;

		// Token: 0x04006388 RID: 25480
		private SpellSupporterBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey4 $locvar8;

		// Token: 0x0200106B RID: 4203
		private sealed class <NormalGradeAttackLogic>c__AnonStorey4
		{
			// Token: 0x06006922 RID: 26914 RVA: 0x001DA564 File Offset: 0x001D8964
			public <NormalGradeAttackLogic>c__AnonStorey4()
			{
			}

			// Token: 0x06006923 RID: 26915 RVA: 0x001DA56C File Offset: 0x001D896C
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), 1.8)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x0400638B RID: 25483
			internal IBattleUnit unit;
		}
	}
}
