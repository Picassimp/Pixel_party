using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbiHolder : MonoBehaviour
{

    private List<float> holder = new List<float>();
    private bool isShield = false;
    [SerializeField] private GameObject shieldsprite;
    private GameObject GO;
    [SerializeField] private Image skill1, skill2;
    [SerializeField] private List<Sprite> skillImg  = new List<Sprite>();
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject jailObject;

    void Update()
    {
        if (holder.Count ==1)
        {
            skill1.sprite = skillImg[(int) (holder[0]-1)];
            skill2.sprite = null;
        }

        if (holder.Count == 2)
        {
            skill2.sprite = skillImg[(int) (holder[1] - 1)];
        }
        if (GO)
        {
            GO.transform.position = transform.position;
        }
    }

    public void addSkill()
    {
        if(holder.Count <= 1) {
            holder.Add(Random.Range(1, 4));
        }
        else
        {
            holder.Remove(holder[1]);
            holder.Add(Random.Range(1, 4));

        }
        //Debug.Log("Skill1:"+holder[0]+",Skill2:" + holder[1]);
        
    }

    public void useSkill()
    {
        if(holder.Count != 0) {
            switch (holder[0])
            {
                case 1:
                    {
                        //switch
                        if (!target.gameObject.GetComponent<AbiHolder>().shieldCheck())
                        {
                            chuyenvitri();
                        }
                        
                        break;
                    }
                case 2:
                    {
                        if (!target.gameObject.GetComponent<AbiHolder>().shieldCheck())
                        {
                            jail();
                        }
                        //jail
                        break;
                    }
                case 3:
                    {
                        //shield
                        if (!isShield)
                        {
                            isShield= true;
                            GO = Instantiate(shieldsprite, gameObject.transform.position, Quaternion.identity) as GameObject;
                            
                            Invoke("shieldOver", 5f);
                        }
                        else
                        {
                            shieldOver();
                            isShield = true;
                            GO = Instantiate(shieldsprite, gameObject.transform.position, Quaternion.identity) as GameObject;
                            
                            Invoke("shieldOver", 5f);
                        }
                        break;
                    }
            }
            holder.Remove(holder[0]);
            skill1.sprite = null;
            //Debug.Log("Skill1:" + holder[0]);
        }
    }


    private void chuyenvitri()
    {
        GameObject[] player1 = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] player2 = GameObject.FindGameObjectsWithTag("Player2");

        Vector3 tempPosition = player1[0].transform.position;
        player1[0].transform.position = player2[0].transform.position;
        player2[0].transform.position = tempPosition;
    }

    private void jail()
    {
        Instantiate(jailObject, target.transform.position, Quaternion.identity);
    }

    private void shieldOver()
    {
        isShield= false;
        Destroy(GO);
    }

    public bool shieldCheck()
    {
        return isShield;
    }
}
