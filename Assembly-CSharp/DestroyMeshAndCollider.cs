using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000CA RID: 202
public class DestroyMeshAndCollider : MonoBehaviour
{
	// Token: 0x060003C8 RID: 968 RVA: 0x00022BA8 File Offset: 0x00020FA8
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (this.istrigger)
			{
				base.gameObject.GetComponent<BoxCollider>().isTrigger = true;
			}
			if (base.gameObject.GetComponent<LightProperties>() != null)
			{
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
			}
			if (base.gameObject.layer == 15)
			{
				base.gameObject.AddComponent<NavMeshObstacle>();
				base.GetComponent<NavMeshObstacle>().carving = true;
			}
			base.enabled = false;
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00022C6C File Offset: 0x0002106C
	private void Start()
	{
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00022C70 File Offset: 0x00021070
	private void Update()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (this.istrigger)
			{
				base.gameObject.GetComponent<BoxCollider>().isTrigger = true;
			}
			base.enabled = false;
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x04000446 RID: 1094
	public bool istrigger = true;

	// Token: 0x04000447 RID: 1095
	public bool deletecollider;
}
