using System;
using System.Collections.Generic;

// Token: 0x020003C2 RID: 962
[Serializable]
public class CrashExtraHitTalent : TacticTalentBase
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x000C0E88 File Offset: 0x000BF288
	public CrashExtraHitTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x000C0E92 File Offset: 0x000BF292
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.CrashExtraHit;
	}

	// Token: 0x060019C4 RID: 6596 RVA: 0x000C0E98 File Offset: 0x000BF298
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CrashExtraHitData
			{
				IsStar = false,
				Extra = CrashExtraHitTalent.Extra
			}
		};
	}

	// Token: 0x060019C5 RID: 6597 RVA: 0x000C0ECB File Offset: 0x000BF2CB
	// Note: this type is marked as 'beforefieldinit'.
	static CrashExtraHitTalent()
	{
	}

	// Token: 0x04001987 RID: 6535
	public static int Extra = 1;
}
