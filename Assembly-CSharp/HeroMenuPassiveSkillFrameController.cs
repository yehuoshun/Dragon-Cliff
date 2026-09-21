using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001C1 RID: 449
public class HeroMenuPassiveSkillFrameController : MonoBehaviour
{
	// Token: 0x06000C00 RID: 3072 RVA: 0x0008801B File Offset: 0x0008641B
	public HeroMenuPassiveSkillFrameController()
	{
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x00088023 File Offset: 0x00086423
	private void Start()
	{
		this._heroMenu = base.GetComponentInParent<HeroMenuController>();
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x00088034 File Offset: 0x00086434
	private void Update()
	{
		if (this._heroMenu.SelectedHero != null)
		{
			if (GameWorld.instance.PlayerProfile.Buildings.Any((KeyValuePair<TownSlot, IBuildingProfile> b) => b.Value is School))
			{
				if (this._heroMenu.SelectedHero.AdventurerProfile.Skills.All((SkillType s) => s.GetSkillLogic().SkillCommandType != SkillCommandType.Secondary))
				{
					this.PassiveSkillFrame.SetActive(true);
					goto IL_9F;
				}
			}
			this.PassiveSkillFrame.SetActive(false);
			IL_9F:;
		}
		else
		{
			this.PassiveSkillFrame.SetActive(false);
		}
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x000880F1 File Offset: 0x000864F1
	[CompilerGenerated]
	private static bool <Update>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value is School;
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x00088102 File Offset: 0x00086502
	[CompilerGenerated]
	private static bool <Update>m__1(SkillType s)
	{
		return s.GetSkillLogic().SkillCommandType != SkillCommandType.Secondary;
	}

	// Token: 0x04000E5F RID: 3679
	public GameObject PassiveSkillFrame;

	// Token: 0x04000E60 RID: 3680
	private HeroMenuController _heroMenu;

	// Token: 0x04000E61 RID: 3681
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, bool> <>f__am$cache0;

	// Token: 0x04000E62 RID: 3682
	[CompilerGenerated]
	private static Func<SkillType, bool> <>f__am$cache1;
}
