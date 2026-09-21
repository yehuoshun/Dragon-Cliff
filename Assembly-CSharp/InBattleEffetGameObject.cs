using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200035C RID: 860
public class InBattleEffetGameObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001708 RID: 5896 RVA: 0x000B4A24 File Offset: 0x000B2E24
	public InBattleEffetGameObject()
	{
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x000B4A2C File Offset: 0x000B2E2C
	private void Awake()
	{
		this._background = base.GetComponent<Image>();
		this._pointerIn = false;
		if (this.EffectsCount != null)
		{
			this.EffectsCount.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x000B4A63 File Offset: 0x000B2E63
	private void Update()
	{
		if (this._pointerIn && this._battleEffect != null)
		{
			this.UpdateEffectInfo();
		}
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000B4A81 File Offset: 0x000B2E81
	public BattleEffectBase GetBattleEffect()
	{
		return this._battleEffect;
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x000B4A8C File Offset: 0x000B2E8C
	public void SetBattleEffect(BattleEffectBase BattleEffect)
	{
		this._battleEffect = BattleEffect;
		this.EffectIcon.sprite = FilePath.GetEffectIconBy(this._battleEffect.BattleEffectType);
		this._background.sprite = FilePath.GetSkillEffectNatureBackground(this._battleEffect.BattleEffectNatureForWearer);
		this.EffectCountLable.fontMaterial = FilePath.GetMaterialByBattleEffectNature(BattleEffect.BattleEffectNatureForWearer);
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x000B4AEC File Offset: 0x000B2EEC
	public void OnPointerEnter(PointerEventData eventData)
	{
		this._pointerIn = true;
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x000B4AF5 File Offset: 0x000B2EF5
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
		this._pointerIn = false;
	}

	// Token: 0x0600170F RID: 5903 RVA: 0x000B4B04 File Offset: 0x000B2F04
	public void EffectExpired()
	{
		this.BattleFinished();
		GameObjectUtil.RecycleDestroy(base.gameObject);
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x000B4B18 File Offset: 0x000B2F18
	private void UpdateEffectInfo()
	{
		if (this._battleEffect == null)
		{
			return;
		}
		Description description = this._battleEffect.Description;
		string title = description.Title;
		string text = (this._battleEffect.NumberOfLastingTurns == null) ? string.Empty : ("\nCanLastTurn: " + this._battleEffect.NumberOfLastingTurns);
		string description2 = string.Concat(new object[]
		{
			description.Details1,
			text,
			"\nCan be Dispersed: ",
			this._battleEffect.CanBeDispersed,
			"\nCausing Source: ",
			this._battleEffect.EffectSource.GetType().Name,
			"\n最多层数: ",
			this._battleEffect.MaxStackableInstances,
			"\nCaster: ",
			this._battleEffect.EffectSource.SourceUnit.GetUnitType().GetDescription().Title
		});
		this.OpenTooltip(new TooltipItem
		{
			Title = title,
			Description = description2,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x000B4C5B File Offset: 0x000B305B
	private void BattleFinished()
	{
		this._pointerIn = false;
		this.CloseTooltip();
	}

	// Token: 0x04001716 RID: 5910
	public Image EffectIcon;

	// Token: 0x04001717 RID: 5911
	public Text EffectsCount;

	// Token: 0x04001718 RID: 5912
	private BattleEffectBase _battleEffect;

	// Token: 0x04001719 RID: 5913
	public TextMeshProUGUI EffectCountLable;

	// Token: 0x0400171A RID: 5914
	private Image _background;

	// Token: 0x0400171B RID: 5915
	private bool _pointerIn;
}
