using System;

// Token: 0x02000AFC RID: 2812
public class RedGoblinWizard : MinionUnitConfigurationBase
{
	// Token: 0x06004B8B RID: 19339 RVA: 0x001F12CA File Offset: 0x001EF6CA
	public RedGoblinWizard()
	{
	}

	// Token: 0x17000FFD RID: 4093
	// (get) Token: 0x06004B8C RID: 19340 RVA: 0x001F12D2 File Offset: 0x001EF6D2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedGoblinWizard;
		}
	}

	// Token: 0x17000FFE RID: 4094
	// (get) Token: 0x06004B8D RID: 19341 RVA: 0x001F12D9 File Offset: 0x001EF6D9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
