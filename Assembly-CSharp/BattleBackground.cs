using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class BattleBackground : MonoBehaviour
{
	// Token: 0x060006D2 RID: 1746 RVA: 0x0006A39A File Offset: 0x0006879A
	public BattleBackground()
	{
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0006A3A2 File Offset: 0x000687A2
	public void StopMoving()
	{
		this._animatedTextures.ForEach(delegate(AnimatedTexture a)
		{
			a.StopMoving();
		});
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0006A3CC File Offset: 0x000687CC
	public void ContinueMoving()
	{
		this._animatedTextures.ForEach(delegate(AnimatedTexture a)
		{
			a.ContinueMoving();
		});
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0006A3F6 File Offset: 0x000687F6
	[CompilerGenerated]
	private static void <StopMoving>m__0(AnimatedTexture a)
	{
		a.StopMoving();
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0006A3FE File Offset: 0x000687FE
	[CompilerGenerated]
	private static void <ContinueMoving>m__1(AnimatedTexture a)
	{
		a.ContinueMoving();
	}

	// Token: 0x040009E8 RID: 2536
	[SerializeField]
	public AdventureType AdventureType;

	// Token: 0x040009E9 RID: 2537
	[SerializeField]
	private List<AnimatedTexture> _animatedTextures;

	// Token: 0x040009EA RID: 2538
	[CompilerGenerated]
	private static Action<AnimatedTexture> <>f__am$cache0;

	// Token: 0x040009EB RID: 2539
	[CompilerGenerated]
	private static Action<AnimatedTexture> <>f__am$cache1;
}
