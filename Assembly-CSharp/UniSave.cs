using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ProtoBuf;
using ProtoBuf.Meta;
using UnityEngine;

// Token: 0x02000250 RID: 592
public static class UniSave
{
	// Token: 0x0600108D RID: 4237 RVA: 0x000687D4 File Offset: 0x00066BD4
	static UniSave()
	{
		UniSave.GameObjects = new List<GameObjectSerializer>();
		UniSave._deserializedData = new SaveData();
		UniSave.SavedUniqueGameObjectName = new List<string>();
		UniSave._savedUniqueGameObjectNameResults = new List<string>();
		UniSave.DestroyedObjectNames = new List<string>();
		UniSave._destroyedObjectsResults = new List<string>();
		UniSave.Model = TypeModel.Create();
		MetaType metaType = UniSave.Model.Add(typeof(object), true);
		int num = 1;
		foreach (Type derivedType in from component in UniSave.SupportedComponents
		select Type.GetType(component.Value))
		{
			metaType.AddSubType(num, derivedType);
			num++;
		}
		UniSave.Crypto = new RijndaelManaged
		{
			Key = Encoding.ASCII.GetBytes("euWSPxcFdNX4lsph"),
			IV = Encoding.ASCII.GetBytes("f8LEgmUIAsFtwC1l")
		};
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x00068E0C File Offset: 0x0006720C
	public static bool IsComponentSupported(Component component)
	{
		foreach (KeyValuePair<string, string> keyValuePair in UniSave.SupportedComponents)
		{
			if (component.GetType().Name == keyValuePair.Key)
			{
				UniSave._isSupported = true;
				break;
			}
			UniSave._isSupported = false;
		}
		return UniSave._isSupported;
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x00068E94 File Offset: 0x00067294
	public static string GetOriginalComponentName(string type)
	{
		IEnumerable<string> source = from component in UniSave.SupportedComponents
		where component.Value.Equals(type)
		select component.Key;
		return source.FirstOrDefault<string>();
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06001090 RID: 4240 RVA: 0x00068EF0 File Offset: 0x000672F0
	// (remove) Token: 0x06001091 RID: 4241 RVA: 0x00068F24 File Offset: 0x00067324
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event UniSave.OperationFailedHandler OnSavingFailed;

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06001092 RID: 4242 RVA: 0x00068F58 File Offset: 0x00067358
	// (remove) Token: 0x06001093 RID: 4243 RVA: 0x00068F8C File Offset: 0x0006738C
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event UniSave.OperationFailedHandler OnLoadingFailed;

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06001094 RID: 4244 RVA: 0x00068FC0 File Offset: 0x000673C0
	// (remove) Token: 0x06001095 RID: 4245 RVA: 0x00068FF4 File Offset: 0x000673F4
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event UniSave.OperationCompletedHandler OnSavingCompleted;

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06001096 RID: 4246 RVA: 0x00069028 File Offset: 0x00067428
	// (remove) Token: 0x06001097 RID: 4247 RVA: 0x0006905C File Offset: 0x0006745C
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event UniSave.OperationCompletedHandler OnLoadingCompleted;

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x06001098 RID: 4248 RVA: 0x00069090 File Offset: 0x00067490
	// (set) Token: 0x06001099 RID: 4249 RVA: 0x00069097 File Offset: 0x00067497
	public static bool IsSaving { get; private set; }

	// Token: 0x0600109A RID: 4250 RVA: 0x000690A0 File Offset: 0x000674A0
	public static SaveFileInfo[] GetSaves()
	{
		RuntimePlatform platform = Application.platform;
		DirectoryInfo directoryInfo;
		switch (platform)
		{
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			break;
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			directoryInfo = new DirectoryInfo("Levels");
			if (!Directory.Exists("Levels"))
			{
				Directory.CreateDirectory("Levels");
			}
			goto IL_D0;
		default:
			if (platform != RuntimePlatform.Android)
			{
				directoryInfo = null;
				goto IL_D0;
			}
			break;
		}
		directoryInfo = new DirectoryInfo(Application.persistentDataPath + Path.DirectorySeparatorChar + "Levels");
		if (!Directory.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Levels"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + Path.DirectorySeparatorChar + "Levels");
		}
		IL_D0:
		SaveFileInfo[] array;
		if (directoryInfo == null)
		{
			UnityEngine.Debug.LogError("Couldn't retrieve a list of save files, because no supported platform is found.");
			array = new SaveFileInfo[0];
			return array;
		}
		UnityEngine.Debug.Log("POOP");
		FileInfo[] array2 = (from f in directoryInfo.GetFiles("*.story")
		where File.Exists(string.Concat(new object[]
		{
			"Levels",
			Path.DirectorySeparatorChar,
			f.Name.Replace(".story", string.Empty),
			".info"
		}))
		select f).ToArray<FileInfo>();
		array2 = (from f in array2
		orderby f.LastWriteTimeUtc descending
		select f).ToArray<FileInfo>();
		array = new SaveFileInfo[array2.Count<FileInfo>()];
		UnityEngine.Debug.Log(array.Length.ToString());
		int num = 0;
		foreach (FileInfo fileInfo in array2)
		{
			using (FileStream fileStream = File.OpenRead("Levels" + Path.DirectorySeparatorChar + fileInfo.Name.Replace(".story", ".info")))
			{
				SaveFileInfo saveFileInfo = new SaveFileInfo(Serializer.Deserialize<SaveFileInfo>(fileStream));
				array[num] = saveFileInfo;
			}
			num++;
		}
		return array;
	}

	// Token: 0x0600109B RID: 4251 RVA: 0x000692B8 File Offset: 0x000676B8
	public static void Save(string saveName)
	{
		if (string.IsNullOrEmpty(saveName))
		{
			UnityEngine.Debug.LogError("The name of the save file is invalid.");
			return;
		}
		if (UniSave._serializationThread != null && UniSave._serializationThread.IsAlive)
		{
			return;
		}
		UniSave.IsSaving = true;
		UniSave._currentSaveName = saveName;
		RuntimePlatform platform = Application.platform;
		switch (platform)
		{
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			break;
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			UniSave._filePath = string.Concat(new object[]
			{
				"Levels",
				Path.DirectorySeparatorChar,
				saveName,
				".story"
			});
			UniSave._saveFileInfoPath = string.Concat(new object[]
			{
				"Levels",
				Path.DirectorySeparatorChar,
				saveName,
				".info"
			});
			if (!Directory.Exists("Levels"))
			{
				Directory.CreateDirectory("Levels");
			}
			goto IL_1C9;
		default:
			if (platform != RuntimePlatform.Android)
			{
				goto IL_1C9;
			}
			break;
		}
		UniSave._filePath = string.Concat(new object[]
		{
			Application.persistentDataPath,
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar,
			saveName,
			".story"
		});
		UniSave._saveFileInfoPath = string.Concat(new object[]
		{
			Application.persistentDataPath,
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar,
			saveName,
			".info"
		});
		if (!Directory.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Levels"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + Path.DirectorySeparatorChar + "Levels");
		}
		IL_1C9:
		if (UniSave._serializationData == null)
		{
			UniSave._serializationData = new SaveData();
		}
		State[] array = UnityEngine.Object.FindObjectsOfType(typeof(State)) as State[];
		if (array != null)
		{
			foreach (State state in array)
			{
				state.Save();
			}
		}
		UniSave._serializationData.LevelName = Application.loadedLevelName;
		UniSave._serializationData.UniqueGameObjectNames = UniSave.SavedUniqueGameObjectName;
		UniSave._serializationData.GameObjects = UniSave.GameObjects;
		UniSave._serializationData.DestroyedObjectNames = UniSave.DestroyedObjectNames;
		UniSave._fileInfo = new SaveFileInfo(saveName, Application.loadedLevel, Application.loadedLevelName, DateTime.UtcNow.ToString("M/d/yyyy hh:mm tt"));
		if (UniSave.<>f__mg$cache0 == null)
		{
			UniSave.<>f__mg$cache0 = new ThreadStart(UniSave.Serialize);
		}
		UniSave._serializationThread = new Thread(UniSave.<>f__mg$cache0);
		UniSave._serializationThread.Start();
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x00069578 File Offset: 0x00067978
	private static void Serialize()
	{
		ICryptoTransform transform = UniSave.Crypto.CreateEncryptor(UniSave.Crypto.Key, UniSave.Crypto.IV);
		DateTime now = DateTime.Now;
		try
		{
			using (FileStream fileStream = File.Create(UniSave._filePath))
			{
				using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write))
				{
					UniSave.Model.Serialize(cryptoStream, UniSave._serializationData);
				}
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Saving \"" + UniSave._currentSaveName + "\" failed. " + ex.Message);
			if (UniSave.OnSavingFailed != null)
			{
				UniSave.OnSavingFailed(ex);
			}
			return;
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			UniSave.Model.Serialize(memoryStream, UniSave._serializationData);
			UniSave._saveFileCache = memoryStream.ToArray();
		}
		UniSave.Log(LogType.Log, "File \"" + UniSave._currentSaveName + "\" saved to memory.");
		if (UniSave.OnSavingCompleted != null)
		{
			UniSave.OnSavingCompleted();
		}
		UniSave._memoryFileName = UniSave._currentSaveName;
		using (FileStream fileStream2 = File.Create(UniSave._saveFileInfoPath))
		{
			Serializer.Serialize<SaveFileInfo>(fileStream2, UniSave._fileInfo);
		}
		UniSave.IsSaving = false;
		DateTime now2 = DateTime.Now;
		TimeSpan timeSpan = now2 - now;
		UniSave.Log(LogType.Log, "Saved \"" + UniSave._currentSaveName + "\" successfully.");
		UniSave.Log(LogType.Log, "Save time: " + timeSpan);
		UniSave._serializationData = null;
		UniSave.GameObjects.Clear();
		UniSave.SavedUniqueGameObjectName.Clear();
		UniSave.DestroyedObjectNames.Clear();
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x0006977C File Offset: 0x00067B7C
	public static IEnumerator LoadAfterLoadingScreen()
	{
		if (UniSave._filePath == null)
		{
			yield break;
		}
		DateTime startTime = DateTime.Now;
		try
		{
			if (UniSave._saveFileCache != null && UniSave._currentSaveName == UniSave._memoryFileName)
			{
				UniSave.Log(LogType.Log, "File \"" + UniSave._currentSaveName + "\" is in memory. Loading from memory.");
				using (MemoryStream memoryStream = new MemoryStream(UniSave._saveFileCache))
				{
					memoryStream.Position = 0L;
					UniSave._deserializedData = (SaveData)UniSave.Model.Deserialize(memoryStream, UniSave._deserializedData, typeof(SaveData));
				}
			}
			else
			{
				UniSave.Log(LogType.Log, "File \"" + UniSave._currentSaveName + "\" is not in memory. Loading from disk.");
				ICryptoTransform transform = UniSave.Crypto.CreateDecryptor(UniSave.Crypto.Key, UniSave.Crypto.IV);
				using (FileStream fileStream = File.OpenRead(UniSave._filePath))
				{
					using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Read))
					{
						UniSave._deserializedData = (SaveData)UniSave.Model.Deserialize(cryptoStream, UniSave._deserializedData, typeof(SaveData));
					}
				}
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					UniSave.Model.Serialize(memoryStream2, UniSave._deserializedData);
					UniSave._saveFileCache = memoryStream2.ToArray();
				}
				UniSave._memoryFileName = UniSave._currentSaveName;
				UniSave.Log(LogType.Log, "File \"" + UniSave._currentSaveName + "\" saved to memory.");
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Failed loading \"" + UniSave._currentSaveName + "\". " + ex.Message);
			if (UniSave.OnLoadingFailed != null)
			{
				UniSave.OnLoadingFailed(ex);
			}
			yield break;
		}
		Application.LoadLevel(UniSave._deserializedData.LevelName);
		while (Application.isLoadingLevel)
		{
			yield return null;
		}
		UniSave.DestroyedGameObjects();
		UniSave.DefaultGameObjects();
		UniSave.RuntimeGameObjects();
		DateTime endTime = DateTime.Now;
		TimeSpan duration = endTime - startTime;
		UniSave.Log(LogType.Log, "Loaded \"" + UniSave._currentSaveName + "\" successfully.");
		UniSave.Log(LogType.Log, "Load time: " + duration);
		if (UniSave.OnLoadingCompleted != null)
		{
			UniSave.OnLoadingCompleted();
		}
		UniSave._deserializedData = null;
		yield break;
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x00069790 File Offset: 0x00067B90
	public static void Delete(string saveName)
	{
		RuntimePlatform platform = Application.platform;
		switch (platform)
		{
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			break;
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			UniSave._filePath = string.Concat(new object[]
			{
				"Levels",
				Path.DirectorySeparatorChar,
				saveName,
				".story"
			});
			UniSave._saveFileInfoPath = string.Concat(new object[]
			{
				"Levels",
				Path.DirectorySeparatorChar,
				saveName,
				".info"
			});
			goto IL_131;
		default:
			if (platform != RuntimePlatform.Android)
			{
				goto IL_131;
			}
			break;
		}
		UniSave._filePath = string.Concat(new object[]
		{
			Application.persistentDataPath,
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar,
			saveName,
			".story"
		});
		UniSave._saveFileInfoPath = string.Concat(new object[]
		{
			Application.persistentDataPath,
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar,
			saveName,
			".info"
		});
		IL_131:
		File.Delete(UniSave._filePath);
		File.Delete(UniSave._saveFileInfoPath);
	}

	// Token: 0x0600109F RID: 4255 RVA: 0x000698E4 File Offset: 0x00067CE4
	private static void DestroyedGameObjects()
	{
		UnityEngine.Object.Destroy(Loading.Instance.gameObject);
		UniSave.DestroyedObjectNames.Clear();
		UniSave._destroyedObjectsResults = UniSave._deserializedData.DestroyedObjectNames;
		IEnumerable<GameObject> enumerable = from destroyedObjectName in UniSave._destroyedObjectsResults
		from obj in UnityEngine.Object.FindObjectsOfType(typeof(State)) as State[]
		select new
		{
			destroyedObjectName,
			obj
		} into <>__TranspIdent0
		where !<>__TranspIdent0.obj.IsSpawnedAtRuntime && <>__TranspIdent0.destroyedObjectName == <>__TranspIdent0.obj.UniqueName
		select <>__TranspIdent0.obj.gameObject;
		foreach (GameObject obj2 in enumerable)
		{
			UnityEngine.Object.Destroy(obj2);
		}
		UniSave._savedUniqueGameObjectNameResults = UniSave._deserializedData.UniqueGameObjectNames;
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x000699F8 File Offset: 0x00067DF8
	private static void DefaultGameObjects()
	{
		IEnumerable<State> source = from obj in UnityEngine.Object.FindObjectsOfType(typeof(State)) as State[]
		where !obj.IsSpawnedAtRuntime
		select obj;
		Dictionary<string, GameObject> defaultObjectNames = source.ToDictionary((State obj) => obj.UniqueName, (State obj) => obj.gameObject);
		UniSave._gameObjectsResults = UniSave._deserializedData.GameObjects;
		var enumerable = from goUniqueName in defaultObjectNames
		where UniSave._savedUniqueGameObjectNameResults.Contains(goUniqueName.Key)
		from gameObject in UniSave._gameObjectsResults
		select new
		{
			goUniqueName,
			gameObject
		} into <>__TranspIdent1
		where <>__TranspIdent1.gameObject.UniqueName == <>__TranspIdent1.goUniqueName.Key
		from objectComponent in <>__TranspIdent1.gameObject.Components.Cast<object>()
		select new
		{
			objectComponent = objectComponent,
			SerializedData = <>__TranspIdent1.gameObject,
			Key = defaultObjectNames[<>__TranspIdent1.goUniqueName.Key]
		};
		foreach (var <>__AnonType in enumerable)
		{
			<>__AnonType.Key.name = <>__AnonType.SerializedData.Name;
			<>__AnonType.Key.hideFlags = (HideFlags)<>__AnonType.SerializedData.HideFlags;
			<>__AnonType.Key.isStatic = <>__AnonType.SerializedData.IsStatic;
			<>__AnonType.Key.layer = <>__AnonType.SerializedData.Layer;
			<>__AnonType.Key.active = <>__AnonType.SerializedData.Active;
			<>__AnonType.Key.tag = <>__AnonType.SerializedData.Tag;
			Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[UniSave.GetOriginalComponentName(<>__AnonType.objectComponent.GetType().Name)], false, BindingFlags.CreateInstance, null, new object[]
			{
				<>__AnonType.Key,
				<>__AnonType.objectComponent
			}, null, null);
		}
	}

	// Token: 0x060010A1 RID: 4257 RVA: 0x00069C64 File Offset: 0x00068064
	private static void RuntimeGameObjects()
	{
		IEnumerable<GameObjectSerializer> enumerable = from gameObject in UniSave._gameObjectsResults
		from component in gameObject.Components
		select new
		{
			gameObject,
			component
		} into <>__TranspIdent2
		where <>__TranspIdent2.component is StateSerializer
		select new
		{
			<>__TranspIdent2 = <>__TranspIdent2,
			state = (StateSerializer)<>__TranspIdent2.component
		} into <>__TranspIdent3
		where <>__TranspIdent3.state.IsSpawnedAtRuntime
		select <>__TranspIdent3.<>__TranspIdent2.gameObject;
		foreach (GameObjectSerializer gameObjectSerializer in enumerable)
		{
			GameObject gameObject2 = new GameObject
			{
				name = gameObjectSerializer.Name,
				hideFlags = (HideFlags)gameObjectSerializer.HideFlags,
				isStatic = gameObjectSerializer.IsStatic,
				layer = gameObjectSerializer.Layer,
				active = gameObjectSerializer.Active,
				tag = gameObjectSerializer.Tag
			};
			foreach (object obj in gameObjectSerializer.Components)
			{
				Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[UniSave.GetOriginalComponentName(obj.GetType().Name)], false, BindingFlags.CreateInstance, null, new object[]
				{
					gameObject2,
					obj
				}, null, null);
			}
			UniSave.CreateChildren(gameObjectSerializer, gameObject2);
		}
	}

