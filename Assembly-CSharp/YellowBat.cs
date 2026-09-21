using System;

// Token: 0x02000AEF RID: 2799
public class YellowBat : MinionUnitConfigurationBase
{
	// Token: 0x06004B53 RID: 19283 RVA: 0x001EBE59 File Offset: 0x001EA259
	public YellowBat()
	{
	}

	// Token: 0x17000FE3 RID: 4067
	// (get) Token: 0x06004B54 RID: 19284 RVA: 0x001EBE61 File Offset: 0x001EA261
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowBat;
		}
	}

	// Token: 0x17000FE4 RID: 4068
	// (get) Token: 0x06004B55 RID: 19285 RVA: 0x001EBE68 File Offset: 0x001EA268
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
