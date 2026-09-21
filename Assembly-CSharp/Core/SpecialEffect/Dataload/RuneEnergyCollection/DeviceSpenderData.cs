using System;
using System.Collections;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection
{
	// Token: 0x02000859 RID: 2137
	[Serializable]
	public abstract class DeviceSpenderData : ISpecialEffectDataLoad
	{
		// Token: 0x06003CFC RID: 15612 RVA: 0x0017C55B File Offset: 0x0017A95B
		protected DeviceSpenderData()
		{
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06003CFD RID: 15613
		public abstract RunePowerType EnergyType { get; }

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06003CFE RID: 15614
		public abstract int Cost { get; }

		// Token: 0x06003CFF RID: 15615
		public abstract SpecialEffectType GetSpecialEffectType();

		// Token: 0x06003D00 RID: 15616
		public abstract Description GetDescription();

		// Token: 0x06003D01 RID: 15617 RVA: 0x0017C563 File Offset: 0x0017A963
		public bool IsStarEffect()
		{
			return false;
		}

		// Token: 0x06003D02 RID: 15618
		public abstract double GetEffectPowerValue();

		// Token: 0x06003D03 RID: 15619
		public abstract IEnumerable Process(AdventurerBattleUnit wearer);
	}
}
