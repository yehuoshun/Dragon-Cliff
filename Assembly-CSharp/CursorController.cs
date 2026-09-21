using System;
using UnityEngine;

// Token: 0x02000A01 RID: 2561
public class CursorController : MonoBehaviour
{
	// Token: 0x060045AC RID: 17836 RVA: 0x001C2AFA File Offset: 0x001C0EFA
	public CursorController()
	{
	}

	// Token: 0x060045AD RID: 17837 RVA: 0x001C2B0D File Offset: 0x001C0F0D
	private void Start()
	{
		Cursor.SetCursor(this.CursorTexture, Vector2.zero, this.CursorMode);
	}

	// Token: 0x040034FA RID: 13562
	public Texture2D CursorTexture;

	// Token: 0x040034FB RID: 13563
	public CursorMode CursorMode;

	// Token: 0x040034FC RID: 13564
	public Vector2 HotSpot = Vector2.zero;
}
