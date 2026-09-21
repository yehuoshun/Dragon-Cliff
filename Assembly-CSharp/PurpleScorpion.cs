using System;

// Token: 0x02000B33 RID: 2867
public class PurpleScorpion : MinionUnitConfigurationBase
{
	// Token: 0x06004C54 RID: 19540 RVA: 0x001F195E File Offset: 0x001EFD5E
	public PurpleScorpion()
	{
	}

	// Token: 0x17001065 RID: 4197
	// (get) Token: 0x06004C55 RID: 19541 RVA: 0x001F1966 File Offset: 0x001EFD66
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleScorpion;
		}
	}

	// Token: 0x17001066 RID: 4198
	// (get) Token: 0x06004C56 RID: 19542 RVA: 0x001F196D File Offset: 0x001EFD6D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
