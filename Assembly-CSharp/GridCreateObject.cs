using System;
using UnityEngine;

// Token: 0x020000D0 RID: 208
public class GridCreateObject : MonoBehaviour
{
	// Token: 0x060003E9 RID: 1001 RVA: 0x00023E77 File Offset: 0x00022277
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00023EB2 File Offset: 0x000222B2
	private void Start()
	{
		if (base.gameObject.name != "grid")
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00023ED4 File Offset: 0x000222D4
	private void Update()
	{
		this.editorobj = GameObject.FindWithTag("editorobj");
		this.checkobjscript = (this.editorobj.GetComponent("SceneryMapMaker") as SceneryMapMaker);
		this.spawnobj = this.checkobjscript.currentpath;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00023F14 File Offset: 0x00022314
	private void OnMouseDown()
	{
		if ((CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && this.editorobj.GetComponent<ToolBarMapMaker>().type == 2) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && this.editorobj.GetComponent<ToolBarMapMaker>().type == 4))
		{
			if (Input.GetMouseButton(1))
			{
				GameObject gameObject = PhotonNetwork.Instantiate("photonobj", base.transform.position, base.transform.rotation, 0, null);
				gameObject.name = this.spawnobj;
				gameObject.transform.position = base.transform.position;
				gameObject.transform.rotation = base.transform.rotation;
			}
		}
		else if (CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && this.editorobj.GetComponent<ToolBarMapMaker>().type == 5)
		{
			if (Input.GetMouseButton(1))
			{
				GameObject gameObject2 = GameObject.Find("Modelfilebrowser");
				GameObject gameObject3 = PhotonNetwork.Instantiate("photonmod", base.transform.position, base.transform.rotation, 0, null);
				gameObject3.transform.position = base.transform.position;
				gameObject3.transform.rotation = base.transform.rotation;
				this.str2 = gameObject2.GetComponent<UniFileBrowser>().filePath + gameObject2.GetComponent<UniFileBrowser>().fileName;
				this.str1 = Application.dataPath;
				this.str3 = this.str2.Replace(this.str1, string.Empty);
				this.str3 = this.str3.Replace("/", ",");
				if (GameObject.Find(this.str3 + "-first"))
				{
					gameObject3.name = this.str3;
				}
				else
				{
					gameObject3.name = this.str3 + "-first";
				}
				gameObject3.transform.position = base.transform.position;
			}
		}
		else if ((Input.GetMouseButton(1) && this.editorobj.GetComponent<ToolBarMapMaker>().type == 2) || (Input.GetMouseButton(1) && this.editorobj.GetComponent<ToolBarMapMaker>().type == 3) || (Input.GetMouseButton(1) && this.editorobj.GetComponent<ToolBarMapMaker>().type == 4))
		{
			GameObject gameObject4 = UnityEngine.Object.Instantiate(Resources.Load(this.spawnobj)) as GameObject;
			gameObject4.transform.position = base.transform.position;
			gameObject4.transform.rotation = base.transform.rotation;
			gameObject4.name = this.spawnobj;
			gameObject4.GetComponent<MeshFilter>().mesh = null;
		}
		else if (Input.GetMouseButton(1) && this.editorobj.GetComponent<ToolBarMapMaker>().type == 5)
		{
			GameObject gameObject5 = GameObject.Find("Modelfilebrowser");
			GameObject gameObject6 = UnityEngine.Object.Instantiate(Resources.Load("Model")) as GameObject;
			gameObject6.transform.position = base.transform.position;
			gameObject6.transform.rotation = base.transform.rotation;
			this.str2 = gameObject5.GetComponent<UniFileBrowser>().filePath + gameObject5.GetComponent<UniFileBrowser>().fileName;
			this.str1 = Application.dataPath;
			this.str3 = this.str2.Replace(this.str1, string.Empty);
			this.str3 = this.str3.Replace("/", ",");
			if (GameObject.Find(this.str3 + "-first"))
			{
				gameObject6.name = this.str3;
			}
			else
			{
				gameObject6.name = this.str3 + "-first";
			}
		}
	}

	// Token: 0x04000469 RID: 1129
	public SceneryMapMaker checkobjscript;

	// Token: 0x0400046A RID: 1130
	public ToolBarMapMaker checkmodscript;

	// Token: 0x0400046B RID: 1131
	public string spawnobj;

	// Token: 0x0400046C RID: 1132
	public GameObject editorobj;

	// Token: 0x0400046D RID: 1133
	public string str1;

	// Token: 0x0400046E RID: 1134
	public string str2;

	// Token: 0x0400046F RID: 1135
	public string str3;
}
