using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200021A RID: 538
public class HeroPaginationController : PaginationController<PageCharacterController>
{
	// Token: 0x06000E22 RID: 3618 RVA: 0x00090E17 File Offset: 0x0008F217
	public HeroPaginationController()
	{
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x00090E1F File Offset: 0x0008F21F
	private void Activate(Component hero, bool active)
	{
		hero.gameObject.SetActive(active);
		hero.GetComponent<Animator>().enabled = active;
		if (!active)
		{
			hero.GetComponent<PageCharacterController>().PageElement = null;
		}
	}

	// Token: 0x06000E24 RID: 3620 RVA: 0x00090E4C File Offset: 0x0008F24C
	public PageCharacterController GetHeroController(string id)
	{
		return base.ItemHolders.Find((PageCharacterController p) => p.PageElement != null && p.PageElement.Id == id);
	}

	// Token: 0x02000C46 RID: 3142
	[CompilerGenerated]
	private sealed class <GetHeroController>c__AnonStorey0
	{
		// Token: 0x0600527B RID: 21115 RVA: 0x00090E7D File Offset: 0x0008F27D
		public <GetHeroController>c__AnonStorey0()
		{
		}

		// Token: 0x0600527C RID: 21116 RVA: 0x00090E85 File Offset: 0x0008F285
		internal bool <>m__0(PageCharacterController p)
		{
			return p.PageElement != null && p.PageElement.Id == this.id;
		}

		// Token: 0x04004063 RID: 16483
		internal string id;
	}
}
