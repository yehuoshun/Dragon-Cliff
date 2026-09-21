using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class SelectedHeroAvatarIndication : MonoBehaviour
{
	// Token: 0x06001586 RID: 5510 RVA: 0x000AB5EA File Offset: 0x000A99EA
	public SelectedHeroAvatarIndication()
	{
	}

	// Token: 0x06001587 RID: 5511 RVA: 0x000AB5F4 File Offset: 0x000A99F4
	private void Start()
	{
		foreach (IndividualHeroAvatarControl individualHeroAvatarControl in this.HeroAvatars)
		{
			individualHeroAvatarControl.SetupControl(this);
		}
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x000AB627 File Offset: 0x000A9A27
	public void SetupControl(ToBattleList control)
	{
		this._scrollList = control;
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x000AB630 File Offset: 0x000A9A30
	public void AddedHeroToList(AdventurerObj obj)
	{
		List<IndividualHeroAvatarControl> list = (from h in this.HeroAvatars
		where h.GetAdventurerObj() == null
		select h).ToList<IndividualHeroAvatarControl>();
		if (list.Count != 0)
		{
			list.FirstOrDefault<IndividualHeroAvatarControl>().SetHero(obj);
		}
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x000AB684 File Offset: 0x000A9A84
	public void RemoveHeroWithCheckBoxOption(AdventurerObj obj)
	{
		List<IndividualHeroAvatarControl> source = (from c in this.HeroAvatars
		where c.GetAdventurerObj() != null
		select c).ToList<IndividualHeroAvatarControl>();
		List<IndividualHeroAvatarControl> list = (from h in source
		where h.GetAdventurerObj().GetAdventurerProfile().Id == obj.GetAdventurerProfile().Id
		select h).ToList<IndividualHeroAvatarControl>();
		if (list.Count != 0)
		{
			list.FirstOrDefault<IndividualHeroAvatarControl>().RemovedFromTheCheckBoxOption(obj);
		}
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x000AB700 File Offset: 0x000A9B00
	public void RemoveWithAvatarCrossOption(AdventurerObj obj)
	{
		this._scrollList.RemoveFromAvatarPanel(obj);
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000AB70E File Offset: 0x000A9B0E
	[CompilerGenerated]
	private static bool <AddedHeroToList>m__0(IndividualHeroAvatarControl h)
	{
		return h.GetAdventurerObj() == null;
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x000AB71C File Offset: 0x000A9B1C
	[CompilerGenerated]
	private static bool <RemoveHeroWithCheckBoxOption>m__1(IndividualHeroAvatarControl c)
	{
		return c.GetAdventurerObj() != null;
	}

	// Token: 0x04001597 RID: 5527
	public IndividualHeroAvatarControl[] HeroAvatars;

	// Token: 0x04001598 RID: 5528
	private ToBattleList _scrollList;

	// Token: 0x04001599 RID: 5529
	[CompilerGenerated]
	private static Func<IndividualHeroAvatarControl, bool> <>f__am$cache0;

	// Token: 0x0400159A RID: 5530
	[CompilerGenerated]
	private static Func<IndividualHeroAvatarControl, bool> <>f__am$cache1;

	// Token: 0x02000C90 RID: 3216
	[CompilerGenerated]
	private sealed class <RemoveHeroWithCheckBoxOption>c__AnonStorey0
	{
		// Token: 0x06005341 RID: 21313 RVA: 0x000AB72A File Offset: 0x000A9B2A
		public <RemoveHeroWithCheckBoxOption>c__AnonStorey0()
		{
		}

		// Token: 0x06005342 RID: 21314 RVA: 0x000AB732 File Offset: 0x000A9B32
		internal bool <>m__0(IndividualHeroAvatarControl h)
		{
			return h.GetAdventurerObj().GetAdventurerProfile().Id == this.obj.GetAdventurerProfile().Id;
		}

		// Token: 0x040040D0 RID: 16592
		internal AdventurerObj obj;
	}
}
