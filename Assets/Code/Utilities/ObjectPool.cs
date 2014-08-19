using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private int poolAmount;
	[SerializeField] private bool instantiateOnAwake;
	[SerializeField] private GameObject parentGO;

	private GameObject masterPoolHolder;
	private Pool pool;
	private static List<Pool> masterPool;

	void Awake() {
		if (GameObject.FindWithTag("PoolHolder")) {
			masterPoolHolder = GameObject.FindWithTag("PoolHolder");
		} else {
			masterPoolHolder = new GameObject("Pool Holder");
			masterPoolHolder.tag = "PoolHolder";
		}
		if (masterPool == null) {
			masterPool = new List<Pool>();
		}
		Pool existingPool = null;
		foreach (var p in masterPool) {
			if (p.prefab == prefab) existingPool = p;
		}
		if (existingPool == null) {
			pool = new Pool();
			pool.prefab = prefab;
			if (parentGO == null) {
				pool.holder = new GameObject(string.Format("{0} Holder", prefab.name));
				pool.holder.transform.parent = masterPoolHolder.transform;
			} else {
				pool.holder = parentGO;
			}
			if (instantiateOnAwake) {
				for (int i = 0; i < poolAmount; i++) {
					AddPoolObject();
				}
			}
			masterPool.Add(pool);
		} else {
			pool = existingPool;
		}
	}

	public GameObject Available {
		get {
			GameObject availableObject = null;
			foreach (GameObject go in pool.gameObjs) {
				if (!go.activeInHierarchy) {
					availableObject = go;
					availableObject.SetActive(true);
					return availableObject;
				}
			}
			availableObject = AddPoolObject();
			availableObject.SetActive(true);
			return availableObject;
		}
	}

	public void DisableAll() {
		foreach (GameObject go in pool.gameObjs) {
			if (go) {
				go.SetActive(false);
			}
		}
	}

	GameObject AddPoolObject() {
		GameObject go = (GameObject)Instantiate(pool.prefab);
		go.transform.parent = parentGO == null ? pool.holder.transform : parentGO.transform;
		go.SetActive(false);
		pool.gameObjs.Add(go);
		return go;
	}
	
	public static void Clear() {
		if (masterPool != null) masterPool.Clear();
	}

	public class Pool {
		public GameObject prefab;
		public GameObject holder;
		public List<GameObject> gameObjs;

		public Pool() {
			gameObjs = new List<GameObject>();
		}

	}

}
