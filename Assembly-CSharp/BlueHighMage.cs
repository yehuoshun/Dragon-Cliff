using System;

// Token: 0x02000AF6 RID: 2806
public class BlueHighMage : MinionUnitConfigurationBase
{
	// Token: 0x06004B79 RID: 19321 RVA: 0x001F1244 File Offset: 0x001EF644
	public BlueHighMage()
	{
	}

	// Token: 0x17000FF1 RID: 4081
	// (get) Token: 0x06004B7A RID: 19322 RVA: 0x001F124C File Offset: 0x001EF64C
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueHighMage;
		}
	}

	// Token: 0x17000FF2 RID: 4082
	// (get) Token: 0x06004B7B RID: 19323 RVA: 0x001F1253 File Offset: 0x001EF653
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
