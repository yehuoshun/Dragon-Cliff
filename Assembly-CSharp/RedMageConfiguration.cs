using System;

// Token: 0x02000A6E RID: 2670
public class RedMageConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004896 RID: 18582 RVA: 0x001E0022 File Offset: 0x001DE422
	public RedMageConfiguration()
	{
	}

	// Token: 0x17000EC5 RID: 3781
	// (get) Token: 0x06004897 RID: 18583 RVA: 0x001E0031 File Offset: 0x001DE431
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedMage;
		}
	}

	// Token: 0x17000EC6 RID: 3782
	// (get) Token: 0x06004898 RID: 18584 RVA: 0x001E0038 File Offset: 0x001DE438
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EC7 RID: 3783
	// (get) Token: 0x06004899 RID: 18585 RVA: 0x001E0040 File Offset: 0x001DE440
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Vitality, 3.0, false).SetValue(AttributeType.Intelligience, 2.7999999523162842, false).SetValue(AttributeType.Agility, 5.0, false).SetValue(AttributeType.CritRate, 0.11999999731779099, false);
		}
	}

	// Token: 0x17000EC8 RID: 3784
	// (get) Token: 0x0600489A RID: 18586 RVA: 0x001E0092 File Offset: 0x001DE492
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.RedMageInvitation;
		}
	}

	// Token: 0x17000EC9 RID: 3785
	// (get) Token: 0x0600489B RID: 18587 RVA: 0x001E0099 File Offset: 0x001DE499
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x04003A7B RID: 14971
	private OutputType _outputType = OutputType.Fire;
}
