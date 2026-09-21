using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class KeyBoardSettingPanelController : MonoBehaviour
{
	// Token: 0x060011FE RID: 4606 RVA: 0x0009CBBF File Offset: 0x0009AFBF
	public KeyBoardSettingPanelController()
	{
	}

	// Token: 0x060011FF RID: 4607 RVA: 0x0009CBD7 File Offset: 0x0009AFD7
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06001200 RID: 4608 RVA: 0x0009CBE0 File Offset: 0x0009AFE0
	public void Init()
	{
		this.Tactic1.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic1);
		this.Tactic2.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic2);
		this.Tactic3.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic3);
		this.Tactic4.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic4);
		this.Tactic5.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic5);
	}

	// Token: 0x06001201 RID: 4609 RVA: 0x0009CC58 File Offset: 0x0009B058
	public void OnTactic1()
	{
		if (this._regex.IsMatch(this.Tactic1.text))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic1, this.Tactic1.text.ToUpper());
		}
		this.Tactic1.DeactivateInputField();
		this.Tactic1.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic1);
	}

	// Token: 0x06001202 RID: 4610 RVA: 0x0009CCBC File Offset: 0x0009B0BC
	public void OnTactic2()
	{
		if (this._regex.IsMatch(this.Tactic2.text))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic2, this.Tactic2.text.ToUpper());
		}
		this.Tactic2.DeactivateInputField();
		this.Tactic2.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic2);
	}

	// Token: 0x06001203 RID: 4611 RVA: 0x0009CD20 File Offset: 0x0009B120
	public void OnTactic3()
	{
		if (this._regex.IsMatch(this.Tactic3.text))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic3, this.Tactic3.text.ToUpper());
		}
		this.Tactic3.DeactivateInputField();
		this.Tactic3.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic3);
	}

	// Token: 0x06001204 RID: 4612 RVA: 0x0009CD84 File Offset: 0x0009B184
	public void OnTactic4()
	{
		if (this._regex.IsMatch(this.Tactic4.text))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic4, this.Tactic4.text.ToUpper());
		}
		this.Tactic4.DeactivateInputField();
		this.Tactic4.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic4);
	}

	// Token: 0x06001205 RID: 4613 RVA: 0x0009CDE8 File Offset: 0x0009B1E8
	public void OnTactic5()
	{
		if (this._regex.IsMatch(this.Tactic5.text))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic5, this.Tactic5.text.ToUpper());
		}
		this.Tactic5.DeactivateInputField();
		this.Tactic5.text = PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic5);
	}

	// Token: 0x06001206 RID: 4614 RVA: 0x0009CE4C File Offset: 0x0009B24C
	private bool KeyAlreadyUsed(string key)
	{
		key = key.ToUpper();
		return key == PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic1) || key == PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic2) || key == PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic3) || key == PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic4) || key == PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic5);
	}

	// Token: 0x040012DA RID: 4826
	public TMP_InputField Tactic1;

	// Token: 0x040012DB RID: 4827
	public TMP_InputField Tactic2;

	// Token: 0x040012DC RID: 4828
	public TMP_InputField Tactic3;

	// Token: 0x040012DD RID: 4829
	public TMP_InputField Tactic4;

	// Token: 0x040012DE RID: 4830
	public TMP_InputField Tactic5;

	// Token: 0x040012DF RID: 4831
	private readonly Regex _regex = new Regex("^[a-zA-Z0-9]$");
}
