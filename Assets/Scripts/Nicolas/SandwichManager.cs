using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SandwichManager : MonoBehaviour
{
    public static SandwichManager instance;

    [HideInInspector]
    public int comboIngredients = 0;
    public int numberCombo = 0;

    public CameraFollow cameraScript;

    public List<GameObject> sandwich;

    [SerializeField]
    private Transform forkWayPoints;

    private int moveCount;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public void RemoveIngredient(GameObject fall)
    {
        sandwich.Remove(fall);
        fall.tag = "Untagged";
        OrderManager.instance.CheckFallOrder(fall);

        if (fall.GetComponent<Aliment>().ingredientsDisponible != enumIngredients.IngredientsDisponible.Salade)
        {
            ScoreManager.instance.combo = 1f;
            comboIngredients = 0;
            numberCombo = 0;
        }
    }

    public void AddIngredient(GameObject up)
    {
        sandwich.Add(up);
        up.tag = "sandwich";
        OrderManager.instance.CheckNewOrded(up);

        AlimentsChoiceSpawner.instance.lastAlimentDrop = up;
        
        if(up.GetComponent<Aliment>().ingredientsDisponible != enumIngredients.IngredientsDisponible.Salade)
        {
            ScoreManager.instance.score += (up.GetComponent<Aliment>().points * ScoreManager.instance.combo);

            if (up.GetComponent<Aliment>().ingredientsDisponible == enumIngredients.IngredientsDisponible.Pain)
            {
                Rigidbody rigidbody = up.GetComponent<Rigidbody>();
                rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }

            if (up.GetComponent<Aliment>().ingredientsDisponible == enumIngredients.IngredientsDisponible.Pain)
            {
                ScoreManager.instance.combo = 1f;
                comboIngredients = 0;
                numberCombo = 0;

                foreach(GameObject aliment in sandwich)
                {
                    Rigidbody rigidbody = aliment.GetComponent<Rigidbody>();
                    rigidbody.constraints = RigidbodyConstraints.FreezeAll;

                }
            }
            else
            {
                if (comboIngredients < 2)
                    comboIngredients++;
                else
                {
                    numberCombo++;
                    comboIngredients = 0;
                    ScoreManager.instance.combo += 0.5f;

                    Vector3 pos = up.transform.position;
                    //pour positioner devant le burger
                    pos.z -= 1.55f;

                    int starnb = Random.Range(0, 2);

                    ParticleManager.instance.StartParticle("StarSpark" + starnb, pos);
                    ComboIncreasing();
                }
            }
        }
        MoveCamera();
        UpFork();
    }

    public void UpFork()
    {
        forkWayPoints.DOMoveY(sandwich[sandwich.Count - 1].transform.position.y + 1f, 0.5f);
    }

    public void ComboIncreasing()
    {
        switch (numberCombo)
        {
            case 1:
                SoundManager.instance.source.clip = SoundManager.instance.delicieux;
                SoundManager.instance.source.Play();
                break;
            case 2:
                SoundManager.instance.source.clip = SoundManager.instance.goutu;
                SoundManager.instance.source.Play();
                break;
            case 3:
                SoundManager.instance.source.clip = SoundManager.instance.semiCroustillant;
                SoundManager.instance.source.Play();
                break;
            case 4:
                SoundManager.instance.source.clip = SoundManager.instance.delicat;
                SoundManager.instance.source.Play();
                break;
            case 5:
                SoundManager.instance.source.clip = SoundManager.instance.smoothy;
                SoundManager.instance.source.Play();
                break;
            default: break;
        }
    }

    public void MoveCamera()
    {
        cameraScript.gameObject.transform.DOMoveY(cameraScript.gameObject.transform.position.y + 0.05f, 0.2f);

        cameraScript.gameObject.transform.DOMoveZ(cameraScript.gameObject.transform.position.z + 0.05f, 0.2f);
    }
}
