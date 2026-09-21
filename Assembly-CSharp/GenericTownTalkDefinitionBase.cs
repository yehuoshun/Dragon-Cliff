using System;

// Token: 0x02000978 RID: 2424
public abstract class GenericTownTalkDefinitionBase
{
	// Token: 0x060042A1 RID: 17057 RVA: 0x001B40B4 File Offset: 0x001B24B4
	protected GenericTownTalkDefinitionBase()
	{
	}

	// Token: 0x060042A2 RID: 17058
	public abstract bool MetRequirement(GameWorldEvent evt, object additionalData);

	// Token: 0x060042A3 RID: 17059
	public abstract void Run(GameWorldEvent evt, object additionalData);

	// Token: 0x060042A4 RID: 17060 RVA: 0x001B40BC File Offset: 0x001B24BC
	// Note: this type is marked as 'beforefieldinit'.
	static GenericTownTalkDefinitionBase()
	{
	}

	// Token: 0x040032CD RID: 13005
	protected static UnitClass _oldManClass = UnitClass.OldWiseMan;

	// Token: 0x040032CE RID: 13006
	protected static UnitClass _townGuard = UnitClass.TownGuardian;

	// Token: 0x040032CF RID: 13007
	protected static UnitClass _schoolManager = UnitClass.SchoolManager;

	// Token: 0x040032D0 RID: 13008
	protected static UnitClass _weaponShopManager = UnitClass.WeaponShopManager;

	// Token: 0x040032D1 RID: 13009
	protected static UnitClass _forgeManager = UnitClass.FurnaceManager;
}
