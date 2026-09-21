using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000797 RID: 1943
	[Serializable]
	public class StreetManStarHitBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x06003932 RID: 14642 RVA: 0x001733D2 File Offset: 0x001717D2
		public StreetManStarHitBoostData()
		{
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x001733DA File Offset: 0x001717DA
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.StreetManStarHitBoost;
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x001733E4 File Offset: 0x001717E4
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{hit}", this.Extra.ToString());
			return description;
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x00173425 File Offset: 0x00171825
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003936 RID: 14646 RVA: 0x00173428 File Offset: 0x00171828
		public double GetEffectPowerValue()
		{
			return (double)this.Extra;
		}

		// Token: 0x04002C68 RID: 11368
		public int Extra;
	}
}
