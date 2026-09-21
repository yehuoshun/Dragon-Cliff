using System;
using System.Collections.Generic;

// Token: 0x02000AF4 RID: 2804
public class BlackMage : MinionUnitConfigurationBase
{
	// Token: 0x06004B72 RID: 19314 RVA: 0x001F11EA File Offset: 0x001EF5EA
	public BlackMage()
	{
	}

	// Token: 0x17000FED RID: 4077
	// (get) Token: 0x06004B73 RID: 19315 RVA: 0x001F11F2 File Offset: 0x001EF5F2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlackMage;
		}
	}

	// Token: 0x17000FEE RID: 4078
	// (get) Token: 0x06004B74 RID: 19316 RVA: 0x001F11F9 File Offset: 0x001EF5F9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004B75 RID: 19317 RVA: 0x001F11FC File Offset: 0x001EF5FC
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.Add(new ExtraTargetingData
		{
			Extra = 1,
			CandidateTypes = new List<TargetCandidateType>
			{
				TargetCandidateType.HostileAlive
			}
		});
		return original;
	}
}
