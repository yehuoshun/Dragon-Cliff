using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003CC RID: 972
[Serializable]
public class ElementDamageEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001A2C RID: 6700 RVA: 0x000C1798 File Offset: 0x000BFB98
	public ElementDamageEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A2D RID: 6701 RVA: 0x000C17D6 File Offset: 0x000BFBD6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ElementDamageEnhancement;
	}

	// Token: 0x06001A2E RID: 6702 RVA: 0x000C17DA File Offset: 0x000BFBDA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x000C17DD File Offset: 0x000BFBDD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A30 RID: 6704 RVA: 0x000C17E5 File Offset: 0x000BFBE5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x000C17ED File Offset: 0x000BFBED
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x000C17F5 File Offset: 0x000BFBF5
	public int GetMaxLevel()
	{
		return ElementDamageEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x000C17FC File Offset: 0x000BFBFC
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x000C1814 File Offset: 0x000BFC14
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == ElementDamageEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealFireDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealPhysicalDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealPoisonDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealShadowDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealLightningDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealIceDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DealDivineDamageEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = ElementDamageEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = ElementDamageEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001A35 RID: 6709 RVA: 0x000C1A49 File Offset: 0x000BFE49
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A36 RID: 6710 RVA: 0x000C1A60 File Offset: 0x000BFE60
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == ElementDamageEnhancementTalent._key);
	}

	// Token: 0x06001A37 RID: 6711 RVA: 0x000C1A92 File Offset: 0x000BFE92
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A38 RID: 6712 RVA: 0x000C1A99 File Offset: 0x000BFE99
	// Note: this type is marked as 'beforefieldinit'.
	static ElementDamageEnhancementTalent()
	{
	}

	// Token: 0x06001A39 RID: 6713 RVA: 0x000C1AB9 File Offset: 0x000BFEB9
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == ElementDamageEnhancementTalent._key;
	}

	// Token: 0x06001A3A RID: 6714 RVA: 0x000C1ACB File Offset: 0x000BFECB
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == ElementDamageEnhancementTalent._key;
	}

	// Token: 0x040019B6 RID: 6582
	private static string _key = "elementdamageenhancementtalent";

	// Token: 0x040019B7 RID: 6583
	public static double Rate = 0.25;

	// Token: 0x040019B8 RID: 6584
	public string Id;

	// Token: 0x040019B9 RID: 6585
	public string AdditionalKey;

	// Token: 0x040019BA RID: 6586
	public int CurrentLevel;

	// Token: 0x040019BB RID: 6587
	public static int MaxLevel = 3;

	// Token: 0x040019BC RID: 6588
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019BD RID: 6589
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
