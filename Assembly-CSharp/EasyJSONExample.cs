using System;
using System.Collections;
using System.Collections.Generic;
using EasyJSON;
using UnityEngine;

// Token: 0x020001BB RID: 443
public class EasyJSONExample : MonoBehaviour
{
	// Token: 0x06000A95 RID: 2709 RVA: 0x0005CB38 File Offset: 0x0005AF38
	private IEnumerator Start()
	{
		EasyJSONExample.Box box = new EasyJSONExample.Box();
		box.dimension = new Vector3(2f, 1.5f, 3f);
		EasyJSONExample.Product product = new EasyJSONExample.Product();
		product.name = "Cheese";
		product.description = "Cheese made by a firefighter from Boston, Texas.";
		product.price = 9.99f;
		box.products.Add(product);
		EasyJSONExample.Product product2 = new EasyJSONExample.Product();
		product2.name = "Ham";
		product2.description = "Ham from Tokyo, Argentina.";
		product2.price = 69.69f;
		box.products.Add(product2);
		EasyJSONExample.Product product3 = new EasyJSONExample.Product();
		product3.name = "Bread";
		product3.description = "Bread gently cooked by your mother.";
		product3.price = 13.31f;
		box.products.Add(product3);
		string output = Serializer.Serialize<EasyJSONExample.Box>(box, false);
		Debug.Log("Compressed Json:\n" + output);
		string prettyOutput = Serializer.Serialize<EasyJSONExample.Box>(box, true);
		Debug.Log("Pretty Json:\n" + prettyOutput);
		EasyJSONExample.Box deserializedBox = output.Deserialize<EasyJSONExample.Box>();
		Debug.Log(string.Format("Box with {0} product(s) and dimension {1}.", deserializedBox.quantity, deserializedBox.dimension));
		WWW www = new WWW("http://www.takohi.com/data/unity/assets/easyjson/box.json");
		yield return www;
		EasyJSONExample.Box wwwBox = www.Deserialize<EasyJSONExample.Box>();
		Debug.Log(string.Format("Box with {0} product(s) and dimension {1}.", wwwBox.quantity, wwwBox.dimension));
		yield break;
	}

	// Token: 0x020001BC RID: 444
	public class Product
	{
		// Token: 0x04000C7E RID: 3198
		public string name;

		// Token: 0x04000C7F RID: 3199
		public string description;

		// Token: 0x04000C80 RID: 3200
		public float price;
	}

	// Token: 0x020001BD RID: 445
	public class Box
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0005CB67 File Offset: 0x0005AF67
		public int quantity
		{
			get
			{
				return this.products.Count;
			}
		}

		// Token: 0x04000C81 RID: 3201
		public Vector3 dimension;

		// Token: 0x04000C82 RID: 3202
		public List<EasyJSONExample.Product> products = new List<EasyJSONExample.Product>();
	}
}
