using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000421 RID: 1057
[Serializable]
public class TauntEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001D19 RID: 7449 RVA: 0x000C7554 File Offset: 0x000C5954
	public TauntEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x000C7592 File Offset: 0x000C5992
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TauntEnhancement;
	}

	// Token: 0x06001D1B RID: 7451 RVA: 0x000C7596 File Offset: 0x000C5996
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001D1C RID: 7452 RVA: 0x000C7599 File Offset: 0x000C5999
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001D1D RID: 7453 RVA: 0x000C75A1 File Offset: 0x000C59A1
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x000C75A9 File Offset: 0x000C59A9
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001D1F RID: 7455 RVA: 0x000C75B1 File Offset: 0x000C59B1
	public int GetMaxLevel()
	{
		return TauntEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x000C75B8 File Offset: 0x000C59B8
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001D21 RID: 7457 RVA: 0x000C75D0 File Offset: 0x000C59D0
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == TauntEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.TauntOnHit,
			ModificationType = ModificationType.Addition,
			Value = TauntEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = TauntEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001D22 RID: 7458 RVA: 0x000C764F File Offset: 0x000C5A4F
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001D23 RID: 7459 RVA: 0x000C7666 File Offset: 0x000C5A66
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == TauntEnhancementTalent._key);
	}

	// Token: 0x06001D24 RID: 7460 RVA: 0x000C7698 File Offset: 0x000C5A98
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001D25 RID: 7461 RVA: 0x000C769F File Offset: 0x000C5A9F
	// Note: this type is marked as 'beforefieldinit'.
	static TauntEnhancementTalent()
	{
	}

	// Token: 0x06001D26 RID: 7462 RVA: 0x000C76BF File Offset: 0x000C5ABF
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == TauntEnhancementTalent._key;
	}

	// Token: 0x06001D27 RID: 7463 RVA: 0x000C76D1 File Offset: 0x000C5AD1
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == TauntEnhancementTalent._key;
	}

	// Token: 0x04001AE6 RID: 6886
	private static string _key = "tauntenhancementtalent";

	// Token: 0x04001AE7 RID: 6887
	public static double Rate = 0.14;

	// Token: 0x04001AE8 RID: 6888
	public static int MaxLevel = 5;

	// Token: 0x04001AE9 RID: 6889
	public string Id;

	// Token: 0x04001AEA RID: 6890
	public string AdditionalKey;

	// Token: 0x04001AEB RID: 6891
	public int CurrentLevel;

	// Token: 0x04001AEC RID: 6892
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001AED RID: 6893
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
