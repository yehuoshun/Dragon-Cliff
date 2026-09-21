using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000790 RID: 1936
	[Serializable]
	public class NightBladeStarHealReductionBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x0600390D RID: 14605 RVA: 0x00173066 File Offset: 0x00171466
		public NightBladeStarHealReductionBoostData()
		{
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x0017306E File Offset: 0x0017146E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.NightbladeStarHealReduceBoost;
		}

		// Token: 0x0600390F RID: 14607 RVA: 0x00173075 File Offset: 0x00171475
		public Description GetDescription()
		{
			return this.GetSpecialEffectType().GetDescription();
		}

		// Token: 0x06003910 RID: 14608 RVA: 0x00173082 File Offset: 0x00171482
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x00173085 File Offset: 0x00171485
		public double GetEffectPowerValue()
		{
			return 1.0;
		}
	}
}
