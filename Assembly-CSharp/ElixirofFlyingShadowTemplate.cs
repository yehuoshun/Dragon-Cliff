using System;
using System.Collections.Generic;

// Token: 0x020005DD RID: 1501
public class ElixirofFlyingShadowTemplate : ConsumableTemplateBase
{
	// Token: 0x06002994 RID: 10644 RVA: 0x0011C017 File Offset: 0x0011A417
	public ElixirofFlyingShadowTemplate()
	{
	}

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x06002995 RID: 10645 RVA: 0x0011C01F File Offset: 0x0011A41F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ElixirofFlyingShadow;
		}
	}

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x06002996 RID: 10646 RVA: 0x0011C026 File Offset: 0x0011A426
	public override int ItemTierNumber
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x06002997 RID: 10647 RVA: 0x0011C02C File Offset: 0x0011A42C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeBoostData
			{
				IsStar = false,
				MultiplicationBoosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.15,
						BoostAttribute = AttributeType.Agility
					},
					new BoostSetting
					{
						BoostValue = 0.15,
						BoostAttribute = AttributeType.Allresistances
					}
				},
				AdditionBoosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.15,
						BoostAttribute = AttributeType.DodgeRateAdjustment
					},
					new BoostSetting
					{
						BoostValue = 0.15,
						BoostAttribute = AttributeType.TurnStartHeal
					}
				}
			}
		};
	}
}
