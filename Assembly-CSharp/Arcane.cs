using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006E5 RID: 1765
public class Arcane : MainSkillBase
{
	// Token: 0x06002FE1 RID: 12257 RVA: 0x00146A3A File Offset: 0x00144E3A
	public Arcane()
	{
	}

	// Token: 0x1700064D RID: 1613
	// (get) Token: 0x06002FE2 RID: 12258 RVA: 0x00146A42 File Offset: 0x00144E42
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Arcane;
		}
	}

	// Token: 0x1700064E RID: 1614
	// (get) Token: 0x06002FE3 RID: 12259 RVA: 0x00146A49 File Offset: 0x00144E49
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06002FE4 RID: 12260 RVA: 0x00146A54 File Offset: 0x00144E54
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ArcaneCritEnhancementTalent
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
				SkillType = SkillType.Arcane,
				SlotNumber = 1
			},
			new SelfHealOnKillTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Arcane,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x06002FE5 RID: 12261 RVA: 0x00146B40 File Offset: 0x00144F40
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Lightening), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x06002FE6 RID: 12262 RVA: 0x00146BBF File Offset: 0x00144FBF
	private double GetDamagePercentage(Skill skill)
	{
		return 0.9 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002FE7 RID: 12263 RVA: 0x00146BDE File Offset: 0x00144FDE
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.9 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002FE8 RID: 12264 RVA: 0x00146C00 File Offset: 0x00145000
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06002FE9 RID: 12265 RVA: 0x00146C4D File Offset: 0x0014504D
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002FEA RID: 12266 RVA: 0x00146C54 File Offset: 0x00145054
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
			{
				double rate = 0.15 + skill.SourceUnit.SpecialEffects.OfType<DrunkReaderEnhancementData>().Sum((DrunkReaderEnhancementData d) => d.CritDamageBoost);
				if (skill.GetActiveTalents().OfType<ArcaneCritEnhancementTalent>().Any<ArcaneCritEnhancementTalent>())
				{
					rate = ArcaneCritEnhancementTalent.Rate + skill.SourceUnit.SpecialEffects.OfType<DrunkReaderEnhancementData>().Sum((DrunkReaderEnhancementData d) => d.CritDamageBoost);
				}
				foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
				{
					if (damageComponent.IsCrit)
					{
						IEnumerator enumerator3 = caster.ApplySkillEffect(AttributeModificationEffect.CreateArcaneFocusedEffect(skill, rate, base.GetType().FullName), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x1700064F RID: 1615
	// (get) Token: 0x06002FEB RID: 12267 RVA: 0x00146C85 File Offset: 0x00145085
	public List<AttributeModifier> AdditionalAttributeModifiers
	{
		get
		{
			return new List<AttributeModifier>();
		}
	}

	// Token: 0x17000650 RID: 1616
	// (get) Token: 0x06002FEC RID: 12268 RVA: 0x00146C8C File Offset: 0x0014508C
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000651 RID: 1617
	// (get) Token: 0x06002FED RID: 12269 RVA: 0x00146C8F File Offset: 0x0014508F
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Lightening;
		}
	}

	// Token: 0x17000652 RID: 1618
	// (get) Token: 0x06002FEE RID: 12270 RVA: 0x00146C92 File Offset: 0x00145092
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000653 RID: 1619
	// (get) Token: 0x06002FEF RID: 12271 RVA: 0x00146C95 File Offset: 0x00145095
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002787 RID: 10119
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E4C RID: 3660
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BF3 RID: 23539 RVA: 0x00146C98 File Offset: 0x00145098
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005BF4 RID: 23540 RVA: 0x00146CA0 File Offset: 0x001450A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = skill.SourceUnit;
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
						case 1u:
							Block_12:
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
							if (damageComponent.IsCrit)
							{
								enumerator3 = caster.ApplySkillEffect(AttributeModificationEffect.CreateArcaneFocusedEffect(skill, rate, base.GetType().FullName), false).GetEnumerator();
								num = 4294967293u;
								goto Block_12;
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
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
					{
						rate = 0.15 + skill.SourceUnit.SpecialEffects.OfType<DrunkReaderEnhancementData>().Sum((DrunkReaderEnhancementData d) => d.CritDamageBoost);
						if (skill.GetActiveTalents().OfType<ArcaneCritEnhancementTalent>().Any<ArcaneCritEnhancementTalent>())
						{
							rate = ArcaneCritEnhancementTalent.Rate + skill.SourceUnit.SpecialEffects.OfType<DrunkReaderEnhancementData>().Sum((DrunkReaderEnhancementData d) => d.CritDamageBoost);
						}
						enumerator2 = damageBattleDamage.Damages.GetEnumerator();
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

		// Token: 0x1700132E RID: 4910
		// (get) Token: 0x06005BF5 RID: 23541 RVA: 0x00146F8C File Offset: 0x0014538C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700132F RID: 4911
		// (get) Token: 0x06005BF6 RID: 23542 RVA: 0x00146F94 File Offset: 0x00145394
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x00146F9C File Offset: 0x0014539C
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
			}
		}

		// Token: 0x06005BF8 RID: 23544 RVA: 0x00147054 File Offset: 0x00145454
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BF9 RID: 23545 RVA: 0x0014705B File Offset: 0x0014545B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BFA RID: 23546 RVA: 0x00147064 File Offset: 0x00145464
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Arcane.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Arcane.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005BFB RID: 23547 RVA: 0x001470B0 File Offset: 0x001454B0
		private static double <>m__0(DrunkReaderEnhancementData d)
		{
			return d.CritDamageBoost;
		}

		// Token: 0x06005BFC RID: 23548 RVA: 0x001470B8 File Offset: 0x001454B8
		private static double <>m__1(DrunkReaderEnhancementData d)
		{
			return d.CritDamageBoost;
		}

		// Token: 0x04004E14 RID: 19988
		internal AdventureUnitSkill skill;

		// Token: 0x04004E15 RID: 19989
		internal IBattleUnit <caster>__0;

		// Token: 0x04004E16 RID: 19990
		internal ReleaseableDamage damage;

		// Token: 0x04004E17 RID: 19991
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E18 RID: 19992
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004E19 RID: 19993
		internal double <rate>__2;

		// Token: 0x04004E1A RID: 19994
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04004E1B RID: 19995
		internal DamageComponent <damageComponent>__3;

		// Token: 0x04004E1C RID: 19996
		internal IEnumerator $locvar2;

		// Token: 0x04004E1D RID: 19997
		internal object <_>__4;

		// Token: 0x04004E1E RID: 19998
		internal IDisposable $locvar3;

		// Token: 0x04004E1F RID: 19999
		internal Arcane $this;

		// Token: 0x04004E20 RID: 20000
		internal object $current;

		// Token: 0x04004E21 RID: 20001
		internal bool $disposing;

		// Token: 0x04004E22 RID: 20002
		internal int $PC;

		// Token: 0x04004E23 RID: 20003
		private static Func<DrunkReaderEnhancementData, double> <>f__am$cache0;

		// Token: 0x04004E24 RID: 20004
		private static Func<DrunkReaderEnhancementData, double> <>f__am$cache1;
	}
}
