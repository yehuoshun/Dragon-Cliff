using System;

// Token: 0x02000B2C RID: 2860
public class BlueDevil : MinionUnitConfigurationBase
{
	// Token: 0x06004C3F RID: 19519 RVA: 0x001F18C7 File Offset: 0x001EFCC7
	public BlueDevil()
	{
	}

	// Token: 0x17001057 RID: 4183
	// (get) Token: 0x06004C40 RID: 19520 RVA: 0x001F18E1 File Offset: 0x001EFCE1
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17001058 RID: 4184
	// (get) Token: 0x06004C41 RID: 19521 RVA: 0x001F18E9 File Offset: 0x001EFCE9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003AE4 RID: 15076
	private readonly UnitClass _correspondingUnitClass = UnitClass.BlueDevil;

	// Token: 0x04003AE5 RID: 15077
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellKiller;
}
