using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009C2 RID: 2498
public class BoatLevelOne : VehicleGeneratorBase
{
	// Token: 0x0600444F RID: 17487 RVA: 0x001BAF49 File Offset: 0x001B9349
	public BoatLevelOne()
	{
	}

	// Token: 0x17000D9B RID: 3483
	// (get) Token: 0x06004450 RID: 17488 RVA: 0x001BAF51 File Offset: 0x001B9351
	public override VehicleType VehicleType
	{
		get
		{
			return VehicleType.ExplorationBoatLevelOne;
		}
	}

	// Token: 0x17000D9C RID: 3484
	// (get) Token: 0x06004451 RID: 17489 RVA: 0x001BAF54 File Offset: 0x001B9354
	public override double RepairPerDurability
	{
		get
		{
			return 1500.0;
		}
	}

	// Token: 0x17000D9D RID: 3485
	// (get) Token: 0x06004452 RID: 17490 RVA: 0x001BAF60 File Offset: 0x001B9360
	public override List<ResourceConsumptionRequirement> ProductionRequirements
	{
		get
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = 50000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Leather,
					AmountRequired = 1000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Ore,
					AmountRequired = 1000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.PracticePoints,
					AmountRequired = 50000
				}
			};
		}
	}

	// Token: 0x06004453 RID: 17491 RVA: 0x001BB000 File Offset: 0x001B9400
	public override Vehicle Create()
	{
		int num = UnityEngine.Random.Range(30, 36);
		return new Vehicle
		{
			Level = 1,
			Type = VehicleType.ExplorationBoatLevelOne,
			Id = Guid.NewGuid().ToString(),
			Travellers = new List<ITraveller>(),
			Stats = new List<VechileAttributeModifier>
			{
				new VechileAttributeModifier
				{
					AttributeType = VehicleAttributeType.Capacity,
					Value = 3.0,
					Key = string.Empty
				},
				new VechileAttributeModifier
				{
					AttributeType = VehicleAttributeType.Life,
					Value = (double)UnityEngine.Random.Range(20, 26),
					Key = string.Empty
				},
				new VechileAttributeModifier
				{
					AttributeType = VehicleAttributeType.Speed,
					Value = 1.0,
					Key = string.Empty
				}
			},
			Durability = (double)num,
			CurrentMaxDurability = (double)num
		};
	}
}
