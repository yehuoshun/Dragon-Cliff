using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000331 RID: 817
public class LevelSelectable : MonoBehaviour
{
	// Token: 0x060015BC RID: 5564 RVA: 0x000ACA1C File Offset: 0x000AAE1C
	public LevelSelectable()
	{
	}

	// Token: 0x060015BD RID: 5565 RVA: 0x000ACA24 File Offset: 0x000AAE24
	public int GetLevel()
	{
		return this._thisLevel;
	}

	// Token: 0x060015BE RID: 5566 RVA: 0x000ACA2C File Offset: 0x000AAE2C
	private void Awake()
	{
		this._background = base.GetComponent<Image>();
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.ClickOnThisLevel));
	}

	// Token: 0x060015BF RID: 5567 RVA: 0x000ACA64 File Offset: 0x000AAE64
	public void SetDungeonRecord(DungeonRecord record, int level, AdventureLevelSelectionControl control)
	{
		this._thisLevel = level;
		this._record = record;
		this._control = control;
		this.Level.text = "Level " + level;
		this.Display.color = ((level > record.CurrentAchievedLevel) ? Color.red : Color.green);
	}

	// Token: 0x060015C0 RID: 5568 RVA: 0x000ACAC8 File Offset: 0x000AAEC8
	public void CheckSelectionState()
	{
		if (this._thisLevel > this._record.CurrentAchievedLevel + 1)
		{
			this._background.color = Color.grey;
			this._isUnlocked = false;
		}
		else
		{
			this._isUnlocked = true;
			this.DeSelect();
		}
		if (this._record.CurrentSelectedLevel == this._thisLevel)
		{
			this.ClickOnThisLevel();
		}
	}

	// Token: 0x060015C1 RID: 5569 RVA: 0x000ACB32 File Offset: 0x000AAF32
	public void DeSelect()
	{
		this._background.color = Color.white;
	}

	// Token: 0x060015C2 RID: 5570 RVA: 0x000ACB44 File Offset: 0x000AAF44
	public void OnSelect()
	{
		this._background.color = Color.yellow;
	}

	// Token: 0x060015C3 RID: 5571 RVA: 0x000ACB56 File Offset: 0x000AAF56
	private void ClickOnThisLevel()
	{
		if (this._isUnlocked)
		{
			this._control.SelectedLevel(this._thisLevel);
		}
		else
		{
			Debug.Log("Did not unlock yet");
		}
	}

	// Token: 0x040015DA RID: 5594
	public Text Level;

	// Token: 0x040015DB RID: 5595
	public Image Display;

	// Token: 0x040015DC RID: 5596
	private Button _button;

	// Token: 0x040015DD RID: 5597
	private Image _background;

	// Token: 0x040015DE RID: 5598
	private AdventureLevelSelectionControl _control;

	// Token: 0x040015DF RID: 5599
	private DungeonRecord _record;

	// Token: 0x040015E0 RID: 5600
	private int _thisLevel;

	// Token: 0x040015E1 RID: 5601
	private bool _isUnlocked;
}
