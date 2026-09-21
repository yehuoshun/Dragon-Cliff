using System;

// Token: 0x02000AEE RID: 2798
public class RedBat : MinionUnitConfigurationBase
{
	// Token: 0x06004B50 RID: 19280 RVA: 0x001EBE47 File Offset: 0x001EA247
	public RedBat()
	{
	}

	// Token: 0x17000FE1 RID: 4065
	// (get) Token: 0x06004B51 RID: 19281 RVA: 0x001EBE4F File Offset: 0x001EA24F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedBat;
		}
	}

	// Token: 0x17000FE2 RID: 4066
	// (get) Token: 0x06004B52 RID: 19282 RVA: 0x001EBE56 File Offset: 0x001EA256
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
