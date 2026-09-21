using System;

// Token: 0x02000AE6 RID: 2790
public class OriginalSkeleton : MinionUnitConfigurationBase
{
	// Token: 0x06004B33 RID: 19251 RVA: 0x001EBD3F File Offset: 0x001EA13F
	public OriginalSkeleton()
	{
	}

	// Token: 0x17000FD5 RID: 4053
	// (get) Token: 0x06004B34 RID: 19252 RVA: 0x001EBD47 File Offset: 0x001EA147
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Skeleton;
		}
	}

	// Token: 0x17000FD6 RID: 4054
	// (get) Token: 0x06004B35 RID: 19253 RVA: 0x001EBD4E File Offset: 0x001EA14E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
