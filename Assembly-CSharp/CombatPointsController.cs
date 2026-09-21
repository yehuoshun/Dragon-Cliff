using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000120 RID: 288
public class CombatPointsController : MonoBehaviour
{
	// Token: 0x060007DA RID: 2010 RVA: 0x000732F5 File Offset: 0x000716F5
	public CombatPointsController()
	{
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x00073314 File Offset: 0x00071714
	public void Reset()
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
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000733C0 File Offset: 0x000717C0
	public Transform GetPointTrans(StandSlotPoints point)
	{
		switch (point)
		{
		case StandSlotPoints.Hero5:
			return this.StandPoints[4];
		case StandSlotPoints.Hero1:
			return this.StandPoints[0];
		case StandSlotPoints.Hero2:
			return this.StandPoints[1];
		case StandSlotPoints.Hero3:
			return this.StandPoints[2];
		case StandSlotPoints.Hero4:
			return this.StandPoints[3];
		case StandSlotPoints.Hero6:
			return this.StandPoints[5];
		case StandSlotPoints.Monster6:
			return this.StandPoints[6];
		case StandSlotPoints.Monster7:
			return this.StandPoints[7];
		case StandSlotPoints.Monster8:
			return this.StandPoints[8];
		case StandSlotPoints.Monster9:
			return this.StandPoints[9];
		case StandSlotPoints.Monster10:
			return this.StandPoints[10];
		case StandSlotPoints.Monster11:
			return this.StandPoints[11];
		case StandSlotPoints.Monster12:
			return this.StandPoints[12];
		case StandSlotPoints.Monster13:
			return this.StandPoints[13];
		case StandSlotPoints.Boss:
			return this.BossPoint;
		default:
			throw new Exception("Point " + point + " not exist");
		}
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000734F0 File Offset: 0x000718F0
	public Transform CreateEffect(GameObject effectObj, StandSlotPoints target)
	{
		Transform pointTrans = this.GetPointTrans(target);
		if (pointTrans == null)
		{
			return null;
		}
		effectObj.transform.SetParent(pointTrans, false);
		effectObj.transform.localPosition = Vector3.zero;
		return pointTrans;
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x00073531 File Offset: 0x00071931
	public void SpawnFriendlyPet(GameObject unitObj)
	{
		unitObj.transform.SetParent(this.StandPoints[5], false);
		unitObj.transform.localPosition = Vector3.zero;
		unitObj.GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero6);
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x00073567 File Offset: 0x00071967
	public void SpawnEnemyPet(GameObject unitObj)
	{
		unitObj.transform.SetParent(this.StandPoints[13], false);
		unitObj.transform.localPosition = Vector3.zero;
		unitObj.GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster13);
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x000735A0 File Offset: 0x000719A0
	public void Init(List<GameObject> adventurers, List<GameObject> monsters, GameObject boss = null)
	{
		switch (adventurers.Count)
		{
		case 1:
			if (adventurers[0] != null)
			{
				adventurers[0].transform.SetParent(this.StandPoints[1], false);
				adventurers[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero2);
			}
			break;
		case 2:
			if (adventurers[0] != null)
			{
				adventurers[0].transform.SetParent(this.StandPoints[0], false);
				adventurers[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero1);
			}
			if (adventurers[1] != null)
			{
				adventurers[1].transform.SetParent(this.StandPoints[2], false);
				adventurers[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero3);
			}
			break;
		case 3:
			if (adventurers[0] != null)
			{
				adventurers[0].transform.SetParent(this.StandPoints[0], false);
				adventurers[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero1);
			}
			if (adventurers[1] != null)
			{
				adventurers[1].transform.SetParent(this.StandPoints[1], false);
				adventurers[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero2);
			}
			if (adventurers[2] != null)
			{
				adventurers[2].transform.SetParent(this.StandPoints[2], false);
				adventurers[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero3);
			}
			break;
		case 4:
			if (adventurers[0] != null)
			{
				adventurers[0].transform.SetParent(this.StandPoints[0], false);
				adventurers[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero1);
			}
			if (adventurers[1] != null)
			{
				adventurers[1].transform.SetParent(this.StandPoints[1], false);
				adventurers[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero2);
			}
			if (adventurers[2] != null)
			{
				adventurers[2].transform.SetParent(this.StandPoints[2], false);
				adventurers[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero3);
			}
			if (adventurers[3] != null)
			{
				adventurers[3].transform.SetParent(this.StandPoints[3], false);
				adventurers[3].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero4);
			}
			break;
		case 5:
			if (adventurers[0] != null)
			{
				adventurers[0].transform.SetParent(this.StandPoints[0], false);
				adventurers[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero1);
			}
			if (adventurers[1] != null)
			{
				adventurers[1].transform.SetParent(this.StandPoints[1], false);
				adventurers[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero2);
			}
			if (adventurers[2] != null)
			{
				adventurers[2].transform.SetParent(this.StandPoints[2], false);
				adventurers[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero3);
			}
			if (adventurers[3] != null)
			{
				adventurers[3].transform.SetParent(this.StandPoints[3], false);
				adventurers[3].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero4);
			}
			if (adventurers[4] != null)
			{
				adventurers[4].transform.SetParent(this.StandPoints[4], false);
				adventurers[4].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Hero5);
			}
			break;
		default:
			throw new Exception("The number of adventurers is: " + adventurers.Count + ", should be between 1-3");
		}
		switch (monsters.Count)
		{
		case 0:
			break;
		case 1:
			monsters[0].transform.SetParent(this.StandPoints[10], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster10);
			break;
		case 2:
			monsters[0].transform.SetParent(this.StandPoints[11], false);
			monsters[1].transform.SetParent(this.StandPoints[12], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster11);
			monsters[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster12);
			break;
		case 3:
			monsters[0].transform.SetParent(this.StandPoints[10], false);
			monsters[1].transform.SetParent(this.StandPoints[11], false);
			monsters[2].transform.SetParent(this.StandPoints[12], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster10);
			monsters[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster11);
			monsters[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster12);
			break;
		case 4:
			monsters[0].transform.SetParent(this.StandPoints[10], false);
			monsters[1].transform.SetParent(this.StandPoints[9], false);
			monsters[2].transform.SetParent(this.StandPoints[8], false);
			monsters[3].transform.SetParent(this.StandPoints[7], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster10);
			monsters[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster9);
			monsters[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster8);
			monsters[3].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster7);
			break;
		case 5:
			monsters[0].transform.SetParent(this.StandPoints[12], false);
			monsters[1].transform.SetParent(this.StandPoints[11], false);
			monsters[2].transform.SetParent(this.StandPoints[10], false);
			monsters[3].transform.SetParent(this.StandPoints[9], false);
			monsters[4].transform.SetParent(this.StandPoints[8], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster12);
			monsters[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster11);
			monsters[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster10);
			monsters[3].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster9);
			monsters[4].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster8);
			break;
		case 6:
			monsters[0].transform.SetParent(this.StandPoints[12], false);
			monsters[1].transform.SetParent(this.StandPoints[11], false);
			monsters[2].transform.SetParent(this.StandPoints[10], false);
			monsters[3].transform.SetParent(this.StandPoints[9], false);
			monsters[4].transform.SetParent(this.StandPoints[8], false);
			monsters[5].transform.SetParent(this.StandPoints[7], false);
			monsters[0].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster12);
			monsters[1].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster11);
			monsters[2].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster10);
			monsters[3].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster9);
			monsters[4].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster8);
			monsters[5].GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Monster7);
			break;
		default:
			throw new Exception("The number of monsters is: " + monsters.Count + ", should be between 0-6");
		}
		if (boss != null)
		{
			boss.transform.SetParent(this.BossPoint, false);
			boss.GetComponent<CombatUnit>().InitStandPoint(StandSlotPoints.Boss);
			boss.transform.localPosition = Vector3.zero;
		}
		(from a in adventurers
		where a != null
		select a).ToList<GameObject>().ForEach(delegate(GameObject a)
		{
			a.transform.localPosition = Vector3.zero;
		});
		monsters.ForEach(delegate(GameObject a)
		{
			a.transform.localPosition = Vector3.zero;
			a.transform.localScale = Vector3.one;
		});
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00073F15 File Offset: 0x00072315
	public void Collect()
	{
		if (this.AllDrops != null)
		{
			this.AllDrops.ForEach(delegate(CombatDropController d)
			{
				d.ToBeCollected(this.DropsCollectPoint.position, this.CollectSpeed);
			});
			this.ClearDrops();
		}
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x00073F3F File Offset: 0x0007233F
	public void AddDrop(CombatDropController drop)
	{
		this.AllDrops.Add(drop);
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x00073F4D File Offset: 0x0007234D
	private void ClearDrops()
	{
		this.AllDrops.Clear();
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00073F5A File Offset: 0x0007235A
	[CompilerGenerated]
	private static bool <Init>m__0(GameObject a)
	{
		return a != null;
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00073F63 File Offset: 0x00072363
	[CompilerGenerated]
	private static void <Init>m__1(GameObject a)
	{
		a.transform.localPosition = Vector3.zero;
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00073F75 File Offset: 0x00072375
	[CompilerGenerated]
	private static void <Init>m__2(GameObject a)
	{
		a.transform.localPosition = Vector3.zero;
		a.transform.localScale = Vector3.one;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x00073F97 File Offset: 0x00072397
	[CompilerGenerated]
	private void <Collect>m__3(CombatDropController d)
	{
		d.ToBeCollected(this.DropsCollectPoint.position, this.CollectSpeed);
	}

	// Token: 0x04000AB9 RID: 2745
	public List<Transform> StandPoints;

	// Token: 0x04000ABA RID: 2746
	public Transform BossPoint;

	// Token: 0x04000ABB RID: 2747
	public Transform AttackPoint;

	// Token: 0x04000ABC RID: 2748
	public Transform SkillCastPoint;

	// Token: 0x04000ABD RID: 2749
	public Transform DropsCollectPoint;

	// Token: 0x04000ABE RID: 2750
	public float CollectSpeed = 2f;

	// Token: 0x04000ABF RID: 2751
	private List<CombatDropController> AllDrops = new List<CombatDropController>();

	// Token: 0x04000AC0 RID: 2752
	[CompilerGenerated]
	private static Func<GameObject, bool> <>f__am$cache0;

	// Token: 0x04000AC1 RID: 2753
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache1;

	// Token: 0x04000AC2 RID: 2754
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache2;
}
