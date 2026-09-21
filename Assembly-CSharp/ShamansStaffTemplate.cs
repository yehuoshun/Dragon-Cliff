using System;

// Token: 0x0200063F RID: 1599
public class ShamansStaffTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B48 RID: 11080 RVA: 0x001206AC File Offset: 0x0011EAAC
	public ShamansStaffTemplate()
	{
	}

	// Token: 0x17000513 RID: 1299
	// (get) Token: 0x06002B49 RID: 11081 RVA: 0x001206B4 File Offset: 0x0011EAB4
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ShamansStaff;
		}
	}

	// Token: 0x17000514 RID: 1300
	// (get) Token: 0x06002B4A RID: 11082 RVA: 0x001206BB File Offset: 0x0011EABB
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}
}
