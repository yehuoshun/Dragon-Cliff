using System;
using System.Collections.Generic;

// Token: 0x02000418 RID: 1048
[Serializable]
public class SwiftWindPushEnhancementTalent : TacticTalentBase
{
	// Token: 0x06001CCB RID: 7371 RVA: 0x000C47D7 File Offset: 0x000C2BD7
	public SwiftWindPushEnhancementTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CCC RID: 7372 RVA: 0x000C47E1 File Offset: 0x000C2BE1
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SwiftWindPushBoostEnhancement;
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x000C47E8 File Offset: 0x000C2BE8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SwiftWindPushBoostEnhancementData
			{
				IsStar = false,
				PushRate = SwiftWindPushEnhancementTalent.Pushrate
			}
		};
	}

	// Token: 0x06001CCE RID: 7374 RVA: 0x000C481B File Offset: 0x000C2C1B
	// Note: this type is marked as 'beforefieldinit'.
	static SwiftWindPushEnhancementTalent()
	{
	}

	// Token: 0x04001AC2 RID: 6850
	public static double Pushrate = 0.6;
}
