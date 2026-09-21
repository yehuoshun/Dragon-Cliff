using System;
using System.Collections.Generic;

// Token: 0x02000999 RID: 2457
[Serializable]
public class ArmoryResearchProcessor : TownEventProcessorBase
{
	// Token: 0x06004343 RID: 17219 RVA: 0x001B6F31 File Offset: 0x001B5331
	public ArmoryResearchProcessor()
	{
	}

	// Token: 0x17000D50 RID: 3408
	// (get) Token: 0x06004344 RID: 17220 RVA: 0x001B6F39 File Offset: 0x001B5339
	public override TownEventType Type
	{
		get
		{
			return TownEventType.ArmoryResearch;
		}
	}

	// Token: 0x17000D51 RID: 3409
	// (get) Token: 0x06004345 RID: 17221 RVA: 0x001B6F3C File Offset: 0x001B533C
	public override List<ResourceType> ResourceConsumptionTypes
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.Money,
				ResourceType.PracticePoints
			};
		}
	}

	// Token: 0x17000D52 RID: 3410
	// (get) Token: 0x06004346 RID: 17222 RVA: 0x001B6F66 File Offset: 0x001B5366
	public override int DaysRequired
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x17000D53 RID: 3411
	// (get) Token: 0x06004347 RID: 17223 RVA: 0x001B6F6A File Offset: 0x001B536A
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D54 RID: 3412
	// (get) Token: 0x06004348 RID: 17224 RVA: 0x001B6F6D File Offset: 0x001B536D
	public override int ActivePointsToExclusive
	{
		get
		{
			return 7;
		}
	}

	// Token: 0x17000D55 RID: 3413
	// (get) Token: 0x06004349 RID: 17225 RVA: 0x001B6F70 File Offset: 0x001B5370
	public override int RequiredDifficultyValue
	{
		get
		{
			return 50;
		}
	}

	// Token: 0x17000D56 RID: 3414
	// (get) Token: 0x0600434A RID: 17226 RVA: 0x001B6F74 File Offset: 0x001B5374
	public override int RequiredPolicyPoint
	{
		get
		{
			return 60;
		}
	}

	// Token: 0x0600434B RID: 17227 RVA: 0x001B6F78 File Offset: 0x001B5378
	public override void TownEventCompleted()
	{
		int numberOfTriggersLeft = 3 + (int)Math.Round(base.GetEventHappinessRatio() * 9.0, MidpointRounding.AwayFromZero);
		ArmoryMasteryEffect effect = new ArmoryMasteryEffect(new int?(60), GameWorld.instance.PlayerProfile.GameDays, 2, numberOfTriggersLeft);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
