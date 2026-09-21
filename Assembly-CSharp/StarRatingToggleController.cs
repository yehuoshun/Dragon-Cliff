using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000207 RID: 519
public class StarRatingToggleController : MonoBehaviour
{
	// Token: 0x06000DC6 RID: 3526 RVA: 0x0008FC97 File Offset: 0x0008E097
	public StarRatingToggleController()
	{
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x0008FCA0 File Offset: 0x0008E0A0
	public void Init(int level, SaveRecordController parent)
	{
		this._level = level;
		this._record = parent;
		if (level != 1)
		{
			if (level == 2)
			{
				this.DifficultyValue.text = UIComponentType.DifficultyLevel2.GetName();
			}
		}
		else
		{
			this.DifficultyValue.text = UIComponentType.DifficultyLevel1.GetName();
		}
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x0008FD02 File Offset: 0x0008E102
	public void SetToggle(int selectedLevel)
	{
		this.StarToggle.isOn = (this._level == selectedLevel);
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x0008FD18 File Offset: 0x0008E118
	public void Toggle()
	{
		if (this.StarToggle.isOn)
		{
			this._record.SelectStarRating(this._level);
		}
		else
		{
			this._record.DeselectStarRating();
		}
	}

	// Token: 0x04000FBA RID: 4026
	public TextMeshProUGUI DifficultyValue;

	// Token: 0x04000FBB RID: 4027
	public Toggle StarToggle;

	// Token: 0x04000FBC RID: 4028
	private int _level;

	// Token: 0x04000FBD RID: 4029
	private SaveRecordController _record;
}
