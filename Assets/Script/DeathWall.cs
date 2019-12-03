using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Ball")
		{
			ball ball = collision.GetComponent<ball>();
			BallsManager.Instance.Balls.Remove(ball);
			ball.Die();
		}
	}
}