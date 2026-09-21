using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x020006F5 RID: 1781
public class Fireblast : MainSkillBase
{
	// Token: 0x060030B9 RID: 12473 RVA: 0x0014B3EB File Offset: 0x001497EB
	public Fireblast()
	{
	}

	// Token: 0x060030BA RID: 12474 RVA: 0x0014B3F4 File Offset: 0x001497F4
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.FireBlast,
				SlotNumber = 1
			},
			new NegativeEffectsRefreshTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new AttributeBoostOnKillTalentByRate
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.FireBlast,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x060030BB RID: 12475 RVA: 0x0014B4E0 File Offset: 0x001498E0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		if (skill.SourceUnit.SpecialEffects.OfType<FireChargerStarElementData>().Any<FireChargerStarElementData>())
		{
			return new StableDamageDefinition(new List<DamageHitDefinition>
			{
				new DamageHitDefinition
				{
					Potions = new List<DamageHitModuleDefinition>
					{
						new DamageHitModuleDefinition(new OutputType?(OutputType.Lightening), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Ice), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill)),
						new DamageHitModuleDefinition(new OutputType?(OutputType.Shadow), this.GetDamagePercentage(skill.Skill))
					}
				}
			}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
		}
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Lightening), this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x060030BC RID: 12476 RVA: 0x0014B69E File Offset: 0x00149A9E
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030BD RID: 12477 RVA: 0x0014B6A5 File Offset: 0x00149AA5
	private double GetDamagePercentage(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x060030BE RID: 12478 RVA: 0x0014B6C4 File Offset: 0x00149AC4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.AdditionalDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060030BF RID: 12479 RVA: 0x0014B728 File Offset: 0x00149B28
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		FireChargerDoTBlastData blastEffect = skill.SourceUnit.SpecialEffects.OfType<FireChargerDoTBlastData>().FirstOrDefault<FireChargerDoTBlastData>();
		if (blastEffect != null)
		{
			List<OutputType> elements = (!skill.SourceUnit.SpecialEffects.OfType<FireChargerStarElementData>().Any<FireChargerStarElementData>()) ? new List<OutputType>
			{
				skill.SourceUnit.GetOutputType(),
				OutputType.Lightening,
				OutputType.Fire
			} : new List<OutputType>
			{
				OutputType.Divine,
				OutputType.Fire,
				OutputType.Ice,
				OutputType.Lightening,
				OutputType.Physical,
				OutputType.Poison,
				OutputType.Shadow
			};
			Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> instances = new Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>>();
			foreach (BattleDamage battleDamage in damage.BattleDamages)
			{
				if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
				{
					List<IDamageInstantlyReleaseable> list = (from e in battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>()
					where elements.Any((OutputType el) => el == e.DamageOutputType)
					select e).ToList<IDamageInstantlyReleaseable>();
					if (list.Any<IDamageInstantlyReleaseable>() && !instances.ContainsKey(battleDamage.Target))
					{
						instances.Add(battleDamage.Target, list);
					}
				}
			}
			if (instances.Any<KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>>>())
			{
				IEnumerator enumerator2 = DamageOverTimeEffect.InstantRun_Batch(instances, blastEffect.AdditionalDamage + 1.0, double.MaxValue).GetEnumerator();
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

	// Token: 0x170006AE RID: 1710
	// (get) Token: 0x060030C0 RID: 12480 RVA: 0x0014B752 File Offset: 0x00149B52
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FireBlast;
		}
	}

	// Token: 0x170006AF RID: 1711
	// (get) Token: 0x060030C1 RID: 12481 RVA: 0x0014B759 File Offset: 0x00149B59
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x170006B0 RID: 1712
	// (get) Token: 0x060030C2 RID: 12482 RVA: 0x0014B761 File Offset: 0x00149B61
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006B1 RID: 1713
	// (get) Token: 0x060030C3 RID: 12483 RVA: 0x0014B764 File Offset: 0x00149B64
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x170006B2 RID: 1714
	// (get) Token: 0x060030C4 RID: 12484 RVA: 0x0014B767 File Offset: 0x00149B67
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x170006B3 RID: 1715
	// (get) Token: 0x060030C5 RID: 12485 RVA: 0x0014B76A File Offset: 0x00149B6A
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002798 RID: 10136
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E57 RID: 3671
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C56 RID: 23638 RVA: 0x0014B76D File Offset: 0x00149B6D
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C57 RID: 23639 RVA: 0x0014B778 File Offset: 0x00149B78
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				blastEffect = skill.SourceUnit.SpecialEffects.OfType<FireChargerDoTBlastData>().FirstOrDefault<FireChargerDoTBlastData>();
				if (blastEffect == null)
				{
					goto IL_2AA;
				}
				List<OutputType> elements = (!skill.SourceUnit.SpecialEffects.OfType<FireChargerStarElementData>().Any<FireChargerStarElementData>()) ? new List<OutputType>
				{
					skill.SourceUnit.GetOutputType(),
					OutputType.Lightening,
					OutputType.Fire
				} : new List<OutputType>
				{
					OutputType.Divine,
					OutputType.Fire,
					OutputType.Ice,
					OutputType.Lightening,
					OutputType.Physical,
					OutputType.Poison,
					OutputType.Shadow
				};
				instances = new Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>>();
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage = enumerator.Current;
						if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
						{
							List<IDamageInstantlyReleaseable> list = (from e in battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>()
							where elements.Any((OutputType el) => el == e.DamageOutputType)
							select e).ToList<IDamageInstantlyReleaseable>();
							if (list.Any<IDamageInstantlyReleaseable>() && !instances.ContainsKey(battleDamage.Target))
							{
								instances.Add(battleDamage.Target, list);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!instances.Any<KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>>>())
				{
					goto IL_2AA;
				}
				enumerator2 = DamageOverTimeEffect.InstantRun_Batch(instances, blastEffect.AdditionalDamage + 1.0, double.MaxValue).GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			default:
				return false;
			}
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
			IL_2AA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001344 RID: 4932
		// (get) Token: 0x06005C58 RID: 23640 RVA: 0x0014BA58 File Offset: 0x00149E58
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001345 RID: 4933
		// (get) Token: 0x06005C59 RID: 23641 RVA: 0x0014BA60 File Offset: 0x00149E60
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C5A RID: 23642 RVA: 0x0014BA68 File Offset: 0x00149E68
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
				}
				finally
				{
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005C5B RID: 23643 RVA: 0x0014BAD8 File Offset: 0x00149ED8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C5C RID: 23644 RVA: 0x0014BADF File Offset: 0x00149EDF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C5D RID: 23645 RVA: 0x0014BAE8 File Offset: 0x00149EE8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Fireblast.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Fireblast.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C5E RID: 23646 RVA: 0x0014BB28 File Offset: 0x00149F28
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04004EC3 RID: 20163
		internal AdventureUnitSkill skill;

		// Token: 0x04004EC4 RID: 20164
		internal FireChargerDoTBlastData <blastEffect>__0;

		// Token: 0x04004EC5 RID: 20165
		internal Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> <instances>__1;

		// Token: 0x04004EC6 RID: 20166
		internal ReleaseableDamage damage;

		// Token: 0x04004EC7 RID: 20167
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004EC8 RID: 20168
		internal IEnumerator $locvar1;

		// Token: 0x04004EC9 RID: 20169
		internal object <_>__2;

		// Token: 0x04004ECA RID: 20170
		internal IDisposable $locvar2;

		// Token: 0x04004ECB RID: 20171
		internal object $current;

		// Token: 0x04004ECC RID: 20172
		internal bool $disposing;

		// Token: 0x04004ECD RID: 20173
		internal int $PC;

		// Token: 0x04004ECE RID: 20174
		private Fireblast.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey1 $locvar3;

		// Token: 0x04004ECF RID: 20175
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x02000E58 RID: 3672
		private sealed class <PostDamageProcess>c__AnonStorey1
		{
			// Token: 0x06005C5F RID: 23647 RVA: 0x0014BB41 File Offset: 0x00149F41
			public <PostDamageProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06005C60 RID: 23648 RVA: 0x0014BB4C File Offset: 0x00149F4C
			internal bool <>m__0(IDamageInstantlyReleaseable e)
			{
				return this.elements.Any((OutputType el) => el == e.DamageOutputType);
			}

			// Token: 0x04004ED0 RID: 20176
			internal List<OutputType> elements;

			// Token: 0x04004ED1 RID: 20177
			internal Fireblast.<PostDamageProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x02000E59 RID: 3673
			private sealed class <PostDamageProcess>c__AnonStorey2
			{
				// Token: 0x06005C61 RID: 23649 RVA: 0x0014BB84 File Offset: 0x00149F84
				public <PostDamageProcess>c__AnonStorey2()
				{
				}

				// Token: 0x06005C62 RID: 23650 RVA: 0x0014BB8C File Offset: 0x00149F8C
				internal bool <>m__0(OutputType el)
				{
					return el == this.e.DamageOutputType;
				}

				// Token: 0x04004ED2 RID: 20178
				internal IDamageInstantlyReleaseable e;

				// Token: 0x04004ED3 RID: 20179
				internal Fireblast.<PostDamageProcess>c__Iterator0.<PostDamageProcess>c__AnonStorey1 <>f__ref$1;
			}
		}
	}
}
