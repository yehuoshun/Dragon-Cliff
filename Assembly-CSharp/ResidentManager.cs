using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000147 RID: 327
public class ResidentManager : MonoBehaviour
{
	// Token: 0x060008F3 RID: 2291 RVA: 0x00078CF9 File Offset: 0x000770F9
	public ResidentManager()
	{
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x00078D38 File Offset: 0x00077138
	private void Update()
	{
		int num = GameWorld.instance.PlayerProfile.Residents.Count;
		if (num > 50)
		{
			num = 50;
		}
		if ((double)(Time.time - this._lastTime) > (double)this.ResidentSpawnTime - (double)this.ResidentSpawnTime * 0.8 * (double)num / 50.0)
		{
			if (UnityEngine.Random.value < this.Threshold)
			{
				this.Spawn();
			}
			this._lastTime = Time.time;
		}
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x00078DC0 File Offset: 0x000771C0
	public void TriggerHappyResident(Resident resident)
	{
		ResidentController residentController = this._inTownResidents.FirstOrDefault((ResidentController r) => r.ResidentAtrb.Resident == resident);
		if (residentController != null)
		{
			residentController.HappyTriggerred();
		}
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x00078E04 File Offset: 0x00077204
	private void Spawn()
	{
		List<Resident> residents = GameWorld.instance.PlayerProfile.Residents;
		if (residents.Count <= 0)
		{
			return;
		}
		Resident resident = residents[UnityEngine.Random.Range(0, residents.Count)];
		GameObject gameObject = ObjectPoolManager.Instance.Spawn(PoolType.Resident, Vector3.zero);
		List<TownSlot> list = (from b in GameWorld.instance.PlayerProfile.Buildings
		where b.Value != null
		select b).ToDictionary((KeyValuePair<TownSlot, IBuildingProfile> k) => k.Key, (KeyValuePair<TownSlot, IBuildingProfile> v) => v.Value).Keys.ToList<TownSlot>();
		NodeController node = PathPointsManager.Instance.GetNode(NodeType.EntranceAndExit);
		NodeController node2 = PathPointsManager.Instance.GetNode(list[UnityEngine.Random.Range(0, list.Count)]);
		float halfwayWaitTime = UnityEngine.Random.Range(1f, 3f);
		ResidentAtrb atrb = new ResidentAtrb
		{
			Resident = resident,
			StartPoint = node,
			EndPoint = node2,
			HalfwayWaitTime = halfwayWaitTime
		};
		gameObject.transform.position = node.transform.position;
		ResidentController component = gameObject.GetComponent<ResidentController>();
		component.Init(atrb);
		this._inTownResidents.Add(component);
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00078F6D File Offset: 0x0007736D
	public void RemoveInTownResident(ResidentController resident)
	{
		this._inTownResidents.Remove(resident);
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x00078F7C File Offset: 0x0007737C
	public void AddHappResident(Resident resident, TownEffectBase effect)
	{
		PathPointsManager instance = PathPointsManager.Instance;
		NodeController startPoint = instance.GetNode(NodeType.EntranceAndExit);
		List<NodeController> list = (from p in startPoint.Neighbours.SelectMany((NodeController p) => p.Neighbours)
		where p != startPoint
		where p.PositionX != 4 && p.PositionY != 7
		select p).ToList<NodeController>();
		NodeController endPoint = list[UnityEngine.Random.Range(0, list.Count)];
		float halfwayWaitTime = 1.5f;
		ResidentAtrb item = new ResidentAtrb
		{
			Resident = resident,
			StartPoint = startPoint,
			EndPoint = endPoint,
			HalfwayWaitTime = halfwayWaitTime,
			HasExpression = true,
			TownEffect = effect
		};
		this._aWaitingResidents.Add(item);
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00079074 File Offset: 0x00077474
	public void SpawnHappyResident(ResidentAtrb residentAtrb)
	{
		GameObject gameObject = ObjectPoolManager.Instance.Spawn(PoolType.Resident, Vector3.zero);
		gameObject.transform.position = residentAtrb.StartPoint.transform.position;
		gameObject.GetComponent<ResidentController>().Init(residentAtrb);
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x000790B9 File Offset: 0x000774B9
	[CompilerGenerated]
	private static bool <Spawn>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value != null;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x000790C8 File Offset: 0x000774C8
	[CompilerGenerated]
	private static TownSlot <Spawn>m__1(KeyValuePair<TownSlot, IBuildingProfile> k)
	{
		return k.Key;
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x000790D1 File Offset: 0x000774D1
	[CompilerGenerated]
	private static IBuildingProfile <Spawn>m__2(KeyValuePair<TownSlot, IBuildingProfile> v)
	{
		return v.Value;
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000790DA File Offset: 0x000774DA
	[CompilerGenerated]
	private static IEnumerable<NodeController> <AddHappResident>m__3(NodeController p)
	{
		return p.Neighbours;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000790E2 File Offset: 0x000774E2
	[CompilerGenerated]
	private static bool <AddHappResident>m__4(NodeController p)
	{
		return p.PositionX != 4 && p.PositionY != 7;
	}

	// Token: 0x04000B8D RID: 2957
	public float ResidentSpawnTime = 10f;

	// Token: 0x04000B8E RID: 2958
	private float _lastTime;

	// Token: 0x04000B8F RID: 2959
	public float Threshold = 0.5f;

	// Token: 0x04000B90 RID: 2960
	private float _spawnTimer;

	// Token: 0x04000B91 RID: 2961
	private float _spawnGab = 1f;

	// Token: 0x04000B92 RID: 2962
	private readonly List<ResidentAtrb> _aWaitingResidents = new List<ResidentAtrb>();

	// Token: 0x04000B93 RID: 2963
	private readonly List<ResidentController> _inTownResidents = new List<ResidentController>();

	// Token: 0x04000B94 RID: 2964
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, bool> <>f__am$cache0;

	// Token: 0x04000B95 RID: 2965
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, TownSlot> <>f__am$cache1;

	// Token: 0x04000B96 RID: 2966
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache2;

	// Token: 0x04000B97 RID: 2967
	[CompilerGenerated]
	private static Func<NodeController, IEnumerable<NodeController>> <>f__am$cache3;

	// Token: 0x04000B98 RID: 2968
	[CompilerGenerated]
	private static Func<NodeController, bool> <>f__am$cache4;

	// Token: 0x02000C18 RID: 3096
	[CompilerGenerated]
	private sealed class <TriggerHappyResident>c__AnonStorey0
	{
		// Token: 0x060051EA RID: 20970 RVA: 0x000790FF File Offset: 0x000774FF
		public <TriggerHappyResident>c__AnonStorey0()
		{
		}

		// Token: 0x060051EB RID: 20971 RVA: 0x00079107 File Offset: 0x00077507
		internal bool <>m__0(ResidentController r)
		{
			return r.ResidentAtrb.Resident == this.resident;
		}

		// Token: 0x04003FFF RID: 16383
		internal Resident resident;
	}

	// Token: 0x02000C19 RID: 3097
	[CompilerGenerated]
	private sealed class <AddHappResident>c__AnonStorey1
	{
		// Token: 0x060051EC RID: 20972 RVA: 0x0007911C File Offset: 0x0007751C
		public <AddHappResident>c__AnonStorey1()
		{
		}

		// Token: 0x060051ED RID: 20973 RVA: 0x00079124 File Offset: 0x00077524
		internal bool <>m__0(NodeController p)
		{
			return p != this.startPoint;
		}

		// Token: 0x04004000 RID: 16384
		internal NodeController startPoint;
	}
}
