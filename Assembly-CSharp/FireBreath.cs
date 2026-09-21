using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.Dataload.AdventurerStarEffects;
using UnityEngine;

// Token: 0x020006F2 RID: 1778
public class FireBreath : MainSkillBase
{
	// Token: 0x06003092 RID: 12434 RVA: 0x0014A50D File Offset: 0x0014890D
	public FireBreath()
	{
	}

	// Token: 0x06003093 RID: 12435 RVA: 0x0014A518 File Offset: 0x00148918
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new FireBreathFireSeedEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new PushOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.FireBreath,
				SlotNumber = 1
			},
			new FirebreathDamageAbsorbTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x06003094 RID: 12436 RVA: 0x0014A5ED File Offset: 0x001489ED
	private double GetDirectDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06003095 RID: 12437 RVA: 0x0014A60C File Offset: 0x00148A0C
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06003096 RID: 12438 RVA: 0x0014A62C File Offset: 0x00148A2C
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		List<DamageHitDefinition> list = new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDirectDamagePercentage(skill.Skill))
				}
			}
		};
		if (skill.SourceUnit.SpecialEffects.OfType<FirePlayerStarDoubleHitData>().Any<FirePlayerStarDoubleHitData>())
		{
			FirePlayerStarDoubleHitData firePlayerStarDoubleHitData = skill.SourceUnit.SpecialEffects.OfType<FirePlayerStarDoubleHitData>().First<FirePlayerStarDoubleHitData>();
			for (int i = 0; i < firePlayerStarDoubleHitData.NumberOfAdditionalHitCheck; i++)
			{
				if ((double)UnityEngine.Random.value <= firePlayerStarDoubleHitData.Chance)
				{
					list.Add(new DamageHitDefinition
					{
						Potions = new List<DamageHitModuleDefinition>
						{
							new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
							new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDirectDamagePercentage(skill.Skill))
						}
					});
				}
			}
		}
		return new StableDamageDefinition(list, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x06003097 RID: 12439 RVA: 0x0014A76C File Offset: 0x00148B6C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, (this.GetDirectDamagePercentage(skill) * 100.0).ToExpression()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003098 RID: 12440 RVA: 0x0014A7C3 File Offset: 0x00148BC3
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003099 RID: 12441 RVA: 0x0014A7CC File Offset: 0x00148BCC
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		if (damage.Dealer == skill.SourceUnit)
		{
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
				{
					double totalFireDamage = (from d in damageBattleDamage.Damages
					where d.IsDirectDamage && !d.IsMissed
					select d).Sum((DamageComponent d) => d.GetElementalTotal_WithoutNeutralization(OutputType.Fire));
					if (skill.GetActiveTalents().OfType<FireBreathFireSeedEnhancementTalent>().Any<FireBreathFireSeedEnhancementTalent>())
					{
						double rate = FireBreathFireSeedEnhancementTalent.Rate;
						totalFireDamage *= 1.0 + rate;
					}
					if (totalFireDamage > 0.0)
					{
						IEnumerator enumerator2 = FireSeedEffect.AddFireSeed(damageBattleDamage.Target, totalFireDamage, skill.SourceUnit).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x1700069C RID: 1692
	// (get) Token: 0x0600309A RID: 12442 RVA: 0x0014A7F6 File Offset: 0x00148BF6
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FireBreath;
		}
	}

	// Token: 0x1700069D RID: 1693
	// (get) Token: 0x0600309B RID: 12443 RVA: 0x0014A7FD File Offset: 0x00148BFD
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x1700069E RID: 1694
	// (get) Token: 0x0600309C RID: 12444 RVA: 0x0014A805 File Offset: 0x00148C05
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700069F RID: 1695
	// (get) Token: 0x0600309D RID: 12445 RVA: 0x0014A808 File Offset: 0x00148C08
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x170006A0 RID: 1696
	// (get) Token: 0x0600309E RID: 12446 RVA: 0x0014A80B File Offset: 0x00148C0B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x170006A1 RID: 1697
	// (get) Token: 0x0600309F RID: 12447 RVA: 0x0014A80E File Offset: 0x00148C0E
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002795 RID: 10133
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E54 RID: 3668
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C3A RID: 23610 RVA: 0x0014A811 File Offset: 0x00148C11
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C3B RID: 23611 RVA: 0x0014A81C File Offset: 0x00148C1C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (damage.Dealer != skill.SourceUnit)
				{
					goto IL_20C;
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
					Block_10:
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
					if (damageBattleDamage.Target.Status == BattleUnitStatus.Active)
					{
						totalFireDamage = (from d in damageBattleDamage.Damages
						where d.IsDirectDamage && !d.IsMissed
						select d).Sum((DamageComponent d) => d.GetElementalTotal_WithoutNeutralization(OutputType.Fire));
						if (skill.GetActiveTalents().OfType<FireBreathFireSeedEnhancementTalent>().Any<FireBreathFireSeedEnhancementTalent>())
						{
							double rate = FireBreathFireSeedEnhancementTalent.Rate;
							totalFireDamage *= 1.0 + rate;
						}
						if (totalFireDamage > 0.0)
						{
							enumerator2 = FireSeedEffect.AddFireSeed(damageBattleDamage.Target, totalFireDamage, skill.SourceUnit).GetEnumerator();
							num = 4294967293u;
							goto Block_10;
						}
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
			IL_20C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700133E RID: 4926
		// (get) Token: 0x06005C3C RID: 23612 RVA: 0x0014AA74 File Offset: 0x00148E74
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700133F RID: 4927
		// (get) Token: 0x06005C3D RID: 23613 RVA: 0x0014AA7C File Offset: 0x00148E7C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C3E RID: 23614 RVA: 0x0014AA84 File Offset: 0x00148E84
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

		// Token: 0x06005C3F RID: 23615 RVA: 0x0014AB18 File Offset: 0x00148F18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C40 RID: 23616 RVA: 0x0014AB1F File Offset: 0x00148F1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C41 RID: 23617 RVA: 0x0014AB28 File Offset: 0x00148F28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireBreath.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new FireBreath.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C42 RID: 23618 RVA: 0x0014AB68 File Offset: 0x00148F68
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x06005C43 RID: 23619 RVA: 0x0014AB81 File Offset: 0x00148F81
		private static double <>m__1(DamageComponent d)
		{
			return d.GetElementalTotal_WithoutNeutralization(OutputType.Fire);
		}

		// Token: 0x04004E9C RID: 20124
		internal ReleaseableDamage damage;

		// Token: 0x04004E9D RID: 20125
		internal AdventureUnitSkill skill;

		// Token: 0x04004E9E RID: 20126
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004E9F RID: 20127
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004EA0 RID: 20128
		internal double <totalFireDamage>__2;

		// Token: 0x04004EA1 RID: 20129
		internal IEnumerator $locvar1;

		// Token: 0x04004EA2 RID: 20130
		internal object <_>__3;

		// Token: 0x04004EA3 RID: 20131
		internal IDisposable $locvar2;

		// Token: 0x04004EA4 RID: 20132
		internal object $current;

		// Token: 0x04004EA5 RID: 20133
		internal bool $disposing;

		// Token: 0x04004EA6 RID: 20134
		internal int $PC;

		// Token: 0x04004EA7 RID: 20135
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x04004EA8 RID: 20136
		private static Func<DamageComponent, double> <>f__am$cache1;
	}
}
