using System;

// Token: 0x02000AF3 RID: 2803
public class Alchemist : MinionUnitConfigurationBase
{
	// Token: 0x06004B6F RID: 19311 RVA: 0x001F11D7 File Offset: 0x001EF5D7
	public Alchemist()
	{
	}

	// Token: 0x17000FEB RID: 4075
	// (get) Token: 0x06004B70 RID: 19312 RVA: 0x001F11DF File Offset: 0x001EF5DF
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Alchemist;
		}
	}

	// Token: 0x17000FEC RID: 4076
	// (get) Token: 0x06004B71 RID: 19313 RVA: 0x001F11E6 File Offset: 0x001EF5E6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}
}