	// Token: 0x060010A2 RID: 4258 RVA: 0x00069E64 File Offset: 0x00068264
	private static void CreateChildren(GameObjectSerializer gameObject, GameObject newGameObject)
	{
		foreach (GameObjectSerializer gameObjectSerializer in gameObject.Children)
		{
			GameObject gameObject2 = new GameObject
			{
				name = gameObjectSerializer.Name,
				hideFlags = (HideFlags)gameObjectSerializer.HideFlags,
				isStatic = gameObjectSerializer.IsStatic,
				layer = gameObjectSerializer.Layer,
				active = gameObjectSerializer.Active,
				tag = gameObjectSerializer.Tag
			};
			foreach (object obj in gameObjectSerializer.Components)
			{
				Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[UniSave.GetOriginalComponentName(obj.GetType().Name)], false, BindingFlags.CreateInstance, null, new object[]
				{
					gameObject2,
					obj
				}, null, null);
			}
			gameObject2.transform.parent = newGameObject.transform;
			gameObject2.transform.localPosition = (Vector3)gameObjectSerializer.LocalPosition;
			gameObject2.transform.localRotation = (Quaternion)gameObjectSerializer.LocalRotation;
			gameObject2.transform.localScale = (Vector3)gameObjectSerializer.LocalScale;
			if (gameObjectSerializer.Children.Count > 0)
			{
				UniSave.CreateChildren(gameObjectSerializer, gameObject2);
			}
		}
	}

	// Token: 0x060010A3 RID: 4259 RVA: 0x0006A010 File Offset: 0x00068410
	public static void Load(string saveName)
	{
		UniSave._currentSaveName = saveName;
		RuntimePlatform platform = Application.platform;
		switch (platform)
		{
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			break;
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			UniSave._filePath = string.Concat(new object[]
			{
				"Levels",
				Path.DirectorySeparatorChar,
				saveName,
				".story"
			});
			goto IL_CF;
		default:
			if (platform != RuntimePlatform.Android)
			{
				goto IL_CF;
			}
			break;
		}
		UniSave._filePath = string.Concat(new object[]
		{
			Application.persistentDataPath,
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar,
			saveName,
			".story"
		});
		CryptoPlayerPrefs.SetString("filePath", UniSave._filePath);
		IL_CF:
		Application.LoadLevel("Loading");
	}

	// Token: 0x060010A4 RID: 4260 RVA: 0x0006A0F8 File Offset: 0x000684F8
	public static string GenerateUniqueGameObjectName(GameObject gameObject)
	{
		return string.Concat(new object[]
		{
			gameObject.name,
			"_",
			gameObject.transform.position,
			"_",
			gameObject.transform.rotation
		});
	}

	// Token: 0x060010A5 RID: 4261 RVA: 0x0006A150 File Offset: 0x00068550
	public static void CreateGameObject(State state)
	{
		GameObjectSerializer gameObjectSerializer = new GameObjectSerializer
		{
			Name = state.gameObject.name,
			HideFlags = (HideFlagsSerializer)state.gameObject.hideFlags,
			IsStatic = state.gameObject.isStatic,
			Layer = state.gameObject.layer,
			Active = state.gameObject.active,
			Tag = state.gameObject.tag,
			UniqueName = state.UniqueName
		};
		if (!state.IsSpawnedAtRuntime)
		{
			UniSave.SavedUniqueGameObjectName.Add(state.UniqueName);
			IEnumerable<object> enumerable = from i in state.List
			select new
			{
				i = i,
				componentName = state.PopupList[i]
			} into <>__TranspIdent4
			select Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[<>__TranspIdent4.componentName], false, BindingFlags.CreateInstance, null, new object[]
			{
				state.gameObject
			}, null, null);
			foreach (object item in enumerable)
			{
				gameObjectSerializer.Components.Add(item);
			}
		}
		else if (state.IsSpawnedAtRuntime)
		{
			IEnumerable<object> enumerable2 = from component in state.ComponentList
			select new
			{
				component = component,
				componentName = component.GetType().Name
			} into <>__TranspIdent5
			select Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[<>__TranspIdent5.componentName], false, BindingFlags.CreateInstance, null, new object[]
			{
				state.gameObject
			}, null, null);
			foreach (object item2 in enumerable2)
			{
				gameObjectSerializer.Components.Add(item2);
			}
			UniSave.GetChildren(state, gameObjectSerializer);
		}
		UniSave.GameObjects.Add(gameObjectSerializer);
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x0006A36C File Offset: 0x0006876C
	public static void AddToDestroyedObjectsList(string uniqueName)
	{
		UniSave.DestroyedObjectNames.Add(uniqueName);
	}

	// Token: 0x060010A7 RID: 4263 RVA: 0x0006A37C File Offset: 0x0006877C
	private static void GetChildren(State state, GameObjectSerializer parentGameObject)
	{
		IEnumerator enumerator = state.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				State component2 = transform.GetComponent<State>();
				if (component2 == null)
				{
					UnityEngine.Debug.LogError("State component not found on child.");
				}
				else
				{
					GameObjectSerializer gameObjectSerializer = new GameObjectSerializer
					{
						Name = transform.gameObject.name,
						HideFlags = (HideFlagsSerializer)transform.gameObject.hideFlags,
						IsStatic = transform.gameObject.isStatic,
						Layer = transform.gameObject.layer,
						Active = transform.gameObject.active,
						Tag = transform.gameObject.tag,
						UniqueName = component2.UniqueName,
						LocalPosition = (Vector3Serializer)transform.localPosition,
						LocalScale = (Vector3Serializer)transform.localScale,
						LocalRotation = (QuaternionSerializer)transform.localRotation
					};
					Transform currentChild = transform;
					IEnumerable<object> enumerable = from component in component2.ComponentList
					select new
					{
						component = component,
						componentName = component.GetType().Name
					} into <>__TranspIdent6
					select Assembly.GetExecutingAssembly().CreateInstance(UniSave.SupportedComponents[<>__TranspIdent6.componentName], false, BindingFlags.CreateInstance, null, new object[]
					{
						currentChild.gameObject
					}, null, null);
					foreach (object item in enumerable)
					{
						gameObjectSerializer.Components.Add(item);
					}
					parentGameObject.Children.Add(gameObjectSerializer);
					if (transform.childCount > 0)
					{
						UniSave.GetChildren(component2, gameObjectSerializer);
					}
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x060010A8 RID: 4264 RVA: 0x0006A58C File Offset: 0x0006898C
	public static object TryLoadResource(string resourceName)
	{
		string text = resourceName.Replace(" (Instance)", string.Empty);
		UnityEngine.Object @object = Resources.Load(text);
		if (@object == null)
		{
			if (text != null)
			{
				if (text == "Arial" || text == "Font Material" || text == "Default")
				{
					return @object;
				}
				if (text == "Default-Diffuse")
				{
					return UniSave.GetBuiltInResource(typeof(Material), "Default-Diffuse");
				}
				if (text == "Default-Particle")
				{
					return UniSave.GetBuiltInResource(typeof(Material), "Default-Particle");
				}
			}
			return null;
		}
		return @object;
	}

	// Token: 0x060010A9 RID: 4265 RVA: 0x0006A64C File Offset: 0x00068A4C
	private static object GetBuiltInResource(Type type, string name)
	{
		return Resources.FindObjectsOfTypeAll(type).FirstOrDefault((UnityEngine.Object material) => material.name == name);
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x0006A680 File Offset: 0x00068A80
	private static void Log(LogType type, object message)
	{
		if (!UniSave.EnableLogging)
		{
			return;
		}
		if (type != LogType.Log)
		{
			if (type != LogType.Warning)
			{
				if (type == LogType.Error)
				{
					UnityEngine.Debug.LogError(message);
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning(message);
			}
		}
		else
		{
			UnityEngine.Debug.Log(message);
		}
	}

	// Token: 0x0400112E RID: 4398
	public static Dictionary<string, string> SupportedComponents = new Dictionary<string, string>
	{
		{
			"Transform",
			"TransformSerializer"
		},
		{
			"Terrain",
			"TerrainSerializer"
		},
		{
			"MeshRenderer",
			"MeshRendererSerializer"
		},
		{
			"ParticleSystem",
			"ParticleSystemSerializer"
		},
		{
			"TrailRenderer",
			"TrailRendererSerializer"
		},
		{
			"LineRenderer",
			"LineRendererSerializer"
		},
		{
			"LensFlare",
			"LensFlareSerializer"
		},
		{
			"Projector",
			"ProjectorSerializer"
		},
		{
			"ParticleAnimator",
			"ParticleAnimatorSerializer"
		},
		{
			"ParticleRenderer",
			"ParticleRendererSerializer"
		},
		{
			"Rigidbody",
			"RigidbodySerializer"
		},
		{
			"CharacterController",
			"CharacterControllerSerializer"
		},
		{
			"BoxCollider",
			"BoxColliderSerializer"
		},
		{
			"SphereCollider",
			"SphereColliderSerializer"
		},
		{
			"CapsuleCollider",
			"CapsuleColliderSerializer"
		},
		{
			"WheelCollider",
			"WheelColliderSerializer"
		},
		{
			"TerrainCollider",
			"TerrainColliderSerializer"
		},
		{
			"InteractiveCloth",
			"InteractiveClothSerializer"
		},
		{
			"SkinnedCloth",
			"SkinnedClothSerializer"
		},
		{
			"ClothRenderer",
			"ClothRendererSerializer"
		},
		{
			"HingeJoint",
			"HingeJointSerializer"
		},
		{
			"FixedJoint",
			"FixedJointSerializer"
		},
		{
			"SpringJoint",
			"SpringJointSerializer"
		},
		{
			"CharacterJoint",
			"CharacterJointSerializer"
		},
		{
			"ConfigurableJoint",
			"ConfigurableJointSerializer"
		},
		{
			"ConstantForce",
			"ConstantForceSerializer"
		},
		{
			"NavMeshAgent",
			"NavMeshAgentSerializer"
		},
		{
			"OffMeshLink",
			"OffMeshLinkSerializer"
		},
		{
			"AudioListener",
			"AudioListenerSerializer"
		},
		{
			"AudioSource",
			"AudioSourceSerializer"
		},
		{
			"AudioReverbZone",
			"AudioReverbZoneSerializer"
		},
		{
			"AudioLowPassFilter",
			"AudioLowPassFilterSerializer"
		},
		{
			"AudioHighPassFilter",
			"AudioHighPassFilterSerializer"
		},
		{
			"AudioEchoFilter",
			"AudioEchoFilterSerializer"
		},
		{
			"AudioDistortionFilter",
			"AudioDistortionFilterSerializer"
		},
		{
			"AudioReverbFilter",
			"AudioReverbFilterSerializer"
		},
		{
			"AudioChorusFilter",
			"AudioChorusFilterSerializer"
		},
		{
			"Camera",
			"CameraSerializer"
		},
		{
			"Skybox",
			"SkyboxSerializer"
		},
		{
			"FlareLayer",
			"FlareLayerSerializer"
		},
		{
			"GUILayer",
			"GUILayerSerializer"
		},
		{
			"Light",
			"LightSerializer"
		},
		{
			"LightProbeGroup",
			"LightProbeGroupSerializer"
		},
		{
			"OcclusionArea",
			"OcclusionAreaSerializer"
		},
		{
			"OcclusionPortal",
			"OcclusionPortalSerializer"
		},
		{
			"LODGroup",
			"LODGroupSerializer"
		},
		{
			"GUITexture",
			"GUITextureSerializer"
		},
		{
			"GUIText",
			"GUITextSerializer"
		},
		{
			"State",
			"StateSerializer"
		},
		{
			"PositionAndScale",
			"PosandscaleSerializer"
		},
		{
			"TerrainProperties",
			"TerrainPropSerializer"
		},
		{
			"ModelMesh",
			"ModelSerializer"
		},
		{
			"LoadMeshFromWeb",
			"LoadMeshFromWebSerializer"
		},
		{
			"LoadOBJCS",
			"LoadOBJCSSerializer"
		},
		{
			"ModelProperties",
			"ModelPropSerializer"
		},
		{
			"SettingsProperties",
			"SettingsSerializer"
		},
		{
			"GridCreateObject",
			"GridObjSerializer"
		},
		{
			"EditObjEnable",
			"EnableObjSerializer"
		},
		{
			"WallProperties",
			"WallSerializer"
		},
		{
			"LightProperties",
			"LightObjSerializer"
		},
		{
			"EndZoneProperties",
			"EndZoneSerializer"
		},
		{
			"AdvTeleportProperties",
			"AdvTeleSerializer"
		},
		{
			"PlayerPrefsProperties",
			"PlayerPrefsSerializer"
		},
		{
			"TriggerProperties",
			"TriggerSerializer"
		},
		{
			"AudioProperties",
			"AudioSerializer"
		},
		{
			"TimerProperties",
			"TimerSerializer"
		},
		{
			"DoorProperties",
			"DoorSerializer"
		},
		{
			"ModProperties",
			"ModSerializer"
		},
		{
			"NPCProperties",
			"NPCSerializer"
		},
		{
			"NPCObjProperties",
			"NPCObjSerializer"
		},
		{
			"CustomItemsProperties",
			"CustomItemsSerializer"
		},
		{
			"DestroyMeshAndCollider",
			"MandCSerializer"
		},
		{
			"GlobalSkybox",
			"GlobalSkyboxSerializer"
		},
		{
			"PlayerProperties",
			"PlayerSerializer"
		},
		{
			"MonsterProperties",
			"MonsterSerializer"
		},
		{
			"KeyProperties",
			"KeySerializer"
		},
		{
			"EffectProperties",
			"EffectSerializer"
		},
		{
			"PathGridComponent",
			"ANpcGridSerializer"
		},
		{
			"NodeProperties",
			"NodeSerializer"
		},
		{
			"CameraProperties",
			"CameraObjSerializer"
		},
		{
			"CinematicProperties",
			"CinematicSerializer"
		}
	};

	// Token: 0x0400112F RID: 4399
	private static bool _isSupported;

	// Token: 0x04001134 RID: 4404
	public static bool EnableLogging = false;

	// Token: 0x04001135 RID: 4405
	private const string SaveFolder = "Levels";

	// Token: 0x04001136 RID: 4406
	private const string SaveFileExtension = ".story";

	// Token: 0x04001137 RID: 4407
	private const string SaveFileInfoExtension = ".info";

	// Token: 0x04001138 RID: 4408
	private const string CryptoKey = "euWSPxcFdNX4lsph";

	// Token: 0x04001139 RID: 4409
	private const string CryptoIV = "f8LEgmUIAsFtwC1l";

	// Token: 0x0400113A RID: 4410
	private static readonly List<GameObjectSerializer> GameObjects;

	// Token: 0x0400113B RID: 4411
	private static readonly List<string> SavedUniqueGameObjectName;

	// Token: 0x0400113C RID: 4412
	private static readonly RuntimeTypeModel Model;

	// Token: 0x0400113D RID: 4413
	private static SaveData _serializationData = new SaveData();

	// Token: 0x0400113E RID: 4414
	private static SaveData _deserializedData;

	// Token: 0x0400113F RID: 4415
	private static List<string> _savedUniqueGameObjectNameResults;

	// Token: 0x04001140 RID: 4416
	private static readonly List<string> DestroyedObjectNames;

	// Token: 0x04001141 RID: 4417
	private static List<string> _destroyedObjectsResults;

	// Token: 0x04001142 RID: 4418
	private static List<GameObjectSerializer> _gameObjectsResults;

	// Token: 0x04001143 RID: 4419
	private static string _filePath;

	// Token: 0x04001144 RID: 4420
	private static string _saveFileInfoPath;

	// Token: 0x04001145 RID: 4421
	private static SaveFileInfo _fileInfo;

	// Token: 0x04001146 RID: 4422
	private static readonly RijndaelManaged Crypto;

	// Token: 0x04001147 RID: 4423
	private static Thread _serializationThread;

	// Token: 0x04001148 RID: 4424
	private static byte[] _saveFileCache;

	// Token: 0x04001149 RID: 4425
	private static string _currentSaveName;

	// Token: 0x0400114A RID: 4426
	private static string _memoryFileName;

	// Token: 0x0400114F RID: 4431
	[CompilerGenerated]
	private static ThreadStart <>f__mg$cache0;

	// Token: 0x02000255 RID: 597
	// (Invoke) Token: 0x060010DA RID: 4314
	public delegate void OperationFailedHandler(Exception exception);

	// Token: 0x02000256 RID: 598
	// (Invoke) Token: 0x060010DE RID: 4318
	public delegate void OperationCompletedHandler();
}
