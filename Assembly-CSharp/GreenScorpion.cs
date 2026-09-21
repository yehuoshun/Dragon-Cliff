using System;

// Token: 0x02000B32 RID: 2866
public class GreenScorpion : MinionUnitConfigurationBase
{
	// Token: 0x06004C51 RID: 19537 RVA: 0x001F194C File Offset: 0x001EFD4C
	public GreenScorpion()
	{
	}

	// Token: 0x17001063 RID: 4195
	// (get) Token: 0x06004C52 RID: 19538 RVA: 0x001F1954 File Offset: 0x001EFD54
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenScorpion;
		}
	}

	// Token: 0x17001064 RID: 4196
	// (get) Token: 0x06004C53 RID: 19539 RVA: 0x001F195B File Offset: 0x001EFD5B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
