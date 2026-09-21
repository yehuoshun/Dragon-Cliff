using System;

// Token: 0x02000AFD RID: 2813
public class BlueCannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004B8E RID: 19342 RVA: 0x001F12DC File Offset: 0x001EF6DC
	public BlueCannibalBear()
	{
	}

	// Token: 0x17000FFF RID: 4095
	// (get) Token: 0x06004B8F RID: 19343 RVA: 0x001F12E4 File Offset: 0x001EF6E4
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueCannibalBear;
		}
	}

	// Token: 0x17001000 RID: 4096
	// (get) Token: 0x06004B90 RID: 19344 RVA: 0x001F12EB File Offset: 0x001EF6EB
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}
}
