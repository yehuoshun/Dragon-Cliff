using System;

// Token: 0x02000A4E RID: 2638
public class OriginalBloodyCreature : MinionUnitConfigurationBase
{
	// Token: 0x060047CA RID: 18378 RVA: 0x001DF015 File Offset: 0x001DD415
	public OriginalBloodyCreature()
	{
	}

	// Token: 0x17000E19 RID: 3609
	// (get) Token: 0x060047CB RID: 18379 RVA: 0x001DF01D File Offset: 0x001DD41D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BloodyCreature;
		}
	}

	// Token: 0x17000E1A RID: 3610
	// (get) Token: 0x060047CC RID: 18380 RVA: 0x001DF024 File Offset: 0x001DD424
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
