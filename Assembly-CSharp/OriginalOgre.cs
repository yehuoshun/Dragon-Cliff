using System;

// Token: 0x02000A51 RID: 2641
public class OriginalOgre : MinionUnitConfigurationBase
{
	// Token: 0x060047D3 RID: 18387 RVA: 0x001DF04B File Offset: 0x001DD44B
	public OriginalOgre()
	{
	}

	// Token: 0x17000E1F RID: 3615
	// (get) Token: 0x060047D4 RID: 18388 RVA: 0x001DF053 File Offset: 0x001DD453
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Ogre;
		}
	}

	// Token: 0x17000E20 RID: 3616
	// (get) Token: 0x060047D5 RID: 18389 RVA: 0x001DF05A File Offset: 0x001DD45A
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}
}
