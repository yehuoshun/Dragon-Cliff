using System;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000A0F RID: 2575
public class GameObjectCreator : MonoBehaviour
{
	// Token: 0x06004689 RID: 18057 RVA: 0x001CEA14 File Offset: 0x001CCE14
	public GameObjectCreator()
	{
	}

	// Token: 0x0600468A RID: 18058 RVA: 0x001CEA1C File Offset: 0x001CCE1C
	public static GameObject CreateUiItem(NormalItem item, Transform parent)
	{
		GameObject gameObject = ObjectPoolManager.Instance.Spawn(PoolType.Item, Vector3.zero);
		gameObject.GetComponent<ItemController>().Init(item);
		gameObject.transform.SetParent(parent, false);
		return gameObject;
	}

	// Token: 0x0600468B RID: 18059 RVA: 0x001CEA54 File Offset: 0x001CCE54
	public static GameObject CreateEquipmentInfoDetails(AttributeModifier modifier, Transform parent)
	{
		EquipmentInfoDetails equipmentInfoDetails = UnityEngine.Object.Instantiate<EquipmentInfoDetails>(Resources.Load<EquipmentInfoDetails>(FilePath.GetEquipmentInfoDetails()));
		equipmentInfoDetails.gameObject.transform.SetParent(parent);
		equipmentInfoDetails.Init(modifier);
		return equipmentInfoDetails.gameObject;
	}

	// Token: 0x0600468C RID: 18060 RVA: 0x001CEA8F File Offset: 0x001CCE8F
	public static void DestroyUiItem(GameObject item)
	{
		ObjectPoolManager.Instance.Destroy(PoolType.Item, item);
	}

	// Token: 0x0600468D RID: 18061 RVA: 0x001CEAA0 File Offset: 0x001CCEA0
	public static GameObject CreateUiHero(AdventurerProfile adventurer, Transform parent)
	{
		AdventurerUIController adventurerUIController = UnityEngine.Object.Instantiate<AdventurerUIController>(Resources.Load<AdventurerUIController>(FilePath.GetUiHero(adventurer.UnitClass)));
		adventurerUIController.Init(adventurer, FixedAdventurerAnimation.Walk);
		adventurerUIController.GetComponent<AdventurerUIAnimation>().Init(FixedAdventurerAnimation.Walk);
		adventurerUIController.gameObject.transform.SetParent(parent, false);
		return adventurerUIController.gameObject;
	}
}
