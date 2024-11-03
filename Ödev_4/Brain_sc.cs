using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_sc : MonoBehaviour
{
    public int DNALength = 2;
    public float timeAlive;
    public DNA_sc dna_sc;
    public GameObject eyes;
    bool isAlive = true;
    bool canSeeGround = true;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            isAlive = false;
        }
    }

    public void Init()
    {
        // Initialize DNA
        // 0 forward
        // 1 left
        // 2 right
        dna_sc = new DNA_sc(DNALength, 3);
        timeAlive = 0;
        isAlive = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;

        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, 10);
        canSeeGround = false;
        RaycastHit hit;
        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        {
            if (hit.collider.gameObject.tag == "platform")
            {
                canSeeGround = true;
            }
        }
        timeAlive = PopulationManager_sc.elapsed;

        // read DNA
        float turn = 0;
        float move = 0;
        if (canSeeGround)
        {
            if (dna_sc.GetGene(0) == 0) move = 1;
            else if (dna_sc.GetGene(0) == 1) turn = -90;
            else if (dna_sc.GetGene(0) == 2) turn = 90;

        }
        else
        {
            if (dna_sc.GetGene(1) == 0) move = 1;
            else if (dna_sc.GetGene(1) == 1) turn = -90;
            else if (dna_sc.GetGene(1) == 2) turn = 90;
        }

        this.transform.Translate(0, 0, move * 0.1f);
        this.transform.Rotate(0, turn, 0);
    }
}
