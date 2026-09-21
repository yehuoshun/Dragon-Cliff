using System;

// Token: 0x02000A57 RID: 2647
public class Polymer : MinionUnitConfigurationBase
{
	// Token: 0x060047E5 RID: 18405 RVA: 0x001DF0B9 File Offset: 0x001DD4B9
	public Polymer()
	{
	}

	// Token: 0x17000E2B RID: 3627
	// (get) Token: 0x060047E6 RID: 18406 RVA: 0x001DF0C1 File Offset: 0x001DD4C1
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Polymer;
		}
	}

	// Token: 0x17000E2C RID: 3628
	// (get) Token: 0x060047E7 RID: 18407 RVA: 0x001DF0C8 File Offset: 0x001DD4C8
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}
}
