using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006FB RID: 1787
public class Meteorolite : MainSkillBase
{
	// Token: 0x06003100 RID: 12544 RVA: 0x0014D05A File Offset: 0x0014B45A
	public Meteorolite()
	{
	}

	// Token: 0x170006CE RID: 1742
	// (get) Token: 0x06003101 RID: 12545 RVA: 0x0014D062 File Offset: 0x0014B462
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Meteorolite;
		}
	}

	// Token: 0x06003102 RID: 12546 RVA: 0x0014D06C File Offset: 0x0014B46C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Meteorolite,
				SlotNumber = 1
			},
			new DispelPositiveEffectOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Meteorolite,
				SlotNumber = 1
			},
			new AttributeBoostOnKillTalentByRate
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Meteorolite,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x170006CF RID: 1743
	// (get) Token: 0x06003103 RID: 12547 RVA: 0x0014D167 File Offset: 0x0014B567
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003104 RID: 12548 RVA: 0x0014D16F File Offset: 0x0014B56F
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.08;
	}

	// Token: 0x06003105 RID: 12549 RVA: 0x0014D190 File Offset: 0x0014B590
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003106 RID: 12550 RVA: 0x0014D1E0 File Offset: 0x0014B5E0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		int num = 3;
		num += skill.SourceUnit.BattleEffects.OfType<FashionEnhancedEffect>().Sum((FashionEnhancedEffect e) => e.Extra);
		FashionBoyStarDoubleDamageData fashionBoyStarDoubleDamageData = skill.SourceUnit.SpecialEffects.OfType<FashionBoyStarDoubleDamageData>().FirstOrDefault<FashionBoyStarDoubleDamageData>();
		List<DamageHitDefinition> list = new List<DamageHitDefinition>();
		if (fashionBoyStarDoubleDamageData != null)
		{
			double num2 = 1.0;
			for (int i = 0; i < num; i++)
			{
				if (i > 0 && (double)UnityEngine.Random.value <= fashionBoyStarDoubleDamageData.Chance)
				{
					num2 *= 2.0;
				}
				list.Add(new DamageHitDefinition
				{
					Potions = new List<DamageHitModuleDefinition>
					{
						new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill) * num2),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill) * num2)
					}
				});
			}
		}
		else
		{
			list.AddRange(Enumerable.Repeat<DamageHitDefinition>(new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill))
				}
			}, num).ToList<DamageHitDefinition>());
		}
		return new StableDamageDefinition(list, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x06003107 RID: 12551 RVA: 0x0014D372 File Offset: 0x0014B772
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003108 RID: 12552 RVA: 0x0014D37C File Offset: 0x0014B77C
	public override IEnumerable PriorDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage battleDamage in damage.BattleDamages)
		{
			IBattleUnit target = battleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				List<DamageComponentValue> list = new List<DamageComponentValue>();
				foreach (DamageComponent damageComponent in battleDamage.Damages)
				{
					if (damageComponent.IsCrit)
					{
						list.Add(new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(skill.SourceUnit, target, OutputType.Fire, this.GetDamagePercentage(skill.Skill)),
							new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), this.GetDamagePercentage(skill.Skill))
						}, target, skill.SourceUnit, true, false));
					}
				}
				battleDamage.Damages.AddRange(from d in list
				select new DamageComponent(d, skill));
			}
		}
		yield break;
	}

	// Token: 0x170006D0 RID: 1744
	// (get) Token: 0x06003109 RID: 12553 RVA: 0x0014D3AD File Offset: 0x0014B7AD
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006D1 RID: 1745
	// (get) Token: 0x0600310A RID: 12554 RVA: 0x0014D3B0 File Offset: 0x0014B7B0
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x170006D2 RID: 1746
	// (get) Token: 0x0600310B RID: 12555 RVA: 0x0014D3B3 File Offset: 0x0014B7B3
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006D3 RID: 1747
	// (get) Token: 0x0600310C RID: 12556 RVA: 0x0014D3B6 File Offset: 0x0014B7B6
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x0600310D RID: 12557 RVA: 0x0014D3B9 File Offset: 0x0014B7B9
	[CompilerGenerated]
	private static int <GetDamageDefinition>m__0(FashionEnhancedEffect e)
	{
		return e.Extra;
	}

	// Token: 0x040027A0 RID: 10144
	private SkillCommandType _skillCommandType;

	// Token: 0x040027A1 RID: 10145
	[CompilerGenerated]
	private static Func<FashionEnhancedEffect, int> <>f__am$cache0;

	// Token: 0x02000E5C RID: 3676
	[CompilerGenerated]
	private sealed class <PriorDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C75 RID: 23669 RVA: 0x0014D3C1 File Offset: 0x0014B7C1
		[DebuggerHidden]
		public <PriorDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C76 RID: 23670 RVA: 0x0014D3CC File Offset: 0x0014B7CC
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				foreach (BattleDamage battleDamage in damage.BattleDamages)
				{
					IBattleUnit target = battleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						List<DamageComponentValue> list = new List<DamageComponentValue>();
						foreach (DamageComponent damageComponent in battleDamage.Damages)
						{
							if (damageComponent.IsCrit)
							{
								list.Add(new DamageComponentValue(new List<DamagePotionValue>
								{
									new DamagePotionValue(skill.SourceUnit, target, OutputType.Fire, base.GetDamagePercentage(skill.Skill)),
									new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), base.GetDamagePercentage(skill.Skill))
								}, target, skill.SourceUnit, true, false));
							}
						}
						battleDamage.Damages.AddRange(from d in list
						select new DamageComponent(d, skill));
					}
				}
			}
			return false;
		}

		// Token: 0x1700134A RID: 4938
		// (get) Token: 0x06005C77 RID: 23671 RVA: 0x0014D58C File Offset: 0x0014B98C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700134B RID: 4939
		// (get) Token: 0x06005C78 RID: 23672 RVA: 0x0014D594 File Offset: 0x0014B994
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C79 RID: 23673 RVA: 0x0014D59C File Offset: 0x0014B99C
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005C7A RID: 23674 RVA: 0x0014D59E File Offset: 0x0014B99E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C7B RID: 23675 RVA: 0x0014D5A5 File Offset: 0x0014B9A5
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C7C RID: 23676 RVA: 0x0014D5B0 File Offset: 0x0014B9B0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Meteorolite.<PriorDamageProcess>c__Iterator0 <PriorDamageProcess>c__Iterator = new Meteorolite.<PriorDamageProcess>c__Iterator0();
			<PriorDamageProcess>c__Iterator.$this = this;
			<PriorDamageProcess>c__Iterator.damage = damage;
			<PriorDamageProcess>c__Iterator.skill = skill;
			return <PriorDamageProcess>c__Iterator;
		}

		// Token: 0x04004F01 RID: 20225
		internal ReleaseableDamage damage;

		// Token: 0x04004F02 RID: 20226
		internal AdventureUnitSkill skill;

		// Token: 0x04004F03 RID: 20227
		internal Meteorolite $this;

		// Token: 0x04004F04 RID: 20228
		internal object $current;

		// Token: 0x04004F05 RID: 20229
		internal bool $disposing;

		// Token: 0x04004F06 RID: 20230
		internal int $PC;

		// Token: 0x02000E5D RID: 3677
		private sealed class <PriorDamageProcess>c__AnonStorey1
		{
			// Token: 0x06005C7D RID: 23677 RVA: 0x0014D5FC File Offset: 0x0014B9FC
			public <PriorDamageProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06005C7E RID: 23678 RVA: 0x0014D604 File Offset: 0x0014BA04
			internal DamageComponent <>m__0(DamageComponentValue d)
			{
				return new DamageComponent(d, this.skill);
			}

			// Token: 0x04004F07 RID: 20231
			internal AdventureUnitSkill skill;

			// Token: 0x04004F08 RID: 20232
			internal Meteorolite.<PriorDamageProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
