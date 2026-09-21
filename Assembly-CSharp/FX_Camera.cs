using System;
using UnityEngine;

// Token: 0x02000A07 RID: 2567
public class FX_Camera : MonoBehaviour
{
	// Token: 0x0600461B RID: 17947 RVA: 0x001C5B5B File Offset: 0x001C3F5B
	public FX_Camera()
	{
	}

	// Token: 0x0600461C RID: 17948 RVA: 0x001C5B63 File Offset: 0x001C3F63
	private void Start()
	{
		CameraEffect.CameraFX = this;
		this._positionTemp = base.transform.position;
	}

	// Token: 0x0600461D RID: 17949 RVA: 0x001C5B7C File Offset: 0x001C3F7C
	public void UpdateCameraLocation(Vector3 position, float orthographicSize)
	{
		base.transform.position = position;
		base.GetComponent<Camera>().orthographicSize = orthographicSize;
		this._positionTemp = position;
	}

	// Token: 0x0600461E RID: 17950 RVA: 0x001C5B9D File Offset: 0x001C3F9D
	public void Shake(Vector3 power)
	{
		this._forcePower = -power * 4f;
	}

	// Token: 0x0600461F RID: 17951 RVA: 0x001C5BB8 File Offset: 0x001C3FB8
	private void Update()
	{
		this._forcePower = Vector3.Lerp(this._forcePower, Vector3.zero, Time.deltaTime * 5f);
		base.transform.position = this._positionTemp + new Vector3(Mathf.Cos(Time.time * 80f) * this._forcePower.x, Mathf.Cos(Time.time * 80f) * this._forcePower.y, Mathf.Cos(Time.time * 80f) * this._forcePower.z);
	}

	// Token: 0x04003524 RID: 13604
	private Vector3 _positionTemp;

	// Token: 0x04003525 RID: 13605
	private Vector3 _forcePower;
}
