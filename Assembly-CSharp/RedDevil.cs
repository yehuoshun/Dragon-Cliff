using System;

// Token: 0x02000A58 RID: 2648
public class RedDevil : MinionUnitConfigurationBase
{
	// Token: 0x060047E8 RID: 18408 RVA: 0x001DF0CB File Offset: 0x001DD4CB
	public RedDevil()
	{
	}

	// Token: 0x17000E2D RID: 3629
	// (get) Token: 0x060047E9 RID: 18409 RVA: 0x001DF0E5 File Offset: 0x001DD4E5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000E2E RID: 3630
	// (get) Token: 0x060047EA RID: 18410 RVA: 0x001DF0ED File Offset: 0x001DD4ED
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003A65 RID: 14949
	private readonly UnitClass _correspondingUnitClass = UnitClass.RedDevil;

	// Token: 0x04003A66 RID: 14950
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellKiller;
}
