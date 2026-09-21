using System;
using System.Collections.Generic;

// Token: 0x0200099C RID: 2460
[Serializable]
public class MeditationProcessor : TownEventProcessorBase
{
	// Token: 0x0600435E RID: 17246 RVA: 0x001B7138 File Offset: 0x001B5538
	public MeditationProcessor()
	{
	}

	// Token: 0x17000D65 RID: 3429
	// (get) Token: 0x0600435F RID: 17247 RVA: 0x001B7140 File Offset: 0x001B5540
	public override TownEventType Type
	{
		get
		{
			return TownEventType.Meditation;
		}
	}

	// Token: 0x17000D66 RID: 3430
	// (get) Token: 0x06004360 RID: 17248 RVA: 0x001B7144 File Offset: 0x001B5544
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

	// Token: 0x17000D67 RID: 3431
	// (get) Token: 0x06004361 RID: 17249 RVA: 0x001B716E File Offset: 0x001B556E
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D68 RID: 3432
	// (get) Token: 0x06004362 RID: 17250 RVA: 0x001B7172 File Offset: 0x001B5572
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D69 RID: 3433
	// (get) Token: 0x06004363 RID: 17251 RVA: 0x001B7175 File Offset: 0x001B5575
	public override int ActivePointsToExclusive
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000D6A RID: 3434
	// (get) Token: 0x06004364 RID: 17252 RVA: 0x001B7178 File Offset: 0x001B5578
	public override int RequiredDifficultyValue
	{
		get
		{
			return 70;
		}
	}

	// Token: 0x17000D6B RID: 3435
	// (get) Token: 0x06004365 RID: 17253 RVA: 0x001B717C File Offset: 0x001B557C
	public override int RequiredPolicyPoint
	{
		get
		{
			return 40;
		}
	}

	// Token: 0x06004366 RID: 17254 RVA: 0x001B7180 File Offset: 0x001B5580
	public override void TownEventCompleted()
	{
		base.GenerateOrientedAdventurers(new List<UnitClassStyle>
		{
			UnitClassStyle.Healer,
			UnitClassStyle.SpellDefender,
			UnitClassStyle.PhysicalDefender,
			UnitClassStyle.Protector
		});
		double eventResultValue = base.GetEventResultValue(200.0, 2000.0);
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(10, GameWorld.instance.PlayerProfile.GameDays, eventResultValue, AttributeType.Resilience, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
