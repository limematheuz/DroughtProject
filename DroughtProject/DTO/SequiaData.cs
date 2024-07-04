namespace DroughtProject.DTO
{

using Newtonsoft.Json;

public class SequiaData {

    [JsonProperty("data_canvi_estat_sequera")]
    public string data_canvi_estat_sequera { get; set; }

    
    [JsonProperty("codi_unitat_explotaci")]
    public int codi_unitat_explotaci { get; set; }
    
    [JsonProperty("unitat_explotaci")]
    public string unitat_explotaci { get; set; }
   
    [JsonProperty("codi_estat_sequera_hidrol")]
    public int codi_estat_sequera_hidrol { get; set; }
    
    [JsonProperty("estat_sequera_hidrol_gic")]
    public string estat_sequera_hidrol_gic { get; set; }

    [JsonProperty("codi_estat_sequera_pluviom")]
    public int codi_estat_sequera_pluviom { get; set; }

    [JsonProperty("estat_sequera_pluviom_tric")]
    public string estat_sequera_pluviom_tric { get; set; }

    [JsonProperty("codi_municipi")]
    public int codi_municipi { get; set; }

    [JsonProperty("municipi")]
    public string municipi { get; set; }


}

}