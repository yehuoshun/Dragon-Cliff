using System;

// Token: 0x02000A50 RID: 2640
public class OriginalGlutton : MinionUnitConfigurationBase
{
	// Token: 0x060047D0 RID: 18384 RVA: 0x001DF039 File Offset: 0x001DD439
	public OriginalGlutton()
	{
	}

	// Token: 0x17000E1D RID: 3613
	// (get) Token: 0x060047D1 RID: 18385 RVA: 0x001DF041 File Offset: 0x001DD441
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Glutton;
		}
	}

	// Token: 0x17000E1E RID: 3614
	// (get) Token: 0x060047D2 RID: 18386 RVA: 0x001DF048 File Offset: 0x001DD448
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
