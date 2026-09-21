using System;

// Token: 0x02000A59 RID: 2649
public class SkeletonMage : MinionUnitConfigurationBase
{
	// Token: 0x060047EB RID: 18411 RVA: 0x001DF0F5 File Offset: 0x001DD4F5
	public SkeletonMage()
	{
	}

	// Token: 0x17000E2F RID: 3631
	// (get) Token: 0x060047EC RID: 18412 RVA: 0x001DF0FD File Offset: 0x001DD4FD
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.SkeletonMage;
		}
	}

	// Token: 0x17000E30 RID: 3632
	// (get) Token: 0x060047ED RID: 18413 RVA: 0x001DF104 File Offset: 0x001DD504
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}
}
