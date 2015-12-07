using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour 
{
	public List<EnemyState> states = new List<EnemyState>();
	public StateMachineEngine stateMachine = null;
	Collider[] possibleTargets = null;
	float distance = 0.0f;
	int randomExclusiveIndex = 0;
	int randomConcurrentIndex = 0;

	EnemyState[] exclusiveStates = {EnemyState.NONE, EnemyState.PRESSINGA, EnemyState.PRESSINGB, 
									EnemyState.PRESSINGX, EnemyState.PRESSINGLEFTBUMPER, 
									EnemyState.PRESSINGRIGHTBUMPER, EnemyState.PRESSINGLEFTTRIGGER,
									EnemyState.PRESSINGRIGHTTRIGGER};

	EnemyState[] concurrentStates = {EnemyState.MOVEHORIZONTAL, EnemyState.MOVEVERTICAL};
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (this.transform.position, 10f);
	}

	void Awake()
	{
		stateMachine.Initialize<EnemyState> (this);
		stateMachine.ChangeState (EnemyState.NONE);
	}
	
	void Start () 
	{
		StartCoroutine(ChooseExclusiveIndex(2.0f));
		StartCoroutine(ChooseConcurrentIndex(0.5f));
	}

	void FixedUpdate()
	{
		possibleTargets = Physics.OverlapSphere (this.transform.position, 10f);
		for (int i = 0; i < possibleTargets.Length; i++) 
		{
			distance = Vector3.Distance(this.transform.position, possibleTargets[i].transform.position);
			if (distance >= 5f)
			{
				stateMachine.AddConcurrentState(concurrentStates[randomConcurrentIndex]);
			}
			if (distance <= 5.1f)
			{
				stateMachine.ChangeState(exclusiveStates[randomExclusiveIndex]);
			}
		}
	}

	void Update () 
	{
		states = stateMachine.GetStates<EnemyState> ();
	}

	IEnumerator ChooseExclusiveIndex (float frequency)
	{
		randomExclusiveIndex = Random.Range (0, exclusiveStates.Length);
		yield return new WaitForSeconds (frequency);
		StartCoroutine (ChooseExclusiveIndex (frequency));
	}

	IEnumerator ChooseConcurrentIndex (float frequency)
	{
		randomConcurrentIndex = Random.Range (0, concurrentStates.Length);
		yield return new WaitForSeconds (frequency);
		StartCoroutine (ChooseConcurrentIndex (frequency));
	}

	#region NONE
	public void NONE_Enter()
	{

	}
	public void NONE_Update()
	{

	}
	public void NONE_Exit ()
	{

	}
	#endregion

	#region Pressing A
	public void PRESSINGA_Enter()
	{
		print ("Computer pressed A!");
	}
	public void PRESSINGA_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGA_Exit ()
	{
		
	}
	#endregion

	#region Pressing B
	public void PRESSINGB_Enter()
	{
		print ("Computer pressed B!");
	}
	public void PRESSINGB_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGB_Exit ()
	{
		
	}
	#endregion

	#region PRESSING_X
	public void PRESSINGX_Enter()
	{
		print ("Computer pressed X!");
	}
	public void PRESSINGX_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGX_Exit ()
	{
		
	}
	#endregion

	#region PRESSING_LEFTBUMPER
	public void PRESSINGLEFTBUMPER_Enter()
	{
		print ("Computer pressed Left Bumper!");
	}
	public void PRESSINGLEFTBUMPER_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGLEFTBUMPER_Exit ()
	{
		
	}
	#endregion

	#region PRESSING_RIGHTBUMPER
	public void PRESSINGRIGHTBUMPER_Enter()
	{
		print ("Computer pressed Right Bumper!");
	}
	public void PRESSINGRIGHTBUMPER_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGRIGHTBUMPER_Exit ()
	{
		
	}
	#endregion

	#region PRESSING_LEFTTRIGGER
	public void PRESSINGLEFTTRIGGER_Enter()
	{
		print ("Computer pressed Left Trigger!");
	}
	public void PRESSINGLEFTTRIGGER_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGLEFTTRIGGER_Exit ()
	{
		
	}
	#endregion

	#region PRESSING_RIGHTTRIGGER
	public void PRESSINGRIGHTTRIGGER_Enter()
	{
		print ("Computer pressed Right Trigger!");
	}
	public void PRESSINGRIGHTTRIGGER_Update()
	{
		//*CALL INPUT*//
	}
	public void PRESSINGRIGHTTRIGGER_Exit ()
	{
		
	}
	#endregion

	#region MOVE_HORIZONTAL
	public void MOVEHORIZONTAL_Enter()
	{
		print ("Computer is moving horizontally!");
	}
	public void MOVEHORIZONTAL_Update()
	{
		//*CALL INPUT*//
	}
	public void MOVEHORIZONTAL_Exit ()
	{
		
	}
	#endregion

	#region MOVE_VERTICAL
	public void MOVEVERTICAL_Enter()
	{
		print ("Computer is moving vertically!");
	}
	public void MOVEVERTICAL_Update()
	{
		//*CALL INPUT*//
	}
	public void MOVEVERTICAL_Exit ()
	{
		
	}
	#endregion

}
