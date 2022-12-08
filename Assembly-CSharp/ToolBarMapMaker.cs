using System;
using CompilerGenerated;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class ToolBarMapMaker : MonoBehaviour
{
	// Token: 0x06000466 RID: 1126 RVA: 0x00032F68 File Offset: 0x00031368
	private void Start()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			this.pathChar = '\\';
		}
		if (CryptoPlayerPrefs.GetInt("bloom", 0) == 1)
		{
			base.gameObject.GetComponent<FastBloom>().enabled = true;
		}
		if (CryptoPlayerPrefs.GetInt("motionblur", 0) != 1)
		{
			base.gameObject.GetComponent<CameraMotionBlur>().enabled = false;
		}
		if (CryptoPlayerPrefs.GetString("E410675", string.Empty) != "E2193590")
		{
			this.isfree = true;
		}
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00032FFC File Offset: 0x000313FC
	private void Update()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("mapmakerobject");
		this.count = (float)array.Length;
		if (this.type != 5)
		{
			this.curobj = base.gameObject.GetComponent<SceneryMapMaker>().currentobj;
		}
		else
		{
			this.curobj = "Model";
		}
		if (this.isfree)
		{
			int num = 0;
			ModelProperties[] array2 = UnityEngine.Object.FindObjectsOfType(typeof(ModelProperties)) as ModelProperties[];
			foreach (ModelProperties modelProperties in array2)
			{
				if (modelProperties.name.Contains("model"))
				{
					num++;
				}
			}
			this.modellimit = num;
		}
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x000330B4 File Offset: 0x000314B4
	private void OpenFile(string pathToFile)
	{
		int num = pathToFile.LastIndexOf(this.pathChar);
		this.message = string.Empty + pathToFile.Substring(num + 1, pathToFile.Length - num - 1);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x000330F4 File Offset: 0x000314F4
	private void OnGUI()
	{
		GUI.Label(new Rect((float)Screen.width / 1.2f, (float)(Screen.height - 20), 150f, 50f), "Object Count: " + this.count);
		GUI.Label(new Rect(12f, (float)(Screen.height - 42), 200f, 50f), "Current Object: " + this.curobj);
		if (this.isfree)
		{
			GUI.Label(new Rect(5f, 35f, 250f, 65f), this.modellimit.ToString() + "/15 Models used\n(Does not include NPC, walls and floors)\nPlease login to your ZeoWorks account to remove this limit.");
		}
		GUI.skin = this.toolbarskin;
		GUI.Box(new Rect(0f, 0f, (float)Screen.width, 30f), " ");
		GUI.DrawTexture(new Rect((float)(Screen.width - 90), -1f, 90f, 30f), this.logo);
		if (GUI.Button(new Rect(5f, 5f, 50f, 20f), "File"))
		{
			UnityEngine.Object.Instantiate<Transform>(this.fileobj);
		}
		if (GUI.Button(new Rect(60f, 5f, 60f, 20f), "Scene"))
		{
			this.type = 2;
			if (this.type == 2)
			{
				base.GetComponent<SceneryMapMaker>().enabled = !base.GetComponent<SceneryMapMaker>().enabled;
			}
		}
		if (GUI.Button(new Rect(125f, 5f, 50f, 20f), "NPC"))
		{
			this.type = 3;
			base.gameObject.GetComponent<NPCTypeProperties>().enabled = !base.gameObject.GetComponent<NPCTypeProperties>().enabled;
		}
		if (GUI.Button(new Rect(180f, 5f, 60f, 20f), "Events"))
		{
			this.type = 4;
			if (this.type == 4)
			{
				base.GetComponent<EventsMenu>().enabled = !base.GetComponent<EventsMenu>().enabled;
			}
		}
		if (GUI.Button(new Rect(245f, 5f, 60f, 20f), "Models"))
		{
			this.type = 5;
			UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.OpenFile));
			base.gameObject.GetComponent<SceneryMapMaker>().enabled = false;
		}
		if (GUI.Button(new Rect(310f, 5f, 100f, 20f), "Map Generator"))
		{
			this.type = 7;
			GameObject.Find("_mapgenerator").GetComponent<MazeMapProperties>().enabled = !GameObject.Find("_mapgenerator").GetComponent<MazeMapProperties>().enabled;
		}
		if (GUI.Button(new Rect(415f, 5f, 65f, 20f), "Settings"))
		{
			this.type = 6;
			GameObject gameObject = GameObject.Find("Settings");
			gameObject.GetComponent<SettingsProperties>().enabled = !gameObject.GetComponent<SettingsProperties>().enabled;
		}
	}

	// Token: 0x040006A9 RID: 1705
	public GUISkin toolbarskin;

	// Token: 0x040006AA RID: 1706
	public Texture2D logo;

	// Token: 0x040006AB RID: 1707
	public int type;

	// Token: 0x040006AC RID: 1708
	public float count;

	// Token: 0x040006AD RID: 1709
	public string curobj;

	// Token: 0x040006AE RID: 1710
	public int modellimit;

	// Token: 0x040006AF RID: 1711
	public string currentpath;

	// Token: 0x040006B0 RID: 1712
	private char pathChar = '/';

	// Token: 0x040006B1 RID: 1713
	public string message = string.Empty;

	// Token: 0x040006B2 RID: 1714
	private float alpha = 1f;

	// Token: 0x040006B3 RID: 1715
	private bool isfree;

	// Token: 0x040006B4 RID: 1716
	public Transform fileobj;
}
