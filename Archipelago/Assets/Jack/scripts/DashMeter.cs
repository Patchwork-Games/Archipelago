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
    [SerializeField] private float dischargeSpeed = 2;
    private float totalCharge = 0f;
    public float currentCharge = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newIcon = Instantiate(icon, new Vector3(40, 40, 0), Quaternion.identity);
        newIcon.transform.SetParent(transform);//attach new icon as child so it shows on canvas
        energies.Add(newIcon);
        totalCharge += 1;
        currentCharge = totalCharge;
        updateChargeGraphic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateBarTotal();
        }    
    }





    public void UpdateBarTotal()
    { 
        GameObject newIcon = Instantiate(icon, new Vector3(energies[energies.Count-1].transform.position.x + offset, energies[energies.Count - 1].transform.position.y, energies[energies.Count - 1].transform.position.z) , Quaternion.identity);
        newIcon.transform.SetParent(transform);//attach new icon as child so it shows on canvas
        energies.Add(newIcon);
        totalCharge += 1;
        currentCharge = totalCharge;
        updateChargeGraphic();
    }



    public void Discharge()
    {
        currentCharge -= Time.deltaTime * dischargeSpeed;
        if (currentCharge < 0) currentCharge = 0;



        updateChargeGraphic();
    }


    public void Recharge()
    {
        currentCharge += Time.deltaTime * chargeSpeed;
        if (currentCharge > totalCharge) currentCharge = totalCharge;
        Debug.Log("charging: " + currentCharge);

        updateChargeGraphic();
    }




    void updateChargeGraphic()
    {
        for (int i = energies.Count; i >= 0; i--)
        {
            if (currentCharge - i > 0 && currentCharge - i < 1)
            {
                Color newColour;

                //get the fraction left on the current time to change the alpha
                float newAlpha = currentCharge - (int)currentCharge;
                if (newAlpha < 0) newAlpha = 0;
                if (newAlpha > 1) newAlpha = 1;

                newColour = energies[i].GetComponent<Image>().color;
                newColour.a = newAlpha;

                energies[i].GetComponent<Image>().color = newColour;


            }
        }
    }
}
