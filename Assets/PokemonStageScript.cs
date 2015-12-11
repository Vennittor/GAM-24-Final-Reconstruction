using UnityEngine;
using System.Collections;

public class PokemonStageScript : MonoBehaviour
{
    public GameObject[] basicStages;

    GameObject currentStage;
    bool backToNorm = false;
    int stageIndexer = 0;

	void Start ()
    {
        basicStages[stageIndexer].SetActive(true);
        currentStage = basicStages[stageIndexer];
        InvokeRepeating("StageSwitch", Random.Range(10,15), Random.Range(10,15));
	}
    void StageSwitch()
    {
        if (!backToNorm)
        {
            if (stageIndexer < basicStages.Length - 1)
            {
                stageIndexer++;
                StartCoroutine(ScalingStages(currentStage, basicStages[stageIndexer]));
            }
            else
            {
                stageIndexer = 1;
                StartCoroutine(ScalingStages(currentStage, basicStages[stageIndexer]));
            }
        }
        else
        {
            StartCoroutine(ScalingStages(basicStages[stageIndexer], basicStages[0]));
        }
        backToNorm = !backToNorm;
    }
    IEnumerator ScalingStages(GameObject lastStage, GameObject nextStage = null)
    {
        while (lastStage.transform.localScale.y > .01f)
        {
            lastStage.transform.localScale -= new Vector3(0, .01f, 0) * 5 * Time.deltaTime;
            yield return new WaitForSeconds(.01f);
            if (lastStage.transform.localScale.y < .05f)
            {
                BoxCollider[] childColliders = lastStage.GetComponentsInChildren<BoxCollider>();
                foreach (BoxCollider childCollider in childColliders)
                {
                    childCollider.enabled = false;
                }
            }
            if (lastStage.transform.localScale.y < .01f)
            {
                nextStage.SetActive(true);
            }
        }
        while (nextStage.transform.localScale.y < .2f)
        {
           nextStage.transform.localScale += new Vector3(0, .01f, 0) * 5 * Time.deltaTime;
            yield return new WaitForSeconds(.01f);
                lastStage.SetActive(false);
                BoxCollider[] childColliders = nextStage.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider childCollider in childColliders)
            {
                childCollider.enabled = true;
            }
        }
        
    }
}
