using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000125 RID: 293
public class EffectIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000803 RID: 2051 RVA: 0x000747DA File Offset: 0x00072BDA
	public EffectIconController()
	{
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000804 RID: 2052 RVA: 0x000747E2 File Offset: 0x00072BE2
	// (set) Token: 0x06000805 RID: 2053 RVA: 0x000747EA File Offset: 0x00072BEA
	public BattleEffectBase Effect
	{
		[CompilerGenerated]
		get
		{
			return this.<Effect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Effect>k__BackingField = value;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000806 RID: 2054 RVA: 0x000747F3 File Offset: 0x00072BF3
	// (set) Token: 0x06000807 RID: 2055 RVA: 0x000747FB File Offset: 0x00072BFB
	public int CurrentAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentAmount>k__BackingField = value;
		}
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x00074804 File Offset: 0x00072C04
	public void Init(BattleEffectBase effect, bool isPlayer)
	{
		this.Effect = effect;
		this.EffectIconImage.sprite = FilePath.GetEffectIconBy(effect.BattleEffectType);
		this.CurrentAmount = 1;
		this.DispersableDot.SetActive(false);
		if ((this.Effect.CanBeDispersed && isPlayer && effect.BattleEffectNatureForWearer == BattleEffectNature.Negative) || (this.Effect.CanBeDispersed && !isPlayer && effect.BattleEffectNatureForWearer == BattleEffectNature.Positive))
		{
			this.DispersableDot.SetActive(true);
		}
		if (effect.BattleEffectNatureForWearer == BattleEffectNature.Negative)
		{
			this.Frame.color = ColorPicker.NagetiveRed;
		}
		else
		{
			this.Frame.color = ColorPicker.PositiveGreen;
		}
		TextMeshProUGUI componentInChildren = base.GetComponentInChildren<TextMeshProUGUI>();
		if (componentInChildren != null)
		{
			UnityEngine.Object.Destroy(componentInChildren.gameObject);
		}
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x000748E0 File Offset: 0x00072CE0
	public void IncreaseAmount()
	{
		TextMeshProUGUI componentInChildren = base.GetComponentInChildren<TextMeshProUGUI>();
		if (componentInChildren == null)
		{
			TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(Resources.Load<TextMeshProUGUI>(FilePath.CombatScenePath + "EffectAmount"));
			textMeshProUGUI.text = (++this.CurrentAmount).ToString();
			textMeshProUGUI.transform.SetParent(base.transform, false);
		}
		else
		{
			componentInChildren.text = (++this.CurrentAmount).ToString();
		}
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x0007497C File Offset: 0x00072D7C
	public void DecreaseAmount()
	{
		if (this.CurrentAmount > 1)
		{
			TextMeshProUGUI componentInChildren = base.GetComponentInChildren<TextMeshProUGUI>();
			if (componentInChildren == null)
			{
				return;
			}
			if (this.CurrentAmount != 2)
			{
				componentInChildren.text = (--this.CurrentAmount).ToString();
			}
			else
			{
				componentInChildren.text = string.Empty;
				this.CurrentAmount = 1;
			}
		}
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x000749F4 File Offset: 0x00072DF4
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this.Effect.Description;
		string text = description.Details1;
		if (this.Effect.CanBeDispersed)
		{
			text = text + "\n<size=7>\n</size>" + ColorPicker.GetHaxString(ColorPicker.Yellow, UIComponentType.EffectIconCanBeDispersedDescriptoin.GetName());
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = text,
			Position = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(base.transform.position)
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00074A95 File Offset: 0x00072E95
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000AD4 RID: 2772
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleEffectBase <Effect>k__BackingField;

	// Token: 0x04000AD5 RID: 2773
	public Image Frame;

	// Token: 0x04000AD6 RID: 2774
	public Image EffectIconImage;

	// Token: 0x04000AD7 RID: 2775
	public GameObject DispersableDot;

	// Token: 0x04000AD8 RID: 2776
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <CurrentAmount>k__BackingField;
}
