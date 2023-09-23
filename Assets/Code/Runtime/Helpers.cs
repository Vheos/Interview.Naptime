﻿namespace Assets.Code.Runtime
{

	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	static public class Helpers
	{
		static public Vector2 RandomPointOnUnitCircle
		{
			get
			{
				float angle = Random.Range(0f, 2 * Mathf.PI);
				float x = Mathf.Cos(angle);
				float y = Mathf.Sin(angle);
				return new Vector2(x, y);
			}
		}
		static public void FindSpawnPoints2D(int objectCount, float objectRadius, float spawnRadius, float spawnRadiusIncrement,
			out HashSet<Vector2> spawnPoints, out float maxSpawnRadius)
		{
			bool OverlapsAnotherSpawnPoint(Vector2 potentialSpawnPoint, IEnumerable<Vector2> spawnPoints)
			{
				foreach (var spawnPoint in spawnPoints)
					if (Vector2.Distance(potentialSpawnPoint, spawnPoint) <= objectRadius * 2)
						return true;

				return false;
			}

			spawnPoints = new();
			while (spawnPoints.Count < objectCount)
			{
				Vector2 potentialSpawnPoint = RandomPointOnUnitCircle * spawnRadius;
				if (OverlapsAnotherSpawnPoint(potentialSpawnPoint, spawnPoints))
				{
					spawnRadius += spawnRadiusIncrement;
					continue;
				}

				spawnPoints.Add(potentialSpawnPoint);
			}
			maxSpawnRadius = spawnRadius;
		}
		static public float CameraDistance(float frustumHeight, float fov)
			=> frustumHeight * 0.5f / Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
		static public void SetDistance(this Camera @this, Vector3 targetPoint, float distance)
		{
			Vector3 direction = (@this.transform.position - targetPoint).normalized;
			if (direction == Vector3.zero)
				direction = -@this.transform.forward;

			@this.transform.position = direction * distance;
		}
	}
}