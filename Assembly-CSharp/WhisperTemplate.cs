using System;
using System.Collections.Generic;

// Token: 0x0200067A RID: 1658
public class WhisperTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C24 RID: 11300 RVA: 0x0012173D File Offset: 0x0011FB3D
	public WhisperTemplate()
	{
	}

	// Token: 0x17000589 RID: 1417
	// (get) Token: 0x06002C25 RID: 11301 RVA: 0x00121745 File Offset: 0x0011FB45
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Whisper;
		}
	}

	// Token: 0x1700058A RID: 1418
	// (get) Token: 0x06002C26 RID: 11302 RVA: 0x0012174C File Offset: 0x0011FB4C
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002C27 RID: 11303 RVA: 0x00121750 File Offset: 0x0011FB50
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x06002C28 RID: 11304 RVA: 0x00121758 File Offset: 0x0011FB58
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.08 + (double)(grade - QualityGrade.Normal) * 0.01
			}
		};
	}
}
