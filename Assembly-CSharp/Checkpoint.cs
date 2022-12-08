using System;
using UnityEngine;

// Token: 0x02000257 RID: 599
public class Checkpoint : MonoBehaviour
{
	// Token: 0x060010E2 RID: 4322 RVA: 0x0006AF75 File Offset: 0x00069375
	private void Awake()
	{
		this._player = GameObject.FindGameObjectWithTag("Player").transform;
		this._sphereCollider = base.GetComponent<SphereCollider>();
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x0006AF98 File Offset: 0x00069398
	private void Update()
	{
		if (Vector3.Distance(this._player.transform.position, base.transform.position) <= this._sphereCollider.radius)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			UniSave.Save("Autosave");
		}
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x0006AFEA File Offset: 0x000693EA
	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position, "../UniSave/Gizmos/UniSave_Checkpoint.png");
	}

	// Token: 0x04001172 RID: 4466
	private const string GizmoIcon = "../UniSave/Gizmos/UniSave_Checkpoint.png";

	// Token: 0x04001173 RID: 4467
	private const string AutoSaveName = "Autosave";

	// Token: 0x04001174 RID: 4468
	private Transform _player;

	// Token: 0x04001175 RID: 4469
	private SphereCollider _sphereCollider;
}
