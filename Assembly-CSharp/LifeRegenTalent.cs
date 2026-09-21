using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020003E9 RID: 1001
[Serializable]
public class LifeRegenTalent : IAdventurerTalent
{
	// Token: 0x06001B36 RID: 6966 RVA: 0x000C2C90 File Offset: 0x000C1090
	public LifeRegenTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x000C2CCE File Offset: 0x000C10CE
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.LifeRegen;
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x000C2CD2 File Offset: 0x000C10D2
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.First;
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x000C2CD5 File Offset: 0x000C10D5
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x000C2CDD File Offset: 0x000C10DD
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x000C2CE5 File Offset: 0x000C10E5
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x000C2CED File Offset: 0x000C10ED
	public int GetMaxLevel()
	{
		return LifeRegenTalent.MaxLevel;
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x000C2CF4 File Offset: 0x000C10F4
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
		this.UpdateData(profile);
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x000C2D0C File Offset: 0x000C110C
	private void UpdateData(AdventurerProfile profile)
	{
		if (this.CurrentLevel > 0)
		{
			if (!profile.SpecialEffects.OfType<LifeRegenData>().Any<LifeRegenData>())
			{
				profile.SpecialEffects.Add(new LifeRegenData
				{
					TriggeredInBattle = false
				});
			}
		}
		else if (profile.SpecialEffects.OfType<LifeRegenData>().Any<LifeRegenData>())
		{
			profile.SpecialEffects.RemoveAll((ISpecialEffectDataLoad sp) => sp is LifeRegenData);
		}
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x000C2D96 File Offset: 0x000C1196
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
		this.UpdateData(profile);
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x000C2DAD File Offset: 0x000C11AD
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
		this.UpdateData(profile);
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x000C2DBD File Offset: 0x000C11BD
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001B42 RID: 6978 RVA: 0x000C2DC4 File Offset: 0x000C11C4
	// Note: this type is marked as 'beforefieldinit'.
	static LifeRegenTalent()
	{
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x000C2DEF File Offset: 0x000C11EF
	[CompilerGenerated]
	private static bool <UpdateData>m__0(ISpecialEffectDataLoad sp)
	{
		return sp is LifeRegenData;
	}

	// Token: 0x04001A1E RID: 6686
	public string Id;

	// Token: 0x04001A1F RID: 6687
	public string AdditionalKey;

	// Token: 0x04001A20 RID: 6688
	public int CurrentLevel;

	// Token: 0x04001A21 RID: 6689
	public static int MaxLevel = 10;

	// Token: 0x04001A22 RID: 6690
	public static double MinimumLife = 0.3;

	// Token: 0x04001A23 RID: 6691
	public static int RegenSeconds = 3;

	// Token: 0x04001A24 RID: 6692
	public static double RegenRate = 0.02;

	// Token: 0x04001A25 RID: 6693
	[CompilerGenerated]
	private static Predicate<ISpecialEffectDataLoad> <>f__am$cache0;
}
