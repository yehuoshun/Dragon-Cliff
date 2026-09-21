using System;

// Token: 0x02000AEC RID: 2796
public class GreenBat : MinionUnitConfigurationBase
{
	// Token: 0x06004B4A RID: 19274 RVA: 0x001EBE22 File Offset: 0x001EA222
	public GreenBat()
	{
	}

	// Token: 0x17000FDD RID: 4061
	// (get) Token: 0x06004B4B RID: 19275 RVA: 0x001EBE2A File Offset: 0x001EA22A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenBat;
		}
	}

	// Token: 0x17000FDE RID: 4062
	// (get) Token: 0x06004B4C RID: 19276 RVA: 0x001EBE31 File Offset: 0x001EA231
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}
}
