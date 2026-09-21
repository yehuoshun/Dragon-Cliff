using System;

// Token: 0x02000B29 RID: 2857
public class PurpleSpearerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C2A RID: 19498 RVA: 0x001F1871 File Offset: 0x001EFC71
	public PurpleSpearerConfiguration()
	{
	}

	// Token: 0x1700104D RID: 4173
	// (get) Token: 0x06004C2B RID: 19499 RVA: 0x001F1879 File Offset: 0x001EFC79
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleSpearer;
		}
	}

	// Token: 0x1700104E RID: 4174
	// (get) Token: 0x06004C2C RID: 19500 RVA: 0x001F1880 File Offset: 0x001EFC80
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
