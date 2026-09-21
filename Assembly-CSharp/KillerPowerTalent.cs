using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003E8 RID: 1000
[Serializable]
public class KillerPowerTalent : IAdventurerTalent
{
	// Token: 0x06001B27 RID: 6951 RVA: 0x000C2AFC File Offset: 0x000C0EFC
	public KillerPowerTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B28 RID: 6952 RVA: 0x000C2B3A File Offset: 0x000C0F3A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.KillerPower;
	}

	// Token: 0x06001B29 RID: 6953 RVA: 0x000C2B3E File Offset: 0x000C0F3E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x000C2B41 File Offset: 0x000C0F41
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B2B RID: 6955 RVA: 0x000C2B49 File Offset: 0x000C0F49
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x000C2B51 File Offset: 0x000C0F51
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x000C2B59 File Offset: 0x000C0F59
	public int GetMaxLevel()
	{
		return KillerPowerTalent.MaxLevel;
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x000C2B60 File Offset: 0x000C0F60
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x000C2B78 File Offset: 0x000C0F78
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == KillerPowerTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = profile.GetOutputAttributeType(),
			ModificationType = ModificationType.Multiplication,
			Value = KillerPowerTalent.Rate * (double)this.CurrentLevel,
			Key = KillerPowerTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001B30 RID: 6960 RVA: 0x000C2BF8 File Offset: 0x000C0FF8
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x000C2C0F File Offset: 0x000C100F
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == KillerPowerTalent._key);
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x000C2C41 File Offset: 0x000C1041
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x000C2C48 File Offset: 0x000C1048
	// Note: this type is marked as 'beforefieldinit'.
	static KillerPowerTalent()
	{
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x000C2C69 File Offset: 0x000C1069
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == KillerPowerTalent._key;
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x000C2C7B File Offset: 0x000C107B
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == KillerPowerTalent._key;
	}

	// Token: 0x04001A16 RID: 6678
	private static string _key = "mainattributeenhancementtalent";

	// Token: 0x04001A17 RID: 6679
	public static double Rate = 0.005;

	// Token: 0x04001A18 RID: 6680
	public string Id;

	// Token: 0x04001A19 RID: 6681
	public string AdditionalKey;

	// Token: 0x04001A1A RID: 6682
	public int CurrentLevel;

	// Token: 0x04001A1B RID: 6683
	public static int MaxLevel = 10;

	// Token: 0x04001A1C RID: 6684
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001A1D RID: 6685
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
