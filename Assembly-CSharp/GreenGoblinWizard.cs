using System;

// Token: 0x02000AF8 RID: 2808
public class GreenGoblinWizard : MinionUnitConfigurationBase
{
	// Token: 0x06004B7F RID: 19327 RVA: 0x001F1281 File Offset: 0x001EF681
	public GreenGoblinWizard()
	{
	}

	// Token: 0x17000FF5 RID: 4085
	// (get) Token: 0x06004B80 RID: 19328 RVA: 0x001F1289 File Offset: 0x001EF689
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenGoblinWizard;
		}
	}

	// Token: 0x17000FF6 RID: 4086
	// (get) Token: 0x06004B81 RID: 19329 RVA: 0x001F1290 File Offset: 0x001EF690
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
