using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x02000706 RID: 1798
public class Shadowless : MainSkillBase
{
	// Token: 0x06003193 RID: 12691 RVA: 0x001507B3 File Offset: 0x0014EBB3
	public Shadowless()
	{
	}

	// Token: 0x06003194 RID: 12692 RVA: 0x001507BC File Offset: 0x0014EBBC
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ShadowlessDamageEnhancementTalent
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
				SkillType = SkillType.Shadowless,
				SlotNumber = 1
			},
			new AttributeBoostMemberOnKillBasedOnSelfRateTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				SkillType = SkillType.Shadowless,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x06003195 RID: 12693 RVA: 0x0015089D File Offset: 0x0014EC9D
	private double GetDamagePercentage(Skill skill)
	{
		return 2.0 + (double)(skill.Level - 1) * 0.5;
	}

	// Token: 0x06003196 RID: 12694 RVA: 0x001508BC File Offset: 0x0014ECBC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003197 RID: 12695 RVA: 0x001508E8 File Offset: 0x0014ECE8
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new RelativeDamageDefinition(new List<DamageHitDefinition>(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}), new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), delegate(IBattleUnit caster, IBattleUnit target)
		{
			double num = caster.GetSpeed(AttributeRetrievalLevel.Skill);
			if (num <= 0.0)
			{
				num = 1.0;
			}
			double num2 = target.GetSpeed(AttributeRetrievalLevel.Skill);
			if (num2 <= 0.0)
			{
				num2 = 1.0;
			}
			double num3 = num / num2;
			if (num3 <= 0.5)
			{
				num3 = 0.5;
			}
			if (num3 >= 2.5)
			{
				num3 = 2.5;
			}
			if (skill.GetActiveTalents().OfType<ShadowlessDamageEnhancementTalent>().Any<ShadowlessDamageEnhancementTalent>())
			{
				double extraRate = ShadowlessDamageEnhancementTalent.ExtraRate;
				num3 *= 1.0 + extraRate;
			}
			return num3;
		}, skill);
	}

	// Token: 0x06003198 RID: 12696 RVA: 0x0015096F File Offset: 0x0014ED6F
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003199 RID: 12697 RVA: 0x00150978 File Offset: 0x0014ED78
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		ToughWomanStarAgileBoostData star = skill.SourceUnit.SpecialEffects.OfType<ToughWomanStarAgileBoostData>().FirstOrDefault<ToughWomanStarAgileBoostData>();
		if (star != null && skill.SourceUnit.IsAliveInBattle())
		{
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsFatal != null && d.IsFatal.Value))
				{
					IEnumerator enumerator2 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							Value = star.Rate,
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Multiplication,
							AttributeType = AttributeType.Agility,
							Key = string.Empty
						}
					}, "shadowlessstareffect", new int?(10), null, null, false, false, true), false).GetEnumerator();
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

	// Token: 0x17000710 RID: 1808
	// (get) Token: 0x0600319A RID: 12698 RVA: 0x001509A2 File Offset: 0x0014EDA2
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Shadowless;
		}
	}

	// Token: 0x17000711 RID: 1809
	// (get) Token: 0x0600319B RID: 12699 RVA: 0x001509A9 File Offset: 0x0014EDA9
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000712 RID: 1810
	// (get) Token: 0x0600319C RID: 12700 RVA: 0x001509B1 File Offset: 0x0014EDB1
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000713 RID: 1811
	// (get) Token: 0x0600319D RID: 12701 RVA: 0x001509B4 File Offset: 0x0014EDB4
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000714 RID: 1812
	// (get) Token: 0x0600319E RID: 12702 RVA: 0x001509B7 File Offset: 0x0014EDB7
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000715 RID: 1813
	// (get) Token: 0x0600319F RID: 12703 RVA: 0x001509BA File Offset: 0x0014EDBA
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027AC RID: 10156
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E6A RID: 3690
	[CompilerGenerated]
	private sealed class <GetDamageDefinition>c__AnonStorey1
	{
		// Token: 0x06005CCB RID: 23755 RVA: 0x001509BD File Offset: 0x0014EDBD
		public <GetDamageDefinition>c__AnonStorey1()
		{
		}

		// Token: 0x06005CCC RID: 23756 RVA: 0x001509C8 File Offset: 0x0014EDC8
		internal double <>m__0(IBattleUnit caster, IBattleUnit target)
		{
			double num = caster.GetSpeed(AttributeRetrievalLevel.Skill);
			if (num <= 0.0)
			{
				num = 1.0;
			}
			double num2 = target.GetSpeed(AttributeRetrievalLevel.Skill);
			if (num2 <= 0.0)
			{
				num2 = 1.0;
			}
			double num3 = num / num2;
			if (num3 <= 0.5)
			{
				num3 = 0.5;
			}
			if (num3 >= 2.5)
			{
				num3 = 2.5;
			}
			if (this.skill.GetActiveTalents().OfType<ShadowlessDamageEnhancementTalent>().Any<ShadowlessDamageEnhancementTalent>())
			{
				double extraRate = ShadowlessDamageEnhancementTalent.ExtraRate;
				num3 *= 1.0 + extraRate;
			}
			return num3;
		}

		// Token: 0x04004F8D RID: 20365
		internal AdventureUnitSkill skill;
	}

	// Token: 0x02000E6B RID: 3691
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CCD RID: 23757 RVA: 0x00150A7C File Offset: 0x0014EE7C
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CCE RID: 23758 RVA: 0x00150A84 File Offset: 0x0014EE84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				star = skill.SourceUnit.SpecialEffects.OfType<ToughWomanStarAgileBoostData>().FirstOrDefault<ToughWomanStarAgileBoostData>();
				if (star == null || !skill.SourceUnit.IsAliveInBattle())
				{
					goto IL_216;
				}
				enumerator = damage.BattleDamages.GetEnumerator();
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
					break;
				}
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsFatal != null && d.IsFatal.Value))
					{
						enumerator2 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								Value = star.Rate,
								AttributeModifierType = AttributeModifierType.Skill,
								ModificationType = ModificationType.Multiplication,
								AttributeType = AttributeType.Agility,
								Key = string.Empty
							}
						}, "shadowlessstareffect", new int?(10), null, null, false, false, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_216:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700135C RID: 4956
		// (get) Token: 0x06005CCF RID: 23759 RVA: 0x00150CE8 File Offset: 0x0014F0E8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700135D RID: 4957
		// (get) Token: 0x06005CD0 RID: 23760 RVA: 0x00150CF0 File Offset: 0x0014F0F0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CD1 RID: 23761 RVA: 0x00150CF8 File Offset: 0x0014F0F8
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

		// Token: 0x06005CD2 RID: 23762 RVA: 0x00150D8C File Offset: 0x0014F18C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CD3 RID: 23763 RVA: 0x00150D93 File Offset: 0x0014F193
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CD4 RID: 23764 RVA: 0x00150D9C File Offset: 0x0014F19C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Shadowless.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Shadowless.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005CD5 RID: 23765 RVA: 0x00150DDC File Offset: 0x0014F1DC
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsFatal != null && d.IsFatal.Value;
		}

		// Token: 0x04004F8E RID: 20366
		internal AdventureUnitSkill skill;

		// Token: 0x04004F8F RID: 20367
		internal ToughWomanStarAgileBoostData <star>__0;

		// Token: 0x04004F90 RID: 20368
		internal ReleaseableDamage damage;

		// Token: 0x04004F91 RID: 20369
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F92 RID: 20370
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F93 RID: 20371
		internal IEnumerator $locvar1;

		// Token: 0x04004F94 RID: 20372
		internal object <_>__2;

		// Token: 0x04004F95 RID: 20373
		internal IDisposable $locvar2;

		// Token: 0x04004F96 RID: 20374
		internal object $current;

		// Token: 0x04004F97 RID: 20375
		internal bool $disposing;

		// Token: 0x04004F98 RID: 20376
		internal int $PC;

		// Token: 0x04004F99 RID: 20377
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
