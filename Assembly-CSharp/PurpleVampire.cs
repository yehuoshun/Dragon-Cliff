using System;

// Token: 0x02000AED RID: 2797
public class PurpleVampire : MinionUnitConfigurationBase
{
	// Token: 0x06004B4D RID: 19277 RVA: 0x001EBE35 File Offset: 0x001EA235
	public PurpleVampire()
	{
	}

	// Token: 0x17000FDF RID: 4063
	// (get) Token: 0x06004B4E RID: 19278 RVA: 0x001EBE3D File Offset: 0x001EA23D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleVampire;
		}
	}

	// Token: 0x17000FE0 RID: 4064
	// (get) Token: 0x06004B4F RID: 19279 RVA: 0x001EBE44 File Offset: 0x001EA244
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
