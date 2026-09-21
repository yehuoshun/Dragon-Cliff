using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000703 RID: 1795
public class Scorn : MainSkillBase
{
	// Token: 0x06003169 RID: 12649 RVA: 0x0014F3AC File Offset: 0x0014D7AC
	public Scorn()
	{
	}

	// Token: 0x170006FE RID: 1790
	// (get) Token: 0x0600316A RID: 12650 RVA: 0x0014F3B4 File Offset: 0x0014D7B4
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Scorn;
		}
	}

	// Token: 0x0600316B RID: 12651 RVA: 0x0014F3BC File Offset: 0x0014D7BC
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ScornChanceEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new AttributeDebuffByValueOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Scorn,
				SlotNumber = 1
			},
			new DispelPositiveEffectOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Scorn,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x170006FF RID: 1791
	// (get) Token: 0x0600316C RID: 12652 RVA: 0x0014F4A5 File Offset: 0x0014D8A5
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600316D RID: 12653 RVA: 0x0014F4B0 File Offset: 0x0014D8B0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Strength, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x0600316E RID: 12654 RVA: 0x0014F512 File Offset: 0x0014D912
	private double GetDamagePercentage(Skill skill)
	{
		return 2.0 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x0600316F RID: 12655 RVA: 0x0014F531 File Offset: 0x0014D931
	private double GetChance(Skill skill)
	{
		return 0.68 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x06003170 RID: 12656 RVA: 0x0014F550 File Offset: 0x0014D950
	private double GetStrengthDecayRate(Skill skill)
	{
		return 0.5;
	}

	// Token: 0x06003171 RID: 12657 RVA: 0x0014F55C File Offset: 0x0014D95C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.GetChance(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetStrengthDecayRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003172 RID: 12658 RVA: 0x0014F5C0 File Offset: 0x0014D9C0
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003173 RID: 12659 RVA: 0x0014F5C8 File Offset: 0x0014D9C8
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		double chance = this.GetChance(skill.Skill);
		double decayrate = this.GetStrengthDecayRate(skill.Skill);
		if (skill.GetActiveTalents().OfType<ScornChanceEnhancementTalent>().Any<ScornChanceEnhancementTalent>())
		{
			decayrate += ((!skill.GetActiveTalents().OfType<ScornChanceEnhancementTalent>().Any<ScornChanceEnhancementTalent>()) ? 0.0 : ScornChanceEnhancementTalent.Rate);
		}
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active && (double)UnityEngine.Random.value <= chance)
			{
				IEnumerator enumerator2 = target.ApplySkillEffect(AttributeModificationEffect.CreateStrengthDecayEffect(skill, decayrate, base.GetType().FullName), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x17000700 RID: 1792
	// (get) Token: 0x06003174 RID: 12660 RVA: 0x0014F5F9 File Offset: 0x0014D9F9
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000701 RID: 1793
	// (get) Token: 0x06003175 RID: 12661 RVA: 0x0014F5FC File Offset: 0x0014D9FC
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000702 RID: 1794
	// (get) Token: 0x06003176 RID: 12662 RVA: 0x0014F5FF File Offset: 0x0014D9FF
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000703 RID: 1795
	// (get) Token: 0x06003177 RID: 12663 RVA: 0x0014F602 File Offset: 0x0014DA02
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A9 RID: 10153
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E65 RID: 3685
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CAE RID: 23726 RVA: 0x0014F605 File Offset: 0x0014DA05
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CAF RID: 23727 RVA: 0x0014F610 File Offset: 0x0014DA10
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				chance = base.GetChance(skill.Skill);
				decayrate = base.GetStrengthDecayRate(skill.Skill);
				if (skill.GetActiveTalents().OfType<ScornChanceEnhancementTalent>().Any<ScornChanceEnhancementTalent>())
				{
					decayrate += ((!skill.GetActiveTalents().OfType<ScornChanceEnhancementTalent>().Any<ScornChanceEnhancementTalent>()) ? 0.0 : ScornChanceEnhancementTalent.Rate);
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
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active && (double)UnityEngine.Random.value <= chance)
					{
						enumerator2 = target.ApplySkillEffect(AttributeModificationEffect.CreateStrengthDecayEffect(skill, decayrate, base.GetType().FullName), false).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001356 RID: 4950
		// (get) Token: 0x06005CB0 RID: 23728 RVA: 0x0014F860 File Offset: 0x0014DC60
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001357 RID: 4951
		// (get) Token: 0x06005CB1 RID: 23729 RVA: 0x0014F868 File Offset: 0x0014DC68
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CB2 RID: 23730 RVA: 0x0014F870 File Offset: 0x0014DC70
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

		// Token: 0x06005CB3 RID: 23731 RVA: 0x0014F904 File Offset: 0x0014DD04
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CB4 RID: 23732 RVA: 0x0014F90B File Offset: 0x0014DD0B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CB5 RID: 23733 RVA: 0x0014F914 File Offset: 0x0014DD14
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Scorn.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Scorn.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F56 RID: 20310
		internal AdventureUnitSkill skill;

		// Token: 0x04004F57 RID: 20311
		internal double <chance>__0;

		// Token: 0x04004F58 RID: 20312
		internal double <decayrate>__0;

		// Token: 0x04004F59 RID: 20313
		internal ReleaseableDamage damage;

		// Token: 0x04004F5A RID: 20314
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F5B RID: 20315
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F5C RID: 20316
		internal IBattleUnit <target>__2;

		// Token: 0x04004F5D RID: 20317
		internal IEnumerator $locvar1;

		// Token: 0x04004F5E RID: 20318
		internal object <_>__3;

		// Token: 0x04004F5F RID: 20319
		internal IDisposable $locvar2;

		// Token: 0x04004F60 RID: 20320
		internal Scorn $this;

		// Token: 0x04004F61 RID: 20321
		internal object $current;

		// Token: 0x04004F62 RID: 20322
		internal bool $disposing;

		// Token: 0x04004F63 RID: 20323
		internal int $PC;
	}
}
