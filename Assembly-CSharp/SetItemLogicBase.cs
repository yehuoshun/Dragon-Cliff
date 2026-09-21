using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006A8 RID: 1704
public abstract class SetItemLogicBase
{
	// Token: 0x06002D2F RID: 11567 RVA: 0x00126B4F File Offset: 0x00124F4F
	protected SetItemLogicBase()
	{
	}

	// Token: 0x170005B0 RID: 1456
	// (get) Token: 0x06002D30 RID: 11568
	public abstract ResourceType CorrespondingSetResourceType { get; }

	// Token: 0x06002D31 RID: 11569 RVA: 0x00126B57 File Offset: 0x00124F57
	public bool SetRequirementMet(List<Item> gears)
	{
		return gears.Sum((Item g) => g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType)) >= 2;
	}

	// Token: 0x06002D32 RID: 11570 RVA: 0x00126B71 File Offset: 0x00124F71
	public List<AttributeModifier> GetMinorSetAttributeModifiers(List<Item> gears)
	{
		if (gears.Sum((Item g) => g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType)) >= 2)
		{
			return this.MinorAttributeModifiers();
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D33 RID: 11571 RVA: 0x00126B97 File Offset: 0x00124F97
	public List<ISpecialEffectDataLoad> GetMinorSetEffectDataLoads(List<Item> gears)
	{
		if (gears.Sum((Item g) => g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType)) >= 2)
		{
			return this.MinorEffects();
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D34 RID: 11572 RVA: 0x00126BBD File Offset: 0x00124FBD
	public List<AttributeModifier> GetMajorSetAttributeModifiers(List<Item> gears)
	{
		if (gears.Sum((Item g) => g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType)) >= 4)
		{
			return this.MajorAttributeModifiers();
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x06002D35 RID: 11573 RVA: 0x00126BE3 File Offset: 0x00124FE3
	public List<ISpecialEffectDataLoad> GetMajorSetEffectDataLoads(List<Item> gears)
	{
		if (gears.Sum((Item g) => g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType)) >= 4)
		{
			return this.MajorEffects();
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002D36 RID: 11574
	public abstract List<AttributeModifier> MinorAttributeModifiers();

	// Token: 0x06002D37 RID: 11575
	public abstract List<AttributeModifier> MajorAttributeModifiers();

	// Token: 0x06002D38 RID: 11576
	public abstract List<ISpecialEffectDataLoad> MinorEffects();

	// Token: 0x06002D39 RID: 11577
	public abstract List<ISpecialEffectDataLoad> MajorEffects();

	// Token: 0x06002D3A RID: 11578 RVA: 0x00126C09 File Offset: 0x00125009
	[CompilerGenerated]
	private int <SetRequirementMet>m__0(Item g)
	{
		return g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType);
	}

	// Token: 0x06002D3B RID: 11579 RVA: 0x00126C22 File Offset: 0x00125022
	[CompilerGenerated]
	private int <GetMinorSetAttributeModifiers>m__1(Item g)
	{
		return g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType);
	}

	// Token: 0x06002D3C RID: 11580 RVA: 0x00126C3B File Offset: 0x0012503B
	[CompilerGenerated]
	private int <GetMinorSetEffectDataLoads>m__2(Item g)
	{
		return g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType);
	}

	// Token: 0x06002D3D RID: 11581 RVA: 0x00126C54 File Offset: 0x00125054
	[CompilerGenerated]
	private int <GetMajorSetAttributeModifiers>m__3(Item g)
	{
		return g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType);
	}

	// Token: 0x06002D3E RID: 11582 RVA: 0x00126C6D File Offset: 0x0012506D
	[CompilerGenerated]
	private int <GetMajorSetEffectDataLoads>m__4(Item g)
	{
		return g.Sockets.Count((ItemSocket s) => s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType);
	}

	// Token: 0x06002D3F RID: 11583 RVA: 0x00126C86 File Offset: 0x00125086
	[CompilerGenerated]
	private bool <SetRequirementMet>m__5(ItemSocket s)
	{
		return s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType;
	}

	// Token: 0x06002D40 RID: 11584 RVA: 0x00126CB3 File Offset: 0x001250B3
	[CompilerGenerated]
	private bool <GetMinorSetAttributeModifiers>m__6(ItemSocket s)
	{
		return s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType;
	}

	// Token: 0x06002D41 RID: 11585 RVA: 0x00126CE0 File Offset: 0x001250E0
	[CompilerGenerated]
	private bool <GetMinorSetEffectDataLoads>m__7(ItemSocket s)
	{
		return s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType;
	}

	// Token: 0x06002D42 RID: 11586 RVA: 0x00126D0D File Offset: 0x0012510D
	[CompilerGenerated]
	private bool <GetMajorSetAttributeModifiers>m__8(ItemSocket s)
	{
		return s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType;
	}

	// Token: 0x06002D43 RID: 11587 RVA: 0x00126D3A File Offset: 0x0012513A
	[CompilerGenerated]
	private bool <GetMajorSetEffectDataLoads>m__9(ItemSocket s)
	{
		return s.Gem is Item && (s.Gem as Item).Type == this.CorrespondingSetResourceType;
	}
}
