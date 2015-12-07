using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour 
{
	static TimerManager vInstance = null;
	
	public static TimerManager instance
	{
		get
		{
			if (!vInstance)
			{
				vInstance = FindObjectOfType(typeof(TimerManager)) as TimerManager;
				
				if (!vInstance)
				{
					GameObject manager = new GameObject ("TimeManager");
					vInstance = manager.AddComponent<TimerManager>();
				}
			}
			return vInstance;
		}
	}
	
	void OnApplicationQuit()
	{
		vInstance = null;
	}
}

public class Timer
{
	public event System.Action timerComplete;
	public event System.Action timerStarted;

	private bool vIsRunning;
	public bool isRunning { get { return vIsRunning; } }

	private bool vIsPaused;
	public bool isPaused { get { return vIsPaused; } }

	private float vTargetTime;
	public float targetTime { get { return vTargetTime; } }

	private float vCurrentTime = 0;
	public float currentTime { get { return vCurrentTime; } }

	private bool vKilled;
	public bool killed { get { return vKilled; } }

	public Timer(float targetTime)
	{
		this.vTargetTime = targetTime;
		Start ();
	}

	public void Start()
	{
		vIsRunning = true;
		TimerManager.instance.StartCoroutine (MainTimer ());
	}

	public void Pause()
	{
		vIsPaused = true;
	}

	public void Unpause()
	{
		vIsPaused = false;
	}

	public void Kill()
	{
		vKilled = true;
		vIsRunning = false;
		vIsPaused = false;
	}

	IEnumerator MainTimer()
	{
		yield return null;

		if (timerStarted != null)
			timerStarted ();

		while (vIsRunning)
		{
			if (vIsPaused)
			{
				yield return null;
			}
			else
			{
				vCurrentTime += Time.deltaTime;
				if (vCurrentTime >= targetTime)
				{
					vIsRunning = false; 
				}
				else
				{
					yield return null;
				}
			}	
		}
		if (timerComplete != null)
			timerComplete ();
	}
}
