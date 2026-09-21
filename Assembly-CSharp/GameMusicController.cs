using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000131 RID: 305
public class GameMusicController : MonoBehaviour
{
	// Token: 0x0600088E RID: 2190 RVA: 0x00077187 File Offset: 0x00075587
	public GameMusicController()
	{
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0007719A File Offset: 0x0007559A
	private void Awake()
	{
		if (GameMusicController.Instance == null)
		{
			GameMusicController.Instance = this;
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x000771B2 File Offset: 0x000755B2
	private void Start()
	{
		this._battleVolume = this.BattleAudio.volume;
		this._combatVolume = this.CombatAudio.volume;
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000771D8 File Offset: 0x000755D8
	public void AdventureInitialized(Adventure adventure)
	{
		AdventureType adventureType = adventure.AdventureType;
		switch (adventureType)
		{
		case AdventureType.HellishPath:
			this.BattleAudio.clip = this.HellishPath;
			break;
		case AdventureType.SnowMountain:
			this.BattleAudio.clip = this.SnowMountain;
			break;
		default:
			if (adventureType != AdventureType.WoodenForest)
			{
				if (adventureType != AdventureType.BuriedTemple)
				{
					this.BattleAudio.clip = this.Others;
				}
				else
				{
					this.BattleAudio.clip = this.BuriedTemple;
				}
			}
			else
			{
				this.BattleAudio.clip = this.WoodenForest;
			}
			break;
		case AdventureType.MistForest:
			this.BattleAudio.clip = this.MistForest;
			break;
		}
		this.CombatAudio.volume = 0f;
		this.BattleAudio.Play();
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x000772B8 File Offset: 0x000756B8
	public void EnterEncounter(List<AdventurerBattleUnit> adventurerBattleUnits, IEncounter encounter)
	{
		if (encounter.EnemyUnits.OfType<EnemyBattleUnit>().Any((EnemyBattleUnit e) => e.SlotSelection == AdventureEncounterSlotType.Boss))
		{
			if (!this._isPlayingBossMusic)
			{
				this.CombatAudio.clip = this.BossCombat;
				this._isPlayingBossMusic = true;
				this.CombatAudio.Play();
			}
		}
		else if (this._isPlayingBossMusic)
		{
			this.CombatAudio.clip = this.NormalCombat;
			this._isPlayingBossMusic = false;
			this.CombatAudio.Play();
		}
		this.PlayCombatMusic();
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0007735E File Offset: 0x0007575E
	public void CompleteEncounter(List<AdventurerBattleUnit> arg1, IEncounter arg2)
	{
		this.EndCombatMusic();
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00077368 File Offset: 0x00075768
	private void Update()
	{
		if (this._inBattle)
		{
			this._combatTimer += Time.deltaTime;
			this._battleTimer += Time.deltaTime;
			this.BattleAudio.volume = Mathf.Lerp(0f, this._battleVolume, this._battleTimer * this.MusicSwitchSpeed);
			this.CombatAudio.volume = Mathf.Lerp(this._combatVolume, 0f, this._combatTimer * this.MusicSwitchSpeed);
			if (this._battleTimer >= 1f)
			{
				this._inBattle = false;
				this._combatTimer = 0f;
				this._battleTimer = 0f;
			}
		}
		if (this._inCombat)
		{
			this._combatTimer += Time.deltaTime;
			this._battleTimer += Time.deltaTime;
			this.CombatAudio.volume = Mathf.Lerp(0f, this._combatVolume, this._combatTimer * this.MusicSwitchSpeed);
			this.BattleAudio.volume = Mathf.Lerp(this._battleVolume, 0f, this._battleTimer * this.MusicSwitchSpeed);
			if (this._combatTimer >= 1f)
			{
				this._inCombat = false;
				this._combatTimer = 0f;
				this._battleTimer = 0f;
			}
		}
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000774D0 File Offset: 0x000758D0
	public void SetMusicVolume(float value)
	{
		AudioSource[] componentsInChildren = base.GetComponentsInChildren<AudioSource>(true);
		int i = 0;
		while (i < componentsInChildren.Length)
		{
			AudioSource audioSource = componentsInChildren[i];
			if (value == 0f)
			{
				goto IL_60;
			}
			if (!this._inCombat || !(audioSource == this.BattleAudio))
			{
				if (!this._inBattle || !(audioSource == this.CombatAudio))
				{
					goto IL_60;
				}
			}
			IL_67:
			i++;
			continue;
			IL_60:
			audioSource.volume = value;
			goto IL_67;
		}
		foreach (AudioSource audioSource2 in this.OtherMusicAudio)
		{
			audioSource2.volume = value;
		}
		this._battleVolume = this.BattleAudio.volume;
		this._combatVolume = this.CombatAudio.volume;
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000775C4 File Offset: 0x000759C4
	public void SetEffectVolume(float value)
	{
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x000775C8 File Offset: 0x000759C8
	public void PlayTownMusic()
	{
		this.TownAudio.mute = false;
		if (GameWorld.instance.GetCurrentAdventure() == null)
		{
			this.BattleAudio.gameObject.SetActive(false);
			this.CombatAudio.gameObject.SetActive(false);
		}
		else
		{
			this.CombatAudio.mute = true;
			this.BattleAudio.mute = true;
		}
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x00077630 File Offset: 0x00075A30
	public void PlayBattleMusic()
	{
		if (!this.BattleAudio.gameObject.activeSelf)
		{
			this.BattleAudio.gameObject.SetActive(true);
		}
		this.CombatAudio.mute = false;
		this.BattleAudio.mute = false;
		this.TownAudio.mute = true;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00077687 File Offset: 0x00075A87
	public void PlayCombatMusic()
	{
		if (!this.CombatAudio.gameObject.activeSelf)
		{
			this.CombatAudio.gameObject.SetActive(true);
		}
		this._inCombat = true;
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000776B6 File Offset: 0x00075AB6
	public void EndCombatMusic()
	{
		this._inBattle = true;
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x000776BF File Offset: 0x00075ABF
	[CompilerGenerated]
	private static bool <EnterEncounter>m__0(EnemyBattleUnit e)
	{
		return e.SlotSelection == AdventureEncounterSlotType.Boss;
	}

	// Token: 0x04000B18 RID: 2840
	public static GameMusicController Instance;

	// Token: 0x04000B19 RID: 2841
	public float MusicSwitchSpeed = 2f;

	// Token: 0x04000B1A RID: 2842
	public AudioSource TownAudio;

	// Token: 0x04000B1B RID: 2843
	public AudioSource BattleAudio;

	// Token: 0x04000B1C RID: 2844
	public AudioSource CombatAudio;

	// Token: 0x04000B1D RID: 2845
	[Header("Battle Enviroment Music")]
	public AudioClip WoodenForest;

	// Token: 0x04000B1E RID: 2846
	public AudioClip MistForest;

	// Token: 0x04000B1F RID: 2847
	public AudioClip SnowMountain;

	// Token: 0x04000B20 RID: 2848
	public AudioClip BuriedTemple;

	// Token: 0x04000B21 RID: 2849
	public AudioClip HellishPath;

	// Token: 0x04000B22 RID: 2850
	public AudioClip Others;

	// Token: 0x04000B23 RID: 2851
	[Header("Combat Music")]
	public AudioClip NormalCombat;

	// Token: 0x04000B24 RID: 2852
	public AudioClip BossCombat;

	// Token: 0x04000B25 RID: 2853
	[Header("Other MusicSounds")]
	public List<AudioSource> OtherMusicAudio;

	// Token: 0x04000B26 RID: 2854
	private float _battleVolume;

	// Token: 0x04000B27 RID: 2855
	private float _combatVolume;

	// Token: 0x04000B28 RID: 2856
	private bool _inBattle;

	// Token: 0x04000B29 RID: 2857
	private bool _inCombat;

	// Token: 0x04000B2A RID: 2858
	private float _battleTimer;

	// Token: 0x04000B2B RID: 2859
	private float _combatTimer;

	// Token: 0x04000B2C RID: 2860
	private bool _isPlayingBossMusic;

	// Token: 0x04000B2D RID: 2861
	[CompilerGenerated]
	private static Func<EnemyBattleUnit, bool> <>f__am$cache0;
}
