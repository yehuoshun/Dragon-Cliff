using System;

// Token: 0x02000A5B RID: 2651
public class YellowDevil : MinionUnitConfigurationBase
{
	// Token: 0x060047F1 RID: 18417 RVA: 0x001DF11A File Offset: 0x001DD51A
	public YellowDevil()
	{
	}

	// Token: 0x17000E33 RID: 3635
	// (get) Token: 0x060047F2 RID: 18418 RVA: 0x001DF134 File Offset: 0x001DD534
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000E34 RID: 3636
	// (get) Token: 0x060047F3 RID: 18419 RVA: 0x001DF13C File Offset: 0x001DD53C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003A67 RID: 14951
	private readonly UnitClass _correspondingUnitClass = UnitClass.YellowDevil;

	// Token: 0x04003A68 RID: 14952
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.PhysicalWarrior;
}
