using System;
using System.Collections.Generic;

// Token: 0x020009A1 RID: 2465
[Serializable]
public class TradeProcessor : TownEventProcessorBase
{
	// Token: 0x0600439A RID: 17306 RVA: 0x001B7507 File Offset: 0x001B5907
	public TradeProcessor()
	{
	}

	// Token: 0x17000D81 RID: 3457
	// (get) Token: 0x0600439B RID: 17307 RVA: 0x001B750F File Offset: 0x001B590F
	public override TownEventType Type
	{
		get
		{
			return TownEventType.Trade;
		}
	}

	// Token: 0x17000D82 RID: 3458
	// (get) Token: 0x0600439C RID: 17308 RVA: 0x001B7514 File Offset: 0x001B5914
	public override List<ResourceType> ResourceConsumptionTypes
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.PracticePoints
			};
		}
	}

	// Token: 0x17000D83 RID: 3459
	// (get) Token: 0x0600439D RID: 17309 RVA: 0x001B7533 File Offset: 0x001B5933
	public override int DaysRequired
	{
		get
		{
			return 10;
		}
	}

	// Token: 0x17000D84 RID: 3460
	// (get) Token: 0x0600439E RID: 17310 RVA: 0x001B7537 File Offset: 0x001B5937
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D85 RID: 3461
	// (get) Token: 0x0600439F RID: 17311 RVA: 0x001B753A File Offset: 0x001B593A
	public override int ActivePointsToExclusive
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x17000D86 RID: 3462
	// (get) Token: 0x060043A0 RID: 17312 RVA: 0x001B753D File Offset: 0x001B593D
	public override int RequiredDifficultyValue
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x17000D87 RID: 3463
	// (get) Token: 0x060043A1 RID: 17313 RVA: 0x001B7541 File Offset: 0x001B5941
	public override int RequiredPolicyPoint
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x060043A2 RID: 17314 RVA: 0x001B7548 File Offset: 0x001B5948
	public override void TownEventCompleted()
	{
		double eventResultValue = base.GetEventResultValue(0.5, 2.5);
		GearPriceBoostEffect effect = new GearPriceBoostEffect(8, GameWorld.instance.PlayerProfile.GameDays, eventResultValue);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
