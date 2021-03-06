﻿using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ZombiePlayerHealth : MonoBehaviour
{

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;
	public bool destroyOnDeath;
	public Transform SpawnPoint;
	public ZombieCount DeadZombies;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			if (destroyOnDeath)
			{
				Destroy(gameObject);
				DeadZombies.DeadZombies++;
			}
			else
			{
				Debug.Log("Respawn");
				currentHealth = maxHealth;
				transform.position = SpawnPoint.position;
				var lives = GetComponent<ChangeLives>();
				lives.LoseLife();
			}
		}
	}

	void Update ()
		{
			healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
		}
}