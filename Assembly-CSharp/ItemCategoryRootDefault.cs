using System;
using System.Collections.Generic;

// Token: 0x020005F2 RID: 1522
public abstract class ItemCategoryRootDefault
{
	// Token: 0x060029EE RID: 10734 RVA: 0x0011C79A File Offset: 0x0011AB9A
	protected ItemCategoryRootDefault()
	{
	}

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x060029EF RID: 10735
	public abstract ResourceCategory Category { get; }

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x060029F0 RID: 10736
	public abstract List<AttributePotentialDescriptor> Descriptors { get; }

	// Token: 0x060029F1 RID: 10737
	public abstract List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber);

	// Token: 0x060029F2 RID: 10738
	public abstract List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber);

	// Token: 0x060029F3 RID: 10739 RVA: 0x0011C7A4 File Offset: 0x0011ABA4
	public List<ResourceConsumptionRequirement> GetRequirements(int itemTierNumber)
	{
		List<ResourceConsumptionRequirement> list = new List<ResourceConsumptionRequirement>();
		if (itemTierNumber <= 35)
		{
			if (this.Category.IsWeapon())
			{
				int amountRequired = 20 + itemTierNumber * 10;
				list.AddRange(new List<ResourceConsumptionRequirement>
				{
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.Ore,
						AmountRequired = amountRequired
					}
				});
			}
			if (this.Category.IsArmor())
			{
				int amountRequired2 = 20 + itemTierNumber * 10;
				list.AddRange(new List<ResourceConsumptionRequirement>
				{
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.Leather,
						AmountRequired = amountRequired2
					}
				});
			}
		}
		else
		{
			if (this.Category.IsWeapon())
			{
				int num = 12 + (itemTierNumber - 35) * 16;
				if (itemTierNumber >= 36)
				{
					num += (itemTierNumber - 36) * 15;
				}
				if (itemTierNumber > 50)
				{
					num += (itemTierNumber - 50) * 25;
				}
				list.AddRange(new List<ResourceConsumptionRequirement>
				{
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.RefinedOre,
						AmountRequired = num
					}
				});
			}
			if (this.Category.IsArmor())
			{
				int num2 = 12 + (itemTierNumber - 35) * 16;
				if (itemTierNumber >= 36)
				{
					num2 += (itemTierNumber - 36) * 15;
				}
				if (itemTierNumber > 50)
				{
					num2 += (itemTierNumber - 50) * 25;
				}
				list.AddRange(new List<ResourceConsumptionRequirement>
				{
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.RefinedLeather,
						AmountRequired = num2
					}
				});
			}
			if (itemTierNumber > 40)
			{
				list.Add(new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.FragmentOfDemon,
					AmountRequired = (int)Math.Ceiling((double)(itemTierNumber - 40) / 5.0)
				});
			}
		}
		return list;
	}
}
