using System;

// Token: 0x02000B04 RID: 2820
public class PurpleCannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004BA8 RID: 19368 RVA: 0x001F15C2 File Offset: 0x001EF9C2
	public PurpleCannibalBear()
	{
	}

	// Token: 0x1700100D RID: 4109
	// (get) Token: 0x06004BA9 RID: 19369 RVA: 0x001F15DC File Offset: 0x001EF9DC
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x1700100E RID: 4110
	// (get) Token: 0x06004BAA RID: 19370 RVA: 0x001F15E4 File Offset: 0x001EF9E4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003AC6 RID: 15046
	private readonly UnitClass _correspondingUnitClass = UnitClass.PurpleCannibalBear;

	// Token: 0x04003AC7 RID: 15047
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellDefender;
}
