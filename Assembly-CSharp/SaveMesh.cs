using System;
using UnityEngine;

// Token: 0x02000169 RID: 361
public class SaveMesh : MonoBehaviour
{
	// Token: 0x06000891 RID: 2193 RVA: 0x0004FD03 File Offset: 0x0004E103
	private void Start()
	{
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x0004FD08 File Offset: 0x0004E108
	private void Export()
	{
		Mesh mesh = base.GetComponent<MeshFilter>().mesh;
		string str = Application.dataPath + "/Models/" + this.fileName + ".model";
		MonoBehaviour.print("Saved " + base.name + " mesh to " + str);
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0004FD57 File Offset: 0x0004E157
	private void OnGUI()
	{
	}

	// Token: 0x04000AA4 RID: 2724
	public string fileName = "new_model";

	// Token: 0x04000AA5 RID: 2725
	public bool saveTangents;
}
