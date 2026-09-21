using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006EB RID: 1771
public class Cleaning : MainSkillBase
{
	// Token: 0x06003033 RID: 12339 RVA: 0x00148C39 File Offset: 0x00147039
	public Cleaning()
	{
	}

	// Token: 0x17000672 RID: 1650
	// (get) Token: 0x06003034 RID: 12340 RVA: 0x00148C41 File Offset: 0x00147041
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x17000673 RID: 1651
	// (get) Token: 0x06003035 RID: 12341 RVA: 0x00148C44 File Offset: 0x00147044
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Supportive;
		}
	}

	// Token: 0x17000674 RID: 1652
	// (get) Token: 0x06003036 RID: 12342 RVA: 0x00148C47 File Offset: 0x00147047
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Heal;
		}
	}

	// Token: 0x17000675 RID: 1653
	// (get) Token: 0x06003037 RID: 12343 RVA: 0x00148C4B File Offset: 0x0014704B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x17000676 RID: 1654
	// (get) Token: 0x06003038 RID: 12344 RVA: 0x00148C4E File Offset: 0x0014704E
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Cleaning;
		}
	}

	// Token: 0x17000677 RID: 1655
	// (get) Token: 0x06003039 RID: 12345 RVA: 0x00148C55 File Offset: 0x00147055
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600303A RID: 12346 RVA: 0x00148C5D File Offset: 0x0014705D
	private double GetHealRate(Skill skill)
	{
		return 0.16 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x0600303B RID: 12347 RVA: 0x00148C7C File Offset: 0x0014707C
	public override IHealDefinition GetHealDefinition(AdventureUnitSkill skill)
	{
		return new StableHealDefinition(new List<double>
		{
			this.GetHealRate(skill.Skill)
		}, new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), OutputType.Heal, skill);
	}

	// Token: 0x0600303C RID: 12348 RVA: 0x00148CBB File Offset: 0x001470BB
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600303D RID: 12349 RVA: 0x00148CC2 File Offset: 0x001470C2
	private double CleanChance(Skill skill)
	{
		return 0.45 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x0600303E RID: 12350 RVA: 0x00148CE4 File Offset: 0x001470E4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.CleanChance(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600303F RID: 12351 RVA: 0x00148D34 File Offset: 0x00147134
	public override IEnumerable PostHealProcess(ReleaseableHeal heal, AdventureUnitSkill skill)
	{
		List<IBattleUnit> targets = (from h in heal.BattleHeals
		select h.Target).ToList<IBattleUnit>();
		foreach (IBattleUnit battleUnit in targets)
		{
			if (battleUnit.Status != BattleUnitStatus.Dead)
			{
				for (int i = 0; i < 3; i++)
				{
					float hitValue = UnityEngine.Random.Range(0f, 1f);
					if ((double)hitValue <= this.CleanChance(skill.Skill))
					{
						BattleEffectBase toClean = battleUnit.BattleEffects.LastOrDefault((BattleEffectBase ef) => ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Negative);
						if (toClean != null)
						{
							IEnumerator enumerator2 = battleUnit.DisperseEffect(toClean, skill.SourceUnit).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x0400278E RID: 10126
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E50 RID: 3664
	[CompilerGenerated]
	private sealed class <PostHealProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C17 RID: 23575 RVA: 0x00148D65 File Offset: 0x00147165
		[DebuggerHidden]
		public <PostHealProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C18 RID: 23576 RVA: 0x00148D70 File Offset: 0x00147170
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = (from h in heal.BattleHeals
				select h.Target).ToList<IBattleUnit>();
				enumerator = targets.GetEnumerator();
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
					Block_9:
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
					goto IL_1CF;
				}
				IL_1E9:
				while (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					if (battleUnit.Status != BattleUnitStatus.Dead)
					{
						i = 0;
						goto IL_1DD;
					}
				}
				goto IL_214;
				IL_1CF:
				i++;
				IL_1DD:
				if (i >= 3)
				{
					goto IL_1E9;
				}
				hitValue = UnityEngine.Random.Range(0f, 1f);
				if ((double)hitValue > base.CleanChance(skill.Skill))
				{
					goto IL_1CF;
				}
				toClean = battleUnit.BattleEffects.LastOrDefault((BattleEffectBase ef) => ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Negative);
				if (toClean != null)
				{
					enumerator2 = battleUnit.DisperseEffect(toClean, skill.SourceUnit).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
				goto IL_1CF;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_214:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001336 RID: 4918
		// (get) Token: 0x06005C19 RID: 23577 RVA: 0x00148FD0 File Offset: 0x001473D0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001337 RID: 4919
		// (get) Token: 0x06005C1A RID: 23578 RVA: 0x00148FD8 File Offset: 0x001473D8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C1B RID: 23579 RVA: 0x00148FE0 File Offset: 0x001473E0
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

		// Token: 0x06005C1C RID: 23580 RVA: 0x00149074 File Offset: 0x00147474
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C1D RID: 23581 RVA: 0x0014907B File Offset: 0x0014747B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C1E RID: 23582 RVA: 0x00149084 File Offset: 0x00147484
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Cleaning.<PostHealProcess>c__Iterator0 <PostHealProcess>c__Iterator = new Cleaning.<PostHealProcess>c__Iterator0();
			<PostHealProcess>c__Iterator.$this = this;
			<PostHealProcess>c__Iterator.heal = heal;
			<PostHealProcess>c__Iterator.skill = skill;
			return <PostHealProcess>c__Iterator;
		}

		// Token: 0x06005C1F RID: 23583 RVA: 0x001490D0 File Offset: 0x001474D0
		private static IBattleUnit <>m__0(BattleHeal h)
		{
			return h.Target;
		}

		// Token: 0x06005C20 RID: 23584 RVA: 0x001490D8 File Offset: 0x001474D8
		private static bool <>m__1(BattleEffectBase ef)
		{
			return ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Negative;
		}

		// Token: 0x04004E66 RID: 20070
		internal ReleaseableHeal heal;

		// Token: 0x04004E67 RID: 20071
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004E68 RID: 20072
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004E69 RID: 20073
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004E6A RID: 20074
		internal int <i>__2;

		// Token: 0x04004E6B RID: 20075
		internal float <hitValue>__3;

		// Token: 0x04004E6C RID: 20076
		internal AdventureUnitSkill skill;

		// Token: 0x04004E6D RID: 20077
		internal BattleEffectBase <toClean>__4;

		// Token: 0x04004E6E RID: 20078
		internal IEnumerator $locvar1;

		// Token: 0x04004E6F RID: 20079
		internal object <_>__5;

		// Token: 0x04004E70 RID: 20080
		internal IDisposable $locvar2;

		// Token: 0x04004E71 RID: 20081
		internal Cleaning $this;

		// Token: 0x04004E72 RID: 20082
		internal object $current;

		// Token: 0x04004E73 RID: 20083
		internal bool $disposing;

		// Token: 0x04004E74 RID: 20084
		internal int $PC;

		// Token: 0x04004E75 RID: 20085
		private static Func<BattleHeal, IBattleUnit> <>f__am$cache0;

		// Token: 0x04004E76 RID: 20086
		private static Func<BattleEffectBase, bool> <>f__am$cache1;
	}
}
