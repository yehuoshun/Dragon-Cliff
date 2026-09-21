using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000148 RID: 328
public class CloudySystemController : MonoBehaviour
{
	// Token: 0x060008FF RID: 2303 RVA: 0x00079132 File Offset: 0x00077532
	public CloudySystemController()
	{
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x0007915C File Offset: 0x0007755C
	private void Update()
	{
		this._timer += Time.deltaTime;
		if (this._timer > this.NewCloudTime)
		{
			if (UnityEngine.Random.value < this.CloudThreshold)
			{
				this.GenerateCloud();
			}
			this._timer = 0f;
		}
		foreach (WeatherCloud weatherCloud in this._currentClouds)
		{
			if (weatherCloud.PassScreen(this.EndPointX))
			{
				this._removable.Add(weatherCloud);
			}
		}
		this._currentClouds.RemoveAll((WeatherCloud c) => this._removable.Contains(c));
		foreach (WeatherCloud weatherCloud2 in this._removable)
		{
			UnityEngine.Object.Destroy(weatherCloud2.CloudObj.gameObject);
		}
		this._removable.Clear();
		foreach (WeatherCloud weatherCloud3 in this._currentClouds)
		{
			float maxDistanceDelta = weatherCloud3.Speed * Time.deltaTime;
			Vector3 target = new Vector3(this.EndPointX, weatherCloud3.CloudObj.transform.position.y, 1f);
			weatherCloud3.CloudObj.transform.position = Vector3.MoveTowards(weatherCloud3.CloudObj.transform.position, target, maxDistanceDelta);
		}
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x00079338 File Offset: 0x00077738
	private void GenerateCloud()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.PickCloud());
		gameObject.transform.SetParent(this.CloudScreen.transform);
		float num = UnityEngine.Random.Range(this.CloudMinSize, this.CloudMaxSize);
		gameObject.transform.localScale = new Vector3(num, num, 1f);
		gameObject.transform.position = new Vector3(this.StartPointX, UnityEngine.Random.Range(this.PositionMinY, this.PositionMaxY));
		gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, UnityEngine.Random.Range(this.CloudColorMinAlpha / 255f, this.CloudColorMaxAlpha / 255f));
		gameObject.SetActive(true);
		this._currentClouds.Add(new WeatherCloud
		{
			CloudObj = gameObject,
			Speed = UnityEngine.Random.Range(this.CloudMinSpeed, this.CloudMaxSpeed)
		});
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x0007942A File Offset: 0x0007782A
	private GameObject PickCloud()
	{
		return this.Clouds[UnityEngine.Random.Range(0, this.Clouds.Count - 1)];
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x0007944A File Offset: 0x0007784A
	[CompilerGenerated]
	private bool <Update>m__0(WeatherCloud c)
	{
		return this._removable.Contains(c);
	}

	// Token: 0x04000B99 RID: 2969
	public GameObject CloudScreen;

	// Token: 0x04000B9A RID: 2970
	public List<GameObject> Clouds;

	// Token: 0x04000B9B RID: 2971
	public float PositionMinY;

	// Token: 0x04000B9C RID: 2972
	public float PositionMaxY;

	// Token: 0x04000B9D RID: 2973
	public float StartPointX;

	// Token: 0x04000B9E RID: 2974
	public float EndPointX;

	// Token: 0x04000B9F RID: 2975
	public float CloudMinSize;

	// Token: 0x04000BA0 RID: 2976
	public float CloudMaxSize;

	// Token: 0x04000BA1 RID: 2977
	public float CloudColorMinAlpha;

	// Token: 0x04000BA2 RID: 2978
	public float CloudColorMaxAlpha;

	// Token: 0x04000BA3 RID: 2979
	public float NewCloudTime;

	// Token: 0x04000BA4 RID: 2980
	public float CloudThreshold = 0.5f;

	// Token: 0x04000BA5 RID: 2981
	public float CloudMinSpeed;

	// Token: 0x04000BA6 RID: 2982
	public float CloudMaxSpeed;

	// Token: 0x04000BA7 RID: 2983
	private List<WeatherCloud> _currentClouds = new List<WeatherCloud>();

	// Token: 0x04000BA8 RID: 2984
	private List<WeatherCloud> _removable = new List<WeatherCloud>();

	// Token: 0x04000BA9 RID: 2985
	private float _timer;
}
