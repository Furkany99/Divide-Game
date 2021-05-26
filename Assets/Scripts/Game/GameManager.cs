using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject kare;

    [SerializeField]
    private Transform karelerPanel;

    [SerializeField]
    private Text soruText;

    private GameObject[] karelerDizisi=new GameObject[25];

    [SerializeField]
    private Transform soruPanel;

    [SerializeField]
    private GameObject sonucPanel;
    List<int> bolumDegerleri=new List<int>();

    int bolenSayi,bolunenSayi;
    int kacinciSoru;
    int dogruSonuc;
    int butonDegeri;

    int kalanHakk;

    string sorununZorlukDerecesi;

    bool butonaBasildiMi;

    KalanHaklar kalanHaklar;
    PuanManager puanManager;

    private void Awake()
    {
        kalanHakk=3;   
        sonucPanel.GetComponent<RectTransform>().localScale=Vector3.zero;

        kalanHaklar=Object.FindObjectOfType<KalanHaklar>();
        puanManager=Object.FindObjectOfType<PuanManager>();

        kalanHaklar.haklariKontrolEt(kalanHakk);

    }
    void Start()
    {
        butonaBasildiMi=false;

        soruPanel.GetComponent<RectTransform>().localScale=Vector3.zero;

        kareOlustur();
    }

    public void kareOlustur()
    {
        for(int i=0;i<25;i++)
        {
            GameObject kare1=Instantiate(kare,karelerPanel);
            kare1.transform.GetComponent<Button>().onClick.AddListener(()=> ButonaBasildi());
            karelerDizisi[i]=kare1;
        }

        textDeger();

        StartCoroutine(DoFadeRoutine());
        Invoke("soruPaneliGoster",2f);
    }

    void ButonaBasildi()
    {
        if(butonaBasildiMi)
        {
             
            butonDegeri=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            SonucuKontrolEt();

        }
        

    }

    void SonucuKontrolEt()
    {
        if(butonDegeri==dogruSonuc)
        {
            puanManager.PuaniArtir(sorununZorlukDerecesi);
            bolumDegerleri.RemoveAt(kacinciSoru);

            if(bolumDegerleri.Count>0)
            {
                soruPaneliGoster();
            }
            else 
            {
                oyunBitti();
            }

            
        }
        else
        {
            kalanHakk--;
            kalanHaklar.haklariKontrolEt(kalanHakk);
        }

        if(kalanHakk<=0)
        {
            oyunBitti();
        }
    }

    void oyunBitti()
    {
        butonaBasildiMi=false;
        sonucPanel.GetComponent<RectTransform>().DOScale(1,0.5f);
        
    }

    IEnumerator DoFadeRoutine()
    {
        foreach(var kare1 in karelerDizisi)
        {
            kare1.GetComponent<CanvasGroup>().DOFade(1,0.2f);

            yield return new WaitForSeconds(0.05f);
        }
    }

    void textDeger()
    {
        foreach(var kare1 in karelerDizisi)
        {
            int rastgeleDeger=Random.Range(1,16);
            bolumDegerleri.Add(rastgeleDeger);

            kare1.transform.GetChild(0).GetComponent<Text>().text=rastgeleDeger.ToString();
        }
    }

    void soruPaneliGoster()
    {
        soruyuSor();
        butonaBasildiMi=true;
        soruPanel.GetComponent<RectTransform>().DOScale(1,0.5f);
    }

    void soruyuSor()
    {
        bolenSayi= Random.Range(2,11);

        kacinciSoru=Random.Range(0,bolumDegerleri.Count);
        dogruSonuc=bolumDegerleri[kacinciSoru];

        bolunenSayi=bolenSayi*dogruSonuc;

        if(bolunenSayi<=40)
        {
            sorununZorlukDerecesi="kolay";
        }
        else if(bolunenSayi>40 && bolunenSayi<=80)
        {
            sorununZorlukDerecesi="orta";
        }
        else
        {
            sorununZorlukDerecesi="zor";
        }


        soruText.text=bolunenSayi.ToString()+ " : "+bolenSayi.ToString();

    }


}
