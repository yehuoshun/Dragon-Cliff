using System;

// Token: 0x020006FA RID: 1786
public abstract class MainSkillBase : SkillLogicBase
{
	// Token: 0x060030FC RID: 12540 RVA: 0x00146A10 File Offset: 0x00144E10
	protected MainSkillBase()
	{
	}

	// Token: 0x170006CC RID: 1740
	// (get) Token: 0x060030FD RID: 12541 RVA: 0x00146A1F File Offset: 0x00144E1F
	public override CastingStyle CastingStyle
	{
		get
		{
			return this._castingStyle;
		}
	}

	// Token: 0x170006CD RID: 1741
	// (get) Token: 0x060030FE RID: 12542 RVA: 0x00146A27 File Offset: 0x00144E27
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030FF RID: 12543 RVA: 0x00146A2F File Offset: 0x00144E2F
	public virtual double GetCastingGaugeRate(int level)
	{
		return 20.0;
	}

	// Token: 0x0400279E RID: 10142
	private CastingStyle _castingStyle = CastingStyle.DirectCast;

	// Token: 0x0400279F RID: 10143
	private SkillCommandType _skillCommandType;
}
