using System;
using System.Collections.Generic;

// Token: 0x020003DE RID: 990
[Serializable]
public class GhostlySmokeConfusionTalent : TacticTalentBase
{
	// Token: 0x06001AD0 RID: 6864 RVA: 0x000C260F File Offset: 0x000C0A0F
	public GhostlySmokeConfusionTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AD1 RID: 6865 RVA: 0x000C2619 File Offset: 0x000C0A19
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.GhostlySmokeConfusionEnhancement;
	}

	// Token: 0x06001AD2 RID: 6866 RVA: 0x000C2620 File Offset: 0x000C0A20
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GhostlySmokeConfusionEnhancementData
			{
				IsStar = false,
				Chance = GhostlySmokeConfusionTalent.Chance,
				Time = GhostlySmokeConfusionTalent.Seconds
			}
		};
	}

	// Token: 0x06001AD3 RID: 6867 RVA: 0x000C265E File Offset: 0x000C0A5E
	// Note: this type is marked as 'beforefieldinit'.
	static GhostlySmokeConfusionTalent()
	{
	}

	// Token: 0x040019F9 RID: 6649
	public static double Chance = 1.0;

	// Token: 0x040019FA RID: 6650
	public static int Seconds = 1;
}
