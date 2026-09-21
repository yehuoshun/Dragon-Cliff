using System;

// Token: 0x02000B05 RID: 2821
public class RedCannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004BAB RID: 19371 RVA: 0x001F15EC File Offset: 0x001EF9EC
	public RedCannibalBear()
	{
	}

	// Token: 0x1700100F RID: 4111
	// (get) Token: 0x06004BAC RID: 19372 RVA: 0x001F1606 File Offset: 0x001EFA06
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17001010 RID: 4112
	// (get) Token: 0x06004BAD RID: 19373 RVA: 0x001F160E File Offset: 0x001EFA0E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003AC8 RID: 15048
	private readonly UnitClass _correspondingUnitClass = UnitClass.RedCannibalBear;

	// Token: 0x04003AC9 RID: 15049
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellWarrior;
}
