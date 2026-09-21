using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002BC RID: 700
public class VehiclePointsController : MonoBehaviour
{
	// Token: 0x060012C0 RID: 4800 RVA: 0x0009FCE8 File Offset: 0x0009E0E8
	public VehiclePointsController()
	{
	}

	// Token: 0x060012C1 RID: 4801 RVA: 0x0009FCF0 File Offset: 0x0009E0F0
	public void UpdateShipsOnPoints()
	{
		foreach (Transform transform in this.StandPoints)
		{
			IEnumerator enumerator2 = transform.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					Transform transform2 = (Transform)obj;
					UnityEngine.Object.Destroy(transform2.gameObject);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator2 as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		List<Vehicle> list = (from v in GameWorld.instance.PlayerProfile.CurrentVehicles
		where v.IsAvaliable(null)
		orderby v.Type
		select v).ToList<Vehicle>();
		for (int i = 0; i < list.Count; i++)
		{
			if (i < this.StandPoints.Count)
			{
				SeaShipController seaShipController = UnityEngine.Object.Instantiate<SeaShipController>(this.ShipPre);
				seaShipController.Init(list[i]);
				seaShipController.IdleAnim();
				seaShipController.transform.SetParent(this.StandPoints[i], false);
			}
		}
	}

	// Token: 0x060012C2 RID: 4802 RVA: 0x0009FE60 File Offset: 0x0009E260
	public void PlaceStartJourneyShip(Vehicle vehicle)
	{
		SeaShipController seaShipController = UnityEngine.Object.Instantiate<SeaShipController>(this.ShipPre);
		seaShipController.Init(vehicle);
		seaShipController.StartJourneyAnim();
		seaShipController.transform.SetParent(this.ReadyToGoPoint, false);
		this.UpdateShipsOnPoints();
	}

	// Token: 0x060012C3 RID: 4803 RVA: 0x0009FEA0 File Offset: 0x0009E2A0
	[CompilerGenerated]
	private static bool <UpdateShipsOnPoints>m__0(Vehicle v)
	{
		return v.IsAvaliable(null);
	}

	// Token: 0x060012C4 RID: 4804 RVA: 0x0009FEBC File Offset: 0x0009E2BC
	[CompilerGenerated]
	private static VehicleType <UpdateShipsOnPoints>m__1(Vehicle v)
	{
		return v.Type;
	}

	// Token: 0x0400136B RID: 4971
	public Transform ReadyToGoPoint;

	// Token: 0x0400136C RID: 4972
	public List<Transform> StandPoints;

	// Token: 0x0400136D RID: 4973
	public SeaShipController ShipPre;

	// Token: 0x0400136E RID: 4974
	[CompilerGenerated]
	private static Func<Vehicle, bool> <>f__am$cache0;

	// Token: 0x0400136F RID: 4975
	[CompilerGenerated]
	private static Func<Vehicle, VehicleType> <>f__am$cache1;
}
