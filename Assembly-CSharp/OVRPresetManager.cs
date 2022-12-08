using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
public class OVRPresetManager
{
	// Token: 0x06000649 RID: 1609 RVA: 0x0003FC35 File Offset: 0x0003E035
	public bool SetCurrentPreset(string presetName)
	{
		OVRPresetManager.PresetName = presetName;
		return true;
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0003FC40 File Offset: 0x0003E040
	public bool SetPropertyInt(string name, ref int v)
	{
		string key = OVRPresetManager.PresetName + name;
		PlayerPrefs.SetInt(key, v);
		return true;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0003FC64 File Offset: 0x0003E064
	public bool GetPropertyInt(string name, ref int v)
	{
		string key = OVRPresetManager.PresetName + name;
		if (!PlayerPrefs.HasKey(key))
		{
			return false;
		}
		v = PlayerPrefs.GetInt(key);
		return true;
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0003FC94 File Offset: 0x0003E094
	public bool SetPropertyFloat(string name, ref float v)
	{
		string key = OVRPresetManager.PresetName + name;
		PlayerPrefs.SetFloat(key, v);
		return true;
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0003FCB8 File Offset: 0x0003E0B8
	public bool GetPropertyFloat(string name, ref float v)
	{
		string key = OVRPresetManager.PresetName + name;
		if (!PlayerPrefs.HasKey(key))
		{
			return false;
		}
		v = PlayerPrefs.GetFloat(key);
		return true;
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0003FCE8 File Offset: 0x0003E0E8
	public bool SetPropertyString(string name, ref string v)
	{
		string key = OVRPresetManager.PresetName + name;
		PlayerPrefs.SetString(key, v);
		return true;
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0003FD0C File Offset: 0x0003E10C
	public bool GetPropertyString(string name, ref string v)
	{
		string key = OVRPresetManager.PresetName + name;
		if (!PlayerPrefs.HasKey(key))
		{
			return false;
		}
		v = PlayerPrefs.GetString(key);
		return true;
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0003FD3C File Offset: 0x0003E13C
	public bool DeleteProperty(string name)
	{
		string key = OVRPresetManager.PresetName + name;
		PlayerPrefs.DeleteKey(key);
		return true;
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0003FD5C File Offset: 0x0003E15C
	public bool SaveAll()
	{
		PlayerPrefs.Save();
		return true;
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0003FD64 File Offset: 0x0003E164
	public bool DeleteAll()
	{
		PlayerPrefs.DeleteAll();
		return true;
	}

	// Token: 0x040008D4 RID: 2260
	private static string PresetName = string.Empty;
}
