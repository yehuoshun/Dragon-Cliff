using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000705 RID: 1797
public class ShadowSacrifice : MainSkillBase
{
	// Token: 0x06003185 RID: 12677 RVA: 0x0014FDB0 File Offset: 0x0014E1B0
	public ShadowSacrifice()
	{
	}

	// Token: 0x06003186 RID: 12678 RVA: 0x0014FDB8 File Offset: 0x0014E1B8
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ShadowSacrificeExplosionEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new ShadowSacrificeStunEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new ShadowSacrificeHealOnExpTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x06003187 RID: 12679 RVA: 0x0014FE7B File Offset: 0x0014E27B
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003188 RID: 12680 RVA: 0x0014FE9A File Offset: 0x0014E29A
	private double GetExplosionRate(Skill skill)
	{
		return 0.5 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06003189 RID: 12681 RVA: 0x0014FEBC File Offset: 0x0014E2BC
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Shadow), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x0600318A RID: 12682 RVA: 0x0014FF3C File Offset: 0x0014E33C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.ExplosiveDamageRateKey, this.GetExplosionRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600318B RID: 12683 RVA: 0x0014FFA0 File Offset: 0x0014E3A0
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600318C RID: 12684 RVA: 0x0014FFA8 File Offset: 0x0014E3A8
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		double extraRate = (!skill.GetActiveTalents().OfType<ShadowSacrificeExplosionEnhancementTalent>().Any<ShadowSacrificeExplosionEnhancementTalent>()) ? 0.0 : ShadowSacrificeExplosionEnhancementTalent.ExtraRate;
		if (damage.BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value)))
		{
			List<BattleDamage> extraDamages = new List<BattleDamage>();
			List<IBattleUnit> otherEnemies = skill.SourceUnit.GetLiveEnemyTargets(false, true);
			int stunSeconds = (!skill.GetActiveTalents().OfType<ShadowSacrificeStunEnhancementTalent>().Any<ShadowSacrificeStunEnhancementTalent>()) ? 0 : ShadowSacrificeStunEnhancementTalent.StunSeconds;
			foreach (IBattleUnit otherEnemy in otherEnemies)
			{
				extraDamages.Add(new BattleDamage(otherEnemy, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(skill.SourceUnit, otherEnemy, OutputType.Shadow, this.GetExplosionRate(skill.Skill) + extraRate)
					}, otherEnemy, skill.SourceUnit, false, false)
				}));
				if (stunSeconds > 0)
				{
					IEnumerator enumerator2 = LockTimeEffect.AddStunSeconds(otherEnemy, (float)stunSeconds, skill.SourceUnit, true).GetEnumerator();
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
			ReleaseableDamage releaseable = new ReleaseableDamage(extraDamages, skill.SourceUnit);
			IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
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
			double healrate = (!skill.GetActiveTalents().OfType<ShadowSacrificeHealOnExpTalent>().Any<ShadowSacrificeHealOnExpTalent>()) ? 0.0 : ShadowSacrificeHealOnExpTalent.HealRate;
			if (healrate > 0.0)
			{
				List<IBattleUnit> targets = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in targets
				select new BattleHeal(t, skill.SourceUnit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = healrate * t.GetMaxLife(AttributeRetrievalLevel.Skill),
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), skill.SourceUnit);
				IEnumerator enumerator4 = releaseableHeal.Release().GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _3 = enumerator4.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x1700070A RID: 1802
	// (get) Token: 0x0600318D RID: 12685 RVA: 0x0014FFD9 File Offset: 0x0014E3D9
	public override SkillType SkillType
	{
		get
		{
			return SkillType.ShadowSacrifice;
		}
	}

	// Token: 0x1700070B RID: 1803
	// (get) Token: 0x0600318E RID: 12686 RVA: 0x0014FFE0 File Offset: 0x0014E3E0
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700070C RID: 1804
	// (get) Token: 0x0600318F RID: 12687 RVA: 0x0014FFE8 File Offset: 0x0014E3E8
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700070D RID: 1805
	// (get) Token: 0x06003190 RID: 12688 RVA: 0x0014FFEB File Offset: 0x0014E3EB
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Shadow;
		}
	}

	// Token: 0x1700070E RID: 1806
	// (get) Token: 0x06003191 RID: 12689 RVA: 0x0014FFEE File Offset: 0x0014E3EE
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700070F RID: 1807
	// (get) Token: 0x06003192 RID: 12690 RVA: 0x0014FFF1 File Offset: 0x0014E3F1
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027AB RID: 10155
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E67 RID: 3687
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CBE RID: 23742 RVA: 0x0014FFF4 File Offset: 0x0014E3F4
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CBF RID: 23743 RVA: 0x0014FFFC File Offset: 0x0014E3FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				<PostDamageProcess>c__AnonStorey = new ShadowSacrifice.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey1();
				<PostDamageProcess>c__AnonStorey.skill = skill;
				extraRate = ((!<PostDamageProcess>c__AnonStorey.skill.GetActiveTalents().OfType<ShadowSacrificeExplosionEnhancementTalent>().Any<ShadowSacrificeExplosionEnhancementTalent>()) ? 0.0 : ShadowSacrificeExplosionEnhancementTalent.ExtraRate);
				if (!damage.BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value)))
				{
					goto IL_4F2;
				}
				extraDamages = new List<BattleDamage>();
				otherEnemies = <PostDamageProcess>c__AnonStorey.skill.SourceUnit.GetLiveEnemyTargets(false, true);
				stunSeconds = ((!<PostDamageProcess>c__AnonStorey.skill.GetActiveTalents().OfType<ShadowSacrificeStunEnhancementTalent>().Any<ShadowSacrificeStunEnhancementTalent>()) ? 0 : ShadowSacrificeStunEnhancementTalent.StunSeconds);
				enumerator = otherEnemies.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_323;
			case 3u:
				goto IL_46E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_13:
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
					otherEnemy = enumerator.Current;
					extraDamages.Add(new BattleDamage(otherEnemy, <PostDamageProcess>c__AnonStorey.skill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(<PostDamageProcess>c__AnonStorey.skill.SourceUnit, otherEnemy, OutputType.Shadow, base.GetExplosionRate(<PostDamageProcess>c__AnonStorey.skill.Skill) + extraRate)
						}, otherEnemy, <PostDamageProcess>c__AnonStorey.skill.SourceUnit, false, false)
					}));
					if (stunSeconds > 0)
					{
						enumerator2 = LockTimeEffect.AddStunSeconds(otherEnemy, (float)stunSeconds, <PostDamageProcess>c__AnonStorey.skill.SourceUnit, true).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
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
			releaseable = new ReleaseableDamage(extraDamages, <PostDamageProcess>c__AnonStorey.skill.SourceUnit);
			enumerator3 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_323:
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
			<PostDamageProcess>c__AnonStorey2.healrate = ((!<PostDamageProcess>c__AnonStorey.skill.GetActiveTalents().OfType<ShadowSacrificeHealOnExpTalent>().Any<ShadowSacrificeHealOnExpTalent>()) ? 0.0 : ShadowSacrificeHealOnExpTalent.HealRate);
			if (<PostDamageProcess>c__AnonStorey2.healrate <= 0.0)
			{
				goto IL_4F2;
			}
			targets = <PostDamageProcess>c__AnonStorey.skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			releaseableHeal = new ReleaseableHeal((from t in targets
			select new BattleHeal(t, <PostDamageProcess>c__AnonStorey2.<>f__ref$1.skill.SourceUnit, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = <PostDamageProcess>c__AnonStorey2.healrate * t.GetMaxLife(AttributeRetrievalLevel.Skill),
					HealType = OutputType.RealHeal,
					IsDirectHeal = false
				}
			}, false)).ToList<BattleHeal>(), <PostDamageProcess>c__AnonStorey.skill.SourceUnit);
			enumerator4 = releaseableHeal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_46E:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_4F2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700135A RID: 4954
		// (get) Token: 0x06005CC0 RID: 23744 RVA: 0x0015056C File Offset: 0x0014E96C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700135B RID: 4955
		// (get) Token: 0x06005CC1 RID: 23745 RVA: 0x00150574 File Offset: 0x0014E974
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CC2 RID: 23746 RVA: 0x0015057C File Offset: 0x0014E97C
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005CC3 RID: 23747 RVA: 0x0015068C File Offset: 0x0014EA8C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CC4 RID: 23748 RVA: 0x00150693 File Offset: 0x0014EA93
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CC5 RID: 23749 RVA: 0x0015069C File Offset: 0x0014EA9C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShadowSacrifice.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new ShadowSacrifice.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005CC6 RID: 23750 RVA: 0x001506E8 File Offset: 0x0014EAE8
		private static bool <>m__0(BattleDamage d)
		{
			return d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value);
		}

		// Token: 0x06005CC7 RID: 23751 RVA: 0x00150714 File Offset: 0x0014EB14
		private static bool <>m__1(DamageComponent dd)
		{
			return dd.IsFatal != null && dd.IsFatal.Value;
		}

		// Token: 0x04004F6D RID: 20333
		internal AdventureUnitSkill skill;

		// Token: 0x04004F6E RID: 20334
		internal double <extraRate>__0;

		// Token: 0x04004F6F RID: 20335
		internal ReleaseableDamage damage;

		// Token: 0x04004F70 RID: 20336
		internal List<BattleDamage> <extraDamages>__1;

		// Token: 0x04004F71 RID: 20337
		internal List<IBattleUnit> <otherEnemies>__1;

		// Token: 0x04004F72 RID: 20338
		internal int <stunSeconds>__1;

		// Token: 0x04004F73 RID: 20339
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004F74 RID: 20340
		internal IBattleUnit <otherEnemy>__2;

		// Token: 0x04004F75 RID: 20341
		internal IEnumerator $locvar1;

		// Token: 0x04004F76 RID: 20342
		internal object <_>__3;

		// Token: 0x04004F77 RID: 20343
		internal IDisposable $locvar2;

		// Token: 0x04004F78 RID: 20344
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04004F79 RID: 20345
		internal IEnumerator $locvar3;

		// Token: 0x04004F7A RID: 20346
		internal object <_>__4;

		// Token: 0x04004F7B RID: 20347
		internal IDisposable $locvar4;

		// Token: 0x04004F7C RID: 20348
		internal List<IBattleUnit> <targets>__5;

		// Token: 0x04004F7D RID: 20349
		internal ReleaseableHeal <releaseableHeal>__5;

		// Token: 0x04004F7E RID: 20350
		internal IEnumerator $locvar5;

		// Token: 0x04004F7F RID: 20351
		internal object <_>__6;

		// Token: 0x04004F80 RID: 20352
		internal IDisposable $locvar6;

		// Token: 0x04004F81 RID: 20353
		internal ShadowSacrifice $this;

		// Token: 0x04004F82 RID: 20354
		internal object $current;

		// Token: 0x04004F83 RID: 20355
		internal bool $disposing;

		// Token: 0x04004F84 RID: 20356
		internal int $PC;

		// Token: 0x04004F85 RID: 20357
		private ShadowSacrifice.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey1 $locvar7;

		// Token: 0x04004F86 RID: 20358
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x04004F87 RID: 20359
		private ShadowSacrifice.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey2 $locvar8;

		// Token: 0x04004F88 RID: 20360
		private static Func<DamageComponent, bool> <>f__am$cache1;

		// Token: 0x02000E68 RID: 3688
		private sealed class <PostDamageProcess>c__AnonStorey1
		{
			// Token: 0x06005CC8 RID: 23752 RVA: 0x00150745 File Offset: 0x0014EB45
			public <PostDamageProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04004F89 RID: 20361
			internal AdventureUnitSkill skill;
		}

		// Token: 0x02000E69 RID: 3689
		private sealed class <PostDamageProcess>c__AnonStorey2
		{
			// Token: 0x06005CC9 RID: 23753 RVA: 0x0015074D File Offset: 0x0014EB4D
			public <PostDamageProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06005CCA RID: 23754 RVA: 0x00150758 File Offset: 0x0014EB58
			internal BattleHeal <>m__0(IBattleUnit t)
			{
				return new BattleHeal(t, this.<>f__ref$1.skill.SourceUnit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.healrate * t.GetMaxLife(AttributeRetrievalLevel.Skill),
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false);
			}

			// Token: 0x04004F8A RID: 20362
			internal double healrate;

			// Token: 0x04004F8B RID: 20363
			internal ShadowSacrifice.<PostDamageProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04004F8C RID: 20364
			internal ShadowSacrifice.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
