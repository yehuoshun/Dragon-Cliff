using System;
using System.Collections.Generic;

// Token: 0x0200099E RID: 2462
[Serializable]
public class TeaPartyProcessor : TownEventProcessorBase
{
	// Token: 0x06004373 RID: 17267 RVA: 0x001B744F File Offset: 0x001B584F
	public TeaPartyProcessor()
	{
	}

	// Token: 0x17000D73 RID: 3443
	// (get) Token: 0x06004374 RID: 17268 RVA: 0x001B7457 File Offset: 0x001B5857
	public override TownEventType Type
	{
		get
		{
			return TownEventType.TeaParty;
		}
	}

	// Token: 0x17000D74 RID: 3444
	// (get) Token: 0x06004375 RID: 17269 RVA: 0x001B745C File Offset: 0x001B585C
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

	// Token: 0x17000D75 RID: 3445
	// (get) Token: 0x06004376 RID: 17270 RVA: 0x001B7486 File Offset: 0x001B5886
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D76 RID: 3446
	// (get) Token: 0x06004377 RID: 17271 RVA: 0x001B748A File Offset: 0x001B588A
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D77 RID: 3447
	// (get) Token: 0x06004378 RID: 17272 RVA: 0x001B748D File Offset: 0x001B588D
	public override int ActivePointsToExclusive
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000D78 RID: 3448
	// (get) Token: 0x06004379 RID: 17273 RVA: 0x001B7490 File Offset: 0x001B5890
	public override int RequiredDifficultyValue
	{
		get
		{
			return 70;
		}
	}

	// Token: 0x17000D79 RID: 3449
	// (get) Token: 0x0600437A RID: 17274 RVA: 0x001B7494 File Offset: 0x001B5894
	public override int RequiredPolicyPoint
	{
		get
		{
			return 40;
		}
	}

	// Token: 0x0600437B RID: 17275 RVA: 0x001B7498 File Offset: 0x001B5898
	public override void TownEventCompleted()
	{
		base.GenerateOrientedAdventurers(new List<UnitClassStyle>
		{
			UnitClassStyle.PhysicalSupporter,
			UnitClassStyle.SpellSupporter
		});
		double eventResultValue = base.GetEventResultValue(200.0, 3000.0);
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(10, GameWorld.instance.PlayerProfile.GameDays, eventResultValue, AttributeType.Allresistances, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
