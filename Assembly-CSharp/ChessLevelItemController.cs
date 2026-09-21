using System;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002E5 RID: 741
public class ChessLevelItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060013AF RID: 5039 RVA: 0x000A44D1 File Offset: 0x000A28D1
	public ChessLevelItemController()
	{
	}

	// Token: 0x060013B0 RID: 5040 RVA: 0x000A44DC File Offset: 0x000A28DC
	public void Init(AdventureType adventure, int level)
	{
		this.Text.text = level.ToString();
		this._adventure = adventure;
		this._level = level;
		this.BackgroundFrame.sprite = this.NormalSprite;
		this.StarImage.color = Color.white;
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x000A4530 File Offset: 0x000A2930
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._adventure.GetLevelDetails().Any((DungeonLevelDetails l) => l.LevelNumber == this._level))
		{
			this.BackgroundFrame.sprite = this.SelectedSprite;
			this.StarImage.color = Color.red;
		}
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x000A4580 File Offset: 0x000A2980
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this._adventure.GetLevelDetails().Any((DungeonLevelDetails l) => l.LevelNumber == this._level))
		{
			this.BackgroundFrame.sprite = this.NormalSprite;
			this.StarImage.color = Color.white;
		}
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x000A45CF File Offset: 0x000A29CF
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._adventure.GetLevelDetails().Any((DungeonLevelDetails l) => l.LevelNumber == this._level))
		{
			base.GetComponentInParent<WorldMapController>().SelectLevelFromChessLevelItem(this._adventure, this._level);
		}
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x000A4609 File Offset: 0x000A2A09
	[CompilerGenerated]
	private bool <OnPointerEnter>m__0(DungeonLevelDetails l)
	{
		return l.LevelNumber == this._level;
	}

	// Token: 0x060013B5 RID: 5045 RVA: 0x000A4619 File Offset: 0x000A2A19
	[CompilerGenerated]
	private bool <OnPointerExit>m__1(DungeonLevelDetails l)
	{
		return l.LevelNumber == this._level;
	}

	// Token: 0x060013B6 RID: 5046 RVA: 0x000A4629 File Offset: 0x000A2A29
	[CompilerGenerated]
	private bool <OnPointerClick>m__2(DungeonLevelDetails l)
	{
		return l.LevelNumber == this._level;
	}

	// Token: 0x04001427 RID: 5159
	public TextMeshProUGUI Text;

	// Token: 0x04001428 RID: 5160
	public Image BackgroundFrame;

	// Token: 0x04001429 RID: 5161
	public Image StarImage;

	// Token: 0x0400142A RID: 5162
	public Sprite NormalSprite;

	// Token: 0x0400142B RID: 5163
	public Sprite SelectedSprite;

	// Token: 0x0400142C RID: 5164
	private AdventureType _adventure;

	// Token: 0x0400142D RID: 5165
	private int _level;
}
