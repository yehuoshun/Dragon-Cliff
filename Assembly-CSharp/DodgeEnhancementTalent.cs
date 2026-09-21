using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003C9 RID: 969
[Serializable]
public class DodgeEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001A0A RID: 6666 RVA: 0x000C142C File Offset: 0x000BF82C
	public DodgeEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A0B RID: 6667 RVA: 0x000C146A File Offset: 0x000BF86A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DodgeEnhancement;
	}

	// Token: 0x06001A0C RID: 6668 RVA: 0x000C146E File Offset: 0x000BF86E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001A0D RID: 6669 RVA: 0x000C1471 File Offset: 0x000BF871
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A0E RID: 6670 RVA: 0x000C1479 File Offset: 0x000BF879
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A0F RID: 6671 RVA: 0x000C1481 File Offset: 0x000BF881
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A10 RID: 6672 RVA: 0x000C1489 File Offset: 0x000BF889
	public int GetMaxLevel()
	{
		return DodgeEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001A11 RID: 6673 RVA: 0x000C1490 File Offset: 0x000BF890
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A12 RID: 6674 RVA: 0x000C14A8 File Offset: 0x000BF8A8
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == DodgeEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DodgeRateAdjustment,
			ModificationType = ModificationType.Addition,
			Value = DodgeEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = DodgeEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001A13 RID: 6675 RVA: 0x000C1527 File Offset: 0x000BF927
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001A14 RID: 6676 RVA: 0x000C153E File Offset: 0x000BF93E
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == DodgeEnhancementTalent._key);
	}

	// Token: 0x06001A15 RID: 6677 RVA: 0x000C1570 File Offset: 0x000BF970
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A16 RID: 6678 RVA: 0x000C1577 File Offset: 0x000BF977
	// Note: this type is marked as 'beforefieldinit'.
	static DodgeEnhancementTalent()
	{
	}

	// Token: 0x06001A17 RID: 6679 RVA: 0x000C1597 File Offset: 0x000BF997
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == DodgeEnhancementTalent._key;
	}

	// Token: 0x06001A18 RID: 6680 RVA: 0x000C15A9 File Offset: 0x000BF9A9
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == DodgeEnhancementTalent._key;
	}

	// Token: 0x040019A5 RID: 6565
	private static string _key = "dodgeenhancementtalent";

	// Token: 0x040019A6 RID: 6566
	public static double Rate = 0.02;

	// Token: 0x040019A7 RID: 6567
	public string Id;

	// Token: 0x040019A8 RID: 6568
	public string AdditionalKey;

	// Token: 0x040019A9 RID: 6569
	public int CurrentLevel;

	// Token: 0x040019AA RID: 6570
	public static int MaxLevel = 5;

	// Token: 0x040019AB RID: 6571
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x040019AC RID: 6572
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
