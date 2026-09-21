using System;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000354 RID: 852
public class BattleOptionCard : SelectableCardController
{
	// Token: 0x060016B3 RID: 5811 RVA: 0x000B2731 File Offset: 0x000B0B31
	public BattleOptionCard()
	{
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x000B2739 File Offset: 0x000B0B39
	private void Start()
	{
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.Select));
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x000B2764 File Offset: 0x000B0B64
	public void InitIndividualBattleOptions(IBattleOption battleOption)
	{
		this._battleOption = battleOption;
		this.CardTitle.text = battleOption.GetDescription().Title;
		this.CardDescription.text = battleOption.GetDescription().Details1;
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x000B2799 File Offset: 0x000B0B99
	public override void Select()
	{
		CombatManager.Instance.SetSelectedBattleOption(this._battleOption);
	}

	// Token: 0x040016C1 RID: 5825
	private IBattleOption _battleOption;

	// Token: 0x040016C2 RID: 5826
	private Button _button;
}
