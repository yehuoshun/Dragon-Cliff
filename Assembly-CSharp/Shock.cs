using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000708 RID: 1800
public class Shock : MainSkillBase
{
	// Token: 0x060031AE RID: 12718 RVA: 0x00151320 File Offset: 0x0014F720
	public Shock()
	{
	}

	// Token: 0x060031AF RID: 12719 RVA: 0x00151328 File Offset: 0x0014F728
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x060031B0 RID: 12720 RVA: 0x00151347 File Offset: 0x0014F747
	private double GetProgressChangeRate(Skill skill)
	{
		return -(0.2 + (double)(skill.Level - 1) * 0.04);
	}

	// Token: 0x060031B1 RID: 12721 RVA: 0x00151368 File Offset: 0x0014F768
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.ProgressChangeRateKey, this.GetProgressChangeRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031B2 RID: 12722 RVA: 0x001513CC File Offset: 0x0014F7CC
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x060031B3 RID: 12723 RVA: 0x0015144F File Offset: 0x0014F84F
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031B4 RID: 12724 RVA: 0x00151458 File Offset: 0x0014F858
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				UnitTurnProgressUpdateEvent pushEffect = new UnitTurnProgressUpdateEvent
				{
					CausingSource = skill,
					Dealer = caster,
					ChangePercentage = this.GetProgressChangeRate(skill.Skill)
				};
				List<BattleEffectBase> positiveEffects = (from ef in target.BattleEffects
				where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
				select ef).ToList<BattleEffectBase>();
				if (positiveEffects.Any<BattleEffectBase>())
				{
					positiveEffects.Shuffle<BattleEffectBase>();
					IEnumerator enumerator2 = target.DisperseEffect(positiveEffects.First<BattleEffectBase>(), caster).GetEnumerator();
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
				IEnumerator enumerator3 = target.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x1700071C RID: 1820
	// (get) Token: 0x060031B5 RID: 12725 RVA: 0x00151489 File Offset: 0x0014F889
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Shock;
		}
	}

	// Token: 0x1700071D RID: 1821
	// (get) Token: 0x060031B6 RID: 12726 RVA: 0x00151490 File Offset: 0x0014F890
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700071E RID: 1822
	// (get) Token: 0x060031B7 RID: 12727 RVA: 0x00151498 File Offset: 0x0014F898
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700071F RID: 1823
	// (get) Token: 0x060031B8 RID: 12728 RVA: 0x0015149B File Offset: 0x0014F89B
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000720 RID: 1824
	// (get) Token: 0x060031B9 RID: 12729 RVA: 0x0015149E File Offset: 0x0014F89E
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x17000721 RID: 1825
	// (get) Token: 0x060031BA RID: 12730 RVA: 0x001514A1 File Offset: 0x0014F8A1
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027AE RID: 10158
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E6D RID: 3693
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CDE RID: 23774 RVA: 0x001514A4 File Offset: 0x0014F8A4
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CDF RID: 23775 RVA: 0x001514AC File Offset: 0x0014F8AC
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
					goto IL_1D9;
				case 2u:
					Block_8:
					try
					{
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
					break;
				}
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						pushEffect = new UnitTurnProgressUpdateEvent
						{
							CausingSource = skill,
							Dealer = caster,
							ChangePercentage = base.GetProgressChangeRate(skill.Skill)
						};
						positiveEffects = (from ef in target.BattleEffects
						where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
						select ef).ToList<BattleEffectBase>();
						if (positiveEffects.Any<BattleEffectBase>())
						{
							positiveEffects.Shuffle<BattleEffectBase>();
							enumerator2 = target.DisperseEffect(positiveEffects.First<BattleEffectBase>(), caster).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
						}
						goto IL_1D9;
					}
				}
				goto IL_2A5;
				IL_1D9:
				enumerator3 = target.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2A5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001360 RID: 4960
		// (get) Token: 0x06005CE0 RID: 23776 RVA: 0x001517B4 File Offset: 0x0014FBB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001361 RID: 4961
		// (get) Token: 0x06005CE1 RID: 23777 RVA: 0x001517BC File Offset: 0x0014FBBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CE2 RID: 23778 RVA: 0x001517C4 File Offset: 0x0014FBC4
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005CE3 RID: 23779 RVA: 0x001518AC File Offset: 0x0014FCAC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CE4 RID: 23780 RVA: 0x001518B3 File Offset: 0x0014FCB3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CE5 RID: 23781 RVA: 0x001518BC File Offset: 0x0014FCBC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Shock.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Shock.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005CE6 RID: 23782 RVA: 0x00151908 File Offset: 0x0014FD08
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed;
		}

		// Token: 0x04004FA6 RID: 20390
		internal AdventureUnitSkill skill;

		// Token: 0x04004FA7 RID: 20391
		internal IBattleUnit <caster>__0;

		// Token: 0x04004FA8 RID: 20392
		internal ReleaseableDamage damage;

		// Token: 0x04004FA9 RID: 20393
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004FAA RID: 20394
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004FAB RID: 20395
		internal IBattleUnit <target>__2;

		// Token: 0x04004FAC RID: 20396
		internal UnitTurnProgressUpdateEvent <pushEffect>__3;

		// Token: 0x04004FAD RID: 20397
		internal List<BattleEffectBase> <positiveEffects>__3;

		// Token: 0x04004FAE RID: 20398
		internal IEnumerator $locvar1;

		// Token: 0x04004FAF RID: 20399
		internal object <_>__4;

		// Token: 0x04004FB0 RID: 20400
		internal IDisposable $locvar2;

		// Token: 0x04004FB1 RID: 20401
		internal IEnumerator $locvar3;

		// Token: 0x04004FB2 RID: 20402
		internal object <_>__5;

		// Token: 0x04004FB3 RID: 20403
		internal IDisposable $locvar4;

		// Token: 0x04004FB4 RID: 20404
		internal Shock $this;

		// Token: 0x04004FB5 RID: 20405
		internal object $current;

		// Token: 0x04004FB6 RID: 20406
		internal bool $disposing;

		// Token: 0x04004FB7 RID: 20407
		internal int $PC;

		// Token: 0x04004FB8 RID: 20408
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}
}
