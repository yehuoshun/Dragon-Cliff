using System;

// Token: 0x02000B0A RID: 2826
public class BlueDoomFighterConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BCC RID: 19404 RVA: 0x001F1653 File Offset: 0x001EFA53
	public BlueDoomFighterConfiguration()
	{
	}

	// Token: 0x17001015 RID: 4117
	// (get) Token: 0x06004BCD RID: 19405 RVA: 0x001F165B File Offset: 0x001EFA5B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueDoomFighter;
		}
	}

	// Token: 0x17001016 RID: 4118
	// (get) Token: 0x06004BCE RID: 19406 RVA: 0x001F1662 File Offset: 0x001EFA62
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}
}
