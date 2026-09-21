using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x0200070F RID: 1807
public class Taunt : MainSkillBase
{
	// Token: 0x06003207 RID: 12807 RVA: 0x00153415 File Offset: 0x00151815
	public Taunt()
	{
	}

	// Token: 0x17000746 RID: 1862
	// (get) Token: 0x06003208 RID: 12808 RVA: 0x0015341D File Offset: 0x0015181D
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Taunt;
		}
	}

	// Token: 0x17000747 RID: 1863
	// (get) Token: 0x06003209 RID: 12809 RVA: 0x00153424 File Offset: 0x00151824
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600320A RID: 12810 RVA: 0x0015342C File Offset: 0x0015182C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TauntDamageEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new TauntTimeEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new TauntDebuffTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x0600320B RID: 12811 RVA: 0x001534F0 File Offset: 0x001518F0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		double num = (!skill.GetActiveTalents().OfType<TauntDamageEnhancementTalent>().Any<TauntDamageEnhancementTalent>()) ? 0.0 : TauntDamageEnhancementTalent.DamageIncreaseRate;
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill) + num),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill) + num)
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x0600320C RID: 12812 RVA: 0x001535A1 File Offset: 0x001519A1
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x0600320D RID: 12813 RVA: 0x001535C0 File Offset: 0x001519C0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600320E RID: 12814 RVA: 0x0015360D File Offset: 0x00151A0D
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600320F RID: 12815 RVA: 0x00153614 File Offset: 0x00151A14
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		bool canTaunt = !skill.GetActiveTalents().OfType<TauntDamageEnhancementTalent>().Any<TauntDamageEnhancementTalent>();
		int tauntTime = 4;
		if (skill.GetActiveTalents().OfType<TauntTimeEnhancementTalent>().Any<TauntTimeEnhancementTalent>())
		{
			tauntTime = TauntTimeEnhancementTalent.TauntTime;
		}
		List<TauntDebuffTalent> tauntDebuff = skill.GetActiveTalents().OfType<TauntDebuffTalent>().ToList<TauntDebuffTalent>();
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.BattleEffects.OfType<TauntEffect>().Any<TauntEffect>())
			{
				foreach (TauntDebuffTalent tauntDebuffTalent in tauntDebuff)
				{
					IEnumerator enumerator3 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = TauntDebuffTalent.Type,
							ModificationType = ModificationType.Multiplication,
							Value = -TauntDebuffTalent.ReductionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "tauntdebuff", new int?(3), new float?(5f), null, true, true), false).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			if (target.Status == BattleUnitStatus.Active)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => !d.IsMissed) && canTaunt)
				{
					bool cannotBeResisted = false;
					PaladinStarTauntEnhanceData star = skill.SourceUnit.SpecialEffects.OfType<PaladinStarTauntEnhanceData>().FirstOrDefault<PaladinStarTauntEnhanceData>();
					if (star != null && (double)UnityEngine.Random.value <= star.Chance)
					{
						cannotBeResisted = true;
					}
					IEnumerator enumerator4 = target.ApplySkillEffect(new TauntEffect(caster, target, skill, new int?(tauntTime), !cannotBeResisted), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x17000748 RID: 1864
	// (get) Token: 0x06003210 RID: 12816 RVA: 0x0015363E File Offset: 0x00151A3E
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000749 RID: 1865
	// (get) Token: 0x06003211 RID: 12817 RVA: 0x00153641 File Offset: 0x00151A41
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x1700074A RID: 1866
	// (get) Token: 0x06003212 RID: 12818 RVA: 0x00153644 File Offset: 0x00151A44
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x1700074B RID: 1867
	// (get) Token: 0x06003213 RID: 12819 RVA: 0x00153647 File Offset: 0x00151A47
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B5 RID: 10165
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E72 RID: 3698
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D08 RID: 23816 RVA: 0x0015364A File Offset: 0x00151A4A
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005D09 RID: 23817 RVA: 0x00153654 File Offset: 0x00151A54
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = skill.SourceUnit;
				canTaunt = !skill.GetActiveTalents().OfType<TauntDamageEnhancementTalent>().Any<TauntDamageEnhancementTalent>();
				tauntTime = 4;
				if (skill.GetActiveTalents().OfType<TauntTimeEnhancementTalent>().Any<TauntTimeEnhancementTalent>())
				{
					tauntTime = TauntTimeEnhancementTalent.TauntTime;
				}
				tauntDebuff = skill.GetActiveTalents().OfType<TauntDebuffTalent>().ToList<TauntDebuffTalent>();
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
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
						case 1u:
							Block_16:
							try
							{
								switch (num)
								{
								}
								if (enumerator3.MoveNext())
								{
									_ = enumerator3.Current;
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator2.MoveNext())
						{
							tauntDebuffTalent = enumerator2.Current;
							enumerator3 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeType = TauntDebuffTalent.Type,
									ModificationType = ModificationType.Multiplication,
									Value = -TauntDebuffTalent.ReductionRate,
									Key = string.Empty,
									AttributeModifierType = AttributeModifierType.Skill
								}
							}, "tauntdebuff", new int?(3), new float?(5f), null, true, true), false).GetEnumerator();
							num = 4294967293u;
							goto Block_16;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				case 2u:
					Block_13:
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
					goto IL_3E1;
				default:
					goto IL_3E1;
				}
				IL_27B:
				if (target.Status == BattleUnitStatus.Active)
				{
					if (damageBattleDamage.Damages.Any((DamageComponent d) => !d.IsMissed) && canTaunt)
					{
						cannotBeResisted = false;
						star = skill.SourceUnit.SpecialEffects.OfType<PaladinStarTauntEnhanceData>().FirstOrDefault<PaladinStarTauntEnhanceData>();
						if (star != null && (double)UnityEngine.Random.value <= star.Chance)
						{
							cannotBeResisted = true;
						}
						enumerator4 = target.ApplySkillEffect(new TauntEffect(caster, target, skill, new int?(tauntTime), !cannotBeResisted), false).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
				}
				IL_3E1:
				if (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.BattleEffects.OfType<TauntEffect>().Any<TauntEffect>())
					{
						enumerator2 = tauntDebuff.GetEnumerator();
						num = 4294967293u;
						goto Block_6;
					}
					goto IL_27B;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700136A RID: 4970
		// (get) Token: 0x06005D0A RID: 23818 RVA: 0x00153ADC File Offset: 0x00151EDC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700136B RID: 4971
		// (get) Token: 0x06005D0B RID: 23819 RVA: 0x00153AE4 File Offset: 0x00151EE4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D0C RID: 23820 RVA: 0x00153AEC File Offset: 0x00151EEC
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
							try
							{
							}
							finally
							{
								if ((disposable = (enumerator3 as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						break;
					case 2u:
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

		// Token: 0x06005D0D RID: 23821 RVA: 0x00153BF8 File Offset: 0x00151FF8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D0E RID: 23822 RVA: 0x00153BFF File Offset: 0x00151FFF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D0F RID: 23823 RVA: 0x00153C08 File Offset: 0x00152008
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Taunt.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Taunt.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005D10 RID: 23824 RVA: 0x00153C48 File Offset: 0x00152048
		private static bool <>m__0(DamageComponent d)
		{
			return !d.IsMissed;
		}

		// Token: 0x04004FF8 RID: 20472
		internal AdventureUnitSkill skill;

		// Token: 0x04004FF9 RID: 20473
		internal IBattleUnit <caster>__0;

		// Token: 0x04004FFA RID: 20474
		internal bool <canTaunt>__0;

		// Token: 0x04004FFB RID: 20475
		internal int <tauntTime>__0;

		// Token: 0x04004FFC RID: 20476
		internal List<TauntDebuffTalent> <tauntDebuff>__0;

		// Token: 0x04004FFD RID: 20477
		internal ReleaseableDamage damage;

		// Token: 0x04004FFE RID: 20478
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004FFF RID: 20479
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04005000 RID: 20480
		internal IBattleUnit <target>__2;

		// Token: 0x04005001 RID: 20481
		internal List<TauntDebuffTalent>.Enumerator $locvar1;

		// Token: 0x04005002 RID: 20482
		internal TauntDebuffTalent <tauntDebuffTalent>__3;

		// Token: 0x04005003 RID: 20483
		internal IEnumerator $locvar2;

		// Token: 0x04005004 RID: 20484
		internal object <_>__4;

		// Token: 0x04005005 RID: 20485
		internal IDisposable $locvar3;

		// Token: 0x04005006 RID: 20486
		internal bool <cannotBeResisted>__5;

		// Token: 0x04005007 RID: 20487
		internal PaladinStarTauntEnhanceData <star>__5;

		// Token: 0x04005008 RID: 20488
		internal IEnumerator $locvar4;

		// Token: 0x04005009 RID: 20489
		internal object <_>__6;

		// Token: 0x0400500A RID: 20490
		internal IDisposable $locvar5;

		// Token: 0x0400500B RID: 20491
		internal object $current;

		// Token: 0x0400500C RID: 20492
		internal bool $disposing;

		// Token: 0x0400500D RID: 20493
		internal int $PC;

		// Token: 0x0400500E RID: 20494
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
