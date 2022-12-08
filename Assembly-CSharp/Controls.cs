using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class Controls : MonoBehaviour
{
	// Token: 0x060010EB RID: 4331 RVA: 0x0006B1F0 File Offset: 0x000695F0
	private void Awake()
	{
		this._player = GameObject.FindGameObjectWithTag("Player").transform;
		this._spawnpoint = GameObject.Find("Box Spawnpoint");
		this._directionalLight = GameObject.Find("Directional light").GetComponent<Light>();
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x0006B22C File Offset: 0x0006962C
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Vector3 position = new Vector3(UnityEngine.Random.Range(this._spawnpoint.transform.position.x - 4f, this._spawnpoint.transform.position.x + 4f), this._spawnpoint.transform.position.y, UnityEngine.Random.Range(this._spawnpoint.transform.position.z - 2f, this._spawnpoint.transform.position.z + 2f));
			UnityEngine.Object.Instantiate<GameObject>(this.Box, position, Quaternion.identity);
		}
		Vector3 direction = GameObject.FindGameObjectWithTag("MainCamera").transform.TransformDirection(Vector3.forward);
		if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(this._player.position, direction, out this._raycastHitInfo, 2f) && (this._raycastHitInfo.transform.name == this.Box.name || this._raycastHitInfo.transform.name == this.Box.name + "(Clone)"))
		{
			UnityEngine.Object.Destroy(this._raycastHitInfo.transform.gameObject);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			RenderSettings.skybox = (Material)Resources.Load("Eerie Skybox");
			RenderSettings.ambientLight = new Color(0.09411765f, 0.19215687f, 0.23529412f);
			this._directionalLight.color = new Color(0.53333336f, 0.6901961f, 0.69803923f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			RenderSettings.skybox = (Material)Resources.Load("DawnDusk Skybox");
			RenderSettings.ambientLight = new Color(0.3647059f, 0.41568628f, 0.3882353f);
			this._directionalLight.color = new Color(0.99607843f, 0.99215686f, 0.69803923f);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			RenderSettings.skybox = (Material)Resources.Load("Sunny2 Skybox");
			RenderSettings.ambientLight = new Color(0.77254903f, 0.9098039f, 0.98039216f);
			this._directionalLight.color = new Color(0.9490196f, 0.96862745f, 0.9843137f);
		}
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x0006B4B8 File Offset: 0x000698B8
	public void OnGUI()
	{
		if (TestGUI.Instance.CurrentState.Method.Name == "InGame")
		{
			GUI.Box(new Rect(20f, (float)(Screen.height - 120), 520f, 100f), string.Concat(new string[]
			{
				"Press E to spawn wooden boxes.",
				Environment.NewLine,
				"Press Left Mouse Button to remove a wooden box when standing close and looking at it.",
				Environment.NewLine,
				"Press 1, 2, or 3 to change the Skybox",
				Environment.NewLine,
				Environment.NewLine,
				"To Save/Load, press Escape to bring up the menu."
			}));
		}
	}

	// Token: 0x04001178 RID: 4472
	private Transform _player;

	// Token: 0x04001179 RID: 4473
	private GameObject _spawnpoint;

	// Token: 0x0400117A RID: 4474
	public GameObject Box;

	// Token: 0x0400117B RID: 4475
	private RaycastHit _raycastHitInfo;

	// Token: 0x0400117C RID: 4476
	private Light _directionalLight;
}
