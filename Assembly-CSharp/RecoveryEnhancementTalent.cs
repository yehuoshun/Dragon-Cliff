using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class RecoveryEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001BBD RID: 7101 RVA: 0x000C3708 File Offset: 0x000C1B08
	public RecoveryEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BBE RID: 7102 RVA: 0x000C3746 File Offset: 0x000C1B46
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RecoveryEnhancement;
	}

	// Token: 0x06001BBF RID: 7103 RVA: 0x000C374A File Offset: 0x000C1B4A
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001BC0 RID: 7104 RVA: 0x000C374D File Offset: 0x000C1B4D
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BC1 RID: 7105 RVA: 0x000C3755 File Offset: 0x000C1B55
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x000C375D File Offset: 0x000C1B5D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BC3 RID: 7107 RVA: 0x000C3765 File Offset: 0x000C1B65
	public int GetMaxLevel()
	{
		return RecoveryEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001BC4 RID: 7108 RVA: 0x000C376C File Offset: 0x000C1B6C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001BC5 RID: 7109 RVA: 0x000C3784 File Offset: 0x000C1B84
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == RecoveryEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.BattleStartHeal,
			ModificationType = ModificationType.Addition,
			Value = RecoveryEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = RecoveryEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x000C3803 File Offset: 0x000C1C03
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x000C381A File Offset: 0x000C1C1A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == RecoveryEnhancementTalent._key);
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x000C384C File Offset: 0x000C1C4C
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001BC9 RID: 7113 RVA: 0x000C3853 File Offset: 0x000C1C53
	// Note: this type is marked as 'beforefieldinit'.
	static RecoveryEnhancementTalent()
	{
	}

	// Token: 0x06001BCA RID: 7114 RVA: 0x000C3873 File Offset: 0x000C1C73
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == RecoveryEnhancementTalent._key;
	}

	// Token: 0x06001BCB RID: 7115 RVA: 0x000C3885 File Offset: 0x000C1C85
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == RecoveryEnhancementTalent._key;
	}

	// Token: 0x04001A54 RID: 6740
	private static string _key = "recoveryenhancementtalent";

	// Token: 0x04001A55 RID: 6741
	public static double Rate = 0.04;

	// Token: 0x04001A56 RID: 6742
	public string Id;

	// Token: 0x04001A57 RID: 6743
	public string AdditionalKey;

	// Token: 0x04001A58 RID: 6744
	public int CurrentLevel;

	// Token: 0x04001A59 RID: 6745
	public static int MaxLevel = 5;

	// Token: 0x04001A5A RID: 6746
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001A5B RID: 6747
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
