using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
	#region Singleton

	private static BallsManager _instance;
	public static BallsManager Instance => _instance;

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
		}
	}
	#endregion

	[SerializeField]

	public ball ballPrefab;

	private ball initiaBall;

	private Rigidbody2D initiaBallRb;

	public float initiaBallSpeed = 250;

	public List<ball> Balls { get; set; }

	private void Start()
	{
		InitBall();
	}

	private void Update()
	{
		if (!GameManager.Instance.IsGameStarted)
		{
			Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
			Vector3 ballPasition = new Vector3(paddlePosition.x + .78f, paddlePosition.y + .7f, 0);
			initiaBall.transform.position = ballPasition; 

			if (Input.GetMouseButtonDown(0))
			{
				initiaBallRb.isKinematic = false;
				initiaBallRb.AddForce(new Vector2(0, initiaBallSpeed));
				GameManager.Instance.IsGameStarted = true;  

			}


		}
	}

	public void ResetBalls()
	{
		foreach (var ball in this.Balls.ToList())
		{
			Destroy(ball.gameObject);
		}

		InitBall();
	}

	private void InitBall()
	{
		Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
		Vector3 startingPosition = new Vector3(paddlePosition.x +.78f, paddlePosition.y + .7f, 0);
		initiaBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
		initiaBallRb = initiaBall.GetComponent<Rigidbody2D>();

		this.Balls = new List<ball>
		{
			initiaBall
		};

	}

	
}
