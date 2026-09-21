using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002FF RID: 767
public class WorldMapDefualtHeroController : MonoBehaviour
{
	// Token: 0x0600146E RID: 5230 RVA: 0x000A728C File Offset: 0x000A568C
	public WorldMapDefualtHeroController()
	{
	}

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x0600146F RID: 5231 RVA: 0x000A7294 File Offset: 0x000A5694
	// (set) Token: 0x06001470 RID: 5232 RVA: 0x000A729C File Offset: 0x000A569C
	public int Index
	{
		[CompilerGenerated]
		get
		{
			return this.<Index>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Index>k__BackingField = value;
		}
	}

	// Token: 0x06001471 RID: 5233 RVA: 0x000A72A8 File Offset: 0x000A56A8
	public virtual void Init(AdventurerProfile profile, int index)
	{
		this.Reset();
		if (profile != null)
		{
			this.Index = index;
			this._profile = profile;
			this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(profile.Grade, profile.IsStar());
			this.AvatarImage.sprite = FilePath.GetCharacterBasicAppearance(profile.UnitClass, false).GetStandSprite();
			this.AvatarObj.SetActive(true);
		}
	}

	// Token: 0x06001472 RID: 5234 RVA: 0x000A7313 File Offset: 0x000A5713
	public virtual void Reset()
	{
		this.AvatarObj.SetActive(false);
	}

	// Token: 0x0400149D RID: 5277
	public GameObject AvatarObj;

	// Token: 0x0400149E RID: 5278
	public Image GradeImage;

	// Token: 0x0400149F RID: 5279
	public Image AvatarImage;

	// Token: 0x040014A0 RID: 5280
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Index>k__BackingField;

	// Token: 0x040014A1 RID: 5281
	protected AdventurerProfile _profile;
}
