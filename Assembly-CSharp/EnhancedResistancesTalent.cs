using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003D2 RID: 978
[Serializable]
public class EnhancedResistancesTalent : IAdventurerTalent
{
	// Token: 0x06001A6A RID: 6762 RVA: 0x000C1EF8 File Offset: 0x000C02F8
	public EnhancedResistancesTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A6B RID: 6763 RVA: 0x000C1F36 File Offset: 0x000C0336
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EnhancedResistances;
	}

	// Token: 0x06001A6C RID: 6764 RVA: 0x000C1F3A File Offset: 0x000C033A
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001A6D RID: 6765 RVA: 0x000C1F3D File Offset: 0x000C033D
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A6E RID: 6766 RVA: 0x000C1F45 File Offset: 0x000C0345
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A6F RID: 6767 RVA: 0x000C1F4D File Offset: 0x000C034D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A70 RID: 6768 RVA: 0x000C1F55 File Offset: 0x000C0355
	public int GetMaxLevel()
	{
		return EnhancedResistancesTalent.MaxLevel;
	}

	// Token: 0x06001A71 RID: 6769 RVA: 0x000C1F5C File Offset: 0x000C035C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A72 RID: 6770 RVA: 0x000C1F74 File Offset: 0x000C0374
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EnhancedResistancesTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.Allresistances,
			ModificationType = ModificationType.Multiplication,
			Value = EnhancedResistancesTalent.Rate * (double)this.CurrentLevel,
			Key = EnhancedResistancesTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001A73 RID: 6771 RVA: 0x000C1FF0 File Offset: 0x000C03F0
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A74 RID: 6772 RVA: 0x000C2007 File Offset: 0x000C0407
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EnhancedResistancesTalent._key);
	}

	// Token: 0x06001A75 RID: 6773 RVA: 0x000C2039 File Offset: 0x000C0439
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A76 RID: 6774 RVA: 0x000C2040 File Offset: 0x000C0440
	// Note: this type is marked as 'beforefieldinit'.
	static EnhancedResistancesTalent()
	{
	}

	// Token: 0x06001A77 RID: 6775 RVA: 0x000C2060 File Offset: 0x000C0460
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == EnhancedResistancesTalent._key;
	}

	// Token: 0x06001A78 RID: 6776 RVA: 0x000C2072 File Offset: 0x000C0472
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == EnhancedResistancesTalent._key;
	}

	// Token: 0x040019D1 RID: 6609
	private static string _key = "resistanceenhancementtalent";

	// Token: 0x040019D2 RID: 6610
	public static double Rate = 0.02;

	// Token: 0x040019D3 RID: 6611
	public string Id;

	// Token: 0x040019D4 RID: 6612
	public string AdditionalKey;

	// Token: 0x040019D5 RID: 6613
	public int CurrentLevel;

	// Token: 0x040019D6 RID: 6614
	public static int MaxLevel = 5;

	// Token: 0x040019D7 RID: 6615
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019D8 RID: 6616
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
