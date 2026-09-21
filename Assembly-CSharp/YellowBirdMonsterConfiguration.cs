using System;

// Token: 0x02000B10 RID: 2832
public class YellowBirdMonsterConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BDE RID: 19422 RVA: 0x001F16C0 File Offset: 0x001EFAC0
	public YellowBirdMonsterConfiguration()
	{
	}

	// Token: 0x17001021 RID: 4129
	// (get) Token: 0x06004BDF RID: 19423 RVA: 0x001F16C8 File Offset: 0x001EFAC8
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowBirdMonster;
		}
	}

	// Token: 0x17001022 RID: 4130
	// (get) Token: 0x06004BE0 RID: 19424 RVA: 0x001F16CF File Offset: 0x001EFACF
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}
}
