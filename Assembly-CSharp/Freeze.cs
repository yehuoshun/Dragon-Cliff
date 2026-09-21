using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006F7 RID: 1783
public class Freeze : MainSkillBase
{
	// Token: 0x060030D3 RID: 12499 RVA: 0x0014BD08 File Offset: 0x0014A108
	public Freeze()
	{
	}

	// Token: 0x170006BA RID: 1722
	// (get) Token: 0x060030D4 RID: 12500 RVA: 0x0014BD10 File Offset: 0x0014A110
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Freeze;
		}
	}

	// Token: 0x060030D5 RID: 12501 RVA: 0x0014BD18 File Offset: 0x0014A118
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SkillExtraTargetTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Freeze,
				SlotNumber = 1
			},
			new DispelPositiveEffectOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Freeze,
				SlotNumber = 1
			},
			new FreezeEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x170006BB RID: 1723
	// (get) Token: 0x060030D6 RID: 12502 RVA: 0x0014BDFF File Offset: 0x0014A1FF
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030D7 RID: 12503 RVA: 0x0014BE07 File Offset: 0x0014A207
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060030D8 RID: 12504 RVA: 0x0014BE26 File Offset: 0x0014A226
	private double GetChance(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x060030D9 RID: 12505 RVA: 0x0014BE48 File Offset: 0x0014A248
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.GetChance(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060030DA RID: 12506 RVA: 0x0014BEAC File Offset: 0x0014A2AC
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Ice), this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Speed, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x060030DB RID: 12507 RVA: 0x0014BF2C File Offset: 0x0014A32C
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030DC RID: 12508 RVA: 0x0014BF34 File Offset: 0x0014A334
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				IEnumerator enumerator2 = target.ApplySkillEffect(AttributeModificationEffect.CreateChillEffect(skill, 0.3, base.GetType().FullName), false).GetEnumerator();
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
				if ((double)UnityEngine.Random.value <= this.GetChance(skill.Skill))
				{
					int lastingSeconds = 2;
					if (skill.GetActiveTalents().OfType<FreezeEnhancementTalent>().Any<FreezeEnhancementTalent>())
					{
						lastingSeconds = FreezeEnhancementTalent.LastingSecondsToReplace;
					}
					IEnumerator enumerator3 = LockTimeEffect.AddFrozenSeconds(target, (float)lastingSeconds, skill, false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x170006BC RID: 1724
	// (get) Token: 0x060030DD RID: 12509 RVA: 0x0014BF65 File Offset: 0x0014A365
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006BD RID: 1725
	// (get) Token: 0x060030DE RID: 12510 RVA: 0x0014BF68 File Offset: 0x0014A368
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Ice;
		}
	}

	// Token: 0x170006BE RID: 1726
	// (get) Token: 0x060030DF RID: 12511 RVA: 0x0014BF6B File Offset: 0x0014A36B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006BF RID: 1727
	// (get) Token: 0x060030E0 RID: 12512 RVA: 0x0014BF6E File Offset: 0x0014A36E
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x0400279A RID: 10138
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E5A RID: 3674
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C63 RID: 23651 RVA: 0x0014BF71 File Offset: 0x0014A371
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C64 RID: 23652 RVA: 0x0014BF7C File Offset: 0x0014A37C
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
					Block_5:
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
					if ((double)UnityEngine.Random.value <= base.GetChance(skill.Skill))
					{
						lastingSeconds = 2;
						if (skill.GetActiveTalents().OfType<FreezeEnhancementTalent>().Any<FreezeEnhancementTalent>())
						{
							lastingSeconds = FreezeEnhancementTalent.LastingSecondsToReplace;
						}
						enumerator3 = LockTimeEffect.AddFrozenSeconds(target, (float)lastingSeconds, skill, false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					break;
				case 2u:
					goto IL_1BC;
				}
				IL_23E:
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						enumerator2 = target.ApplySkillEffect(AttributeModificationEffect.CreateChillEffect(skill, 0.3, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
				}
				goto IL_269;
				Block_8:
				try
				{
					IL_1BC:
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
				goto IL_23E;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_269:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001346 RID: 4934
		// (get) Token: 0x06005C65 RID: 23653 RVA: 0x0014C248 File Offset: 0x0014A648
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001347 RID: 4935
		// (get) Token: 0x06005C66 RID: 23654 RVA: 0x0014C250 File Offset: 0x0014A650
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C67 RID: 23655 RVA: 0x0014C258 File Offset: 0x0014A658
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

		// Token: 0x06005C68 RID: 23656 RVA: 0x0014C340 File Offset: 0x0014A740
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C69 RID: 23657 RVA: 0x0014C347 File Offset: 0x0014A747
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C6A RID: 23658 RVA: 0x0014C350 File Offset: 0x0014A750
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Freeze.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Freeze.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004ED4 RID: 20180
		internal ReleaseableDamage damage;

		// Token: 0x04004ED5 RID: 20181
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004ED6 RID: 20182
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004ED7 RID: 20183
		internal IBattleUnit <target>__2;

		// Token: 0x04004ED8 RID: 20184
		internal AdventureUnitSkill skill;

		// Token: 0x04004ED9 RID: 20185
		internal IEnumerator $locvar1;

		// Token: 0x04004EDA RID: 20186
		internal object <_>__3;

		// Token: 0x04004EDB RID: 20187
		internal IDisposable $locvar2;

		// Token: 0x04004EDC RID: 20188
		internal int <lastingSeconds>__4;

		// Token: 0x04004EDD RID: 20189
		internal IEnumerator $locvar3;

		// Token: 0x04004EDE RID: 20190
		internal object <_>__5;

		// Token: 0x04004EDF RID: 20191
		internal IDisposable $locvar4;

		// Token: 0x04004EE0 RID: 20192
		internal Freeze $this;

		// Token: 0x04004EE1 RID: 20193
		internal object $current;

		// Token: 0x04004EE2 RID: 20194
		internal bool $disposing;

		// Token: 0x04004EE3 RID: 20195
		internal int $PC;
	}
}
