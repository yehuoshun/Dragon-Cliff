using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009C4 RID: 2500
public class BoatLevelTwo : VehicleGeneratorBase
{
	// Token: 0x06004459 RID: 17497 RVA: 0x001BB2E7 File Offset: 0x001B96E7
	public BoatLevelTwo()
	{
	}

	// Token: 0x17000DA1 RID: 3489
	// (get) Token: 0x0600445A RID: 17498 RVA: 0x001BB2EF File Offset: 0x001B96EF
	public override VehicleType VehicleType
	{
		get
		{
			return VehicleType.ExplorationBoatLevelTwo;
		}
	}

	// Token: 0x17000DA2 RID: 3490
	// (get) Token: 0x0600445B RID: 17499 RVA: 0x001BB2F2 File Offset: 0x001B96F2
	public override double RepairPerDurability
	{
		get
		{
			return 3000.0;
		}
	}

	// Token: 0x17000DA3 RID: 3491
	// (get) Token: 0x0600445C RID: 17500 RVA: 0x001BB300 File Offset: 0x001B9700
	public override List<ResourceConsumptionRequirement> ProductionRequirements
	{
		get
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = 100000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.PracticePoints,
					AmountRequired = 100000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.RefinedOre,
					AmountRequired = 2000
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.RefinedLeather,
					AmountRequired = 2000
				}
			};
		}
	}

	// Token: 0x0600445D RID: 17501 RVA: 0x001BB3A0 File Offset: 0x001B97A0
	public override Vehicle Create()
	{
		int num = UnityEngine.Random.Range(35, 46);
		return new Vehicle
		{
			Level = 2,
			Type = VehicleType.ExplorationBoatLevelTwo,
			Id = Guid.NewGuid().ToString(),
			Travellers = new List<ITraveller>(),
			Stats = new List<VechileAttributeModifier>
			{
				new VechileAttributeModifier
				{
					AttributeType = VehicleAttributeType.Capacity,
					Value = 4.0,
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
					Value = 2.0,
					Key = string.Empty
				}
			},
			Durability = (double)num,
			CurrentMaxDurability = (double)num
		};
	}
}
