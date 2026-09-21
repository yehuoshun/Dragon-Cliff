using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200078A RID: 1930
	[Serializable]
	public class FireChargerStarElementData : ISpecialEffectDataLoad
	{
		// Token: 0x060038EF RID: 14575 RVA: 0x00172E2E File Offset: 0x0017122E
		public FireChargerStarElementData()
		{
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x00172E36 File Offset: 0x00171236
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FireChargerStarElement;
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x00172E3D File Offset: 0x0017123D
		public Description GetDescription()
		{
			return this.GetSpecialEffectType().GetDescription();
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x00172E4A File Offset: 0x0017124A
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x00172E4D File Offset: 0x0017124D
		public double GetEffectPowerValue()
		{
			return 0.0;
		}
	}
}
