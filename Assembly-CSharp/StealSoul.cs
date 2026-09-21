using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200070A RID: 1802
public class StealSoul : MainSkillBase
{
	// Token: 0x060031C6 RID: 12742 RVA: 0x00151A50 File Offset: 0x0014FE50
	public StealSoul()
	{
	}

	// Token: 0x17000728 RID: 1832
	// (get) Token: 0x060031C7 RID: 12743 RVA: 0x00151A58 File Offset: 0x0014FE58
	public override SkillType SkillType
	{
		get
		{
			return SkillType.StealSoul;
		}
	}

	// Token: 0x17000729 RID: 1833
	// (get) Token: 0x060031C8 RID: 12744 RVA: 0x00151A5F File Offset: 0x0014FE5F
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060031C9 RID: 12745 RVA: 0x00151A68 File Offset: 0x0014FE68
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.StealSoul,
				SlotNumber = 1
			},
			new StealSoulDispelEnhancementTalent
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
				SkillType = SkillType.StealSoul,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x060031CA RID: 12746 RVA: 0x00151B51 File Offset: 0x0014FF51
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060031CB RID: 12747 RVA: 0x00151B70 File Offset: 0x0014FF70
	private double GetHealRate(Skill skill)
	{
		return 0.15 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x060031CC RID: 12748 RVA: 0x00151B90 File Offset: 0x0014FF90
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031CD RID: 12749 RVA: 0x00151BF4 File Offset: 0x0014FFF4
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x060031CE RID: 12750 RVA: 0x00151C73 File Offset: 0x00150073
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031CF RID: 12751 RVA: 0x00151C7C File Offset: 0x0015007C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		List<HealComponentValue> heals = new List<HealComponentValue>();
		int numberOfDispels = 1;
		if (skill.GetActiveTalents().OfType<StealSoulDispelEnhancementTalent>().Any<StealSoulDispelEnhancementTalent>())
		{
			numberOfDispels = StealSoulDispelEnhancementTalent.NumberOfDispels;
		}
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
			{
				if (damageComponent.IsCrit && damageComponent.Target.IsAliveInBattle())
				{
					IEnumerator enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(damageComponent.Target, new int?(numberOfDispels)).GetEnumerator();
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
		}
		ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
		{
			new BattleHeal(skill.SourceUnit, skill, heals, false)
		}, skill.SourceUnit);
		IEnumerator enumerator4 = releaseable.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x1700072A RID: 1834
	// (get) Token: 0x060031D0 RID: 12752 RVA: 0x00151CA6 File Offset: 0x001500A6
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700072B RID: 1835
	// (get) Token: 0x060031D1 RID: 12753 RVA: 0x00151CA9 File Offset: 0x001500A9
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x1700072C RID: 1836
	// (get) Token: 0x060031D2 RID: 12754 RVA: 0x00151CAC File Offset: 0x001500AC
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700072D RID: 1837
	// (get) Token: 0x060031D3 RID: 12755 RVA: 0x00151CAF File Offset: 0x001500AF
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B0 RID: 10160
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E6E RID: 3694
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CE7 RID: 23783 RVA: 0x00151CB2 File Offset: 0x001500B2
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CE8 RID: 23784 RVA: 0x00151CBC File Offset: 0x001500BC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				heals = new List<HealComponentValue>();
				numberOfDispels = 1;
				if (skill.GetActiveTalents().OfType<StealSoulDispelEnhancementTalent>().Any<StealSoulDispelEnhancementTalent>())
				{
					numberOfDispels = StealSoulDispelEnhancementTalent.NumberOfDispels;
				}
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_253;
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
							Block_11:
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
						while (enumerator2.MoveNext())
						{
							damageComponent = enumerator2.Current;
							if (damageComponent.IsCrit && damageComponent.Target.IsAliveInBattle())
							{
								enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(damageComponent.Target, new int?(numberOfDispels)).GetEnumerator();
								num = 4294967293u;
								goto Block_11;
							}
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
				}
				if (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					enumerator2 = damageBattleDamage.Damages.GetEnumerator();
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
			releaseable = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(skill.SourceUnit, skill, heals, false)
			}, skill.SourceUnit);
			enumerator4 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_253:
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001362 RID: 4962
		// (get) Token: 0x06005CE9 RID: 23785 RVA: 0x0015200C File Offset: 0x0015040C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001363 RID: 4963
		// (get) Token: 0x06005CEA RID: 23786 RVA: 0x00152014 File Offset: 0x00150414
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CEB RID: 23787 RVA: 0x0015201C File Offset: 0x0015041C
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
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

		// Token: 0x06005CEC RID: 23788 RVA: 0x00152110 File Offset: 0x00150510
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CED RID: 23789 RVA: 0x00152117 File Offset: 0x00150517
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CEE RID: 23790 RVA: 0x00152120 File Offset: 0x00150520
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StealSoul.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new StealSoul.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004FB9 RID: 20409
		internal List<HealComponentValue> <heals>__0;

		// Token: 0x04004FBA RID: 20410
		internal int <numberOfDispels>__0;

		// Token: 0x04004FBB RID: 20411
		internal AdventureUnitSkill skill;

		// Token: 0x04004FBC RID: 20412
		internal ReleaseableDamage damage;

		// Token: 0x04004FBD RID: 20413
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004FBE RID: 20414
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004FBF RID: 20415
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04004FC0 RID: 20416
		internal DamageComponent <damageComponent>__2;

		// Token: 0x04004FC1 RID: 20417
		internal IEnumerator $locvar2;

		// Token: 0x04004FC2 RID: 20418
		internal object <_>__3;

		// Token: 0x04004FC3 RID: 20419
		internal IDisposable $locvar3;

		// Token: 0x04004FC4 RID: 20420
		internal ReleaseableHeal <releaseable>__0;

		// Token: 0x04004FC5 RID: 20421
		internal IEnumerator $locvar4;

		// Token: 0x04004FC6 RID: 20422
		internal object <_>__4;

		// Token: 0x04004FC7 RID: 20423
		internal IDisposable $locvar5;

		// Token: 0x04004FC8 RID: 20424
		internal object $current;

		// Token: 0x04004FC9 RID: 20425
		internal bool $disposing;

		// Token: 0x04004FCA RID: 20426
		internal int $PC;
	}
}
