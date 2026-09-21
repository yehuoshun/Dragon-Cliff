using System;

// Token: 0x02000B35 RID: 2869
public class YellowGrassFaceConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C5A RID: 19546 RVA: 0x001F1983 File Offset: 0x001EFD83
	public YellowGrassFaceConfiguration()
	{
	}

	// Token: 0x17001069 RID: 4201
	// (get) Token: 0x06004C5B RID: 19547 RVA: 0x001F198B File Offset: 0x001EFD8B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowGrassFace;
		}
	}

	// Token: 0x1700106A RID: 4202
	// (get) Token: 0x06004C5C RID: 19548 RVA: 0x001F1992 File Offset: 0x001EFD92
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
