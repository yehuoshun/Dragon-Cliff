using System;
using UnityEngine;

// Token: 0x02000164 RID: 356
public class CasinoParticlesContrller : MonoBehaviour
{
	// Token: 0x06000977 RID: 2423 RVA: 0x0007B256 File Offset: 0x00079656
	public CasinoParticlesContrller()
	{
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0007B25E File Offset: 0x0007965E
	public void SmallWin()
	{
		this.StopAll();
		this.ShootoutConfetti.SetActive(true);
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x0007B272 File Offset: 0x00079672
	public void BigWin()
	{
		this.StopAll();
		this.DropdownConfetti.SetActive(true);
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x0007B286 File Offset: 0x00079686
	public void StopAll()
	{
		this.DropdownConfetti.SetActive(false);
		this.ShootoutConfetti.SetActive(false);
	}

	// Token: 0x04000C29 RID: 3113
	public GameObject DropdownConfetti;

	// Token: 0x04000C2A RID: 3114
	public GameObject ShootoutConfetti;
}
