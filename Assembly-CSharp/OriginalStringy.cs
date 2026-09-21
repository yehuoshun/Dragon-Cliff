using System;

// Token: 0x02000A55 RID: 2645
public class OriginalStringy : MinionUnitConfigurationBase
{
	// Token: 0x060047DF RID: 18399 RVA: 0x001DF095 File Offset: 0x001DD495
	public OriginalStringy()
	{
	}

	// Token: 0x17000E27 RID: 3623
	// (get) Token: 0x060047E0 RID: 18400 RVA: 0x001DF09D File Offset: 0x001DD49D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Stringy;
		}
	}

	// Token: 0x17000E28 RID: 3624
	// (get) Token: 0x060047E1 RID: 18401 RVA: 0x001DF0A4 File Offset: 0x001DD4A4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
