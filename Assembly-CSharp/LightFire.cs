using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000716 RID: 1814
public class LightFire : SecondarySkillBase
{
	// Token: 0x0600325F RID: 12895 RVA: 0x00155378 File Offset: 0x00153778
	public LightFire()
	{
	}

	// Token: 0x17000775 RID: 1909
	// (get) Token: 0x06003260 RID: 12896 RVA: 0x00155393 File Offset: 0x00153793
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x17000776 RID: 1910
	// (get) Token: 0x06003261 RID: 12897 RVA: 0x00155396 File Offset: 0x00153796
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Supportive;
		}
	}

	// Token: 0x17000777 RID: 1911
	// (get) Token: 0x06003262 RID: 12898 RVA: 0x00155399 File Offset: 0x00153799
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000778 RID: 1912
	// (get) Token: 0x06003263 RID: 12899 RVA: 0x0015539C File Offset: 0x0015379C
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x06003264 RID: 12900 RVA: 0x0015539F File Offset: 0x0015379F
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000779 RID: 1913
	// (get) Token: 0x06003265 RID: 12901 RVA: 0x001553A6 File Offset: 0x001537A6
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x1700077A RID: 1914
	// (get) Token: 0x06003266 RID: 12902 RVA: 0x001553AE File Offset: 0x001537AE
	public override SkillType SkillType
	{
		get
		{
			return SkillType.LightFire;
		}
	}

	// Token: 0x1700077B RID: 1915
	// (get) Token: 0x06003267 RID: 12903 RVA: 0x001553B5 File Offset: 0x001537B5
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003268 RID: 12904 RVA: 0x001553BD File Offset: 0x001537BD
	private double GetPossiblity(Skill skill)
	{
		return 0.52 + (double)(skill.Level - 1) * 0.06;
	}

	// Token: 0x06003269 RID: 12905 RVA: 0x001553DC File Offset: 0x001537DC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.PossibilityKey, this.GetPossiblity(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600326A RID: 12906 RVA: 0x00155408 File Offset: 0x00153808
	public override IEnumerable PerSecondLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit skillOwner)
	{
		List<IBattleUnit> targets = skillOwner.GetLiveEnemyTargets(false, true);
		if (targets.Any<IBattleUnit>() && (double)UnityEngine.Random.value <= this.GetPossiblity(processingSkill.Skill))
		{
			IBattleUnit selectedTarget = targets[UnityEngine.Random.Range(0, targets.Count)];
			IEnumerator enumerator = FireSeedEffect.AddFireSeed(selectedTarget, skillOwner.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, processingSkill.SourceUnit).GetEnumerator();
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
		yield break;
	}

	// Token: 0x040027C1 RID: 10177
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027C2 RID: 10178
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E79 RID: 3705
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D43 RID: 23875 RVA: 0x00155439 File Offset: 0x00153839
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D44 RID: 23876 RVA: 0x00155444 File Offset: 0x00153844
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = skillOwner.GetLiveEnemyTargets(false, true);
				if (!targets.Any<IBattleUnit>() || (double)UnityEngine.Random.value > base.GetPossiblity(processingSkill.Skill))
				{
					goto IL_140;
				}
				selectedTarget = targets[UnityEngine.Random.Range(0, targets.Count)];
				enumerator = FireSeedEffect.AddFireSeed(selectedTarget, skillOwner.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, processingSkill.SourceUnit).GetEnumerator();
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
			IL_140:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001378 RID: 4984
		// (get) Token: 0x06005D45 RID: 23877 RVA: 0x001555AC File Offset: 0x001539AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001379 RID: 4985
		// (get) Token: 0x06005D46 RID: 23878 RVA: 0x001555B4 File Offset: 0x001539B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D47 RID: 23879 RVA: 0x001555BC File Offset: 0x001539BC
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

		// Token: 0x06005D48 RID: 23880 RVA: 0x0015562C File Offset: 0x00153A2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D49 RID: 23881 RVA: 0x00155633 File Offset: 0x00153A33
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D4A RID: 23882 RVA: 0x0015563C File Offset: 0x00153A3C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LightFire.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new LightFire.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			<PerSecondLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005062 RID: 20578
		internal IBattleUnit skillOwner;

		// Token: 0x04005063 RID: 20579
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04005064 RID: 20580
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005065 RID: 20581
		internal IBattleUnit <selectedTarget>__1;

		// Token: 0x04005066 RID: 20582
		internal IEnumerator $locvar0;

		// Token: 0x04005067 RID: 20583
		internal object <_>__2;

		// Token: 0x04005068 RID: 20584
		internal IDisposable $locvar1;

		// Token: 0x04005069 RID: 20585
		internal LightFire $this;

		// Token: 0x0400506A RID: 20586
		internal object $current;

		// Token: 0x0400506B RID: 20587
		internal bool $disposing;

		// Token: 0x0400506C RID: 20588
		internal int $PC;
	}
}
