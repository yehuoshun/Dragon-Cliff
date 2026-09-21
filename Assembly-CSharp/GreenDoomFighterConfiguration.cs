using System;

// Token: 0x02000B0D RID: 2829
public class GreenDoomFighterConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BD5 RID: 19413 RVA: 0x001F168A File Offset: 0x001EFA8A
	public GreenDoomFighterConfiguration()
	{
	}

	// Token: 0x1700101B RID: 4123
	// (get) Token: 0x06004BD6 RID: 19414 RVA: 0x001F1692 File Offset: 0x001EFA92
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenDoomFighter;
		}
	}

	// Token: 0x1700101C RID: 4124
	// (get) Token: 0x06004BD7 RID: 19415 RVA: 0x001F1699 File Offset: 0x001EFA99
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Protector;
		}
	}
}
