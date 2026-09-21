using System;

// Token: 0x0200071C RID: 1820
public abstract class SecondarySkillBase : SkillLogicBase
{
	// Token: 0x060032A6 RID: 12966 RVA: 0x00153FD0 File Offset: 0x001523D0
	protected SecondarySkillBase()
	{
	}

	// Token: 0x1700079F RID: 1951
	// (get) Token: 0x060032A7 RID: 12967 RVA: 0x00153FE6 File Offset: 0x001523E6
	public override CastingStyle CastingStyle
	{
		get
		{
			return this._castingStyle;
		}
	}

	// Token: 0x170007A0 RID: 1952
	// (get) Token: 0x060032A8 RID: 12968 RVA: 0x00153FEE File Offset: 0x001523EE
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x170007A1 RID: 1953
	// (get) Token: 0x060032A9 RID: 12969
	public abstract int? RequiredSchoolLevel { get; }

	// Token: 0x060032AA RID: 12970 RVA: 0x00153FF6 File Offset: 0x001523F6
	public virtual bool CanbeLearnedFromSchool()
	{
		return true;
	}

	// Token: 0x040027CD RID: 10189
	private CastingStyle _castingStyle = CastingStyle.Passive;

	// Token: 0x040027CE RID: 10190
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;
}
