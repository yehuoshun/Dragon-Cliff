using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000704 RID: 1796
public class SeedsOfSin : MainSkillBase
{
	// Token: 0x06003178 RID: 12664 RVA: 0x0014F960 File Offset: 0x0014DD60
	public SeedsOfSin()
	{
	}

	// Token: 0x06003179 RID: 12665 RVA: 0x0014F968 File Offset: 0x0014DD68
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.SeedsOfSin,
				SlotNumber = 1
			},
			new DispelPositiveEffectOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.SeedsOfSin,
				SlotNumber = 1
			},
			new SeedsOfSinPetPushTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x0600317A RID: 12666 RVA: 0x0014FA50 File Offset: 0x0014DE50
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x0600317B RID: 12667 RVA: 0x0014FACF File Offset: 0x0014DECF
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.35;
	}

	// Token: 0x0600317C RID: 12668 RVA: 0x0014FAF0 File Offset: 0x0014DEF0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600317D RID: 12669 RVA: 0x0014FB3D File Offset: 0x0014DF3D
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600317E RID: 12670 RVA: 0x0014FB44 File Offset: 0x0014DF44
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		IBattleUnit pet = skill.SourceUnit.GetPetOrNull();
		if (pet != null)
		{
			double pushRate = (!skill.GetActiveTalents().OfType<SeedsOfSinPetPushTalent>().Any<SeedsOfSinPetPushTalent>()) ? 0.0 : SeedsOfSinPetPushTalent.PushRate;
			if (pushRate > 0.0)
			{
				IEnumerator enumerator = UnitStyleConfigurationBase.PushTargetProgress(pet, skill.SourceUnit, pushRate).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object _ = enumerator.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000704 RID: 1796
	// (get) Token: 0x0600317F RID: 12671 RVA: 0x0014FB67 File Offset: 0x0014DF67
	public override SkillType SkillType
	{
		get
		{
			return SkillType.SeedsOfSin;
		}
	}

	// Token: 0x17000705 RID: 1797
	// (get) Token: 0x06003180 RID: 12672 RVA: 0x0014FB6E File Offset: 0x0014DF6E
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000706 RID: 1798
	// (get) Token: 0x06003181 RID: 12673 RVA: 0x0014FB76 File Offset: 0x0014DF76
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000707 RID: 1799
	// (get) Token: 0x06003182 RID: 12674 RVA: 0x0014FB79 File Offset: 0x0014DF79
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Shadow;
		}
	}

	// Token: 0x17000708 RID: 1800
	// (get) Token: 0x06003183 RID: 12675 RVA: 0x0014FB7C File Offset: 0x0014DF7C
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000709 RID: 1801
	// (get) Token: 0x06003184 RID: 12676 RVA: 0x0014FB7F File Offset: 0x0014DF7F
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027AA RID: 10154
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E66 RID: 3686
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CB6 RID: 23734 RVA: 0x0014FB82 File Offset: 0x0014DF82
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CB7 RID: 23735 RVA: 0x0014FB8C File Offset: 0x0014DF8C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				pet = skill.SourceUnit.GetPetOrNull();
				if (pet == null)
				{
					goto IL_137;
				}
				pushRate = ((!skill.GetActiveTalents().OfType<SeedsOfSinPetPushTalent>().Any<SeedsOfSinPetPushTalent>()) ? 0.0 : SeedsOfSinPetPushTalent.PushRate);
				if (pushRate <= 0.0)
				{
					goto IL_137;
				}
				enumerator = UnitStyleConfigurationBase.PushTargetProgress(pet, skill.SourceUnit, pushRate).GetEnumerator();
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
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
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
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_137:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001358 RID: 4952
		// (get) Token: 0x06005CB8 RID: 23736 RVA: 0x0014FCEC File Offset: 0x0014E0EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001359 RID: 4953
		// (get) Token: 0x06005CB9 RID: 23737 RVA: 0x0014FCF4 File Offset: 0x0014E0F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CBA RID: 23738 RVA: 0x0014FCFC File Offset: 0x0014E0FC
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
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005CBB RID: 23739 RVA: 0x0014FD6C File Offset: 0x0014E16C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CBC RID: 23740 RVA: 0x0014FD73 File Offset: 0x0014E173
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CBD RID: 23741 RVA: 0x0014FD7C File Offset: 0x0014E17C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SeedsOfSin.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new SeedsOfSin.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004F64 RID: 20324
		internal AdventureUnitSkill skill;

		// Token: 0x04004F65 RID: 20325
		internal IBattleUnit <pet>__0;

		// Token: 0x04004F66 RID: 20326
		internal double <pushRate>__1;

		// Token: 0x04004F67 RID: 20327
		internal IEnumerator $locvar0;

		// Token: 0x04004F68 RID: 20328
		internal object <_>__2;

		// Token: 0x04004F69 RID: 20329
		internal IDisposable $locvar1;

		// Token: 0x04004F6A RID: 20330
		internal object $current;

		// Token: 0x04004F6B RID: 20331
		internal bool $disposing;

		// Token: 0x04004F6C RID: 20332
		internal int $PC;
	}
}
