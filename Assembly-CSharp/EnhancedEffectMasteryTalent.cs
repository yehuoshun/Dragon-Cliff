using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003D1 RID: 977
[Serializable]
public class EnhancedEffectMasteryTalent : IAdventurerTalent
{
	// Token: 0x06001A5B RID: 6747 RVA: 0x000C1D68 File Offset: 0x000C0168
	public EnhancedEffectMasteryTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A5C RID: 6748 RVA: 0x000C1DA6 File Offset: 0x000C01A6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EnhancedEffects;
	}

	// Token: 0x06001A5D RID: 6749 RVA: 0x000C1DAA File Offset: 0x000C01AA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001A5E RID: 6750 RVA: 0x000C1DAD File Offset: 0x000C01AD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A5F RID: 6751 RVA: 0x000C1DB5 File Offset: 0x000C01B5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A60 RID: 6752 RVA: 0x000C1DBD File Offset: 0x000C01BD
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A61 RID: 6753 RVA: 0x000C1DC5 File Offset: 0x000C01C5
	public int GetMaxLevel()
	{
		return EnhancedEffectMasteryTalent.MaxLevel;
	}

	// Token: 0x06001A62 RID: 6754 RVA: 0x000C1DCC File Offset: 0x000C01CC
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x000C1DE4 File Offset: 0x000C01E4
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EnhancedEffectMasteryTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.EffectMastery,
			ModificationType = ModificationType.Addition,
			Value = EnhancedEffectMasteryTalent.Rate * (double)this.CurrentLevel,
			Key = EnhancedEffectMasteryTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001A64 RID: 6756 RVA: 0x000C1E63 File Offset: 0x000C0263
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A65 RID: 6757 RVA: 0x000C1E7A File Offset: 0x000C027A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EnhancedEffectMasteryTalent._key);
	}

	// Token: 0x06001A66 RID: 6758 RVA: 0x000C1EAC File Offset: 0x000C02AC
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A67 RID: 6759 RVA: 0x000C1EB3 File Offset: 0x000C02B3
	// Note: this type is marked as 'beforefieldinit'.
	static EnhancedEffectMasteryTalent()
	{
	}

	// Token: 0x06001A68 RID: 6760 RVA: 0x000C1ED3 File Offset: 0x000C02D3
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == EnhancedEffectMasteryTalent._key;
	}

	// Token: 0x06001A69 RID: 6761 RVA: 0x000C1EE5 File Offset: 0x000C02E5
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == EnhancedEffectMasteryTalent._key;
	}

	// Token: 0x040019C9 RID: 6601
	private static string _key = "effectmasteryenhancementtalent";

	// Token: 0x040019CA RID: 6602
	public static double Rate = 0.1;

	// Token: 0x040019CB RID: 6603
	public string Id;

	// Token: 0x040019CC RID: 6604
	public string AdditionalKey;

	// Token: 0x040019CD RID: 6605
	public int CurrentLevel;

	// Token: 0x040019CE RID: 6606
	public static int MaxLevel = 5;

	// Token: 0x040019CF RID: 6607
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019D0 RID: 6608
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
