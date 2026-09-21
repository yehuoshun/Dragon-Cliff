using System;

// Token: 0x02000B2F RID: 2863
public class BlueShamanConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C48 RID: 19528 RVA: 0x001F1916 File Offset: 0x001EFD16
	public BlueShamanConfiguration()
	{
	}

	// Token: 0x1700105D RID: 4189
	// (get) Token: 0x06004C49 RID: 19529 RVA: 0x001F191E File Offset: 0x001EFD1E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueShaman;
		}
	}

	// Token: 0x1700105E RID: 4190
	// (get) Token: 0x06004C4A RID: 19530 RVA: 0x001F1925 File Offset: 0x001EFD25
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
