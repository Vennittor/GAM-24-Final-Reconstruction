using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JobManager : MonoBehaviour 
{
	static JobManager vInstance = null;
	
	public static JobManager instance
	{
		get
		{
			if (!vInstance)
			{
				vInstance = FindObjectOfType(typeof(JobManager)) as JobManager;

				if (!vInstance)
				{
					GameObject manager = new GameObject ("JobManager");
					vInstance = manager.AddComponent<JobManager>();
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

public class Job
{
	public event System.Action<bool> jobComplete;

	private bool vIsRunning;
	public bool isRunning { get { return vIsRunning; } }

	private bool vIsPaused;
	public bool isPaused { get { return vIsPaused; } }

	IEnumerator vCoroutine;
	bool jobKilled;
	Stack<Job> childJobStack;
	
	//Constructor
	public Job (IEnumerator coroutine) : this (coroutine, true)
	{}

	//Start in a paused state, or run on construction
	public Job (IEnumerator coroutine, bool shouldStart)
	{
		vCoroutine = coroutine;

		if (shouldStart)
		{
			start ();
		}
	}
	
	public static Job make(IEnumerator coroutine)
	{
		return new Job(coroutine);
	}

	public static Job make (IEnumerator coroutine, bool shouldStart)
	{
		return new Job (coroutine, shouldStart);
	}
	
	public Job createAndAddChildJob (IEnumerator coroutine)
	{
		Job j = new Job (coroutine, false); 
		addChildJob (j);
		return j;
	}
	public void addChildJob (Job childJob)
	{
		if (childJobStack == null)
			childJobStack = new Stack<Job>();
		childJobStack.Push (childJob);
	}

	public void removeChildJob(Job childJob)
	{
		if (childJobStack.Contains(childJob))
		{
			Stack<Job> childStack = new Stack<Job>(childJobStack.Count - 1);
			Job[] allCurrentChildren = childJobStack.ToArray();
			System.Array.Reverse(allCurrentChildren);

			for(int i=0; i < allCurrentChildren.Length; i++)
			{
				Job j = allCurrentChildren[i];
				if (j != childJob)
					childStack.Push(j);
			}
			childJobStack = childStack;
		}
	}

	public void start()
	{
		vIsRunning = true;
		JobManager.instance.StartCoroutine (doWork ());
	}

	public IEnumerator startAsCoroutine()
	{
		vIsRunning = true;
		yield return JobManager.instance.StartCoroutine(doWork ());
	}

	public void pause()
	{
		vIsPaused = true;
	}

	public void unpause()
	{
		vIsPaused = false;
	}

	public void kill()
	{
		jobKilled = true;
		vIsRunning = false;
		vIsPaused = false;
	}

	public void kill(float delayInSeconds)
	{
		int delay = (int)(delayInSeconds * 1000);

		new System.Threading.Timer (Object =>
		{
			lock (this) 
			{
				kill ();
			}
		}, null, delay, System.Threading.Timeout.Infinite);
	}

	private IEnumerator doWork()
	{
		yield return null;

		while (vIsRunning)
		{
			if (vIsPaused)
			{
				yield return null;
			}
			else
			{
				if (vCoroutine.MoveNext())
				{
					yield return vCoroutine.Current;
				}
				else
				{
					if (childJobStack != null)
						yield return JobManager.instance.StartCoroutine(runChildJobs());

					vIsRunning = false;
				}
			}
		}

		if (jobComplete != null)
			jobComplete (jobKilled);
	}

	private IEnumerator runChildJobs()
	{
		if (childJobStack != null && childJobStack.Count > 0)
		{
			do
			{
				Job childJob = childJobStack.Pop();
				yield return JobManager.instance.StartCoroutine(childJob.startAsCoroutine());
			}
			while (childJobStack.Count > 0);
		}
	}
}