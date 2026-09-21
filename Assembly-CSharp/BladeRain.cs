using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x020006E7 RID: 1767
public class BladeRain : MainSkillBase
{
	// Token: 0x06002FFD RID: 12285 RVA: 0x001472EF File Offset: 0x001456EF
	public BladeRain()
	{
	}

	// Token: 0x1700065A RID: 1626
	// (get) Token: 0x06002FFE RID: 12286 RVA: 0x001472F7 File Offset: 0x001456F7
	public override SkillType SkillType
	{
		get
		{
			return SkillType.BladeRain;
		}
	}

	// Token: 0x1700065B RID: 1627
	// (get) Token: 0x06002FFF RID: 12287 RVA: 0x001472FE File Offset: 0x001456FE
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003000 RID: 12288 RVA: 0x00147308 File Offset: 0x00145708
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.BladeRain,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.BladeRain,
				SlotNumber = 1
			},
			new AttributeBoostOnKillTalentByRate
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.BladeRain,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x06003001 RID: 12289 RVA: 0x00147403 File Offset: 0x00145803
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003002 RID: 12290 RVA: 0x0014740C File Offset: 0x0014580C
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x06003003 RID: 12291 RVA: 0x0014748F File Offset: 0x0014588F
	private double GetDamagePercentage(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x06003004 RID: 12292 RVA: 0x001474AE File Offset: 0x001458AE
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x06003005 RID: 12293 RVA: 0x001474D0 File Offset: 0x001458D0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003006 RID: 12294 RVA: 0x00147520 File Offset: 0x00145920
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		RedHornStarDamageBoostData star = skill.SourceUnit.SpecialEffects.OfType<RedHornStarDamageBoostData>().FirstOrDefault<RedHornStarDamageBoostData>();
		if (star != null)
		{
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.GetTotalDamageSoFar() > 0.0))
				{
					IEnumerator enumerator2 = damageBattleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = -0.1,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "bladerainstar", new int?(1), new float?(5f), null, false, false), false).GetEnumerator();
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

	// Token: 0x1700065C RID: 1628
	// (get) Token: 0x06003007 RID: 12295 RVA: 0x0014754A File Offset: 0x0014594A
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700065D RID: 1629
	// (get) Token: 0x06003008 RID: 12296 RVA: 0x0014754D File Offset: 0x0014594D
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x1700065E RID: 1630
	// (get) Token: 0x06003009 RID: 12297 RVA: 0x00147550 File Offset: 0x00145950
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x1700065F RID: 1631
	// (get) Token: 0x0600300A RID: 12298 RVA: 0x00147553 File Offset: 0x00145953
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002789 RID: 10121
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E4D RID: 3661
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BFD RID: 23549 RVA: 0x00147556 File Offset: 0x00145956
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005BFE RID: 23550 RVA: 0x00147560 File Offset: 0x00145960
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				star = skill.SourceUnit.SpecialEffects.OfType<RedHornStarDamageBoostData>().FirstOrDefault<RedHornStarDamageBoostData>();
				if (star == null)
				{
					goto IL_201;
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
					Block_7:
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
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.GetTotalDamageSoFar() > 0.0))
					{
						enumerator2 = damageBattleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = -0.1,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "bladerainstar", new int?(1), new float?(5f), null, false, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_7;
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
			IL_201:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001330 RID: 4912
		// (get) Token: 0x06005BFF RID: 23551 RVA: 0x001477AC File Offset: 0x00145BAC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001331 RID: 4913
		// (get) Token: 0x06005C00 RID: 23552 RVA: 0x001477B4 File Offset: 0x00145BB4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C01 RID: 23553 RVA: 0x001477BC File Offset: 0x00145BBC
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

		// Token: 0x06005C02 RID: 23554 RVA: 0x00147850 File Offset: 0x00145C50
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C03 RID: 23555 RVA: 0x00147857 File Offset: 0x00145C57
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C04 RID: 23556 RVA: 0x00147860 File Offset: 0x00145C60
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BladeRain.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new BladeRain.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C05 RID: 23557 RVA: 0x001478A0 File Offset: 0x00145CA0
		private static bool <>m__0(DamageComponent d)
		{
			return d.GetTotalDamageSoFar() > 0.0;
		}

		// Token: 0x04004E25 RID: 20005
		internal AdventureUnitSkill skill;

		// Token: 0x04004E26 RID: 20006
		internal RedHornStarDamageBoostData <star>__0;

		// Token: 0x04004E27 RID: 20007
		internal ReleaseableDamage damage;

		// Token: 0x04004E28 RID: 20008
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E29 RID: 20009
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E2A RID: 20010
		internal IEnumerator $locvar1;

		// Token: 0x04004E2B RID: 20011
		internal object <_>__2;

		// Token: 0x04004E2C RID: 20012
		internal IDisposable $locvar2;

		// Token: 0x04004E2D RID: 20013
		internal object $current;

		// Token: 0x04004E2E RID: 20014
		internal bool $disposing;

		// Token: 0x04004E2F RID: 20015
		internal int $PC;

		// Token: 0x04004E30 RID: 20016
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
