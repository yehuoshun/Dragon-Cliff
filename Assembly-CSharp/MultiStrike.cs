using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006FC RID: 1788
public class MultiStrike : MainSkillBase
{
	// Token: 0x0600310E RID: 12558 RVA: 0x0014D612 File Offset: 0x0014BA12
	public MultiStrike()
	{
	}

	// Token: 0x170006D4 RID: 1748
	// (get) Token: 0x0600310F RID: 12559 RVA: 0x0014D61A File Offset: 0x0014BA1A
	public override SkillType SkillType
	{
		get
		{
			return SkillType.MultiStrike;
		}
	}

	// Token: 0x170006D5 RID: 1749
	// (get) Token: 0x06003110 RID: 12560 RVA: 0x0014D621 File Offset: 0x0014BA21
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003111 RID: 12561 RVA: 0x0014D62C File Offset: 0x0014BA2C
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			},
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			},
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x06003112 RID: 12562 RVA: 0x0014D759 File Offset: 0x0014BB59
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.08;
	}

	// Token: 0x06003113 RID: 12563 RVA: 0x0014D778 File Offset: 0x0014BB78
	private double GetFocusBoostValue(Skill skill)
	{
		return 0.2;
	}

	// Token: 0x06003114 RID: 12564 RVA: 0x0014D784 File Offset: 0x0014BB84
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.BoostRateKey, this.GetFocusBoostValue(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003115 RID: 12565 RVA: 0x0014D7E8 File Offset: 0x0014BBE8
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003116 RID: 12566 RVA: 0x0014D7F0 File Offset: 0x0014BBF0
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
			{
				if (!damageComponent.IsCrit)
				{
					AttributeModificationEffect effect = AttributeModificationEffect.CreateMultiStrikeFocusedEffect(skill, this.GetFocusBoostValue(skill.Skill), base.GetType().FullName);
					IEnumerator enumerator3 = skill.SourceUnit.ApplySkillEffect(effect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x170006D6 RID: 1750
	// (get) Token: 0x06003117 RID: 12567 RVA: 0x0014D821 File Offset: 0x0014BC21
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006D7 RID: 1751
	// (get) Token: 0x06003118 RID: 12568 RVA: 0x0014D824 File Offset: 0x0014BC24
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Poison;
		}
	}

	// Token: 0x170006D8 RID: 1752
	// (get) Token: 0x06003119 RID: 12569 RVA: 0x0014D827 File Offset: 0x0014BC27
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006D9 RID: 1753
	// (get) Token: 0x0600311A RID: 12570 RVA: 0x0014D82A File Offset: 0x0014BC2A
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A2 RID: 10146
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E5E RID: 3678
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C7F RID: 23679 RVA: 0x0014D82D File Offset: 0x0014BC2D
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C80 RID: 23680 RVA: 0x0014D838 File Offset: 0x0014BC38
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
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
					Block_4:
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
							if (!damageComponent.IsCrit)
							{
								effect = AttributeModificationEffect.CreateMultiStrikeFocusedEffect(skill, base.GetFocusBoostValue(skill.Skill), base.GetType().FullName);
								enumerator3 = skill.SourceUnit.ApplySkillEffect(effect, false).GetEnumerator();
								num = 4294967293u;
								goto Block_8;
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
					goto Block_4;
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

		// Token: 0x1700134C RID: 4940
		// (get) Token: 0x06005C81 RID: 23681 RVA: 0x0014DA78 File Offset: 0x0014BE78
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700134D RID: 4941
		// (get) Token: 0x06005C82 RID: 23682 RVA: 0x0014DA80 File Offset: 0x0014BE80
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C83 RID: 23683 RVA: 0x0014DA88 File Offset: 0x0014BE88
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

		// Token: 0x06005C84 RID: 23684 RVA: 0x0014DB40 File Offset: 0x0014BF40
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C85 RID: 23685 RVA: 0x0014DB47 File Offset: 0x0014BF47
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C86 RID: 23686 RVA: 0x0014DB50 File Offset: 0x0014BF50
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MultiStrike.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new MultiStrike.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F09 RID: 20233
		internal ReleaseableDamage damage;

		// Token: 0x04004F0A RID: 20234
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004F0B RID: 20235
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004F0C RID: 20236
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04004F0D RID: 20237
		internal DamageComponent <damageComponent>__2;

		// Token: 0x04004F0E RID: 20238
		internal AdventureUnitSkill skill;

		// Token: 0x04004F0F RID: 20239
		internal AttributeModificationEffect <effect>__3;

		// Token: 0x04004F10 RID: 20240
		internal IEnumerator $locvar2;

		// Token: 0x04004F11 RID: 20241
		internal object <_>__4;

		// Token: 0x04004F12 RID: 20242
		internal IDisposable $locvar3;

		// Token: 0x04004F13 RID: 20243
		internal MultiStrike $this;

		// Token: 0x04004F14 RID: 20244
		internal object $current;

		// Token: 0x04004F15 RID: 20245
		internal bool $disposing;

		// Token: 0x04004F16 RID: 20246
		internal int $PC;
	}
}
