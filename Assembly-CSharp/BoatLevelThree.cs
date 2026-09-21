using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009C3 RID: 2499
public class BoatLevelThree : VehicleGeneratorBase
{
	// Token: 0x06004454 RID: 17492 RVA: 0x001BB107 File Offset: 0x001B9507
	public BoatLevelThree()
	{
	}

	// Token: 0x17000D9E RID: 3486
	// (get) Token: 0x06004455 RID: 17493 RVA: 0x001BB10F File Offset: 0x001B950F
	public override VehicleType VehicleType
	{
		get
		{
			return VehicleType.ExplorationBoatLevelThree;
		}
	}

	// Token: 0x17000D9F RID: 3487
	// (get) Token: 0x06004456 RID: 17494 RVA: 0x001BB112 File Offset: 0x001B9512
	public override double RepairPerDurability
	{
		get
		{
			return 5000.0;
		}
	}

	// Token: 0x17000DA0 RID: 3488
	// (get) Token: 0x06004457 RID: 17495 RVA: 0x001BB120 File Offset: 0x001B9520
	public override List<ResourceConsumptionRequirement> ProductionRequirements
	{
		get
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.PracticePoints,
					AmountRequired = 200000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.RefinedOre,
					AmountRequired = 3500
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.RefinedLeather,
					AmountRequired = 3500
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.BookFragments,
					AmountRequired = 100
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.FragmentOfDemon,
					AmountRequired = 10
				}
			};
		}
	}

	// Token: 0x06004458 RID: 17496 RVA: 0x001BB1E0 File Offset: 0x001B95E0
	public override Vehicle Create()
	{
		int num = UnityEngine.Random.Range(40, 53);
		return new Vehicle
		{
			Level = 3,
			Type = VehicleType.ExplorationBoatLevelThree,
			Id = Guid.NewGuid().ToString(),
			Travellers = new List<ITraveller>(),
			Stats = new List<VechileAttributeModifier>
			{
				new VechileAttributeModifier
				{
					AttributeType = VehicleAttributeType.Capacity,
					Value = 5.0,
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
					Value = 3.0,
					Key = string.Empty
				}
			},
			Durability = (double)num,
			CurrentMaxDurability = (double)num
		};
	}
}
