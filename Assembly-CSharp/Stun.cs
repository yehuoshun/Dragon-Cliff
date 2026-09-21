using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200070C RID: 1804
public class Stun : MainSkillBase
{
	// Token: 0x060031E0 RID: 12768 RVA: 0x0015266C File Offset: 0x00150A6C
	public Stun()
	{
	}

	// Token: 0x17000734 RID: 1844
	// (get) Token: 0x060031E1 RID: 12769 RVA: 0x00152674 File Offset: 0x00150A74
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Stun;
		}
	}

	// Token: 0x17000735 RID: 1845
	// (get) Token: 0x060031E2 RID: 12770 RVA: 0x0015267B File Offset: 0x00150A7B
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060031E3 RID: 12771 RVA: 0x00152684 File Offset: 0x00150A84
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Speed, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x060031E4 RID: 12772 RVA: 0x00152704 File Offset: 0x00150B04
	private double GetDamagePercentage(Skill skill)
	{
		return 0.9 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060031E5 RID: 12773 RVA: 0x00152723 File Offset: 0x00150B23
	private double GetChance(Skill skill)
	{
		return 0.6;
	}

	// Token: 0x060031E6 RID: 12774 RVA: 0x00152730 File Offset: 0x00150B30
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.GetChance(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060031E7 RID: 12775 RVA: 0x00152794 File Offset: 0x00150B94
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031E8 RID: 12776 RVA: 0x0015279C File Offset: 0x00150B9C
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active && (double)UnityEngine.Random.value <= this.GetChance(skill.Skill))
			{
				IEnumerator enumerator2 = LockTimeEffect.AddStunSeconds(target, 2f, skill, false).GetEnumerator();
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

	// Token: 0x17000736 RID: 1846
	// (get) Token: 0x060031E9 RID: 12777 RVA: 0x001527CD File Offset: 0x00150BCD
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000737 RID: 1847
	// (get) Token: 0x060031EA RID: 12778 RVA: 0x001527D0 File Offset: 0x00150BD0
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000738 RID: 1848
	// (get) Token: 0x060031EB RID: 12779 RVA: 0x001527D3 File Offset: 0x00150BD3
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000739 RID: 1849
	// (get) Token: 0x060031EC RID: 12780 RVA: 0x001527D6 File Offset: 0x00150BD6
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B2 RID: 10162
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E70 RID: 3696
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005CF7 RID: 23799 RVA: 0x001527D9 File Offset: 0x00150BD9
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005CF8 RID: 23800 RVA: 0x001527E4 File Offset: 0x00150BE4
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
					if (target.Status == BattleUnitStatus.Active && (double)UnityEngine.Random.value <= base.GetChance(skill.Skill))
					{
						enumerator2 = LockTimeEffect.AddStunSeconds(target, 2f, skill, false).GetEnumerator();
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

		// Token: 0x17001366 RID: 4966
		// (get) Token: 0x06005CF9 RID: 23801 RVA: 0x001529A4 File Offset: 0x00150DA4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001367 RID: 4967
		// (get) Token: 0x06005CFA RID: 23802 RVA: 0x001529AC File Offset: 0x00150DAC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005CFB RID: 23803 RVA: 0x001529B4 File Offset: 0x00150DB4
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

		// Token: 0x06005CFC RID: 23804 RVA: 0x00152A48 File Offset: 0x00150E48
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005CFD RID: 23805 RVA: 0x00152A4F File Offset: 0x00150E4F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005CFE RID: 23806 RVA: 0x00152A58 File Offset: 0x00150E58
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Stun.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new Stun.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.damage = damage;
			<PostDamageProcess>c__Iterator.skill = skill;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x04004FD8 RID: 20440
		internal ReleaseableDamage damage;

		// Token: 0x04004FD9 RID: 20441
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004FDA RID: 20442
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004FDB RID: 20443
		internal IBattleUnit <target>__2;

		// Token: 0x04004FDC RID: 20444
		internal AdventureUnitSkill skill;

		// Token: 0x04004FDD RID: 20445
		internal IEnumerator $locvar1;

		// Token: 0x04004FDE RID: 20446
		internal object <_>__3;

		// Token: 0x04004FDF RID: 20447
		internal IDisposable $locvar2;

		// Token: 0x04004FE0 RID: 20448
		internal Stun $this;

		// Token: 0x04004FE1 RID: 20449
		internal object $current;

		// Token: 0x04004FE2 RID: 20450
		internal bool $disposing;

		// Token: 0x04004FE3 RID: 20451
		internal int $PC;
	}
}
