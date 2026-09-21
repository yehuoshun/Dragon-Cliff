using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000780 RID: 1920
	[Serializable]
	public class ChubbyLadyStarHealerEnhanceData : ISpecialEffectDataLoad
	{
		// Token: 0x060038BC RID: 14524 RVA: 0x001729A1 File Offset: 0x00170DA1
		public ChubbyLadyStarHealerEnhanceData()
		{
		}

		// Token: 0x060038BD RID: 14525 RVA: 0x001729A9 File Offset: 0x00170DA9
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ChubbyLadyStarHealerEnhance;
		}

		// Token: 0x060038BE RID: 14526 RVA: 0x001729B0 File Offset: 0x00170DB0
		public Description GetDescription()
		{
			return this.GetSpecialEffectType().GetDescription();
		}

		// Token: 0x060038BF RID: 14527 RVA: 0x001729BD File Offset: 0x00170DBD
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038C0 RID: 14528 RVA: 0x001729C0 File Offset: 0x00170DC0
		public double GetEffectPowerValue()
		{
			return 0.0;
		}
	}
}
