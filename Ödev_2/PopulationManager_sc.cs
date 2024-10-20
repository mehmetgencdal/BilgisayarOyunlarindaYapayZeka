using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager_sc : MonoBehaviour
{
    // Nesne prefabı
    public GameObject personPrefab;

    // Populasyon büyüklüğü
    public int populationSize = 10;

    // Populasyon listesi
    List<GameObject> population = new List<GameObject>();

    // Her döngüde zaman hesabı için değişken
    public static float elapsed = 0;

    // Her döngüde zaman artışı
    int trialTime = 10;

    // Nesne sayacı
    int generation = 1;

    // GUI stil değişkeni
    GUIStyle guiStyle = new GUIStyle();

    // Nesne sayacı ve zamanı ekrana yazdırma
    void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiStyle);
        GUI.Label(new Rect(10, 30, 100, 20), "Time: " + (int)elapsed, guiStyle);
    }

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9.5f, 9.5f), Random.Range(-3.4f, 5.4f), 0);
        GameObject offspring = Instantiate(personPrefab, pos, Quaternion.identity);
        DNA_sc dna1 = parent1.GetComponent<DNA_sc>();
        DNA_sc dna2 = parent2.GetComponent<DNA_sc>();

        //%50 ihtimalle mutasyon
        if (Random.Range(0, 10) < 5)
        {
            offspring.GetComponent<DNA_sc>().r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
            offspring.GetComponent<DNA_sc>().g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
            offspring.GetComponent<DNA_sc>().b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
            offspring.GetComponent<DNA_sc>().s = Random.Range(0, 10) < 5 ? dna1.s : dna2.s;
        }
        else
        { 
            //%50 mutasyon ihtimali. Genelde mutasyon ihtimali çok daha düşüktür
            offspring.GetComponent<DNA_sc>().r = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA_sc>().g = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA_sc>().b = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA_sc>().s = Random.Range(0.1f, 0.3f);
        }
        return offspring;
    }


    // Yeni nesil oluşturma
    void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA_sc>().timeToDie).ToList();

        population.Clear();

        for (int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }
        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9.5f, 9.5f), Random.Range(-3.4f, 5.4f), 0);
            GameObject o = Instantiate(personPrefab, pos, Quaternion.identity);
            o.GetComponent<DNA_sc>().r = Random.Range(0.0f, 1.0f);
            o.GetComponent<DNA_sc>().g = Random.Range(0.0f, 1.0f);
            o.GetComponent<DNA_sc>().b = Random.Range(0.0f, 1.0f);
            o.GetComponent<DNA_sc>().s = Random.Range(0.1f, 0.3f);
            population.Add(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Her döngüde zaman artışı
        elapsed += Time.deltaTime;

        // Eğer zaman belirlenen süreyi geçerse yeni populasyon oluştur
        if (elapsed > trialTime)
        {
            Debug.Log("New Population");
            BreedNewPopulation();
            elapsed = 0;
        }
    }
}
