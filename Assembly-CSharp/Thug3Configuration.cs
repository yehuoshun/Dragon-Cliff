using System;

// Token: 0x02000B18 RID: 2840
public class Thug3Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004BF7 RID: 19447 RVA: 0x001F173A File Offset: 0x001EFB3A
	public Thug3Configuration()
	{
	}

	// Token: 0x1700102B RID: 4139
	// (get) Token: 0x06004BF8 RID: 19448 RVA: 0x001F1742 File Offset: 0x001EFB42
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug3;
		}
	}

	// Token: 0x1700102C RID: 4140
	// (get) Token: 0x06004BF9 RID: 19449 RVA: 0x001F1749 File Offset: 0x001EFB49
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
