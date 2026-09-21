using System;
using System.Collections.Generic;

// Token: 0x0200099A RID: 2458
[Serializable]
public class BanquetProcessor : TownEventProcessorBase
{
	// Token: 0x0600434C RID: 17228 RVA: 0x001B6FCE File Offset: 0x001B53CE
	public BanquetProcessor()
	{
	}

	// Token: 0x17000D57 RID: 3415
	// (get) Token: 0x0600434D RID: 17229 RVA: 0x001B6FD6 File Offset: 0x001B53D6
	public override TownEventType Type
	{
		get
		{
			return TownEventType.Banquet;
		}
	}

	// Token: 0x17000D58 RID: 3416
	// (get) Token: 0x0600434E RID: 17230 RVA: 0x001B6FDC File Offset: 0x001B53DC
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

	// Token: 0x17000D59 RID: 3417
	// (get) Token: 0x0600434F RID: 17231 RVA: 0x001B7006 File Offset: 0x001B5406
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D5A RID: 3418
	// (get) Token: 0x06004350 RID: 17232 RVA: 0x001B700A File Offset: 0x001B540A
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D5B RID: 3419
	// (get) Token: 0x06004351 RID: 17233 RVA: 0x001B700D File Offset: 0x001B540D
	public override int ActivePointsToExclusive
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000D5C RID: 3420
	// (get) Token: 0x06004352 RID: 17234 RVA: 0x001B7010 File Offset: 0x001B5410
	public override int RequiredDifficultyValue
	{
		get
		{
			return 70;
		}
	}

	// Token: 0x17000D5D RID: 3421
	// (get) Token: 0x06004353 RID: 17235 RVA: 0x001B7014 File Offset: 0x001B5414
	public override int RequiredPolicyPoint
	{
		get
		{
			return 40;
		}
	}

	// Token: 0x06004354 RID: 17236 RVA: 0x001B7018 File Offset: 0x001B5418
	public override void TownEventCompleted()
	{
		base.GenerateOrientedAdventurers(new List<UnitClassStyle>
		{
			UnitClassStyle.PhysicalKiller,
			UnitClassStyle.SpellKiller
		});
		double eventResultValue = base.GetEventResultValue(0.2, 1.2);
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(10, GameWorld.instance.PlayerProfile.GameDays, eventResultValue, AttributeType.CritDamage, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
