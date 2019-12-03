using System;
using System.Collections;
using UnityEngine;

public class ball : MonoBehaviour
{
	public static event Action<ball> OnBallDeath;
	public void Die()
	{
		OnBallDeath?.Invoke(this);
		Destroy(gameObject, 1);
	}

	
}