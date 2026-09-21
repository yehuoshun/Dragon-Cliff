using System;

// Token: 0x02000852 RID: 2130
[Serializable]
public class RespiteData : ISpecialEffectDataLoad
{
	// Token: 0x06003CD9 RID: 15577 RVA: 0x0017C1AB File Offset: 0x0017A5AB
	public RespiteData()
	{
	}

	// Token: 0x06003CDA RID: 15578 RVA: 0x0017C1B3 File Offset: 0x0017A5B3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Respite;
	}

	// Token: 0x06003CDB RID: 15579 RVA: 0x0017C1B8 File Offset: 0x0017A5B8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{arrogancetime}", this.ArrogancePunishmentTime.ToString()).Replace("{respitetime}", this.RespiteShieldTime.ToString()).Replace("{feartime}", this.FearTime.ToString()).ToString();
		return description;
	}

	// Token: 0x06003CDC RID: 15580 RVA: 0x0017C234 File Offset: 0x0017A634
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CDD RID: 15581 RVA: 0x0017C23C File Offset: 0x0017A63C
	public double GetEffectPowerValue()
	{
		return (double)this.FearTime;
	}

	// Token: 0x04002E74 RID: 11892
	public int ArrogancePunishmentTime;

	// Token: 0x04002E75 RID: 11893
	public int RespiteShieldTime;

	// Token: 0x04002E76 RID: 11894
	public int FearTime;

	// Token: 0x04002E77 RID: 11895
	public bool IsStar;
}
