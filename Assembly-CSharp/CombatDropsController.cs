using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200011E RID: 286
public class CombatDropsController : MonoBehaviour
{
	// Token: 0x060007D3 RID: 2003 RVA: 0x00073279 File Offset: 0x00071679
	public CombatDropsController()
	{
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0007328C File Offset: 0x0007168C
	// (set) Token: 0x060007D5 RID: 2005 RVA: 0x00073294 File Offset: 0x00071694
	public List<CombatDropController> AllDrops
	{
		[CompilerGenerated]
		get
		{
			return this.<AllDrops>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AllDrops>k__BackingField = value;
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x0007329D File Offset: 0x0007169D
	public void Collect()
	{
		this.AllDrops.ForEach(delegate(CombatDropController d)
		{
			d.ToBeCollected(this.DropsCollectPoint.transform.position, this.CollectSpeed);
		});
		this.ClearDrops();
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000732BC File Offset: 0x000716BC
	public void AddDrop(CombatDropController drop)
	{
		this.AllDrops.Add(drop);
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000732CA File Offset: 0x000716CA
	private void ClearDrops()
	{
		this.AllDrops.Clear();
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000732D7 File Offset: 0x000716D7
	[CompilerGenerated]
	private void <Collect>m__0(CombatDropController d)
	{
		d.ToBeCollected(this.DropsCollectPoint.transform.position, this.CollectSpeed);
	}

	// Token: 0x04000AA6 RID: 2726
	public GameObject DropsCollectPoint;

	// Token: 0x04000AA7 RID: 2727
	public float CollectSpeed = 2f;

	// Token: 0x04000AA8 RID: 2728
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<CombatDropController> <AllDrops>k__BackingField;
}
