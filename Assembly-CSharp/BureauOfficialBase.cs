using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class BureauOfficialBase : ResidentBase
{
	// Token: 0x060025DE RID: 9694 RVA: 0x00111F27 File Offset: 0x00110327
	public BureauOfficialBase()
	{
	}

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x060025DF RID: 9695 RVA: 0x00111F3E File Offset: 0x0011033E
	public override ResidentType ResidentType
	{
		get
		{
			return this._residentType;
		}
	}

	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x060025E0 RID: 9696 RVA: 0x00111F46 File Offset: 0x00110346
	public override int ResidentRankParameter
	{
		get
		{
			return this._residentRankParameter;
		}
	}

	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x060025E1 RID: 9697 RVA: 0x00111F50 File Offset: 0x00110350
	public override List<JourneyContributeType> JourneyContributeTypes
	{
		get
		{
			return new List<JourneyContributeType>
			{
				JourneyContributeType.TradeSkill,
				JourneyContributeType.ResearchSkill
			};
		}
	}

	// Token: 0x060025E2 RID: 9698 RVA: 0x00111F74 File Offset: 0x00110374
	protected override void GenerateHappyEffect(Resident resident)
	{
		int numberOfDays = UnityEngine.Random.Range(1, 4);
		List<TownEventProcessorBase> list = (from e in GameWorld.instance.PlayerProfile.GetTownEventProcessors()
		where e.IsActive
		select e).ToList<TownEventProcessorBase>();
		if (list.Any<TownEventProcessorBase>())
		{
			TownEventProcessorBase townEventProcessorBase = list[UnityEngine.Random.Range(0, list.Count)];
			townEventProcessorBase.AddProcessDays(numberOfDays);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentPushedEventProgress, new ResidentPushEventProgressEvent
			{
				Resident = resident,
				Event = townEventProcessorBase
			});
		}
	}

	// Token: 0x060025E3 RID: 9699 RVA: 0x0011200C File Offset: 0x0011040C
	public override List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>
		{
			ProductionResidentEffect.CreateDifficultyRelatedEffect(correspondingDifficultyMeasurement, growthCoeffecient)
		};
	}

	// Token: 0x060025E4 RID: 9700 RVA: 0x0011202F File Offset: 0x0011042F
	[CompilerGenerated]
	private static bool <GenerateHappyEffect>m__0(TownEventProcessorBase e)
	{
		return e.IsActive;
	}

	// Token: 0x040020A6 RID: 8358
	private ResidentType _residentType = ResidentType.BureauOfficial;

	// Token: 0x040020A7 RID: 8359
	private int _residentRankParameter = 25;

	// Token: 0x040020A8 RID: 8360
	[CompilerGenerated]
	private static Func<TownEventProcessorBase, bool> <>f__am$cache0;
}
