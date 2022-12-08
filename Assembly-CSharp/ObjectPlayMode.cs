using System;
using Photon;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class ObjectPlayMode : Photon.MonoBehaviour
{
	// Token: 0x06000456 RID: 1110 RVA: 0x00030A22 File Offset: 0x0002EE22
	private void Awake()
	{
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x00030A24 File Offset: 0x0002EE24
	private void Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			base.gameObject.transform.localScale = new Vector3(float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalex), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scaley), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalez));
			base.enabled = false;
		}
		else if (base.gameObject.GetComponent<ModProperties>() != null)
		{
			base.gameObject.AddComponent<PreviewMod>();
			base.gameObject.GetComponent<ModProperties>().enabled = false;
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x00030AE8 File Offset: 0x0002EEE8
	private void Update()
	{
		this.obj = (Resources.Load(base.gameObject.name.ToString()) as GameObject);
		if (GameObject.Find("Play(Clone)") != null)
		{
			base.gameObject.transform.localScale = new Vector3(float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalex), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scaley), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalez));
			base.gameObject.GetComponent<PositionAndScale>().enabled = false;
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<State>());
			if (base.gameObject.GetComponent<ModelProperties>() != null && base.gameObject.GetComponent<ModelProperties>().collect)
			{
				base.gameObject.transform.tag = "collect";
				base.gameObject.GetComponent<Collider>().isTrigger = true;
				if (base.gameObject.GetComponent<MeshCollider>() != null)
				{
					UnityEngine.Object.Destroy(base.gameObject.GetComponent<MeshCollider>());
					if (base.gameObject.GetComponent<BoxCollider>() == null)
					{
						base.gameObject.AddComponent<BoxCollider>();
						base.gameObject.GetComponent<BoxCollider>().isTrigger = true;
					}
				}
				base.gameObject.AddComponent<CollectScript>();
			}
			if (base.gameObject.GetComponent<WallProperties>() != null)
			{
				if (base.gameObject.GetComponent<WallProperties>().iswall || base.gameObject.GetComponent<WallProperties>().iswindow)
				{
					base.gameObject.AddComponent<FootprintComponent>();
					UnityEngine.Object.Destroy(base.gameObject.GetComponent<Collider>());
					base.gameObject.AddComponent<BoxCollider>();
					base.gameObject.GetComponent<WallProperties>().enabled = false;
				}
				if (base.gameObject.GetComponent<WallProperties>().isdoor)
				{
					base.gameObject.GetComponent<MeshFilter>().mesh = (Resources.Load("doorframe", typeof(Mesh)) as Mesh);
					base.gameObject.transform.tag = "Door";
					base.gameObject.layer = 12;
				}
				if (base.gameObject.GetComponent<WallProperties>().iswindow)
				{
					base.gameObject.GetComponent<MeshFilter>().mesh = (Resources.Load("window", typeof(Mesh)) as Mesh);
				}
			}
			if (base.gameObject.GetComponent<LightProperties>() != null)
			{
				if (!base.gameObject.GetComponent<LightProperties>().toggleshadow)
				{
					base.GetComponent<Light>().shadows = LightShadows.None;
				}
				if (base.gameObject.GetComponent<LightProperties>().mmflare)
				{
					base.GetComponent<Light>().flare = (Resources.Load("Flares/Mmzoom") as Flare);
				}
				if (base.gameObject.GetComponent<LightProperties>().streetlight)
				{
					base.GetComponent<Light>().flare = (Resources.Load("Flares/StreetLights") as Flare);
				}
				if (base.gameObject.GetComponent<LightProperties>().smallflare)
				{
					base.GetComponent<Light>().flare = (Resources.Load("Flares/SmallFlare") as Flare);
				}
				if (base.gameObject.GetComponent<LightProperties>().sun)
				{
					base.GetComponent<Light>().flare = (Resources.Load("Flares/Sun") as Flare);
				}
				if (base.gameObject.GetComponent<LightProperties>().toggleflicker)
				{
					base.gameObject.AddComponent<FlashingLight>();
				}
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<LightProperties>());
			}
			if (base.gameObject.GetComponent<State>() != null)
			{
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<State>());
			}
			if (base.gameObject.GetComponent<GridCreateObject>() != null)
			{
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<GridCreateObject>());
			}
			if (base.gameObject.name == "Events/Invisible Barrier")
			{
				base.gameObject.GetComponent<Collider>().isTrigger = false;
			}
			if (base.gameObject.name == "Events/NPC Avoid")
			{
				base.gameObject.GetComponent<Collider>().isTrigger = true;
				base.gameObject.AddComponent<FootprintComponent>();
			}
			if (base.gameObject.GetComponent<CreateSceneObj>() != null)
			{
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<CreateSceneObj>());
			}
			if (base.gameObject.GetComponent<EditObjEnable>() != null)
			{
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<EditObjEnable>());
			}
			if (base.gameObject.GetComponent<NPCObjProperties>() != null)
			{
				if (PhotonNetwork.isMasterClient && this.pvobj == null)
				{
					if (base.gameObject.tag == "npctype1")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC1", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype2")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC2", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype3")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC3", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype4")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC4", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype5")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC5", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype6")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC6", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype7")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC7", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype8")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC8", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype9")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC9", base.transform.position, base.transform.rotation, 0, null);
					}
					if (base.gameObject.tag == "npctype10")
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("NPC10", base.transform.position, base.transform.rotation, 0, null);
					}
				}
				UnityEngine.Object.Destroy(base.gameObject.GetComponent<NPCObjProperties>());
			}
			if (base.gameObject.GetComponent<EffectProperties>() != null)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Effects/_Prefabs/" + base.gameObject.GetComponent<EffectProperties>().effectobj), base.transform.position, base.transform.rotation);
				gameObject.transform.parent = base.gameObject.transform;
				base.gameObject.GetComponent<EffectProperties>().enabled = false;
			}
			if (base.gameObject.GetComponent<NodeProperties>() != null)
			{
				base.gameObject.name = base.gameObject.GetComponent<NodeProperties>().nodename;
				if (base.gameObject.GetComponent<NodeProperties>().showwaypoint)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("WayPoint")) as GameObject;
					gameObject2.GetComponent<DisplayWayPoint>().target = base.gameObject.transform;
					gameObject2.GetComponent<GUIText>().text = base.gameObject.GetComponent<NodeProperties>().waypointname;
					gameObject2.transform.parent = base.gameObject.transform;
				}
			}
			if (base.gameObject.name == "Doors/door1")
			{
				GameObject gameObject3 = Resources.Load("Doors/ingame/door1") as GameObject;
				Transform transform = UnityEngine.Object.Instantiate<Transform>(gameObject3.transform, base.transform.position, base.transform.rotation);
				transform.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door2")
			{
				GameObject gameObject4 = Resources.Load("Doors/ingame/door2") as GameObject;
				Transform transform2 = UnityEngine.Object.Instantiate<Transform>(gameObject4.transform, base.transform.position, base.transform.rotation);
				transform2.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform2.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform2.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform2.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door3")
			{
				GameObject gameObject5 = Resources.Load("Doors/ingame/door3") as GameObject;
				Transform transform3 = UnityEngine.Object.Instantiate<Transform>(gameObject5.transform, base.transform.position, base.transform.rotation);
				transform3.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform3.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform3.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform3.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door4")
			{
				GameObject gameObject6 = Resources.Load("Doors/ingame/door4") as GameObject;
				Transform transform4 = UnityEngine.Object.Instantiate<Transform>(gameObject6.transform, base.transform.position, base.transform.rotation);
				transform4.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform4.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform4.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform4.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door5")
			{
				GameObject gameObject7 = Resources.Load("Doors/ingame/door5") as GameObject;
				Transform transform5 = UnityEngine.Object.Instantiate<Transform>(gameObject7.transform, base.transform.position, base.transform.rotation);
				transform5.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform5.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform5.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform5.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door6")
			{
				GameObject gameObject8 = Resources.Load("Doors/ingame/door6") as GameObject;
				Transform transform6 = UnityEngine.Object.Instantiate<Transform>(gameObject8.transform, base.transform.position, base.transform.rotation);
				transform6.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform6.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform6.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform6.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door7")
			{
				GameObject gameObject9 = Resources.Load("Doors/ingame/door7") as GameObject;
				Transform transform7 = UnityEngine.Object.Instantiate<Transform>(gameObject9.transform, base.transform.position, base.transform.rotation);
				transform7.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform7.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform7.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform7.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door8")
			{
				GameObject gameObject10 = Resources.Load("Doors/ingame/door8") as GameObject;
				Transform transform8 = UnityEngine.Object.Instantiate<Transform>(gameObject10.transform, base.transform.position, base.transform.rotation);
				transform8.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform8.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform8.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform8.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Doors/door9")
			{
				GameObject gameObject11 = Resources.Load("Doors/ingame/door9") as GameObject;
				Transform transform9 = UnityEngine.Object.Instantiate<Transform>(gameObject11.transform, base.transform.position, base.transform.rotation);
				transform9.transform.Find("body").transform.localScale = base.gameObject.transform.localScale;
				transform9.name = base.gameObject.GetComponent<DoorProperties>().triggerid;
				transform9.GetComponent<Door>().islocked = base.gameObject.GetComponent<DoorProperties>().islocked;
				transform9.GetComponent<Door>().keynum = base.gameObject.GetComponent<DoorProperties>().keyid;
				base.gameObject.active = false;
			}
			if (base.gameObject.name == "Items/Healthpack")
			{
				GameObject gameObject12 = Resources.Load("Items/Ingame/Healthpack") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject12.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key1")
			{
				GameObject gameObject13 = Resources.Load("Items/Ingame/Key1") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject13.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key2")
			{
				GameObject gameObject14 = Resources.Load("Items/Ingame/Key2") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject14.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key3")
			{
				GameObject gameObject15 = Resources.Load("Items/Ingame/Key3") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject15.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key4")
			{
				GameObject gameObject16 = Resources.Load("Items/Ingame/Key4") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject16.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key5")
			{
				GameObject gameObject17 = Resources.Load("Items/Ingame/Key5") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject17.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key6")
			{
				GameObject gameObject18 = Resources.Load("Items/Ingame/Key6") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject18.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key7")
			{
				GameObject gameObject19 = Resources.Load("Items/Ingame/Key7") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject19.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key8")
			{
				GameObject gameObject20 = Resources.Load("Items/Ingame/Key8") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject20.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key9")
			{
				GameObject gameObject21 = Resources.Load("Items/Ingame/Key9") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject21.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Custom Item1")
			{
				GameObject gameObject22 = Resources.Load("Items/Ingame/Custom Item1") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject22.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Custom Item2")
			{
				GameObject gameObject23 = Resources.Load("Items/Ingame/Custom Item2") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject23.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Custom Item3")
			{
				GameObject gameObject24 = Resources.Load("Items/Ingame/Custom Item3") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject24.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Custom Item4")
			{
				GameObject gameObject25 = Resources.Load("Items/Ingame/Custom Item4") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject25.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Custom Item5")
			{
				GameObject gameObject26 = Resources.Load("Items/Ingame/Custom Item5") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject26.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/CandleItem")
			{
				GameObject gameObject27 = Resources.Load("Items/Ingame/CandleItem") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject27.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Lantern")
			{
				GameObject gameObject28 = Resources.Load("Items/Ingame/Lantern") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject28.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Flame Torch")
			{
				GameObject gameObject29 = Resources.Load("Items/Ingame/Flame Torch") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject29.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Flashlight")
			{
				GameObject gameObject30 = Resources.Load("Items/Ingame/Flashlight") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject30.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Nvgoggles")
			{
				GameObject gameObject31 = Resources.Load("Items/Ingame/Nvgoggles") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject31.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Nvcamera")
			{
				GameObject gameObject32 = Resources.Load("Items/Ingame/Nvcamera") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject32.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key1")
			{
				GameObject gameObject33 = Resources.Load("Items/Ingame/Key1") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject33.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key2")
			{
				GameObject gameObject34 = Resources.Load("Items/Ingame/Key2") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject34.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key3")
			{
				GameObject gameObject35 = Resources.Load("Items/Ingame/Key3") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject35.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key4")
			{
				GameObject gameObject36 = Resources.Load("Items/Ingame/Key4") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject36.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key5")
			{
				GameObject gameObject37 = Resources.Load("Items/Ingame/Key5") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject37.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key6")
			{
				GameObject gameObject38 = Resources.Load("Items/Ingame/Key6") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject38.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key7")
			{
				GameObject gameObject39 = Resources.Load("Items/Ingame/Key7") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject39.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key8")
			{
				GameObject gameObject40 = Resources.Load("Items/Ingame/Key8") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject40.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Key9")
			{
				GameObject gameObject41 = Resources.Load("Items/Ingame/Key9") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject41.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.name == "Items/Healthpack")
			{
				GameObject gameObject42 = Resources.Load("Items/Ingame/Healthpack") as GameObject;
				UnityEngine.Object.Instantiate<Transform>(gameObject42.transform, base.transform.position, base.transform.rotation);
			}
			if (base.gameObject.GetComponent<EndZoneProperties>() != null)
			{
				base.gameObject.AddComponent<EndZoneSync>();
				if (GameObject.Find("Settings").GetComponent<SettingsProperties>().collect)
				{
					base.gameObject.GetComponent<EndZoneSync>().collect = true;
				}
				if (GameObject.Find("Settings").GetComponent<SettingsProperties>().collectandescape)
				{
					base.gameObject.GetComponent<EndZoneSync>().collectandenter = true;
				}
				if (GameObject.Find("Settings").GetComponent<SettingsProperties>().killnpc)
				{
					base.gameObject.GetComponent<EndZoneSync>().killnpc = true;
				}
				if (base.gameObject.GetComponent<EndZoneProperties>().loadstory)
				{
					GameObject.Find("EndGame").GetComponent<EndGame>().storyname = base.gameObject.GetComponent<EndZoneProperties>().storyname;
				}
				base.gameObject.GetComponent<Collider>().isTrigger = true;
			}
			if (base.gameObject.GetComponent<CameraProperties>() != null)
			{
				GameObject gameObject43 = UnityEngine.Object.Instantiate(Resources.Load("IngameCamera"), base.transform.position, base.transform.rotation) as GameObject;
				gameObject43.name = base.gameObject.GetComponent<CameraProperties>().camname;
			}
			if (base.gameObject.GetComponent<TimerProperties>() != null)
			{
				base.gameObject.AddComponent<TimerZone>();
				base.gameObject.GetComponent<TimerZone>().tp = base.gameObject.GetComponent<TimerProperties>();
				base.gameObject.GetComponent<TimerZone>().maintimer = float.Parse(base.gameObject.GetComponent<TimerProperties>().duration);
				if (base.gameObject.GetComponent<Collider>() != null)
				{
					base.gameObject.GetComponent<Collider>().isTrigger = true;
				}
			}
			if (base.gameObject.name == "Events/Death Barrier")
			{
				base.gameObject.AddComponent<DeathZone>();
			}
			if (base.gameObject.GetComponent<AudioProperties>() != null)
			{
				GameObject gameObject44 = UnityEngine.Object.Instantiate(Resources.Load("AudioZone"), base.transform.position, base.transform.rotation) as GameObject;
				gameObject44.GetComponent<AudioZone>().org = base.gameObject;
				gameObject44.GetComponent<AudioZone>().enabled = true;
				gameObject44.transform.parent = base.transform;
				if (base.gameObject.GetComponent<Collider>() != null)
				{
					base.gameObject.GetComponent<Collider>().isTrigger = true;
				}
			}
			if (base.gameObject.GetComponent<PlayerPrefsProperties>() != null)
			{
				base.gameObject.AddComponent<PlayerPrefsZone>();
			}
			if (base.gameObject.GetComponent<AdvTeleportProperties>() != null)
			{
				base.gameObject.AddComponent<AdvTeleportZone>();
			}
			if (base.gameObject.GetComponent<TriggerProperties>() != null)
			{
				base.GetComponent<Collider>().isTrigger = true;
				base.gameObject.AddComponent<TriggerZoneOffline>();
				base.gameObject.GetComponent<TriggerZoneOffline>().tp = base.gameObject.GetComponent<TriggerProperties>();
			}
			if (base.gameObject.GetComponent<ModelProperties>() != null)
			{
				if (!base.gameObject.GetComponent<ModelProperties>().none)
				{
					base.gameObject.AddComponent<MoveDown>();
				}
				if (base.gameObject.GetComponent<ModelProperties>().rigidbody && (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3))
				{
					if (PhotonNetwork.isMasterClient && this.pvobj == null)
					{
						this.pvobj = PhotonNetwork.InstantiateSceneObject("photongravityobj", base.transform.position, base.transform.rotation, 0, null);
						this.pvobj.name = base.gameObject.name;
					}
					base.gameObject.GetComponent<MeshRenderer>().enabled = false;
					base.gameObject.GetComponent<Collider>().isTrigger = true;
				}
				base.GetComponent<Renderer>().material.color = Color.white;
				base.gameObject.GetComponent<ModelProperties>().enabled = false;
			}
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x040006A0 RID: 1696
	public GameObject obj;

	// Token: 0x040006A1 RID: 1697
	public GameObject pvobj;

	// Token: 0x040006A2 RID: 1698
	public string id;
}
