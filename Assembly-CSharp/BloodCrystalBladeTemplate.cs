using System;
using System.Collections.Generic;

// Token: 0x0200060A RID: 1546
public class BloodCrystalBladeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A72 RID: 10866 RVA: 0x0011F42F File Offset: 0x0011D82F
	public BloodCrystalBladeTemplate()
	{
	}

	// Token: 0x170004A9 RID: 1193
	// (get) Token: 0x06002A73 RID: 10867 RVA: 0x0011F437 File Offset: 0x0011D837
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BloodCrystalBlade;
		}
	}

	// Token: 0x170004AA RID: 1194
	// (get) Token: 0x06002A74 RID: 10868 RVA: 0x0011F43E File Offset: 0x0011D83E
	public override int ItemTierNumber
	{
		get
		{
			return 33;
		}
	}

	// Token: 0x06002A75 RID: 10869 RVA: 0x0011F444 File Offset: 0x0011D844
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.CritDamage
		};
	}

	// Token: 0x06002A76 RID: 10870 RVA: 0x0011F460 File Offset: 0x0011D860
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				StealAttributeType = AttributeType.Strength,
				MaximumStolenValue = (double)(700 + (grade - QualityGrade.Normal) * 200),
				SteamPercentage = 0.5
			}
		};
	}
}
