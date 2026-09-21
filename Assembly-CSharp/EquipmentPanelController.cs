using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200026B RID: 619
public class EquipmentPanelController : MonoBehaviour
{
	// Token: 0x06000FFC RID: 4092 RVA: 0x00096C42 File Offset: 0x00095042
	public EquipmentPanelController()
	{
	}

	// Token: 0x06000FFD RID: 4093 RVA: 0x00096C4C File Offset: 0x0009504C
	public void Init(AdventurerProfile adventurer)
	{
		this.Reset();
		AdventurerUIAnimation component = GameObjectCreator.CreateUiHero(adventurer, this.HeroContainer).GetComponent<AdventurerUIAnimation>();
		UnityEngine.Object.Destroy(component.GetComponent<Button>());
		UnityEngine.Object.Destroy(component.GetComponent<AdventurerUIController>());
		this.HeroName.text = adventurer.GetUnitName();
		this.UpdateEquipment(adventurer);
	}

	// Token: 0x06000FFE RID: 4094 RVA: 0x00096CA0 File Offset: 0x000950A0
	public void UpdateEquipment(AdventurerProfile adventurer)
	{
		List<Item> equipments = adventurer.GetEquipments();
		Item item = equipments.FirstOrDefault((Item i) => i.SlotType == ItemType.Weapon);
		Item item2 = equipments.FirstOrDefault((Item i) => i.SlotType == ItemType.Armor);
		Item item3 = equipments.FirstOrDefault((Item i) => i.SlotType == ItemType.Accessory);
		if (item != null)
		{
			this.Weapon.Init(new NormalItem
			{
				Id = item.Id,
				ResourceType = item.Type,
				Item = item,
				Price = item.GetPrice(),
				ItemGrade = item.ItemGrade
			});
		}
		else
		{
			this.Weapon.SetDefaultImage(ItemType.Weapon);
		}
		if (item2 != null)
		{
			this.Armor.Init(new NormalItem
			{
				Id = item2.Id,
				ResourceType = item2.Type,
				Item = item2,
				Price = item2.GetPrice(),
				ItemGrade = item2.ItemGrade
			});
		}
		else
		{
			this.Armor.SetDefaultImage(ItemType.Armor);
		}
		if (item3 != null)
		{
			this.Accessory.Init(new NormalItem
			{
				Id = item3.Id,
				ResourceType = item3.Type,
				Item = item3,
				Price = item3.GetPrice(),
				ItemGrade = item3.ItemGrade
			});
		}
		else
		{
			this.Accessory.SetDefaultImage(ItemType.Accessory);
		}
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x00096E55 File Offset: 0x00095255
	public void EquipWeapon()
	{
	}

	// Token: 0x06001000 RID: 4096 RVA: 0x00096E57 File Offset: 0x00095257
	public void EquipArmor()
	{
	}

	// Token: 0x06001001 RID: 4097 RVA: 0x00096E59 File Offset: 0x00095259
	public void EquipAccessory()
	{
	}

	// Token: 0x06001002 RID: 4098 RVA: 0x00096E5C File Offset: 0x0009525C
	public void DisrobeWeapon()
	{
		if (this.Weapon.NormalItem != null)
		{
			TownManager.Instance.Ui.HeroMenu.SelectedHero.AdventurerProfile.Disrobe(this.Weapon.NormalItem.Item, true);
			this.Weapon.SetDefaultImage(ItemType.Weapon);
		}
	}

	// Token: 0x06001003 RID: 4099 RVA: 0x00096EB4 File Offset: 0x000952B4
	public void DisrobeArmor()
	{
		if (this.Armor.NormalItem != null)
		{
			TownManager.Instance.Ui.HeroMenu.SelectedHero.AdventurerProfile.Disrobe(this.Armor.NormalItem.Item, true);
			this.Armor.SetDefaultImage(ItemType.Armor);
		}
	}

	// Token: 0x06001004 RID: 4100 RVA: 0x00096F0C File Offset: 0x0009530C
	public void DisrobeAccessory()
	{
		if (this.Accessory.NormalItem != null)
		{
			TownManager.Instance.Ui.HeroMenu.SelectedHero.AdventurerProfile.Disrobe(this.Accessory.NormalItem.Item, true);
			this.Accessory.SetDefaultImage(ItemType.Accessory);
		}
	}

	// Token: 0x06001005 RID: 4101 RVA: 0x00096F64 File Offset: 0x00095364
	private void Reset()
	{
		IEnumerator enumerator = this.HeroContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06001006 RID: 4102 RVA: 0x00096FD0 File Offset: 0x000953D0
	[CompilerGenerated]
	private static bool <UpdateEquipment>m__0(Item i)
	{
		return i.SlotType == ItemType.Weapon;
	}

	// Token: 0x06001007 RID: 4103 RVA: 0x00096FDB File Offset: 0x000953DB
	[CompilerGenerated]
	private static bool <UpdateEquipment>m__1(Item i)
	{
		return i.SlotType == ItemType.Armor;
	}

	// Token: 0x06001008 RID: 4104 RVA: 0x00096FE6 File Offset: 0x000953E6
	[CompilerGenerated]
	private static bool <UpdateEquipment>m__2(Item i)
	{
		return i.SlotType == ItemType.Accessory;
	}

	// Token: 0x0400113F RID: 4415
	public Transform HeroContainer;

	// Token: 0x04001140 RID: 4416
	public Text HeroName;

	// Token: 0x04001141 RID: 4417
	public ItemController Weapon;

	// Token: 0x04001142 RID: 4418
	public ItemController Armor;

	// Token: 0x04001143 RID: 4419
	public ItemController Accessory;

	// Token: 0x04001144 RID: 4420
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04001145 RID: 4421
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;

	// Token: 0x04001146 RID: 4422
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2;
}
