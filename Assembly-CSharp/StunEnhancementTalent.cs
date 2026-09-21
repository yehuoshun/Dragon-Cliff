using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000413 RID: 1043
[Serializable]
public class StunEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001CA4 RID: 7332 RVA: 0x000C44BC File Offset: 0x000C28BC
	public StunEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001CA5 RID: 7333 RVA: 0x000C44FA File Offset: 0x000C28FA
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.StunEnhancement;
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x000C44FE File Offset: 0x000C28FE
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001CA7 RID: 7335 RVA: 0x000C4501 File Offset: 0x000C2901
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001CA8 RID: 7336 RVA: 0x000C4509 File Offset: 0x000C2909
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001CA9 RID: 7337 RVA: 0x000C4511 File Offset: 0x000C2911
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001CAA RID: 7338 RVA: 0x000C4519 File Offset: 0x000C2919
	public int GetMaxLevel()
	{
		return StunEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001CAB RID: 7339 RVA: 0x000C4520 File Offset: 0x000C2920
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001CAC RID: 7340 RVA: 0x000C4538 File Offset: 0x000C2938
	private void UpdateAttributes(AdventurerProfile profile)
	{
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == StunEnhancementTalent._key);
		profile.Attributes.Add(new AttributeModifier
		{
			AttributeType = AttributeType.StunOnHit,
			ModificationType = ModificationType.Addition,
			Value = StunEnhancementTalent.Rate * (double)this.CurrentLevel,
			Key = StunEnhancementTalent._key,
			AttributeModifierType = AttributeModifierType.Gear
		});
	}

	// Token: 0x06001CAD RID: 7341 RVA: 0x000C45B7 File Offset: 0x000C29B7
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateAttributes(profile);
	}

	// Token: 0x06001CAE RID: 7342 RVA: 0x000C45CE File Offset: 0x000C29CE
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		profile.Attributes.RemoveAll((AttributeModifier a) => a.Key == StunEnhancementTalent._key);
	}

	// Token: 0x06001CAF RID: 7343 RVA: 0x000C4600 File Offset: 0x000C2A00
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001CB0 RID: 7344 RVA: 0x000C4607 File Offset: 0x000C2A07
	// Note: this type is marked as 'beforefieldinit'.
	static StunEnhancementTalent()
	{
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x000C4627 File Offset: 0x000C2A27
	[CompilerGenerated]
	private static bool <UpdateAttributes>m__0(AttributeModifier a)
	{
		return a.Key == StunEnhancementTalent._key;
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x000C4639 File Offset: 0x000C2A39
	[CompilerGenerated]
	private static bool <ResetLogic>m__1(AttributeModifier a)
	{
		return a.Key == StunEnhancementTalent._key;
	}

	// Token: 0x04001AB1 RID: 6833
	private static string _key = "stunenhancementtalent";

	// Token: 0x04001AB2 RID: 6834
	public static double Rate = 0.05;

	// Token: 0x04001AB3 RID: 6835
	public string Id;

	// Token: 0x04001AB4 RID: 6836
	public string AdditionalKey;

	// Token: 0x04001AB5 RID: 6837
	public int CurrentLevel;

	// Token: 0x04001AB6 RID: 6838
	public static int MaxLevel = 5;

	// Token: 0x04001AB7 RID: 6839
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache0;

	// Token: 0x04001AB8 RID: 6840
	[CompilerGenerated]
	private static Predicate<AttributeModifier> <>f__am$cache1;
}
