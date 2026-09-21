using System;
using System.Collections.Generic;

// Token: 0x020003DC RID: 988
[Serializable]
public class FrenzyStunTalent : TacticTalentBase
{
	// Token: 0x06001ABD RID: 6845 RVA: 0x000C2437 File Offset: 0x000C0837
	public FrenzyStunTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001ABE RID: 6846 RVA: 0x000C2441 File Offset: 0x000C0841
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FrenzyStunEnhancement;
	}

	// Token: 0x06001ABF RID: 6847 RVA: 0x000C2448 File Offset: 0x000C0848
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FrenzyStunEnhancementData
			{
				IsStar = false,
				Seconds = FrenzyStunTalent.Stun
			}
		};
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x000C247B File Offset: 0x000C087B
	// Note: this type is marked as 'beforefieldinit'.
	static FrenzyStunTalent()
	{
	}

	// Token: 0x040019F0 RID: 6640
	public static int Stun = 1;
}
