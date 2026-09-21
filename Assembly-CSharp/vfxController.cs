using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class vfxController : MonoBehaviour
{
	// Token: 0x060005EB RID: 1515 RVA: 0x00060A47 File Offset: 0x0005EE47
	public vfxController()
	{
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00060A4F File Offset: 0x0005EE4F
	private void Start()
	{
		this.currentStarImage = 0;
		this.currentStarFx = 0;
		this.currentLevel = 3;
		this.currentBgFx = 1;
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00060A6D File Offset: 0x0005EE6D
	public void ChangedStarImage(int i)
	{
		this.currentStarImage = i;
		this.PlayStarFX();
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00060A7C File Offset: 0x0005EE7C
	public void ChangedStarFX(int i)
	{
		this.currentStarFx = i;
		this.PlayStarFX();
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x00060A8B File Offset: 0x0005EE8B
	public void ChangedLevel(int i)
	{
		this.currentLevel = i;
		this.PlayStarFX();
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00060A9A File Offset: 0x0005EE9A
	public void ChangedBgFx(int i)
	{
		this.currentBgFx = i;
		this.PlayStarFX();
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00060AAC File Offset: 0x0005EEAC
	public void PlayStarFX()
	{
		this.DesStarFxObjs = GameObject.FindGameObjectsWithTag("Effects");
		foreach (GameObject gameObject in this.DesStarFxObjs)
		{
			UnityEngine.Object.Destroy(gameObject.gameObject);
		}
		if (this.currentBgFx != 0)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.bgFxPrefabs[this.currentBgFx]);
		}
		switch (this.currentStarImage)
		{
		case 0:
			UnityEngine.Object.Instantiate<GameObject>(this.starFx01Prefabs[this.currentStarFx]);
			starFxController.myStarFxController.ea = this.currentLevel;
			break;
		case 1:
			UnityEngine.Object.Instantiate<GameObject>(this.starFx02Prefabs[this.currentStarFx]);
			starFxController.myStarFxController.ea = this.currentLevel;
			break;
		case 2:
			UnityEngine.Object.Instantiate<GameObject>(this.starFx03Prefabs[this.currentStarFx]);
			starFxController.myStarFxController.ea = this.currentLevel;
			break;
		case 3:
			UnityEngine.Object.Instantiate<GameObject>(this.starFx04Prefabs[this.currentStarFx]);
			starFxController.myStarFxController.ea = this.currentLevel;
			break;
		case 4:
			UnityEngine.Object.Instantiate<GameObject>(this.starFx05Prefabs[this.currentStarFx]);
			starFxController.myStarFxController.ea = this.currentLevel;
			break;
		}
	}

	// Token: 0x040008E8 RID: 2280
	public GameObject[] starFx01Prefabs;

	// Token: 0x040008E9 RID: 2281
	public GameObject[] starFx02Prefabs;

	// Token: 0x040008EA RID: 2282
	public GameObject[] starFx03Prefabs;

	// Token: 0x040008EB RID: 2283
	public GameObject[] starFx04Prefabs;

	// Token: 0x040008EC RID: 2284
	public GameObject[] starFx05Prefabs;

	// Token: 0x040008ED RID: 2285
	public GameObject[] DesStarFxObjs;

	// Token: 0x040008EE RID: 2286
	public GameObject[] bgFxPrefabs;

	// Token: 0x040008EF RID: 2287
	public int currentStarImage;

	// Token: 0x040008F0 RID: 2288
	public int currentStarFx;

	// Token: 0x040008F1 RID: 2289
	public int currentLevel;

	// Token: 0x040008F2 RID: 2290
	public int currentBgFx;
}
