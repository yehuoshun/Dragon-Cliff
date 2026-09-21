using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000451 RID: 1105
public class DefaultAdventureResolver : AdventureResolverBase
{
	// Token: 0x06001F56 RID: 8022 RVA: 0x000DC258 File Offset: 0x000DA658
	public DefaultAdventureResolver()
	{
	}

	// Token: 0x06001F57 RID: 8023 RVA: 0x000DC260 File Offset: 0x000DA660
	public override bool CanBeResolved(AdventureStartParameter parameter)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords.Any((DungeonRecord d) => d.AdventureType == parameter.AdventureType);
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x000DC2A8 File Offset: 0x000DA6A8
	protected override Adventure ResolveLogic(AdventureStartParameter parameter)
	{
		DungeonRecord dungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		return Adventure.InitializeAdventureBaseOnLevel(parameter, parameter.AdventureType.GetAdventureLevelConfiguration(dungeonRecord.CurrentSelectedLevel), DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByDungeonLevel(dungeonRecord.CurrentSelectedLevel, parameter.AdventureType, GameWorld.instance.PlayerProfile.GetStarRating()));
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x000DC304 File Offset: 0x000DA704
	public override List<ISpecialEffectDataLoad> GetDungeonSpecialEffects(AdventureStartParameter parameter)
	{
		DungeonRecord dungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		return parameter.AdventureType.GetAdventureLevelConfiguration(dungeonRecord.CurrentSelectedLevel).DungeonEffects;
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x000DC33D File Offset: 0x000DA73D
	public override int ResolverPrecedenceValue()
	{
		return 0;
	}

	// Token: 0x02000D13 RID: 3347
	[CompilerGenerated]
	private sealed class <CanBeResolved>c__AnonStorey0
	{
		// Token: 0x060055EF RID: 21999 RVA: 0x000DC340 File Offset: 0x000DA740
		public <CanBeResolved>c__AnonStorey0()
		{
		}

		// Token: 0x060055F0 RID: 22000 RVA: 0x000DC348 File Offset: 0x000DA748
		internal bool <>m__0(DungeonRecord d)
		{
			return d.AdventureType == this.parameter.AdventureType;
		}

		// Token: 0x0400447A RID: 17530
		internal AdventureStartParameter parameter;
	}
}
