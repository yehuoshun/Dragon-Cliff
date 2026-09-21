using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000227 RID: 551
public class PageHeroController : PageCharacterController
{
	// Token: 0x06000E61 RID: 3681 RVA: 0x00071B78 File Offset: 0x0006FF78
	public PageHeroController()
	{
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x06000E62 RID: 3682 RVA: 0x00071B80 File Offset: 0x0006FF80
	// (set) Token: 0x06000E63 RID: 3683 RVA: 0x00071B88 File Offset: 0x0006FF88
	public PageHero PageHero
	{
		[CompilerGenerated]
		get
		{
			return this.<PageHero>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PageHero>k__BackingField = value;
		}
	}

	// Token: 0x06000E64 RID: 3684 RVA: 0x00071B91 File Offset: 0x0006FF91
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.PageHero = (PageHero)item;
	}

	// Token: 0x04001002 RID: 4098
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageHero <PageHero>k__BackingField;
}
