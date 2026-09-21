using System;

// Token: 0x02000B2D RID: 2861
public class BlueGrassFaceConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C42 RID: 19522 RVA: 0x001F18F1 File Offset: 0x001EFCF1
	public BlueGrassFaceConfiguration()
	{
	}

	// Token: 0x17001059 RID: 4185
	// (get) Token: 0x06004C43 RID: 19523 RVA: 0x001F18F9 File Offset: 0x001EFCF9
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueGrassFace;
		}
	}

	// Token: 0x1700105A RID: 4186
	// (get) Token: 0x06004C44 RID: 19524 RVA: 0x001F1900 File Offset: 0x001EFD00
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
