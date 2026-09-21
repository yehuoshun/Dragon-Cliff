using System;

// Token: 0x02000A52 RID: 2642
public class OriginalPiper : MinionUnitConfigurationBase
{
	// Token: 0x060047D6 RID: 18390 RVA: 0x001DF05D File Offset: 0x001DD45D
	public OriginalPiper()
	{
	}

	// Token: 0x17000E21 RID: 3617
	// (get) Token: 0x060047D7 RID: 18391 RVA: 0x001DF065 File Offset: 0x001DD465
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Piper;
		}
	}

	// Token: 0x17000E22 RID: 3618
	// (get) Token: 0x060047D8 RID: 18392 RVA: 0x001DF06C File Offset: 0x001DD46C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
