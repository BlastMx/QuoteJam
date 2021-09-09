using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public static SandwichManager instance;

    [HideInInspector]
    public int comboIngredients = 0;
    public int numberCombo = 0;

    public CameraFollow cameraScript;

    public List<GameObject> sandwich;

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
                    Debug.Log(starnb);
                    ParticleManager.instance.StartParticle("StarSpark" + starnb, pos);
                    ComboIncreasing();
                }
            }

        }
        MoveCamera();
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
        cameraScript.targetPos.y = sandwich[sandwich.Count - 2].transform.position.y - sandwich[0].transform.position.y / 2;
    }
}
