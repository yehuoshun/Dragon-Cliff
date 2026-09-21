using System;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection
{
	// Token: 0x0200085A RID: 2138
	[Serializable]
	public class RuneEnergyCollectorData : ISpecialEffectDataLoad
	{
		// Token: 0x06003D04 RID: 15620 RVA: 0x0017C566 File Offset: 0x0017A966
		public RuneEnergyCollectorData()
		{
		}

		// Token: 0x06003D05 RID: 15621 RVA: 0x0017C56E File Offset: 0x0017A96E
		public SpecialEffectType GetSpecialEffectType()
		{
			return this.Type;
		}

		// Token: 0x06003D06 RID: 15622 RVA: 0x0017C578 File Offset: 0x0017A978
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{value}", (this.Type != SpecialEffectType.VitalEnergyRebirthCollection) ? this.Rate.ToString() : ((double)this.Rate * 0.2).ToString("F"));
			return description;
		}

		// Token: 0x06003D07 RID: 15623 RVA: 0x0017C5EC File Offset: 0x0017A9EC
		public bool IsStarEffect()
		{
			return false;
		}

		// Token: 0x06003D08 RID: 15624 RVA: 0x0017C5EF File Offset: 0x0017A9EF
		public double GetEffectPowerValue()
		{
			return (double)this.Rate;
		}

		// Token: 0x04002E89 RID: 11913
		public SpecialEffectType Type;

		// Token: 0x04002E8A RID: 11914
		public int Rate;
	}
}
