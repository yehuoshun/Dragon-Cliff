using System;

// Token: 0x02000B09 RID: 2825
public class BlueBirdMonsterConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BC9 RID: 19401 RVA: 0x001F1641 File Offset: 0x001EFA41
	public BlueBirdMonsterConfiguration()
	{
	}

	// Token: 0x17001013 RID: 4115
	// (get) Token: 0x06004BCA RID: 19402 RVA: 0x001F1649 File Offset: 0x001EFA49
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueBirdMonster;
		}
	}

	// Token: 0x17001014 RID: 4116
	// (get) Token: 0x06004BCB RID: 19403 RVA: 0x001F1650 File Offset: 0x001EFA50
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
