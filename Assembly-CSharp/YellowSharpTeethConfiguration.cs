using System;

// Token: 0x02000B36 RID: 2870
public class YellowSharpTeethConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C5D RID: 19549 RVA: 0x001F1995 File Offset: 0x001EFD95
	public YellowSharpTeethConfiguration()
	{
	}

	// Token: 0x1700106B RID: 4203
	// (get) Token: 0x06004C5E RID: 19550 RVA: 0x001F199D File Offset: 0x001EFD9D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowSharpTeeth;
		}
	}

	// Token: 0x1700106C RID: 4204
	// (get) Token: 0x06004C5F RID: 19551 RVA: 0x001F19A4 File Offset: 0x001EFDA4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
