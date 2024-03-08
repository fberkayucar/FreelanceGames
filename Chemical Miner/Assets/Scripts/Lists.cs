using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{
    public List<string> kimyasalBilesenler = new List<string>();
    public List<string> kimyasalFormuller = new List<string>();
    public Dictionary<string, string> kimyasalBilesenlerFormuller = new Dictionary<string, string>();

    private void Start()
    {
        kimyasalBilesenler.Add("Sodyum oksit");
        kimyasalBilesenler.Add("Sodyum klorür");
        kimyasalBilesenler.Add("Alüminyum klorür");
        kimyasalBilesenler.Add("Baryum florür");
        kimyasalBilesenler.Add("Alüminyum sülfür");
        kimyasalBilesenler.Add("Potasyum fosfür");
        kimyasalBilesenler.Add("Kalsiyum nitrür");
        kimyasalBilesenler.Add("Magnezyum fosfür");
        kimyasalBilesenler.Add("Sodyum hidroksit");
        kimyasalBilesenler.Add("Potasyum nitrat");
        kimyasalBilesenler.Add("Kalsiyum karbonat");
        kimyasalBilesenler.Add("Magnezyum sülfat");
        kimyasalBilesenler.Add("Amonyum klorür");
        kimyasalBilesenler.Add("Potasyum sülfür");
        kimyasalBilesenler.Add("Kalsiyum florür");
        kimyasalBilesenler.Add("Berilyum sülfür");
        kimyasalBilesenler.Add("Lityum hidrür");
        kimyasalBilesenler.Add("Potasyum bromür");
        kimyasalBilesenler.Add("Baryum sülfür");
        kimyasalBilesenler.Add("Kalsiyum oksit");
        kimyasalBilesenler.Add("Potasyum oksit");
        kimyasalBilesenler.Add("Magnezyum oksit");
        kimyasalBilesenler.Add("Baryum oksit");
        kimyasalBilesenler.Add("Alüminyum karbür");
        kimyasalBilesenler.Add("Amonyum nitrat");
        kimyasalBilesenler.Add("Magnezyum sülfür");
        kimyasalBilesenler.Add("Magnezyum hidrür");
        kimyasalBilesenler.Add("Baryum sülfat");
        kimyasalBilesenler.Add("Kalsiyum hidroksit");
        kimyasalBilesenler.Add("Çinko sülfür");
        kimyasalBilesenler.Add("Potasyum florür");
        kimyasalBilesenler.Add("Magnezyum iyodür");
        kimyasalBilesenler.Add("Potasyum iyodür");
        kimyasalBilesenler.Add("Sodyum sülfat");
        kimyasalBilesenler.Add("Lityum hidroksit");
        kimyasalBilesenler.Add("Sodyum bromür");
        kimyasalBilesenler.Add("Kalsiyum karbür");
        kimyasalBilesenler.Add("Potasyum klorür");
        kimyasalBilesenler.Add("Alüminyum hidroksit");
        kimyasalBilesenler.Add("Alüminyum oksit");
        kimyasalBilesenler.Add("Alüminyum florür");
        kimyasalBilesenler.Add("Potasyum hidroksit");
        kimyasalBilesenler.Add("Baryum hidroksit");
        kimyasalBilesenler.Add("Magnezyum hidroksit");
        kimyasalBilesenler.Add("Demir (II) oksit");
        kimyasalBilesenler.Add("Demir (III) oksit");
        kimyasalBilesenler.Add("Civa (I) siyanür");
        kimyasalBilesenler.Add("Bakır (II) nitrat");
        kimyasalBilesenler.Add("Kurşun (II) nitrat");

        kimyasalFormuller.Add("Na₂O");
        kimyasalFormuller.Add("NaCl");
        kimyasalFormuller.Add("AlCl₃");
        kimyasalFormuller.Add("BaF₂");
        kimyasalFormuller.Add("Al₂S₃");
        kimyasalFormuller.Add("K₃P");
        kimyasalFormuller.Add("Ca₃N₂");
        kimyasalFormuller.Add("Mg₃P₂");
        kimyasalFormuller.Add("NaOH");
        kimyasalFormuller.Add("KNO₃");
        kimyasalFormuller.Add("CaCO₃");
        kimyasalFormuller.Add("MgSO₄");
        kimyasalFormuller.Add("NH₄Cl");
        kimyasalFormuller.Add("K₂S");
        kimyasalFormuller.Add("CaF₂");
        kimyasalFormuller.Add("BeS");
        kimyasalFormuller.Add("LiH");
        kimyasalFormuller.Add("KBr");
        kimyasalFormuller.Add("BaS");
        kimyasalFormuller.Add("CaO");
        kimyasalFormuller.Add("K₂O");
        kimyasalFormuller.Add("MgO");
        kimyasalFormuller.Add("BaO");
        kimyasalFormuller.Add("Al₄C₃");
        kimyasalFormuller.Add("NH₄NO₃");
        kimyasalFormuller.Add("Mg₂S₃");
        kimyasalFormuller.Add("MgH₃");
        kimyasalFormuller.Add("BaSO₄");
        kimyasalFormuller.Add("Ca(OH)₂");
        kimyasalFormuller.Add("ZnS");
        kimyasalFormuller.Add("KF");
        kimyasalFormuller.Add("MgI₂");
        kimyasalFormuller.Add("KI");
        kimyasalFormuller.Add("Na₂SO₄");
        kimyasalFormuller.Add("LiOH");
        kimyasalFormuller.Add("NaBr");
        kimyasalFormuller.Add("Ca₂C");
        kimyasalFormuller.Add("KCl");
        kimyasalFormuller.Add("Al(OH)₃");
        kimyasalFormuller.Add("Al₂O₃");
        kimyasalFormuller.Add("AlF₃");
        kimyasalFormuller.Add("KOH");
        kimyasalFormuller.Add("Ba(OH)₂");     
        kimyasalFormuller.Add(("Mg(OH)₂"));    
        kimyasalFormuller.Add(("FeO"));       
        kimyasalFormuller.Add(("Fe₂O₃"));      
        kimyasalFormuller.Add(("HgCN"));       
        kimyasalFormuller.Add(("Cu(NO₃)₂"));  
        kimyasalFormuller.Add(("Pb(NO₃)₂"));

        for (int i = 0; i < 48; i++)
        {
            kimyasalBilesenlerFormuller.Add(kimyasalFormuller[i], kimyasalBilesenler[i]);
        }
    }
}
