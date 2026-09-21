using System;

// Token: 0x02000B2E RID: 2862
public class BlueScorpion : MinionUnitConfigurationBase
{
	// Token: 0x06004C45 RID: 19525 RVA: 0x001F1904 File Offset: 0x001EFD04
	public BlueScorpion()
	{
	}

	// Token: 0x1700105B RID: 4187
	// (get) Token: 0x06004C46 RID: 19526 RVA: 0x001F190C File Offset: 0x001EFD0C
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueScorpion;
		}
	}

	// Token: 0x1700105C RID: 4188
	// (get) Token: 0x06004C47 RID: 19527 RVA: 0x001F1913 File Offset: 0x001EFD13
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
