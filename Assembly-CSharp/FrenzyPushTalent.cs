using System;
using System.Collections.Generic;

// Token: 0x020003DB RID: 987
[Serializable]
public class FrenzyPushTalent : TacticTalentBase
{
	// Token: 0x06001AB9 RID: 6841 RVA: 0x000C23E3 File Offset: 0x000C07E3
	public FrenzyPushTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001ABA RID: 6842 RVA: 0x000C23ED File Offset: 0x000C07ED
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FrenzyPushEnhancemednt;
	}

	// Token: 0x06001ABB RID: 6843 RVA: 0x000C23F4 File Offset: 0x000C07F4
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FrenzyPushEnhancementData
			{
				IsStar = false,
				PushRate = FrenzyPushTalent.Push
			}
		};
	}

	// Token: 0x06001ABC RID: 6844 RVA: 0x000C2427 File Offset: 0x000C0827
	// Note: this type is marked as 'beforefieldinit'.
	static FrenzyPushTalent()
	{
	}

	// Token: 0x040019EF RID: 6639
	public static double Push = 0.04;
}
