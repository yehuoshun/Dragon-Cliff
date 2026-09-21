using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000450 RID: 1104
public class CustomDungeonHuntResolver : AdventureResolverBase
{
	// Token: 0x06001F50 RID: 8016 RVA: 0x000DC083 File Offset: 0x000DA483
	public CustomDungeonHuntResolver()
	{
	}

	// Token: 0x06001F51 RID: 8017 RVA: 0x000DC08B File Offset: 0x000DA48B
	public override bool CanBeResolved(AdventureStartParameter parameter)
	{
		return this.GetTheMostRelevantActiveCustomizedDungeonReq(parameter.AdventureType) != null;
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x000DC0A0 File Offset: 0x000DA4A0
	private CustomizedDungeonThroughRequirementLogic GetTheMostRelevantActiveCustomizedDungeonReq(AdventureType type)
	{
		if (GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords.Any((DungeonRecord r) => r.AdventureType == type))
		{
			DungeonRecord record = GameWorld.instance.PlayerProfile.GetDungeonRecord(type);
			CustomizedDungeonThroughRequirementLogic customizedDungeonThroughRequirementLogic = GameWorld.instance.PlayerProfile.GetQuestRequirements<CustomizedDungeonThroughRequirementLogic>(true).FirstOrDefault((CustomizedDungeonThroughRequirementLogic r) => !r.fullfilled && r.DungeonType == type && !r.IsTwistedTimeDungeon && r.Configuration.LevelNumber == record.CurrentSelectedLevel);
			if (customizedDungeonThroughRequirementLogic != null)
			{
				return customizedDungeonThroughRequirementLogic;
			}
		}
		return GameWorld.instance.PlayerProfile.GetQuestRequirements<CustomizedDungeonThroughRequirementLogic>(true).FirstOrDefault((CustomizedDungeonThroughRequirementLogic r) => !r.fullfilled && r.DungeonType == type && r.IsTwistedTimeDungeon);
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x000DC160 File Offset: 0x000DA560
	protected override Adventure ResolveLogic(AdventureStartParameter parameter)
	{
		CustomizedDungeonThroughRequirementLogic theMostRelevantActiveCustomizedDungeonReq = this.GetTheMostRelevantActiveCustomizedDungeonReq(parameter.AdventureType);
		return Adventure.InitializeAdventureBaseOnLevel(parameter, theMostRelevantActiveCustomizedDungeonReq.Configuration, DifficultyLevelMeasurement.GetDifficultyLevelMeasurementForDungeonRelated(theMostRelevantActiveCustomizedDungeonReq.DifficultyMeasurement));
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x000DC194 File Offset: 0x000DA594
	public override List<ISpecialEffectDataLoad> GetDungeonSpecialEffects(AdventureStartParameter parameter)
	{
		CustomizedDungeonThroughRequirementLogic theMostRelevantActiveCustomizedDungeonReq = this.GetTheMostRelevantActiveCustomizedDungeonReq(parameter.AdventureType);
		return theMostRelevantActiveCustomizedDungeonReq.Configuration.DungeonEffects;
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x000DC1B9 File Offset: 0x000DA5B9
	public override int ResolverPrecedenceValue()
	{
		return 50;
	}

	// Token: 0x02000D11 RID: 3345
	[CompilerGenerated]
	private sealed class <GetTheMostRelevantActiveCustomizedDungeonReq>c__AnonStorey0
	{
		// Token: 0x060055EA RID: 21994 RVA: 0x000DC1BD File Offset: 0x000DA5BD
		public <GetTheMostRelevantActiveCustomizedDungeonReq>c__AnonStorey0()
		{
		}

		// Token: 0x060055EB RID: 21995 RVA: 0x000DC1C5 File Offset: 0x000DA5C5
		internal bool <>m__0(DungeonRecord r)
		{
			return r.AdventureType == this.type;
		}

		// Token: 0x060055EC RID: 21996 RVA: 0x000DC1D5 File Offset: 0x000DA5D5
		internal bool <>m__1(CustomizedDungeonThroughRequirementLogic r)
		{
			return !r.fullfilled && r.DungeonType == this.type && r.IsTwistedTimeDungeon;
		}

		// Token: 0x04004477 RID: 17527
		internal AdventureType type;
	}

	// Token: 0x02000D12 RID: 3346
	[CompilerGenerated]
	private sealed class <GetTheMostRelevantActiveCustomizedDungeonReq>c__AnonStorey1
	{
		// Token: 0x060055ED RID: 21997 RVA: 0x000DC1FC File Offset: 0x000DA5FC
		public <GetTheMostRelevantActiveCustomizedDungeonReq>c__AnonStorey1()
		{
		}

		// Token: 0x060055EE RID: 21998 RVA: 0x000DC204 File Offset: 0x000DA604
		internal bool <>m__0(CustomizedDungeonThroughRequirementLogic r)
		{
			return !r.fullfilled && r.DungeonType == this.<>f__ref$0.type && !r.IsTwistedTimeDungeon && r.Configuration.LevelNumber == this.record.CurrentSelectedLevel;
		}

		// Token: 0x04004478 RID: 17528
		internal DungeonRecord record;

		// Token: 0x04004479 RID: 17529
		internal CustomDungeonHuntResolver.<GetTheMostRelevantActiveCustomizedDungeonReq>c__AnonStorey0 <>f__ref$0;
	}
}
