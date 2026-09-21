using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006E9 RID: 1769
public class BurningHeart : MainSkillBase
{
	// Token: 0x06003018 RID: 12312 RVA: 0x001480D0 File Offset: 0x001464D0
	public BurningHeart()
	{
	}

	// Token: 0x06003019 RID: 12313 RVA: 0x001480D8 File Offset: 0x001464D8
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new BurningHeartStrengthBurnEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.BurningHeart,
				SlotNumber = 1
			},
			new BurningHeartDispelEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x0600301A RID: 12314 RVA: 0x001481B0 File Offset: 0x001465B0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Shadow), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Intelligience, OrderingType.Desc, new int?(1 + skill.SourceUnit.SpecialEffects.OfType<BurningHeartEnhancementData>().Sum((BurningHeartEnhancementData s) => s.ExtraTarget))), skill);
	}

	// Token: 0x0600301B RID: 12315 RVA: 0x00148262 File Offset: 0x00146662
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x0600301C RID: 12316 RVA: 0x00148281 File Offset: 0x00146681
	private double GetIntelligienceDecreaseRate(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x0600301D RID: 12317 RVA: 0x001482A0 File Offset: 0x001466A0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetIntelligienceDecreaseRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600301E RID: 12318 RVA: 0x00148304 File Offset: 0x00146704
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600301F RID: 12319 RVA: 0x0014830C File Offset: 0x0014670C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		List<BurningHeartDispelEnhancementTalent> dispelEnhancements = skill.GetActiveTalents().OfType<BurningHeartDispelEnhancementTalent>().ToList<BurningHeartDispelEnhancementTalent>();
		BurningHeartEnhancementData hitRateReduction = skill.SourceUnit.SpecialEffects.OfType<BurningHeartEnhancementData>().FirstOrDefault<BurningHeartEnhancementData>();
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				double inteligenceDecay = this.GetIntelligienceDecreaseRate(skill.Skill);
				IEnumerator enumerator2 = target.ApplySkillEffect(new BurningHeartEffect(skill, inteligenceDecay, base.GetType().FullName), false).GetEnumerator();
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
				List<BattleEffectBase> positiveEffects = (from ef in target.BattleEffects
				where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
				select ef).ToList<BattleEffectBase>();
				if (positiveEffects.Any<BattleEffectBase>())
				{
					positiveEffects.Shuffle<BattleEffectBase>();
					IEnumerator enumerator3 = target.DisperseEffect(positiveEffects.First<BattleEffectBase>(), skill.SourceUnit).GetEnumerator();
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
				if (dispelEnhancements.Any<BurningHeartDispelEnhancementTalent>())
				{
					double chance = BurningHeartDispelEnhancementTalent.Chance;
					int dispels = BurningHeartDispelEnhancementTalent.NumberOfDispels;
					if ((double)UnityEngine.Random.value <= chance)
					{
						IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(target, new int?(dispels)).GetEnumerator();
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
				}
				if (hitRateReduction != null && target.GetOutputAttributeType() == AttributeType.Intelligience)
				{
					IEnumerator enumerator5 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Addition,
							AttributeType = AttributeType.HitRateAdjustment,
							Value = -hitRateReduction.HitReduction,
							Key = string.Empty
						}
					}, "burningheartenhancementhitrecuction", new int?(2), null, new int?(2), false, true), false).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _4 = enumerator5.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator5 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000666 RID: 1638
	// (get) Token: 0x06003020 RID: 12320 RVA: 0x0014833D File Offset: 0x0014673D
	public override SkillType SkillType
	{
		get
		{
			return SkillType.BurningHeart;
		}
	}

	// Token: 0x17000667 RID: 1639
	// (get) Token: 0x06003021 RID: 12321 RVA: 0x00148344 File Offset: 0x00146744
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000668 RID: 1640
	// (get) Token: 0x06003022 RID: 12322 RVA: 0x0014834C File Offset: 0x0014674C
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000669 RID: 1641
	// (get) Token: 0x06003023 RID: 12323 RVA: 0x0014834F File Offset: 0x0014674F
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x1700066A RID: 1642
	// (get) Token: 0x06003024 RID: 12324 RVA: 0x00148352 File Offset: 0x00146752
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700066B RID: 1643
	// (get) Token: 0x06003025 RID: 12325 RVA: 0x00148355 File Offset: 0x00146755
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x06003026 RID: 12326 RVA: 0x00148358 File Offset: 0x00146758
	[CompilerGenerated]
	private static int <GetDamageDefinition>m__0(BurningHeartEnhancementData s)
	{
		return s.ExtraTarget;
	}

	// Token: 0x0400278B RID: 10123
	private SkillCommandType _skillCommandType;

	// Token: 0x0400278C RID: 10124
	[CompilerGenerated]
	private static Func<BurningHeartEnhancementData, int> <>f__am$cache0;

	// Token: 0x02000E4F RID: 3663
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C0E RID: 23566 RVA: 0x00148360 File Offset: 0x00146760
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C0F RID: 23567 RVA: 0x00148368 File Offset: 0x00146768
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				dispelEnhancements = skill.GetActiveTalents().OfType<BurningHeartDispelEnhancementTalent>().ToList<BurningHeartDispelEnhancementTalent>();
				hitRateReduction = skill.SourceUnit.SpecialEffects.OfType<BurningHeartEnhancementData>().FirstOrDefault<BurningHeartEnhancementData>();
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
			case 4u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_5:
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
					positiveEffects = (from ef in target.BattleEffects
					where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
					select ef).ToList<BattleEffectBase>();
					if (positiveEffects.Any<BattleEffectBase>())
					{
						positiveEffects.Shuffle<BattleEffectBase>();
						enumerator3 = target.DisperseEffect(positiveEffects.First<BattleEffectBase>(), skill.SourceUnit).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_2B0;
				case 2u:
					goto IL_22E;
				case 3u:
					Block_11:
					try
					{
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
					goto IL_38D;
				case 4u:
				{
					Block_14:
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_4 = enumerator5.Current;
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
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					int a = 100;
					break;
				}
				}
				IL_4CB:
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						inteligenceDecay = base.GetIntelligienceDecreaseRate(skill.Skill);
						enumerator2 = target.ApplySkillEffect(new BurningHeartEffect(skill, inteligenceDecay, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
				}
				goto IL_4F6;
				Block_8:
				try
				{
					IL_22E:
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
				IL_2B0:
				if (dispelEnhancements.Any<BurningHeartDispelEnhancementTalent>())
				{
					chance = BurningHeartDispelEnhancementTalent.Chance;
					dispels = BurningHeartDispelEnhancementTalent.NumberOfDispels;
					if ((double)UnityEngine.Random.value <= chance)
					{
						enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(target, new int?(dispels)).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
				}
				IL_38D:
				if (hitRateReduction != null && target.GetOutputAttributeType() == AttributeType.Intelligience)
				{
					enumerator5 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Addition,
							AttributeType = AttributeType.HitRateAdjustment,
							Value = -hitRateReduction.HitReduction,
							Key = string.Empty
						}
					}, "burningheartenhancementhitrecuction", new int?(2), null, new int?(2), false, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
				goto IL_4CB;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_4F6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001334 RID: 4916
		// (get) Token: 0x06005C10 RID: 23568 RVA: 0x001488F4 File Offset: 0x00146CF4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001335 RID: 4917
		// (get) Token: 0x06005C11 RID: 23569 RVA: 0x001488FC File Offset: 0x00146CFC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C12 RID: 23570 RVA: 0x00148904 File Offset: 0x00146D04
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
			case 3u:
			case 4u:
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
					case 4u:
						try
						{
						}
						finally
						{
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
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
			}
		}

		// Token: 0x06005C13 RID: 23571 RVA: 0x00148A70 File Offset: 0x00146E70
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C14 RID: 23572 RVA: 0x00148A77 File Offset: 0x00146E77
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C15 RID: 23573 RVA: 0x00148A80 File Offset: 0x00146E80
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BurningHeart.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new BurningHeart.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x00148ACC File Offset: 0x00146ECC
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed;
		}

		// Token: 0x04004E49 RID: 20041
		internal AdventureUnitSkill skill;

		// Token: 0x04004E4A RID: 20042
		internal List<BurningHeartDispelEnhancementTalent> <dispelEnhancements>__0;

		// Token: 0x04004E4B RID: 20043
		internal BurningHeartEnhancementData <hitRateReduction>__0;

		// Token: 0x04004E4C RID: 20044
		internal ReleaseableDamage damage;

		// Token: 0x04004E4D RID: 20045
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E4E RID: 20046
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E4F RID: 20047
		internal IBattleUnit <target>__2;

		// Token: 0x04004E50 RID: 20048
		internal double <inteligenceDecay>__3;

		// Token: 0x04004E51 RID: 20049
		internal IEnumerator $locvar1;

		// Token: 0x04004E52 RID: 20050
		internal object <_>__4;

		// Token: 0x04004E53 RID: 20051
		internal IDisposable $locvar2;

		// Token: 0x04004E54 RID: 20052
		internal List<BattleEffectBase> <positiveEffects>__3;

		// Token: 0x04004E55 RID: 20053
		internal IEnumerator $locvar3;

		// Token: 0x04004E56 RID: 20054
		internal object <_>__5;

		// Token: 0x04004E57 RID: 20055
		internal IDisposable $locvar4;

		// Token: 0x04004E58 RID: 20056
		internal double <chance>__6;

		// Token: 0x04004E59 RID: 20057
		internal int <dispels>__6;

		// Token: 0x04004E5A RID: 20058
		internal IEnumerator $locvar5;

		// Token: 0x04004E5B RID: 20059
		internal object <_>__7;

		// Token: 0x04004E5C RID: 20060
		internal IDisposable $locvar6;

		// Token: 0x04004E5D RID: 20061
		internal IEnumerator $locvar7;

		// Token: 0x04004E5E RID: 20062
		internal object <_>__8;

		// Token: 0x04004E5F RID: 20063
		internal IDisposable $locvar8;

		// Token: 0x04004E60 RID: 20064
		internal int <a>__9;

		// Token: 0x04004E61 RID: 20065
		internal BurningHeart $this;

		// Token: 0x04004E62 RID: 20066
		internal object $current;

		// Token: 0x04004E63 RID: 20067
		internal bool $disposing;

		// Token: 0x04004E64 RID: 20068
		internal int $PC;

		// Token: 0x04004E65 RID: 20069
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}
}
