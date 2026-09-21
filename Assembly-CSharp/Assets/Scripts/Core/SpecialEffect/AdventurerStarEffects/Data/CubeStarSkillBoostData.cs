using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000782 RID: 1922
	[Serializable]
	public class CubeStarSkillBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x060038C6 RID: 14534 RVA: 0x00172A5A File Offset: 0x00170E5A
		public CubeStarSkillBoostData()
		{
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x00172A62 File Offset: 0x00170E62
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.CubeStarSkillBoost;
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x00172A6C File Offset: 0x00170E6C
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{hit}", this.Extra.ToString());
			return description;
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x00172AAD File Offset: 0x00170EAD
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038CA RID: 14538 RVA: 0x00172AB0 File Offset: 0x00170EB0
		public double GetEffectPowerValue()
		{
			return (double)this.Extra;
		}

		// Token: 0x04002C4A RID: 11338
		public int Extra;
	}
}
