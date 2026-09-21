using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003C3 RID: 963
[Serializable]
public class CritDamageBoostTalent : IAdventurerTalent
{
	// Token: 0x060019C6 RID: 6598 RVA: 0x000C0ED4 File Offset: 0x000BF2D4
	public CritDamageBoostTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x000C0F12 File Offset: 0x000BF312
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.CritDamageBoost;
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x000C0F16 File Offset: 0x000BF316
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x000C0F19 File Offset: 0x000BF319
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x000C0F21 File Offset: 0x000BF321
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019CB RID: 6603 RVA: 0x000C0F29 File Offset: 0x000BF329
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x000C0F31 File Offset: 0x000BF331
	public int GetMaxLevel()
	{
		return CritDamageBoostTalent.MaxLevel;
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x000C0F38 File Offset: 0x000BF338
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x060019CE RID: 6606 RVA: 0x000C0F50 File Offset: 0x000BF350
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == CritDamageBoostTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.CritDamage,
			ModificationType = ModificationType.Addition,
			Value = CritDamageBoostTalent.Rate * (double)this.CurrentLevel,
			Key = CritDamageBoostTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x060019CF RID: 6607 RVA: 0x000C0FCB File Offset: 0x000BF3CB
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x000C0FE2 File Offset: 0x000BF3E2
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == CritDamageBoostTalent._key);
	}

	// Token: 0x060019D1 RID: 6609 RVA: 0x000C1014 File Offset: 0x000BF414
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060019D2 RID: 6610 RVA: 0x000C101B File Offset: 0x000BF41B
	// Note: this type is marked as 'beforefieldinit'.
	static CritDamageBoostTalent()
	{
	}

	// Token: 0x060019D3 RID: 6611 RVA: 0x000C103B File Offset: 0x000BF43B
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == CritDamageBoostTalent._key;
	}

	// Token: 0x060019D4 RID: 6612 RVA: 0x000C104D File Offset: 0x000BF44D
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == CritDamageBoostTalent._key;
	}

	// Token: 0x04001988 RID: 6536
	private static string _key = "critdamageenhancementtalent";

	// Token: 0x04001989 RID: 6537
	public static double Rate = 0.2;

	// Token: 0x0400198A RID: 6538
	public string Id;

	// Token: 0x0400198B RID: 6539
	public string AdditionalKey;

	// Token: 0x0400198C RID: 6540
	public int CurrentLevel;

	// Token: 0x0400198D RID: 6541
	public static int MaxLevel = 5;

	// Token: 0x0400198E RID: 6542
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x0400198F RID: 6543
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
