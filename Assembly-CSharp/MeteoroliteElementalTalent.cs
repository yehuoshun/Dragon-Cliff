using System;
using System.Collections.Generic;

// Token: 0x020003EB RID: 1003
[Serializable]
public class MeteoroliteElementalTalent : TacticTalentBase
{
	// Token: 0x06001B50 RID: 6992 RVA: 0x000C2EFE File Offset: 0x000C12FE
	public MeteoroliteElementalTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001B51 RID: 6993 RVA: 0x000C2F08 File Offset: 0x000C1308
	public OutputType GetChangeType()
	{
		if (this.SlotNumber == 2)
		{
			return OutputType.Ice;
		}
		return OutputType.Poison;
	}

	// Token: 0x06001B52 RID: 6994 RVA: 0x000C2F19 File Offset: 0x000C1319
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.GrandMeteoroliteElementalChange;
	}

	// Token: 0x06001B53 RID: 6995 RVA: 0x000C2F20 File Offset: 0x000C1320
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrandMeteoroliteElementalChangeData
			{
				IsStar = false,
				Type = this.GetChangeType(),
				ExtraDamageRate = MeteoroliteElementalTalent.Rate
			}
		};
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x000C2F5F File Offset: 0x000C135F
	// Note: this type is marked as 'beforefieldinit'.
	static MeteoroliteElementalTalent()
	{
	}

	// Token: 0x04001A2C RID: 6700
	public static double Rate = 0.1;
}
