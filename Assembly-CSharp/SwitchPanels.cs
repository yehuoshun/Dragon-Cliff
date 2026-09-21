using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000BB0 RID: 2992
public class SwitchPanels : MonoBehaviour
{
	// Token: 0x06004F76 RID: 20342 RVA: 0x00207457 File Offset: 0x00205857
	public SwitchPanels()
	{
	}

	// Token: 0x06004F77 RID: 20343 RVA: 0x00207460 File Offset: 0x00205860
	private void Awake()
	{
		Toggle component = base.GetComponent<Toggle>();
		component.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleClick));
	}

	// Token: 0x06004F78 RID: 20344 RVA: 0x0020748B File Offset: 0x0020588B
	public void OnToggleClick(bool isActive)
	{
		this.Menu.SetActive(isActive);
		this.Panel.SetActive(!isActive);
	}

	// Token: 0x04003D2B RID: 15659
	public GameObject Menu;

	// Token: 0x04003D2C RID: 15660
	public GameObject Panel;
}
