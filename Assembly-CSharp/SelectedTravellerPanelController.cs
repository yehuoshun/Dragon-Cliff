using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002AA RID: 682
public class SelectedTravellerPanelController : MonoBehaviour
{
	// Token: 0x0600124F RID: 4687 RVA: 0x0009DC16 File Offset: 0x0009C016
	public SelectedTravellerPanelController()
	{
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x0009DC20 File Offset: 0x0009C020
	public void Init(Vehicle vehicle)
	{
		IEnumerator enumerator = this.TravellerContainer.GetEnumerator();
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
		foreach (GameObject gameObject in this.Slots)
		{
			gameObject.SetActive(false);
		}
		VechileAttributeModifier vechileAttributeModifier = vehicle.Stats.FirstOrDefault((VechileAttributeModifier s) => s.AttributeType == VehicleAttributeType.Capacity);
		if (vechileAttributeModifier != null)
		{
			int num = 0;
			while ((double)num < vechileAttributeModifier.Value)
			{
				this.Slots[num].SetActive(true);
				num++;
			}
		}
		foreach (ITraveller traveller in vehicle.Travellers)
		{
			ShipMenuSelectedTravellerController shipMenuSelectedTravellerController = UnityEngine.Object.Instantiate<ShipMenuSelectedTravellerController>(this.TravellerPre);
			shipMenuSelectedTravellerController.Init(traveller);
			shipMenuSelectedTravellerController.transform.SetParent(this.TravellerContainer, false);
		}
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x0009DDA8 File Offset: 0x0009C1A8
	[CompilerGenerated]
	private static bool <Init>m__0(VechileAttributeModifier s)
	{
		return s.AttributeType == VehicleAttributeType.Capacity;
	}

	// Token: 0x04001315 RID: 4885
	public List<GameObject> Slots;

	// Token: 0x04001316 RID: 4886
	public ShipMenuSelectedTravellerController TravellerPre;

	// Token: 0x04001317 RID: 4887
	public Transform TravellerContainer;

	// Token: 0x04001318 RID: 4888
	[CompilerGenerated]
	private static Func<VechileAttributeModifier, bool> <>f__am$cache0;
}
