using System;
using System.Collections.Generic;

// Token: 0x0200048C RID: 1164
[Serializable]
public class EmbracedShieldStunTalent : TacticTalentBase
{
	// Token: 0x0600214A RID: 8522 RVA: 0x000E9B47 File Offset: 0x000E7F47
	public EmbracedShieldStunTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x000E9B51 File Offset: 0x000E7F51
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EmbracedStun;
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x000E9B58 File Offset: 0x000E7F58
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EmbracedShieldStunEnhancementData
			{
				IsStar = false,
				StunSeconds = EmbracedShieldStunTalent.Seconds
			}
		};
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x000E9B8B File Offset: 0x000E7F8B
	// Note: this type is marked as 'beforefieldinit'.
	static EmbracedShieldStunTalent()
	{
	}

	// Token: 0x04001D55 RID: 7509
	public static int Seconds = 3;
}
