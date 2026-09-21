using System;

// Token: 0x02000B19 RID: 2841
public class Thug4Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004BFA RID: 19450 RVA: 0x001F174C File Offset: 0x001EFB4C
	public Thug4Configuration()
	{
	}

	// Token: 0x1700102D RID: 4141
	// (get) Token: 0x06004BFB RID: 19451 RVA: 0x001F1754 File Offset: 0x001EFB54
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug4;
		}
	}

	// Token: 0x1700102E RID: 4142
	// (get) Token: 0x06004BFC RID: 19452 RVA: 0x001F175B File Offset: 0x001EFB5B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
