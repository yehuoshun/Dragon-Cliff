using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000702 RID: 1794
public class Roar : MainSkillBase
{
	// Token: 0x0600315B RID: 12635 RVA: 0x0014EE48 File Offset: 0x0014D248
	public Roar()
	{
	}

	// Token: 0x170006F8 RID: 1784
	// (get) Token: 0x0600315C RID: 12636 RVA: 0x0014EE50 File Offset: 0x0014D250
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Roar;
		}
	}

	// Token: 0x170006F9 RID: 1785
	// (get) Token: 0x0600315D RID: 12637 RVA: 0x0014EE57 File Offset: 0x0014D257
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600315E RID: 12638 RVA: 0x0014EE60 File Offset: 0x0014D260
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new RoarTargetEnhancementTalent
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
				SkillType = SkillType.Roar,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Roar,
				SlotNumber = 2
			}
		};
	}

	// Token: 0x0600315F RID: 12639 RVA: 0x0014EF44 File Offset: 0x0014D344
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, (!skill.GetActiveTalents().OfType<RoarTargetEnhancementTalent>().Any<RoarTargetEnhancementTalent>()) ? new int?(1) : null), skill);
	}

	// Token: 0x06003160 RID: 12640 RVA: 0x0014EFCA File Offset: 0x0014D3CA
	private double GetDamagePercentage(Skill skill)
	{
		return 1.5 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003161 RID: 12641 RVA: 0x0014EFE9 File Offset: 0x0014D3E9
	private double GetArmorReductionRate(Skill skill)
	{
		return 0.25 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x06003162 RID: 12642 RVA: 0x0014F008 File Offset: 0x0014D408
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.DecreaseRateKey, this.GetArmorReductionRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003163 RID: 12643 RVA: 0x0014F055 File Offset: 0x0014D455
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003164 RID: 12644 RVA: 0x0014F05C File Offset: 0x0014D45C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		double rate = 1.0 - ((!skill.GetActiveTalents().OfType<RoarTargetEnhancementTalent>().Any<RoarTargetEnhancementTalent>()) ? 0.0 : RoarTargetEnhancementTalent.PenetrationDecayRate);
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				IEnumerator enumerator2 = target.ApplySkillEffect(new RoarEffect(skill, this.GetArmorReductionRate(skill.Skill) * rate, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x170006FA RID: 1786
	// (get) Token: 0x06003165 RID: 12645 RVA: 0x0014F08D File Offset: 0x0014D48D
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006FB RID: 1787
	// (get) Token: 0x06003166 RID: 12646 RVA: 0x0014F090 File Offset: 0x0014D490
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170006FC RID: 1788
	// (get) Token: 0x06003167 RID: 12647 RVA: 0x0014F093 File Offset: 0x0014D493
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006FD RID: 1789
	// (get) Token: 0x06003168 RID: 12648 RVA: 0x0014F096 File Offset: 0x0014D496
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A8 RID: 10152
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E64 RID: 3684
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CA6 RID: 23718 RVA: 0x0014F099 File Offset: 0x0014D499
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CA7 RID: 23719 RVA: 0x0014F0A4 File Offset: 0x0014D4A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				rate = 1.0 - ((!skill.GetActiveTalents().OfType<RoarTargetEnhancementTalent>().Any<RoarTargetEnhancementTalent>()) ? 0.0 : RoarTargetEnhancementTalent.PenetrationDecayRate);
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
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						enumerator2 = target.ApplySkillEffect(new RoarEffect(skill, base.GetArmorReductionRate(skill.Skill) * rate, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_6;
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

		// Token: 0x17001354 RID: 4948
		// (get) Token: 0x06005CA8 RID: 23720 RVA: 0x0014F2AC File Offset: 0x0014D6AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001355 RID: 4949
		// (get) Token: 0x06005CA9 RID: 23721 RVA: 0x0014F2B4 File Offset: 0x0014D6B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CAA RID: 23722 RVA: 0x0014F2BC File Offset: 0x0014D6BC
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

		// Token: 0x06005CAB RID: 23723 RVA: 0x0014F350 File Offset: 0x0014D750
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CAC RID: 23724 RVA: 0x0014F357 File Offset: 0x0014D757
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CAD RID: 23725 RVA: 0x0014F360 File Offset: 0x0014D760
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Roar.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Roar.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F49 RID: 20297
		internal AdventureUnitSkill skill;

		// Token: 0x04004F4A RID: 20298
		internal double <rate>__0;

		// Token: 0x04004F4B RID: 20299
		internal ReleaseableDamage damage;

		// Token: 0x04004F4C RID: 20300
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F4D RID: 20301
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F4E RID: 20302
		internal IBattleUnit <target>__2;

		// Token: 0x04004F4F RID: 20303
		internal IEnumerator $locvar1;

		// Token: 0x04004F50 RID: 20304
		internal object <_>__3;

		// Token: 0x04004F51 RID: 20305
		internal IDisposable $locvar2;

		// Token: 0x04004F52 RID: 20306
		internal Roar $this;

		// Token: 0x04004F53 RID: 20307
		internal object $current;

		// Token: 0x04004F54 RID: 20308
		internal bool $disposing;

		// Token: 0x04004F55 RID: 20309
		internal int $PC;
	}
}
