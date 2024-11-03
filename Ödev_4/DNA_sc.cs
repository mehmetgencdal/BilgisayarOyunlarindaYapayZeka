using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA_sc : MonoBehaviour
{
    // Genleri tutan liste
    List<int> genes = new List<int>();
    // DNA uzunluğu
    int dnaLength = 0;
    // Maksimum değerler
    int maxValues = 0;

    // Yapıcı metot, DNA uzunluğu ve maksimum değerleri alır
    public DNA_sc(int l, int v)
    {
        dnaLength = l;
        maxValues = v;
        SetRandom();
    }

    // Genleri rastgele değerlerle doldurur
    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    // Belirtilen pozisyondaki geni belirli bir değerle ayarlar
    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    // Belirtilen pozisyondaki geni döndürür
    public int GetGene(int pos)
    {
        return genes[pos];
    }

    // İki DNA'yı birleştirir
    public void Combine(DNA_sc d1, DNA_sc d2)
    {
        for (int i = 0; i < dnaLength; i++)
        {
            if (i < dnaLength / 2.0)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    // Rastgele bir geni mutasyona uğratır
    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }

    // Start metodu, oyun başladığında bir kez çağrılır
    void Start()
    {
        
    }

    // Update metodu, her karede bir kez çağrılır
    void Update()
    {
        
    }
}
