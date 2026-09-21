using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000426 RID: 1062
[Serializable]
public class VitalityEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001D40 RID: 7488 RVA: 0x000C7860 File Offset: 0x000C5C60
	public VitalityEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001D41 RID: 7489 RVA: 0x000C789E File Offset: 0x000C5C9E
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.VitalityEnhancement;
	}

	// Token: 0x06001D42 RID: 7490 RVA: 0x000C78A2 File Offset: 0x000C5CA2
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001D43 RID: 7491 RVA: 0x000C78A5 File Offset: 0x000C5CA5
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x000C78AD File Offset: 0x000C5CAD
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001D45 RID: 7493 RVA: 0x000C78B5 File Offset: 0x000C5CB5
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001D46 RID: 7494 RVA: 0x000C78BD File Offset: 0x000C5CBD
	public int GetMaxLevel()
	{
		return VitalityEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001D47 RID: 7495 RVA: 0x000C78C4 File Offset: 0x000C5CC4
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001D48 RID: 7496 RVA: 0x000C78DC File Offset: 0x000C5CDC
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == VitalityEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.Vitality,
			ModificationType = ModificationType.Multiplication,
			Value = VitalityEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = VitalityEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001D49 RID: 7497 RVA: 0x000C7957 File Offset: 0x000C5D57
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001D4A RID: 7498 RVA: 0x000C796E File Offset: 0x000C5D6E
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == VitalityEnhancementTalent._key);
	}

	// Token: 0x06001D4B RID: 7499 RVA: 0x000C79A0 File Offset: 0x000C5DA0
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001D4C RID: 7500 RVA: 0x000C79A7 File Offset: 0x000C5DA7
	// Note: this type is marked as 'beforefieldinit'.
	static VitalityEnhancementTalent()
	{
	}

	// Token: 0x06001D4D RID: 7501 RVA: 0x000C79C7 File Offset: 0x000C5DC7
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == VitalityEnhancementTalent._key;
	}

	// Token: 0x06001D4E RID: 7502 RVA: 0x000C79D9 File Offset: 0x000C5DD9
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == VitalityEnhancementTalent._key;
	}

	// Token: 0x04001AF7 RID: 6903
	private static string _key = "vitalityenhancementtalent";

	// Token: 0x04001AF8 RID: 6904
	public static double Rate = 0.02;

	// Token: 0x04001AF9 RID: 6905
	public string Id;

	// Token: 0x04001AFA RID: 6906
	public string AdditionalKey;

	// Token: 0x04001AFB RID: 6907
	public int CurrentLevel;

	// Token: 0x04001AFC RID: 6908
	public static int MaxLevel = 5;

	// Token: 0x04001AFD RID: 6909
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001AFE RID: 6910
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
