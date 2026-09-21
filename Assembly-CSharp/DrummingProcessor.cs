using System;
using System.Collections.Generic;

// Token: 0x0200099B RID: 2459
[Serializable]
public class DrummingProcessor : TownEventProcessorBase
{
	// Token: 0x06004355 RID: 17237 RVA: 0x001B7084 File Offset: 0x001B5484
	public DrummingProcessor()
	{
	}

	// Token: 0x17000D5E RID: 3422
	// (get) Token: 0x06004356 RID: 17238 RVA: 0x001B708C File Offset: 0x001B548C
	public override TownEventType Type
	{
		get
		{
			return TownEventType.Drumming;
		}
	}

	// Token: 0x17000D5F RID: 3423
	// (get) Token: 0x06004357 RID: 17239 RVA: 0x001B7090 File Offset: 0x001B5490
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

	// Token: 0x17000D60 RID: 3424
	// (get) Token: 0x06004358 RID: 17240 RVA: 0x001B70BA File Offset: 0x001B54BA
	public override int DaysRequired
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x17000D61 RID: 3425
	// (get) Token: 0x06004359 RID: 17241 RVA: 0x001B70BE File Offset: 0x001B54BE
	public override int ActivePointsFrom
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x17000D62 RID: 3426
	// (get) Token: 0x0600435A RID: 17242 RVA: 0x001B70C1 File Offset: 0x001B54C1
	public override int ActivePointsToExclusive
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000D63 RID: 3427
	// (get) Token: 0x0600435B RID: 17243 RVA: 0x001B70C4 File Offset: 0x001B54C4
	public override int RequiredDifficultyValue
	{
		get
		{
			return 70;
		}
	}

	// Token: 0x17000D64 RID: 3428
	// (get) Token: 0x0600435C RID: 17244 RVA: 0x001B70C8 File Offset: 0x001B54C8
	public override int RequiredPolicyPoint
	{
		get
		{
			return 40;
		}
	}

	// Token: 0x0600435D RID: 17245 RVA: 0x001B70CC File Offset: 0x001B54CC
	public override void TownEventCompleted()
	{
		base.GenerateOrientedAdventurers(new List<UnitClassStyle>
		{
			UnitClassStyle.PhysicalWarrior,
			UnitClassStyle.SpellWarrior
		});
		double eventResultValue = base.GetEventResultValue(100.0, 1200.0);
		AdventurerAttributeBoostEffect effect = new AdventurerAttributeBoostEffect(10, GameWorld.instance.PlayerProfile.GameDays, eventResultValue, AttributeType.Agility, ModificationType.Addition);
		GameWorld.instance.PlayerProfile.AddTownEffect(effect, this);
	}
}
