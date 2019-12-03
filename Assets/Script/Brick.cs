using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
	private SpriteRenderer sr;
	public int Hitpoints = 1;
	public ParticleSystem DestryEffect;

	public static event Action<Brick> OnBrickDestruction;

	private void Awake()
	{
		this.sr = this.GetComponent<SpriteRenderer>();
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ball ball = collision.gameObject.GetComponent<ball>();
		ApplyCollisionLogic(ball);
	}

	private void ApplyCollisionLogic(ball ball)
	{
		this.Hitpoints--;

		if (this.Hitpoints <= 0)
		{
			BricksManager.Instance.RemainingBricks.Remove(this);
			OnBrickDestruction?.Invoke(this);
			SpawnDestroyEffect();
			Destroy(this.gameObject);
		}
		else
		{
			this.sr.sprite = BricksManager.Instance.Sprites[this.Hitpoints - 1];
		}
	}
	private void SpawnDestroyEffect()
	{
		Vector3 Brickpos = gameObject.transform.position;
		Vector3 spawnPosition = new Vector3(Brickpos.x, Brickpos.y, Brickpos.z - 0.2f);
		GameObject effect = Instantiate(DestryEffect.gameObject, spawnPosition, Quaternion.identity);

		MainModule mm = effect.GetComponent<ParticleSystem>().main;
		mm.startColor = this.sr.color;
		Destroy(effect, DestryEffect.main.startLifetime.constant);
    }


	public void Init(Transform containertransform, Sprite sprite, Color color, int hitpoints)
	{
		this.transform.SetParent(containertransform);
		this.sr.sprite = sprite;
		this.sr.color = color;
		this.Hitpoints = hitpoints;
	}
}
