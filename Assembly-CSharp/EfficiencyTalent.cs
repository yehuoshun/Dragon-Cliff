using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003CB RID: 971
[Serializable]
public class EfficiencyTalent : IAdventurerTalent
{
	// Token: 0x06001A1D RID: 6685 RVA: 0x000C1608 File Offset: 0x000BFA08
	public EfficiencyTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A1E RID: 6686 RVA: 0x000C1646 File Offset: 0x000BFA46
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EfficiencyBoost;
	}

	// Token: 0x06001A1F RID: 6687 RVA: 0x000C164A File Offset: 0x000BFA4A
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001A20 RID: 6688 RVA: 0x000C164D File Offset: 0x000BFA4D
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A21 RID: 6689 RVA: 0x000C1655 File Offset: 0x000BFA55
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A22 RID: 6690 RVA: 0x000C165D File Offset: 0x000BFA5D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x000C1665 File Offset: 0x000BFA65
	public int GetMaxLevel()
	{
		return EfficiencyTalent.MaxLevel;
	}

	// Token: 0x06001A24 RID: 6692 RVA: 0x000C166C File Offset: 0x000BFA6C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A25 RID: 6693 RVA: 0x000C1684 File Offset: 0x000BFA84
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EfficiencyTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.SkillRageEfficiencyRate,
			ModificationType = ModificationType.Addition,
			Value = EfficiencyTalent.Rate * (double)this.CurrentLevel,
			Key = EfficiencyTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001A26 RID: 6694 RVA: 0x000C1703 File Offset: 0x000BFB03
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A27 RID: 6695 RVA: 0x000C171A File Offset: 0x000BFB1A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == EfficiencyTalent._key);
	}

	// Token: 0x06001A28 RID: 6696 RVA: 0x000C174C File Offset: 0x000BFB4C
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A29 RID: 6697 RVA: 0x000C1753 File Offset: 0x000BFB53
	// Note: this type is marked as 'beforefieldinit'.
	static EfficiencyTalent()
	{
	}

	// Token: 0x06001A2A RID: 6698 RVA: 0x000C1773 File Offset: 0x000BFB73
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == EfficiencyTalent._key;
	}

	// Token: 0x06001A2B RID: 6699 RVA: 0x000C1785 File Offset: 0x000BFB85
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == EfficiencyTalent._key;
	}

	// Token: 0x040019AE RID: 6574
	private static string _key = "efficiencyenhancementtalent";

	// Token: 0x040019AF RID: 6575
	public static double Rate = 0.08;

	// Token: 0x040019B0 RID: 6576
	public string Id;

	// Token: 0x040019B1 RID: 6577
	public string AdditionalKey;

	// Token: 0x040019B2 RID: 6578
	public int CurrentLevel;

	// Token: 0x040019B3 RID: 6579
	public static int MaxLevel = 5;

	// Token: 0x040019B4 RID: 6580
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019B5 RID: 6581
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
