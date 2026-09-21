using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002EC RID: 748
public class LevelSelectionItemController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060013DA RID: 5082 RVA: 0x000A4C75 File Offset: 0x000A3075
	public LevelSelectionItemController()
	{
	}

	// Token: 0x060013DB RID: 5083 RVA: 0x000A4C80 File Offset: 0x000A3080
	public void Init(DungeonLevelDetails previoursDun, DungeonLevelDetails dungeon, bool selected)
	{
		this._dungeon = dungeon;
		this._changingLevel = (previoursDun != null && (previoursDun.GemLevel == dungeon.GemLevel - 1 || previoursDun.EquipmentLevel == dungeon.EquipmentLevel - 1));
		this.Background.sprite = ((!this._changingLevel) ? this.NormalSprite : this.ChangingLevelSprite);
		this.LevelText.text = dungeon.LevelNumber.ToString();
		this.SelectedFrame.SetActive(selected);
	}

	// Token: 0x060013DC RID: 5084 RVA: 0x000A4D1B File Offset: 0x000A311B
	public void SelectLevel(int selectedLevel)
	{
		this.SelectedFrame.SetActive(selectedLevel == this._dungeon.LevelNumber);
	}

	// Token: 0x060013DD RID: 5085 RVA: 0x000A4D36 File Offset: 0x000A3136
	public void InitSpecial(int level, string text, bool selected)
	{
		this._level = level;
		this.SelectedFrame.SetActive(selected);
		this.LevelText.text = text;
	}

	// Token: 0x060013DE RID: 5086 RVA: 0x000A4D57 File Offset: 0x000A3157
	public void OnPointerClick(PointerEventData eventData)
	{
		if (!this.IsSpecialItem)
		{
			base.GetComponentInParent<WorldMapController>().SelectLevel(this._dungeon, this._changingLevel);
		}
		else
		{
			base.GetComponentInParent<WorldMapController>().UpdateSpecialLevelSelectionPanel(this._level);
		}
	}

	// Token: 0x04001440 RID: 5184
	public Image Background;

	// Token: 0x04001441 RID: 5185
	public TextMeshProUGUI LevelText;

	// Token: 0x04001442 RID: 5186
	public Sprite NormalSprite;

	// Token: 0x04001443 RID: 5187
	public Sprite ChangingLevelSprite;

	// Token: 0x04001444 RID: 5188
	public bool IsSpecialItem;

	// Token: 0x04001445 RID: 5189
	public GameObject SelectedFrame;

	// Token: 0x04001446 RID: 5190
	private DungeonLevelDetails _dungeon;

	// Token: 0x04001447 RID: 5191
	private int _level;

	// Token: 0x04001448 RID: 5192
	private bool _changingLevel;
}
