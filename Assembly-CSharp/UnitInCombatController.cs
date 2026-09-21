using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
public class UnitInCombatController : CombatUnit
{
	// Token: 0x06000867 RID: 2151 RVA: 0x000754BB File Offset: 0x000738BB
	public UnitInCombatController()
	{
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x000754C3 File Offset: 0x000738C3
	private void Awake()
	{
		this.HealthDetails = base.GetComponentInChildren<HealthDetailsController>().gameObject;
	}

	// Token: 0x04000B07 RID: 2823
	public GameObject HealthDetails;
}
