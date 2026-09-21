using System;

// Token: 0x02000AA1 RID: 2721
public class PurpleDevil : MiniBossUnitConfigurationBase
{
	// Token: 0x060049BB RID: 18875 RVA: 0x001E7D37 File Offset: 0x001E6137
	public PurpleDevil()
	{
	}

	// Token: 0x17000F53 RID: 3923
	// (get) Token: 0x060049BC RID: 18876 RVA: 0x001E7D51 File Offset: 0x001E6151
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000F54 RID: 3924
	// (get) Token: 0x060049BD RID: 18877 RVA: 0x001E7D59 File Offset: 0x001E6159
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003A90 RID: 14992
	private readonly UnitClass _correspondingUnitClass = UnitClass.PurpleDevil;

	// Token: 0x04003A91 RID: 14993
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellWarrior;
}
