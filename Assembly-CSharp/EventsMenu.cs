using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class EventsMenu : MonoBehaviour
{
	// Token: 0x060003E4 RID: 996 RVA: 0x00023913 File Offset: 0x00021D13
	private void Start()
	{
		this.sceneryMapMaker = base.gameObject.GetComponent<SceneryMapMaker>();
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x00023926 File Offset: 0x00021D26
	private void Update()
	{
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00023928 File Offset: 0x00021D28
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(4, new Rect(5f, 40f, 700f, 530f), new GUI.WindowFunction(this.DoWindow0), "Events");
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00023968 File Offset: 0x00021D68
	private void DoWindow0(int windowID)
	{
		GUI.Label(new Rect(50f, 30f, 100f, 20f), "Main Events");
		if (GUI.Button(new Rect(50f, 50f, 100f, 100f), "Trigger Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Trigger Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(150f, 50f, 100f, 100f), "End Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/End Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(250f, 50f, 100f, 100f), "Audio Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Audio Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(350f, 50f, 100f, 100f), "Timer"))
		{
			this.sceneryMapMaker.currentpath = "Events/Timer";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(450f, 50f, 100f, 100f), "Camera"))
		{
			this.sceneryMapMaker.currentpath = "Events/Camera";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(550f, 50f, 100f, 100f), "Cinematic\nCamera"))
		{
			this.sceneryMapMaker.currentpath = "Events/CinematicCamera";
			base.enabled = false;
		}
		GUI.Label(new Rect(50f, 150f, 100f, 20f), "Other Events");
		if (GUI.Button(new Rect(50f, 170f, 100f, 100f), "Player Prefs \n Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Player Prefs Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(150f, 170f, 100f, 100f), "Advanced \n Teleport Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Adv Teleport Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(250f, 170f, 100f, 100f), "Invisible Barrier"))
		{
			this.sceneryMapMaker.currentpath = "Events/Invisible Barrier";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(350f, 170f, 100f, 100f), "Death Barrier"))
		{
			this.sceneryMapMaker.currentpath = "Events/Death Barrier";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(450f, 170f, 100f, 100f), "NPC Avoid"))
		{
			this.sceneryMapMaker.currentpath = "Events/NPC Avoid";
			base.enabled = false;
		}
		GUI.Label(new Rect(50f, 270f, 100f, 20f), "Climbing");
		if (GUI.Button(new Rect(50f, 290f, 100f, 100f), "Climbing Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Climbing Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(150f, 290f, 100f, 100f), "Vault Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Vault Zone";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(250f, 290f, 100f, 100f), "Rope Zone"))
		{
			this.sceneryMapMaker.currentpath = "Events/Rope Zone";
			base.enabled = false;
		}
		GUI.Label(new Rect(50f, 390f, 100f, 20f), "Points");
		if (GUI.Button(new Rect(50f, 410f, 100f, 100f), "Player Start \n Point"))
		{
			this.sceneryMapMaker.currentpath = "Events/Player Start Point";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(150f, 410f, 100f, 100f), "Monster Start \n Point (Versus)"))
		{
			this.sceneryMapMaker.currentpath = "Events/Monster Start Point";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(250f, 410f, 100f, 100f), "Node"))
		{
			this.sceneryMapMaker.currentpath = "Events/Node";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(350f, 410f, 100f, 100f), "Patrol Node"))
		{
			this.sceneryMapMaker.currentpath = "Events/Patrol_Node";
			base.enabled = false;
		}
	}

	// Token: 0x04000467 RID: 1127
	public GUISkin skin;

	// Token: 0x04000468 RID: 1128
	public SceneryMapMaker sceneryMapMaker;
}
