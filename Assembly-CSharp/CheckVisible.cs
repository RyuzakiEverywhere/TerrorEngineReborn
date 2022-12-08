using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class CheckVisible : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x000051B7 File Offset: 0x000035B7
	private void Awake()
	{
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000051BC File Offset: 0x000035BC
	private void Start()
	{
		if (base.gameObject.GetComponent<ModelProperties>() != null)
		{
			if (base.gameObject.GetComponent<ModelProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<ModelProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<ModelProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<WallProperties>() != null)
		{
			if (base.gameObject.GetComponent<WallProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<WallProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<WallProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<LightProperties>() != null)
		{
			if (base.gameObject.GetComponent<LightProperties>().togglevisible)
			{
				this.id = "AllEnabledLights";
			}
			else
			{
				this.id = "AllDisabledLights";
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<EffectProperties>() != null)
		{
			if (base.gameObject.GetComponent<EffectProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<EffectProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<EffectProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<NPCObjProperties>() != null)
		{
			if (base.gameObject.GetComponent<NPCObjProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<NPCObjProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<NPCObjProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<TriggerProperties>() != null)
		{
			if (base.gameObject.GetComponent<TriggerProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<TriggerProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<TriggerProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<DoorProperties>() != null)
		{
			if (base.gameObject.GetComponent<DoorProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<DoorProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<DoorProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<TimerProperties>() != null)
		{
			if (base.gameObject.GetComponent<TimerProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<TimerProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<TimerProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<PlayerPrefsProperties>() != null)
		{
			if (base.gameObject.GetComponent<PlayerPrefsProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<PlayerPrefsProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<PlayerPrefsProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<AdvTeleportProperties>() != null)
		{
			if (base.gameObject.GetComponent<AdvTeleportProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<AdvTeleportProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<AdvTeleportProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<AudioProperties>() != null)
		{
			if (base.gameObject.GetComponent<AudioProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<AudioProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<AudioProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<NodeProperties>() != null)
		{
			if (base.gameObject.GetComponent<NodeProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<NodeProperties>().nodename;
			}
			else
			{
				this.id = base.gameObject.GetComponent<NodeProperties>().nodename;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<ModProperties>() != null)
		{
			if (base.gameObject.GetComponent<ModProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<ModProperties>().modname;
			}
			else
			{
				this.id = base.gameObject.GetComponent<ModProperties>().modname;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<EndZoneProperties>() != null)
		{
			if (base.gameObject.GetComponent<EndZoneProperties>().togglevisible)
			{
				this.id = base.gameObject.GetComponent<EndZoneProperties>().triggerid;
			}
			else
			{
				this.id = base.gameObject.GetComponent<EndZoneProperties>().triggerid;
				base.gameObject.active = false;
			}
		}
		if (base.gameObject.GetComponent<CinematicProperties>() != null)
		{
			base.gameObject.AddComponent<CinematicTrigger>();
		}
	}

	// Token: 0x04000045 RID: 69
	public string id;
}
