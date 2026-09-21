using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class starFxController : MonoBehaviour
{
	// Token: 0x060005E6 RID: 1510 RVA: 0x0006091C File Offset: 0x0005ED1C
	public starFxController()
	{
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x00060924 File Offset: 0x0005ED24
	private void Awake()
	{
		starFxController.myStarFxController = this;
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x0006092C File Offset: 0x0005ED2C
	private void Start()
	{
		this.Reset();
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00060934 File Offset: 0x0005ED34
	private void Update()
	{
		if (!this.isEnd)
		{
			this.currentDelay -= Time.deltaTime;
			if (this.currentDelay <= 0f)
			{
				if (this.currentEa != this.ea)
				{
					this.currentDelay = this.delay;
					this.starFX[this.currentEa].SetActive(true);
					this.currentEa++;
				}
				else
				{
					this.isEnd = true;
					this.currentDelay = this.delay;
					this.currentEa = 0;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.Reset();
		}
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x000609E0 File Offset: 0x0005EDE0
	public void Reset()
	{
		for (int i = 0; i < 3; i++)
		{
			this.starFX[i].SetActive(false);
		}
		this.currentDelay = this.delay;
		this.currentEa = 0;
		this.isEnd = false;
		for (int j = 0; j < 3; j++)
		{
			this.starFX[j].SetActive(false);
		}
	}

	// Token: 0x040008E0 RID: 2272
	public GameObject[] starFX;

	// Token: 0x040008E1 RID: 2273
	public int ea;

	// Token: 0x040008E2 RID: 2274
	public int currentEa;

	// Token: 0x040008E3 RID: 2275
	public float delay;

	// Token: 0x040008E4 RID: 2276
	public float currentDelay;

	// Token: 0x040008E5 RID: 2277
	public bool isEnd;

	// Token: 0x040008E6 RID: 2278
	public int idStar;

	// Token: 0x040008E7 RID: 2279
	public static starFxController myStarFxController;
}
