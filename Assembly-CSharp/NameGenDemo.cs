using System;
using Lexic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000CE RID: 206
public class NameGenDemo : MonoBehaviour
{
	// Token: 0x0600063B RID: 1595 RVA: 0x000626CB File Offset: 0x00060ACB
	public NameGenDemo()
	{
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x000626D4 File Offset: 0x00060AD4
	private void Start()
	{
		this.txt = base.GetComponent<Text>();
		this.namegen = this.nameGenObject.GetComponent<NameGenerator>();
		string text = string.Empty;
		for (int i = 0; i < 10; i++)
		{
			text = text + "\n" + this.namegen.GetNextRandomName();
		}
		this.txt.text = text;
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x0006273A File Offset: 0x00060B3A
	private void Update()
	{
	}

	// Token: 0x04000953 RID: 2387
	public GameObject nameGenObject;

	// Token: 0x04000954 RID: 2388
	private Text txt;

	// Token: 0x04000955 RID: 2389
	private NameGenerator namegen;
}
