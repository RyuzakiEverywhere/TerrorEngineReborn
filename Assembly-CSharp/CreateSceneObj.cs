using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class CreateSceneObj : MonoBehaviour
{
	// Token: 0x060003C5 RID: 965 RVA: 0x00022AE0 File Offset: 0x00020EE0
	private void Start()
	{
		this.boxskin = (Resources.Load("BoxGUI") as GUISkin);
		this.Detector = GameObject.CreatePrimitive(PrimitiveType.Cube);
		this.Detector.name = "SceneObj";
		this.Detector.transform.localScale = new Vector3(4f, 4f, 0.01f);
		this.Detector.transform.position = base.transform.position;
		this.Detector.GetComponent<MeshFilter>().sharedMesh = base.GetComponent<MeshFilter>().sharedMesh;
		UnityEngine.Object.Destroy(base.gameObject);
		this.Detector.gameObject.AddComponent<PositionAndScale>();
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x00022B94 File Offset: 0x00020F94
	private void Update()
	{
	}

	// Token: 0x04000444 RID: 1092
	public GameObject Detector;

	// Token: 0x04000445 RID: 1093
	public GUISkin boxskin;
}
