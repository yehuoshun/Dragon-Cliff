using System;

// Token: 0x02000A9D RID: 2717
public class Cyclops : MiniBossUnitConfigurationBase
{
	// Token: 0x060049AC RID: 18860 RVA: 0x001E7C76 File Offset: 0x001E6076
	public Cyclops()
	{
	}

	// Token: 0x17000F4B RID: 3915
	// (get) Token: 0x060049AD RID: 18861 RVA: 0x001E7C7E File Offset: 0x001E607E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Cyclops;
		}
	}

	// Token: 0x17000F4C RID: 3916
	// (get) Token: 0x060049AE RID: 18862 RVA: 0x001E7C85 File Offset: 0x001E6085
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}
}
