using System;
using System.Collections.Generic;

// Token: 0x02000AF2 RID: 2802
public class EndlessDungeonMinionConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004B6A RID: 19306 RVA: 0x001F118B File Offset: 0x001EF58B
	public EndlessDungeonMinionConfiguration(UnitClass correspondingUnitClass, UnitClassStyle correspondingClassStyle, List<ISpecialEffectDataLoad> additionalSpecialEffects, OutputType outputType)
	{
		this._correspondingUnitClass = correspondingUnitClass;
		this._correspondingClassStyle = correspondingClassStyle;
		this._additionalSpecialEffects = additionalSpecialEffects;
		this._outputType = outputType;
	}

	// Token: 0x17000FE9 RID: 4073
	// (get) Token: 0x06004B6B RID: 19307 RVA: 0x001F11B0 File Offset: 0x001EF5B0
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000FEA RID: 4074
	// (get) Token: 0x06004B6C RID: 19308 RVA: 0x001F11B8 File Offset: 0x001EF5B8
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x06004B6D RID: 19309 RVA: 0x001F11C0 File Offset: 0x001EF5C0
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return this._outputType;
	}

	// Token: 0x06004B6E RID: 19310 RVA: 0x001F11C8 File Offset: 0x001EF5C8
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(this._additionalSpecialEffects);
		return original;
	}

	// Token: 0x04003ABC RID: 15036
	private UnitClass _correspondingUnitClass;

	// Token: 0x04003ABD RID: 15037
	private UnitClassStyle _correspondingClassStyle;

	// Token: 0x04003ABE RID: 15038
	private List<ISpecialEffectDataLoad> _additionalSpecialEffects;

	// Token: 0x04003ABF RID: 15039
	private OutputType _outputType;
}
