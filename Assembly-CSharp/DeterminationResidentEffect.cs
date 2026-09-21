using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public class DeterminationResidentEffect : IResidentEffect
{
	// Token: 0x06002666 RID: 9830 RVA: 0x0011324E File Offset: 0x0011164E
	public DeterminationResidentEffect()
	{
	}

	// Token: 0x170002E1 RID: 737
	// (get) Token: 0x06002667 RID: 9831 RVA: 0x00113256 File Offset: 0x00111656
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Determination;
		}
	}

	// Token: 0x06002668 RID: 9832 RVA: 0x0011325A File Offset: 0x0011165A
	public bool IsUnique()
	{
		return true;
	}

	// Token: 0x06002669 RID: 9833 RVA: 0x0011325D File Offset: 0x0011165D
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x0600266A RID: 9834 RVA: 0x0011325F File Offset: 0x0011165F
	public static IResidentEffect CreateDifficultyRelatedEffect()
	{
		return new DeterminationResidentEffect();
	}

	// Token: 0x0600266B RID: 9835 RVA: 0x00113266 File Offset: 0x00111666
	// Note: this type is marked as 'beforefieldinit'.
	static DeterminationResidentEffect()
	{
	}

	// Token: 0x040020DE RID: 8414
	public static double Rate = 0.15;
}
