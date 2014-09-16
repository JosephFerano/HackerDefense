using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoX
{
	[SerializeField] private Transform[] leftSpawnPoints;
	[SerializeField] private Transform[] rightSpawnPoints;
	[SerializeField] private ObjectPool virusPool;
	[SerializeField] private ObjectPool firewallPool;

	private Dictionary<UnitType, ObjectPool> unitToPool;

	void Awake() {
		unitToPool = new Dictionary<UnitType, ObjectPool>() {
			{ UnitType.Virus , virusPool },
			{ UnitType.Firewall , firewallPool }
		};
	}

	public Unit Spawn(UnitType unitType, Lane lane, Side side) {
		int laneNum = (int)lane;
		GameObject unitGO = unitToPool[unitType].Available;
		Transform[] spawnPoints = side == Side.Left ? leftSpawnPoints : rightSpawnPoints;
		Transform spawnPoint = spawnPoints[laneNum];
		unitGO.transform.position = spawnPoint.position;
		Unit unit = unitGO.GetComponent<Unit>();
		return unit;
	}

}
