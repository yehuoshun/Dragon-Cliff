using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003E5 RID: 997
[Serializable]
public class HitRateEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B02 RID: 6914 RVA: 0x000C2888 File Offset: 0x000C0C88
	public HitRateEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B03 RID: 6915 RVA: 0x000C28C6 File Offset: 0x000C0CC6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.HitRateEnhancement;
	}

	// Token: 0x06001B04 RID: 6916 RVA: 0x000C28CA File Offset: 0x000C0CCA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x000C28CD File Offset: 0x000C0CCD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x000C28D5 File Offset: 0x000C0CD5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B07 RID: 6919 RVA: 0x000C28DD File Offset: 0x000C0CDD
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B08 RID: 6920 RVA: 0x000C28E5 File Offset: 0x000C0CE5
	public int GetMaxLevel()
	{
		return HitRateEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x000C28EC File Offset: 0x000C0CEC
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x000C2904 File Offset: 0x000C0D04
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == HitRateEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.HitRateAdjustment,
			ModificationType = ModificationType.Addition,
			Value = HitRateEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = HitRateEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001B0B RID: 6923 RVA: 0x000C2983 File Offset: 0x000C0D83
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001B0C RID: 6924 RVA: 0x000C299A File Offset: 0x000C0D9A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == HitRateEnhancementTalent._key);
	}

	// Token: 0x06001B0D RID: 6925 RVA: 0x000C29CC File Offset: 0x000C0DCC
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x000C29D3 File Offset: 0x000C0DD3
	// Note: this type is marked as 'beforefieldinit'.
	static HitRateEnhancementTalent()
	{
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x000C29F3 File Offset: 0x000C0DF3
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == HitRateEnhancementTalent._key;
	}

	// Token: 0x06001B10 RID: 6928 RVA: 0x000C2A05 File Offset: 0x000C0E05
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == HitRateEnhancementTalent._key;
	}

	// Token: 0x04001A09 RID: 6665
	private static string _key = "hitrateenhancementtalent";

	// Token: 0x04001A0A RID: 6666
	public static double Rate = 0.05;

	// Token: 0x04001A0B RID: 6667
	public string Id;

	// Token: 0x04001A0C RID: 6668
	public string AdditionalKey;

	// Token: 0x04001A0D RID: 6669
	public int CurrentLevel;

	// Token: 0x04001A0E RID: 6670
	public static int MaxLevel = 3;

	// Token: 0x04001A0F RID: 6671
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001A10 RID: 6672
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
