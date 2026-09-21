using System;
using System.Collections.Generic;

// Token: 0x0200069C RID: 1692
public class EmeraldOfClearHeartSetLogic : SetItemLogicBase
{
	// Token: 0x06002CE7 RID: 11495 RVA: 0x00126FA6 File Offset: 0x001253A6
	public EmeraldOfClearHeartSetLogic()
	{
	}

	// Token: 0x170005A4 RID: 1444
	// (get) Token: 0x06002CE8 RID: 11496 RVA: 0x00126FB9 File Offset: 0x001253B9
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002CE9 RID: 11497 RVA: 0x00126FC4 File Offset: 0x001253C4
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DamageReduction,
				Value = 0.25,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002CEA RID: 11498 RVA: 0x00127018 File Offset: 0x00125418
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.EffectResistanceRating,
				ModificationType = ModificationType.Addition,
				Value = 350.0,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.SetBonus
			}
		};
	}

	// Token: 0x06002CEB RID: 11499 RVA: 0x0012706C File Offset: 0x0012546C
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CEC RID: 11500 RVA: 0x00127074 File Offset: 0x00125474
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EmeraldOfClearHeartData()
		};
	}

	// Token: 0x0400269F RID: 9887
	private ResourceType _correspondingSetResourceType = ResourceType.EmeraldOfClearHeart;
}
