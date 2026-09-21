using System;
using System.Collections.Generic;

// Token: 0x02000419 RID: 1049
[Serializable]
public class SwiftwindDamageTalent : TacticTalentBase
{
	// Token: 0x06001CCF RID: 7375 RVA: 0x000C482B File Offset: 0x000C2C2B
	public SwiftwindDamageTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CD0 RID: 7376 RVA: 0x000C4835 File Offset: 0x000C2C35
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SwiftWindDamageSwitchEnhancement;
	}

	// Token: 0x06001CD1 RID: 7377 RVA: 0x000C483C File Offset: 0x000C2C3C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SwiftWindDamageSwitchEnhancementData
			{
				IsStar = false,
				DamageRate = SwiftwindDamageTalent.DamageRate
			}
		};
	}

	// Token: 0x06001CD2 RID: 7378 RVA: 0x000C486F File Offset: 0x000C2C6F
	// Note: this type is marked as 'beforefieldinit'.
	static SwiftwindDamageTalent()
	{
	}

	// Token: 0x04001AC3 RID: 6851
	public static double DamageRate = 3.5;
}
