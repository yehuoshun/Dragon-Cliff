using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200044F RID: 1103
public class AdventureStartParameter
{
	// Token: 0x06001F48 RID: 8008 RVA: 0x000DBF7C File Offset: 0x000DA37C
	public AdventureStartParameter(AdventureType adventureType, List<string> selectedAdventurers, List<ResourceType> consumables)
	{
		this.AdventureType = adventureType;
		this.SelectedAdventurers = new List<AdventurerProfile>();
		using (List<string>.Enumerator enumerator = selectedAdventurers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string adventurerId = enumerator.Current;
				AdventurerProfile adventurerProfile = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.Id == adventurerId);
				if (adventurerProfile != null)
				{
					this.SelectedAdventurers.Add(adventurerProfile);
				}
			}
		}
		this.Consumables = consumables;
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06001F49 RID: 8009 RVA: 0x000DC02C File Offset: 0x000DA42C
	// (set) Token: 0x06001F4A RID: 8010 RVA: 0x000DC034 File Offset: 0x000DA434
	public List<AdventurerProfile> SelectedAdventurers
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedAdventurers>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SelectedAdventurers>k__BackingField = value;
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06001F4B RID: 8011 RVA: 0x000DC03D File Offset: 0x000DA43D
	// (set) Token: 0x06001F4C RID: 8012 RVA: 0x000DC045 File Offset: 0x000DA445
	public AdventureType AdventureType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdventureType>k__BackingField = value;
		}
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06001F4D RID: 8013 RVA: 0x000DC04E File Offset: 0x000DA44E
	// (set) Token: 0x06001F4E RID: 8014 RVA: 0x000DC056 File Offset: 0x000DA456
	public List<ResourceType> Consumables
	{
		[CompilerGenerated]
		get
		{
			return this.<Consumables>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Consumables>k__BackingField = value;
		}
	}

	// Token: 0x06001F4F RID: 8015 RVA: 0x000DC05F File Offset: 0x000DA45F
	public void ResetType(AdventureType type)
	{
		this.AdventureType = type;
	}

	// Token: 0x04001C49 RID: 7241
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventurerProfile> <SelectedAdventurers>k__BackingField;

	// Token: 0x04001C4A RID: 7242
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureType <AdventureType>k__BackingField;

	// Token: 0x04001C4B RID: 7243
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceType> <Consumables>k__BackingField;

	// Token: 0x02000D10 RID: 3344
	[CompilerGenerated]
	private sealed class <AdventureStartParameter>c__AnonStorey0
	{
		// Token: 0x060055E8 RID: 21992 RVA: 0x000DC068 File Offset: 0x000DA468
		public <AdventureStartParameter>c__AnonStorey0()
		{
		}

		// Token: 0x060055E9 RID: 21993 RVA: 0x000DC070 File Offset: 0x000DA470
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.Id == this.adventurerId;
		}

		// Token: 0x04004476 RID: 17526
		internal string adventurerId;
	}
}
