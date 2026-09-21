using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000A03 RID: 2563
public static class EquipmentUtils
{
	// Token: 0x060045B0 RID: 17840 RVA: 0x001C2B4C File Offset: 0x001C0F4C
	public static List<HeroMenuEquipmentItem> UpdateEquipmentInfo(this IEquipmentControl control, List<Item> equipments)
	{
		Item equipment = equipments.FirstOrDefault((Item e) => e.SlotType == ItemType.Weapon);
		Item equipment2 = equipments.FirstOrDefault((Item e) => e.SlotType == ItemType.Armor);
		List<Item> list = (from e in equipments
		where e.SlotType == ItemType.Accessory
		select e).ToList<Item>();
		Item equipment3 = null;
		Item equipment4 = equipments.FirstOrDefault((Item e) => e.SlotType == ItemType.Scroll);
		Item equipment5 = equipments.FirstOrDefault((Item e) => e.SlotType == ItemType.Amulet);
		Item equipment6 = equipments.FirstOrDefault((Item e) => e.SlotType == ItemType.Device);
		if (list.Count > 0)
		{
			equipment3 = list[0];
		}
		return new List<HeroMenuEquipmentItem>
		{
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Weapon,
				Equipment = equipment
			},
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Armor,
				Equipment = equipment2
			},
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Accessory1,
				Equipment = equipment3
			},
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Scroll,
				Equipment = equipment4
			},
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Amulet,
				Equipment = equipment5
			},
			new HeroMenuEquipmentItem
			{
				SlotType = UiSlotType.Device,
				Equipment = equipment6
			}
		};
	}

	// Token: 0x060045B1 RID: 17841 RVA: 0x001C2D1B File Offset: 0x001C111B
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__0(Item e)
	{
		return e.SlotType == ItemType.Weapon;
	}

	// Token: 0x060045B2 RID: 17842 RVA: 0x001C2D26 File Offset: 0x001C1126
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__1(Item e)
	{
		return e.SlotType == ItemType.Armor;
	}

	// Token: 0x060045B3 RID: 17843 RVA: 0x001C2D31 File Offset: 0x001C1131
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__2(Item e)
	{
		return e.SlotType == ItemType.Accessory;
	}

	// Token: 0x060045B4 RID: 17844 RVA: 0x001C2D3C File Offset: 0x001C113C
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__3(Item e)
	{
		return e.SlotType == ItemType.Scroll;
	}

	// Token: 0x060045B5 RID: 17845 RVA: 0x001C2D47 File Offset: 0x001C1147
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__4(Item e)
	{
		return e.SlotType == ItemType.Amulet;
	}

	// Token: 0x060045B6 RID: 17846 RVA: 0x001C2D52 File Offset: 0x001C1152
	[CompilerGenerated]
	private static bool <UpdateEquipmentInfo>m__5(Item e)
	{
		return e.SlotType == ItemType.Device;
	}

	// Token: 0x040034FE RID: 13566
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x040034FF RID: 13567
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;

	// Token: 0x04003500 RID: 13568
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2;

	// Token: 0x04003501 RID: 13569
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache3;

	// Token: 0x04003502 RID: 13570
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache4;

	// Token: 0x04003503 RID: 13571
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache5;
}
