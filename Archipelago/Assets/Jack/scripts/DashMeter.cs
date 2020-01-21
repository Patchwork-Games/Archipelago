using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
    [SerializeField] private List<GameObject> energies;
    [SerializeField] private GameObject icon;
    [SerializeField] private float offset = 56f;
    [SerializeField] private float chargeSpeed = 1;
    private float totalCharge = 0f;
    public float currentCharge = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newIcon = Instantiate(icon, new Vector3(40, 40, 0), Quaternion.identity);
        newIcon.transform.SetParent(transform);//attach new icon as child so it shows on canvas
        energies.Add(newIcon);
        totalCharge += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateBarTotal();
        }
    }





    void UpdateBarTotal()
    { 
        GameObject newIcon = Instantiate(icon, new Vector3(energies[energies.Count-1].transform.position.x + offset, energies[energies.Count - 1].transform.position.y, energies[energies.Count - 1].transform.position.z) , Quaternion.identity);
        newIcon.transform.SetParent(transform);//attach new icon as child so it shows on canvas
        energies.Add(newIcon);
        totalCharge += 1;
    }



    void Discharge()
    {
        for (int i = 0; i < energies.Count-1; i++)
        {
            if (currentCharge < i)
            {
                //energies[i].GetComponent<Image>().color.a = currentCharge - i;
            }
        }
    }


    void Recharge()
    {
        currentCharge += Time.deltaTime * chargeSpeed;
    }






}
