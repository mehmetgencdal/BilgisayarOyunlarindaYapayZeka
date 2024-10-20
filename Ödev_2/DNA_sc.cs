using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DNA_sc : MonoBehaviour
{
    // Renk kodları geni için değişkenler
    public float r;
    public float g;
    public float b;

    // Boyut geni
    public float s; 

    // Ölüm ve yaşam süresi takibi için değişkenler
    public bool isDead = false;
    public float timeToDie = 0f;

    // Nesnenin görünürlüğü ve çarpışması için değişkenler
    private SpriteRenderer sRenderer;
    private Collider2D sCollider;


    // Nesne tıklandığında avcı ölecek ve ölüm zamanı ekrana yazdırılacak
    // Nesnenin görünürlüğü ve çarpışma durumu false yapılacak
    void OnMouseDown()
    {
        isDead = true;
        timeToDie = PopulationManager_sc.elapsed;
        Debug.Log("Dead At:" + timeToDie);
        sRenderer.enabled = false;
        sCollider.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    

        // Nesnenin görünürlüğü ve çarpışma durumu için değişkenlerin tanımlanması
        sRenderer = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<Collider2D>();

        
        // Nesne rengi için rastgele renk kodları oluşturulması
        sRenderer.color = new Color(r, g, b);

        // Nesne boyutu için rastgele bir sayı oluşturulması
        this.transform.localScale = new Vector3(s, s, s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
