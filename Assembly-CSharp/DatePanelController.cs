using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000268 RID: 616
public class DatePanelController : MonoBehaviour
{
	// Token: 0x06000FF0 RID: 4080 RVA: 0x00096A84 File Offset: 0x00094E84
	public DatePanelController()
	{
	}

	// Token: 0x06000FF1 RID: 4081 RVA: 0x00096A8C File Offset: 0x00094E8C
	private void Start()
	{
		if (GameWorld.instance.PlayerProfile != null)
		{
			this.ChangeWeather();
			this.ChangeDay();
			this.ChangeSeason();
		}
	}

	// Token: 0x06000FF2 RID: 4082 RVA: 0x00096AAF File Offset: 0x00094EAF
	private void Update()
	{
		this.ChangeWeather();
		this.ChangeDay();
		this.ChangeSeason();
	}

	// Token: 0x06000FF3 RID: 4083 RVA: 0x00096AC4 File Offset: 0x00094EC4
	private void ChangeSeason()
	{
		switch (GameWorld.instance.PlayerProfile.CurrentSeason)
		{
		case Season.Spring:
			this.SeasonText.text = UIComponentType.TownSeasonSpring.GetName();
			break;
		case Season.Summer:
			this.SeasonText.text = UIComponentType.TownSeasonSummer.GetName();
			break;
		case Season.Autumn:
			this.SeasonText.text = UIComponentType.TownSeasonAutumn.GetName();
			break;
		case Season.Winter:
			this.SeasonText.text = UIComponentType.TownSeasonWinter.GetName();
			break;
		}
	}

	// Token: 0x06000FF4 RID: 4084 RVA: 0x00096B64 File Offset: 0x00094F64
	private void ChangeWeather()
	{
		this.Weather.sprite = FilePath.GetWeatherImage(GameWorld.instance.PlayerProfile.CurrentWeather);
	}

	// Token: 0x06000FF5 RID: 4085 RVA: 0x00096B85 File Offset: 0x00094F85
	private void ChangeDay()
	{
		this.DateText.text = UIComponentType.DayPanelDays.GetName().ReplaceToBuilder(UIComponentKey.NumberOfDay, GameWorld.instance.PlayerProfile.GameDays.ToString()).ToString();
	}

	// Token: 0x04001134 RID: 4404
	public TextMeshProUGUI SeasonText;

	// Token: 0x04001135 RID: 4405
	public TextMeshProUGUI DateText;

	// Token: 0x04001136 RID: 4406
	public Image Weather;

	// Token: 0x04001137 RID: 4407
	public GameObject AllResourceIconPanel;

	// Token: 0x04001138 RID: 4408
	private int _currentDay;

	// Token: 0x04001139 RID: 4409
	private Weather _currentWeather;

	// Token: 0x0400113A RID: 4410
	private bool _dayChanged;

	// Token: 0x0400113B RID: 4411
	private bool _weatherChanged;
}
