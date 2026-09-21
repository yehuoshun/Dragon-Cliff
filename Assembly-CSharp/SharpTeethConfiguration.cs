using System;

// Token: 0x02000B34 RID: 2868
public class SharpTeethConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C57 RID: 19543 RVA: 0x001F1970 File Offset: 0x001EFD70
	public SharpTeethConfiguration()
	{
	}

	// Token: 0x17001067 RID: 4199
	// (get) Token: 0x06004C58 RID: 19544 RVA: 0x001F1978 File Offset: 0x001EFD78
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.SharpTeeth;
		}
	}

	// Token: 0x17001068 RID: 4200
	// (get) Token: 0x06004C59 RID: 19545 RVA: 0x001F197F File Offset: 0x001EFD7F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}
}
