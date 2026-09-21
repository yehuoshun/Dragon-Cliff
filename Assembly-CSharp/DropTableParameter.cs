using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class DropTableParameter : IPresentable
{
	// Token: 0x06001F2F RID: 7983 RVA: 0x000DBE05 File Offset: 0x000DA205
	public DropTableParameter()
	{
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x000DBE0D File Offset: 0x000DA20D
	// (set) Token: 0x06001F31 RID: 7985 RVA: 0x000DBE15 File Offset: 0x000DA215
	public ResourceType ResourceType
	{
		[CompilerGenerated]
		get
		{
			return this.<ResourceType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResourceType>k__BackingField = value;
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06001F32 RID: 7986 RVA: 0x000DBE1E File Offset: 0x000DA21E
	// (set) Token: 0x06001F33 RID: 7987 RVA: 0x000DBE26 File Offset: 0x000DA226
	public int Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06001F34 RID: 7988 RVA: 0x000DBE2F File Offset: 0x000DA22F
	// (set) Token: 0x06001F35 RID: 7989 RVA: 0x000DBE37 File Offset: 0x000DA237
	public double InclusiveVolumFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<InclusiveVolumFrom>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InclusiveVolumFrom>k__BackingField = value;
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06001F36 RID: 7990 RVA: 0x000DBE40 File Offset: 0x000DA240
	// (set) Token: 0x06001F37 RID: 7991 RVA: 0x000DBE48 File Offset: 0x000DA248
	public double InclusiveVolumTo
	{
		[CompilerGenerated]
		get
		{
			return this.<InclusiveVolumTo>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InclusiveVolumTo>k__BackingField = value;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x000DBE51 File Offset: 0x000DA251
	// (set) Token: 0x06001F39 RID: 7993 RVA: 0x000DBE59 File Offset: 0x000DA259
	public int Presence
	{
		[CompilerGenerated]
		get
		{
			return this.<Presence>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Presence>k__BackingField = value;
		}
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x000DBE62 File Offset: 0x000DA262
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x000DBE6C File Offset: 0x000DA26C
	public ResourceUpdate GetDrop(GenerationDistribution generationDistribution, DifficultyLevelMeasurement df)
	{
		float num = UnityEngine.Random.Range(Convert.ToSingle(this.InclusiveVolumFrom), Convert.ToSingle(this.InclusiveVolumTo));
		if (!this.ResourceType.IsItem())
		{
			return new ResourceUpdate
			{
				ResourceType = this.ResourceType,
				ChangeAmount = (double)num,
				RelatedItems = new List<Item>()
			};
		}
		List<Item> list = new List<Item>();
		int num2 = 0;
		while ((float)num2 < num)
		{
			QualityGrade grade = generationDistribution.GetGrade();
			list.Add(this.ResourceType.ItemGenerate(ResourceSourceType.DungeonDrop, df.GetItemGenerationQuality(grade, this.ResourceType, ResourceSourceType.DungeonDrop), df.GetCorrespondingItemTierLevel(this.ResourceType), this.Level));
			num2++;
		}
		return new ResourceUpdate
		{
			ResourceType = this.ResourceType,
			RelatedItems = list,
			ChangeAmount = (double)num
		};
	}

	// Token: 0x04001C41 RID: 7233
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ResourceType>k__BackingField;

	// Token: 0x04001C42 RID: 7234
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;

	// Token: 0x04001C43 RID: 7235
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <InclusiveVolumFrom>k__BackingField;

	// Token: 0x04001C44 RID: 7236
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <InclusiveVolumTo>k__BackingField;

	// Token: 0x04001C45 RID: 7237
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Presence>k__BackingField;
}
