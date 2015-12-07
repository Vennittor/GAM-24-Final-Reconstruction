using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class StateMachineEngine : MonoBehaviour
{
	private List<StateMapping> currentStates = new List<StateMapping>();
	
	private Dictionary<Enum, StateMapping> stateLookup;
	private Dictionary<string, Delegate> methodLookup;
	
	private readonly string[] ignoredNames = new[] { "add", "remove", "get", "set" };
	
	private bool isInTransition = false;
	
	public void Initialize<T>(MonoBehaviour entity)
	{
		//Define States
		var values = Enum.GetValues(typeof(T));
		stateLookup = new Dictionary<Enum, StateMapping>();
		for (int i = 0; i < values.Length; i++)
		{
			var mapping = new StateMapping((Enum) values.GetValue(i));
			stateLookup.Add(mapping.state, mapping);
		}
		
		//Reflect methods
		var methods = entity.GetType().GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public |
		                                          BindingFlags.NonPublic);
		
		//Bind methods to states
		var separator = "_".ToCharArray();
		for (int i = 0; i < methods.Length; i++)
		{
			var names = methods[i].Name.Split(separator);
			
			//Ignore functions without an underscore
			if (names.Length <= 1)
			{
				continue;
			}
			
			Enum key;
			try
			{
				key = (Enum) Enum.Parse(typeof(T), names[0]);
			}
			catch (ArgumentException)
			{
				//Some things (evetns, properties) generate automatic method. Ignore these
				for (int j = 0; j < ignoredNames.Length; j++)
				{
					if (names[0] == ignoredNames[j])
					{
						goto SkipWarning;
					}
				}
				
				Debug.LogWarning("Method with name " + methods[i].Name + " could not resolve a matching state. Check method spelling");
				continue;
				
			SkipWarning:
					continue;
			}
			
			var targetState = stateLookup[key];
			
			switch (names[1])
			{
			case "Enter":
				if (methods[i].ReturnType == typeof(IEnumerator))
				{
					targetState.Enter = CreateDelegate<Func<IEnumerator>>(methods[i], entity);
				}
				else
				{
					var action = CreateDelegate<Action>(methods[i], entity);
					targetState.Enter = () => { action(); return null; };
				}
				break;
			case "Exit":
				if (methods[i].ReturnType == typeof(IEnumerator))
				{
					targetState.Exit = CreateDelegate<Func<IEnumerator>>(methods[i], entity);
				}
				else
				{
					var action = CreateDelegate<Action>(methods[i], entity);
					targetState.Exit = () => { action(); return null; };
				}
				break;
			case "Update":
				targetState.Update = CreateDelegate<Action>(methods[i], entity);
				break;
			case "LateUpdate":
				targetState.LateUpdate = CreateDelegate<Action>(methods[i], entity);
				break;
			case "FixedUpdate":
				targetState.FixedUpdate = CreateDelegate<Action>(methods[i], entity);
				break;
			}
		}
	}
	
	private V CreateDelegate<V>(MethodInfo method, Object target) where V : class
	{
		var ret = (Delegate.CreateDelegate(typeof (V), target, method) as V);
		
		if (ret == null)
		{
			throw new ArgumentException("Unabled to create delegate for method called " + method.Name);
		}
		return ret;
		
	}

	public void AddConcurrentState(Enum newState)
	{
		if (stateLookup == null)
		{
			throw new Exception("States have not been configured, please call initialized before trying to set state");
		}
		
		if (!stateLookup.ContainsKey(newState))
		{
			throw new Exception("No state with the name " + newState.ToString() + " can be found. Please make sure you are called the correct type the statemachine was initialized with");
		}

		var nextState = stateLookup[newState];

		foreach (StateMapping currentState in currentStates)
		{
			if (currentState == nextState) return;
		}
		if (gameObject.activeInHierarchy == true)
		{
			StartCoroutine(AddConcurrentStateRoutine(nextState));
		}
	}

	public void RemoveConcurrentState(Enum newState)
	{
		if (stateLookup == null)
		{
			throw new Exception("States have not been configured, please call initialized before trying to set state");
		}
		
		if (!stateLookup.ContainsKey(newState))
		{
			throw new Exception("No state with the name " + newState.ToString() + " can be found. Please make sure you are called the correct type the statemachine was initialized with");
		}

		var nextState = stateLookup[newState];

		foreach (StateMapping currentState in currentStates)
		{
			if (currentState == nextState)
			{
				if (gameObject.activeInHierarchy == true)
				{
					StartCoroutine(RemoveConcurrentStateRoutine(nextState));
					return;
				}
			}
		}
	}
	
	public void ChangeState(Enum newState)
	{
		if (stateLookup == null)
		{
			throw new Exception("States have not been configured, please call initialized before trying to set state");
		}
		
		if (!stateLookup.ContainsKey(newState))
		{
			throw new Exception("No state with the name " + newState.ToString() + " can be found. Please make sure you are called the correct type the statemachine was initialized with");
		}
		
		var nextState = stateLookup[newState];

		foreach (StateMapping currentState in currentStates)
		{
			if (currentState == nextState) return;
		}
		if (gameObject.activeInHierarchy == true)
		{
			StartCoroutine(ChangeToNewStateRoutine(nextState));
		}
	}

	private IEnumerator AddConcurrentStateRoutine(StateMapping newState)
	{
		currentStates.Add(newState);
		
		if (newState != null)
		{
			var enterRoutine = newState.Enter();
			
			if (enterRoutine != null)
			{
				yield return StartCoroutine(enterRoutine);
			}
		}
	}

	private IEnumerator RemoveConcurrentStateRoutine(StateMapping newState)
	{
		currentStates.Remove(newState);
		if (newState != null)
		{
			var exitRoutine = newState.Exit();
			
			if (exitRoutine != null)
			{
				yield return StartCoroutine(exitRoutine);
			}
		}
	}
	
	private IEnumerator ChangeToNewStateRoutine(StateMapping newState)
	{
		isInTransition = true;

		foreach (StateMapping currentState in currentStates)
		{
			if (currentState != null)
			{
				
				var exitRoutine = currentState.Exit();
				
				if (exitRoutine != null)
				{
					yield return StartCoroutine(exitRoutine);
				}
			}
		}

		currentStates = new List<StateMapping>();
		currentStates.Add(newState);
		
		if (newState != null)
		{
			var enterRoutine = newState.Enter();
			
			if (enterRoutine != null)
			{
				yield return StartCoroutine(enterRoutine);
			}
		}
		
		isInTransition = false;
	}
	
	void FixedUpdate()
	{
		foreach (StateMapping currentState in currentStates)
		{
			if (currentState != null)
			{
				currentState.FixedUpdate();
			}
		}
	}
	
	void Update()
	{
		for (int i = 0; i < currentStates.Count; i++)
		{
			if (currentStates[i] != null && !isInTransition)
			{
				currentStates[i].Update();
			}
		}
	}
	
	void LateUpdate()
	{
		foreach (StateMapping currentState in currentStates)
		{
			if (currentState != null && !isInTransition)
			{
				currentState.LateUpdate();
			}
		}
	}
	
	public static void DoNothing()
	{
	}
	public static void DoNothingCollider(Collider other)
	{
	}
	public static void DoNothingCollision(Collision other)
	{
	}
	public static IEnumerator DoNothingCoroutine()
	{
		yield break;
	}
	
	public Enum GetState()
	{
		foreach (StateMapping currentState in currentStates)
		{
			if (currentState != null)
			{
				return currentState.state;
			}
		}
		return null;
	}

	public bool GetState<T> (T state)
	{
		foreach (StateMapping currentState in currentStates)
		{
			if (((T)(object)currentState.state).Equals(state))
			{
				return true;
			}
		}
		return false;
	}

	public List<T> GetStates<T>()
	{
		List<T> returnStates = new List<T>();
		foreach (StateMapping currentState in currentStates)
		{
			if (currentState != null)
			{
				returnStates.Add((T)(object)currentState.state);
			}
		}
		return returnStates;
	}
}



public class StateMapping
{
	public Enum state;
	
	public Func<IEnumerator> Enter = StateMachineEngine.DoNothingCoroutine;
	public Func<IEnumerator> Exit = StateMachineEngine.DoNothingCoroutine;
	public Action Update = StateMachineEngine.DoNothing;
	public Action LateUpdate = StateMachineEngine.DoNothing;
	public Action FixedUpdate = StateMachineEngine.DoNothing;
	
	public StateMapping(Enum state)
	{
		this.state = state;
	}
	
}


