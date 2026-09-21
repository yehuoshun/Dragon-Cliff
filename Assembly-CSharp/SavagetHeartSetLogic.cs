using System;
using System.Collections.Generic;

// Token: 0x020006A3 RID: 1699
public class SavagetHeartSetLogic : SetItemLogicBase
{
	// Token: 0x06002D11 RID: 11537 RVA: 0x0012769C File Offset: 0x00125A9C
	public SavagetHeartSetLogic()
	{
	}

	// Token: 0x170005AB RID: 1451
	// (get) Token: 0x06002D12 RID: 11538 RVA: 0x001276AF File Offset: 0x00125AAF
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002D13 RID: 11539 RVA: 0x001276B8 File Offset: 0x00125AB8
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.Intelligience,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = 0.25,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002D14 RID: 11540 RVA: 0x00127708 File Offset: 0x00125B08
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D15 RID: 11541 RVA: 0x0012770F File Offset: 0x00125B0F
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D16 RID: 11542 RVA: 0x00127718 File Offset: 0x00125B18
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SavageHeartData()
		};
	}

	// Token: 0x040026A4 RID: 9892
	private ResourceType _correspondingSetResourceType = ResourceType.SavageHeart;
}
