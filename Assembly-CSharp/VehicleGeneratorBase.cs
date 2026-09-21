using System;
using System.Collections.Generic;

// Token: 0x020009C5 RID: 2501
public abstract class VehicleGeneratorBase
{
	// Token: 0x0600445E RID: 17502 RVA: 0x001BAEAC File Offset: 0x001B92AC
	protected VehicleGeneratorBase()
	{
	}

	// Token: 0x17000DA4 RID: 3492
	// (get) Token: 0x0600445F RID: 17503
	public abstract VehicleType VehicleType { get; }

	// Token: 0x17000DA5 RID: 3493
	// (get) Token: 0x06004460 RID: 17504
	public abstract double RepairPerDurability { get; }

	// Token: 0x17000DA6 RID: 3494
	// (get) Token: 0x06004461 RID: 17505
	public abstract List<ResourceConsumptionRequirement> ProductionRequirements { get; }

	// Token: 0x06004462 RID: 17506 RVA: 0x001BAEB4 File Offset: 0x001B92B4
	public int GetRepairCost(Vehicle boat)
	{
		return (int)Math.Ceiling((boat.CurrentMaxDurability - boat.Durability) * this.RepairPerDurability);
	}

	// Token: 0x06004463 RID: 17507 RVA: 0x001BAED0 File Offset: 0x001B92D0
	public void Repair(Vehicle boat)
	{
		if (GameWorld.instance.PlayerProfile.CanAfford((double)this.GetRepairCost(boat)))
		{
			GameWorld.instance.PlayerProfile.SpendMoney((double)this.GetRepairCost(boat));
			double num = boat.CurrentMaxDurability - boat.Durability;
			double num2 = num * (1.0 - VehicleGeneratorBase.WearAndTearRate);
			double num3 = boat.Durability + num2;
			boat.Durability = num3;
			boat.CurrentMaxDurability = num3;
		}
	}

	// Token: 0x06004464 RID: 17508
	public abstract Vehicle Create();

	// Token: 0x06004465 RID: 17509 RVA: 0x001BAF47 File Offset: 0x001B9347
	// Note: this type is marked as 'beforefieldinit'.
	static VehicleGeneratorBase()
	{
	}

	// Token: 0x0400339A RID: 13210
	protected static double WearAndTearRate;
}
