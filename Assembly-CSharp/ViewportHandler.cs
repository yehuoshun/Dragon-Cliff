using System;
using UnityEngine;

// Token: 0x02000A25 RID: 2597
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ViewportHandler : MonoBehaviour
{
	// Token: 0x060046BF RID: 18111 RVA: 0x001CFA89 File Offset: 0x001CDE89
	public ViewportHandler()
	{
	}

	// Token: 0x17000DC1 RID: 3521
	// (get) Token: 0x060046C0 RID: 18112 RVA: 0x001CFAAE File Offset: 0x001CDEAE
	public float Width
	{
		get
		{
			return this._width;
		}
	}

	// Token: 0x17000DC2 RID: 3522
	// (get) Token: 0x060046C1 RID: 18113 RVA: 0x001CFAB6 File Offset: 0x001CDEB6
	public float Height
	{
		get
		{
			return this._height;
		}
	}

	// Token: 0x17000DC3 RID: 3523
	// (get) Token: 0x060046C2 RID: 18114 RVA: 0x001CFABE File Offset: 0x001CDEBE
	public Vector3 BottomLeft
	{
		get
		{
			return this._bl;
		}
	}

	// Token: 0x17000DC4 RID: 3524
	// (get) Token: 0x060046C3 RID: 18115 RVA: 0x001CFAC6 File Offset: 0x001CDEC6
	public Vector3 BottomCenter
	{
		get
		{
			return this._bc;
		}
	}

	// Token: 0x17000DC5 RID: 3525
	// (get) Token: 0x060046C4 RID: 18116 RVA: 0x001CFACE File Offset: 0x001CDECE
	public Vector3 BottomRight
	{
		get
		{
			return this._br;
		}
	}

	// Token: 0x17000DC6 RID: 3526
	// (get) Token: 0x060046C5 RID: 18117 RVA: 0x001CFAD6 File Offset: 0x001CDED6
	public Vector3 MiddleLeft
	{
		get
		{
			return this._ml;
		}
	}

	// Token: 0x17000DC7 RID: 3527
	// (get) Token: 0x060046C6 RID: 18118 RVA: 0x001CFADE File Offset: 0x001CDEDE
	public Vector3 MiddleCenter
	{
		get
		{
			return this._mc;
		}
	}

	// Token: 0x17000DC8 RID: 3528
	// (get) Token: 0x060046C7 RID: 18119 RVA: 0x001CFAE6 File Offset: 0x001CDEE6
	public Vector3 MiddleRight
	{
		get
		{
			return this._mr;
		}
	}

	// Token: 0x17000DC9 RID: 3529
	// (get) Token: 0x060046C8 RID: 18120 RVA: 0x001CFAEE File Offset: 0x001CDEEE
	public Vector3 TopLeft
	{
		get
		{
			return this._tl;
		}
	}

	// Token: 0x17000DCA RID: 3530
	// (get) Token: 0x060046C9 RID: 18121 RVA: 0x001CFAF6 File Offset: 0x001CDEF6
	public Vector3 TopCenter
	{
		get
		{
			return this._tc;
		}
	}

	// Token: 0x17000DCB RID: 3531
	// (get) Token: 0x060046CA RID: 18122 RVA: 0x001CFAFE File Offset: 0x001CDEFE
	public Vector3 TopRight
	{
		get
		{
			return this._tr;
		}
	}

	// Token: 0x060046CB RID: 18123 RVA: 0x001CFB06 File Offset: 0x001CDF06
	private void Awake()
	{
		this.camera = base.GetComponent<Camera>();
		ViewportHandler.Instance = this;
		this.ComputeResolution();
	}

	// Token: 0x060046CC RID: 18124 RVA: 0x001CFB20 File Offset: 0x001CDF20
	private void ComputeResolution()
	{
		if (this.constraint == ViewportHandler.Constraint.Landscape)
		{
			this.camera.orthographicSize = 1f / this.camera.aspect * this.UnitsSize / 2f;
		}
		else
		{
			this.camera.orthographicSize = this.UnitsSize / 2f;
		}
		this._height = 2f * this.camera.orthographicSize;
		this._width = this._height * this.camera.aspect;
		float x = this.camera.transform.position.x;
		float y = this.camera.transform.position.y;
		float x2 = x - this._width / 2f;
		float x3 = x + this._width / 2f;
		float y2 = y + this._height / 2f;
		float y3 = y - this._height / 2f;
		this._bl = new Vector3(x2, y3, 0f);
		this._bc = new Vector3(x, y3, 0f);
		this._br = new Vector3(x3, y3, 0f);
		this._ml = new Vector3(x2, y, 0f);
		this._mc = new Vector3(x, y, 0f);
		this._mr = new Vector3(x3, y, 0f);
		this._tl = new Vector3(x2, y2, 0f);
		this._tc = new Vector3(x, y2, 0f);
		this._tr = new Vector3(x3, y2, 0f);
	}

	// Token: 0x060046CD RID: 18125 RVA: 0x001CFCCA File Offset: 0x001CE0CA
	private void Update()
	{
	}

	// Token: 0x060046CE RID: 18126 RVA: 0x001CFCCC File Offset: 0x001CE0CC
	private void OnDrawGizmos()
	{
		Gizmos.color = this.wireColor;
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
		if (this.camera.orthographic)
		{
			float z = this.camera.farClipPlane - this.camera.nearClipPlane;
			float z2 = (this.camera.farClipPlane + this.camera.nearClipPlane) * 0.5f;
			Gizmos.DrawWireCube(new Vector3(0f, 0f, z2), new Vector3(this.camera.orthographicSize * 2f * this.camera.aspect, this.camera.orthographicSize * 2f, z));
		}
		else
		{
			Gizmos.DrawFrustum(Vector3.zero, this.camera.fieldOfView, this.camera.farClipPlane, this.camera.nearClipPlane, this.camera.aspect);
		}
		Gizmos.matrix = matrix;
	}

	// Token: 0x040038F9 RID: 14585
	public Color wireColor = Color.white;

	// Token: 0x040038FA RID: 14586
	public float UnitsSize = 1f;

	// Token: 0x040038FB RID: 14587
	public ViewportHandler.Constraint constraint = ViewportHandler.Constraint.Portrait;

	// Token: 0x040038FC RID: 14588
	public static ViewportHandler Instance;

	// Token: 0x040038FD RID: 14589
	public Camera camera;

	// Token: 0x040038FE RID: 14590
	private float _width;

	// Token: 0x040038FF RID: 14591
	private float _height;

	// Token: 0x04003900 RID: 14592
	private Vector3 _bl;

	// Token: 0x04003901 RID: 14593
	private Vector3 _bc;

	// Token: 0x04003902 RID: 14594
	private Vector3 _br;

	// Token: 0x04003903 RID: 14595
	private Vector3 _ml;

	// Token: 0x04003904 RID: 14596
	private Vector3 _mc;

	// Token: 0x04003905 RID: 14597
	private Vector3 _mr;

	// Token: 0x04003906 RID: 14598
	private Vector3 _tl;

	// Token: 0x04003907 RID: 14599
	private Vector3 _tc;

	// Token: 0x04003908 RID: 14600
	private Vector3 _tr;

	// Token: 0x02000A26 RID: 2598
	public enum Constraint
	{
		// Token: 0x0400390A RID: 14602
		Landscape,
		// Token: 0x0400390B RID: 14603
		Portrait
	}
}
