using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiaHolder : MonoBehaviour
{
    public DiaHolder diaHolder;
    private Transform UIPickUp;
    private Transform Template;

    void Awake()
    {
        UIPickUp = transform.Find("UIPickUp");
        Template = UIPickUp.Find("Template");
        Template.gameObject.SetActive(false);
    }

    void Start(){
        diaHolder.OnDiasChanged += DiaHolder_OnDiasChanged;
    }

    private void DiaHolder_OnDiasChanged(object sender, System.EventArgs e){
        UpdateVisual();
    }

    private void UpdateVisual(){
        foreach(Transform child in UIPickUp){
            if(child == Template) continue;
            Destroy(child.gameObject);
        }

        List<Dia.DiaType> diaList = diaHolder.GetDiaList();
        for(int i = 0; i < diaList.Count; i++){
            Dia.DiaType diaType = diaList[i];
            Template.gameObject.SetActive(true);
            Transform diaTransform = Instantiate(Template, UIPickUp);
            Template.gameObject.SetActive(true);
            diaTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image diaImage = diaTransform.Find("Image").GetComponent<Image>();
            switch(diaType){
                default:
                    case Dia.DiaType.RED: diaImage.color = Color.red; break;
                    case Dia.DiaType.GREEN: diaImage.color = Color.green; break;
                    case Dia.DiaType.BLUE: diaImage.color = Color.blue; break;
            }
        }
    }
}
