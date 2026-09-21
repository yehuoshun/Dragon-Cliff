using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003DD RID: 989
[Serializable]
public class FurySpeedTalent : IAdventurerTalent
{
	// Token: 0x06001AC1 RID: 6849 RVA: 0x000C2484 File Offset: 0x000C0884
	public FurySpeedTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001AC2 RID: 6850 RVA: 0x000C24C2 File Offset: 0x000C08C2
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FurySpeed;
	}

	// Token: 0x06001AC3 RID: 6851 RVA: 0x000C24C6 File Offset: 0x000C08C6
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001AC4 RID: 6852 RVA: 0x000C24C9 File Offset: 0x000C08C9
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001AC5 RID: 6853 RVA: 0x000C24D1 File Offset: 0x000C08D1
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001AC6 RID: 6854 RVA: 0x000C24D9 File Offset: 0x000C08D9
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001AC7 RID: 6855 RVA: 0x000C24E1 File Offset: 0x000C08E1
	public int GetMaxLevel()
	{
		return FurySpeedTalent.MaxLevel;
	}

	// Token: 0x06001AC8 RID: 6856 RVA: 0x000C24E8 File Offset: 0x000C08E8
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001AC9 RID: 6857 RVA: 0x000C2500 File Offset: 0x000C0900
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == FurySpeedTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.Agility,
			ModificationType = ModificationType.Multiplication,
			Value = FurySpeedTalent.Rate * (double)this.CurrentLevel,
			Key = FurySpeedTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001ACA RID: 6858 RVA: 0x000C257B File Offset: 0x000C097B
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001ACB RID: 6859 RVA: 0x000C2592 File Offset: 0x000C0992
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == FurySpeedTalent._key);
	}

	// Token: 0x06001ACC RID: 6860 RVA: 0x000C25C4 File Offset: 0x000C09C4
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001ACD RID: 6861 RVA: 0x000C25CB File Offset: 0x000C09CB
	// Note: this type is marked as 'beforefieldinit'.
	static FurySpeedTalent()
	{
	}

	// Token: 0x06001ACE RID: 6862 RVA: 0x000C25EB File Offset: 0x000C09EB
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == FurySpeedTalent._key;
	}

	// Token: 0x06001ACF RID: 6863 RVA: 0x000C25FD File Offset: 0x000C09FD
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == FurySpeedTalent._key;
	}

	// Token: 0x040019F1 RID: 6641
	private static string _key = "agilityenhancementtalent";

	// Token: 0x040019F2 RID: 6642
	public static double Rate = 0.015;

	// Token: 0x040019F3 RID: 6643
	public string Id;

	// Token: 0x040019F4 RID: 6644
	public string AdditionalKey;

	// Token: 0x040019F5 RID: 6645
	public int CurrentLevel;

	// Token: 0x040019F6 RID: 6646
	public static int MaxLevel = 5;

	// Token: 0x040019F7 RID: 6647
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019F8 RID: 6648
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
