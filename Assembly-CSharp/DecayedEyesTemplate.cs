using System;
using System.Collections.Generic;

// Token: 0x0200062F RID: 1583
public class DecayedEyesTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B09 RID: 11017 RVA: 0x00120037 File Offset: 0x0011E437
	public DecayedEyesTemplate()
	{
	}

	// Token: 0x170004F3 RID: 1267
	// (get) Token: 0x06002B0A RID: 11018 RVA: 0x0012003F File Offset: 0x0011E43F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DecayedEyes;
		}
	}

	// Token: 0x170004F4 RID: 1268
	// (get) Token: 0x06002B0B RID: 11019 RVA: 0x00120046 File Offset: 0x0011E446
	public override int ItemTierNumber
	{
		get
		{
			return 28;
		}
	}

	// Token: 0x06002B0C RID: 11020 RVA: 0x0012004C File Offset: 0x0011E44C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.StunOnHit
		};
	}

	// Token: 0x06002B0D RID: 11021 RVA: 0x0012006C File Offset: 0x0011E46C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamageType = OutputType.Lightening,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1
			}
		};
	}
}
