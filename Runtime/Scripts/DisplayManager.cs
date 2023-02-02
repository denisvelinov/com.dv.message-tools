using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DV.MessageTools;
using System.Text;

public class DisplayManager : MonoBehaviour
{
    //Create Reference class and local variable
    private class Root
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public string TimezoneAbbreviation { get; set; }
        public int Elevation { get; set; }
        public List<string> Days { get; set; }
        public List<double> TemperaturesForcastDayMax { get; set; }
    }

    private Root weatherInfo;
    private List<GameObject> display2Content;

    //Reference UIManager
    //[SerializeField] UIManager uiManager;
    //Reference Display1
    [SerializeField] TMP_Text latitudeTMP;
    [SerializeField] TMP_Text longitudeTMP;
    [SerializeField] TMP_Text timezoneTMP;
    [SerializeField] TMP_Text timezoneAbbreviationTMP;
    [SerializeField] TMP_Text elevationTMP;
    [SerializeField] TMP_Text currentDayTMP;
    [SerializeField] TMP_Text currentTempTMP;
    //Reference Display2 content
    [SerializeField] GameObject D2Content;

    [SerializeField] MessagesManager messageManager;                            //Later Implementation: Need to remove this reference, use UIManager instead

    void Start()
    {
        display2Content = new List<GameObject>();
    }

    //Get WeatherData string and split it's components into reference class
    private void DeserializeDataIntoReferenceClass(string weatherData)
    {
        weatherInfo = JsonConvert.DeserializeObject<Root>(weatherData);
    }

    //Set Display1 content
    private void SetDisplay1() 
    {
        SetRow1();
        SetRow2();
        SetRow3();
    }
    //Set Row1
    private void SetRow1() 
    {
        latitudeTMP.text = "Latitude: " + weatherInfo.Latitude;
        longitudeTMP.text = "Longitude: " + weatherInfo.Longitude;
    }
    //Set Row2
    private void SetRow2() 
    {
        timezoneTMP.text = "Timezone: " + weatherInfo.Timezone;
        timezoneAbbreviationTMP.text = "Timezone Abbreviation: " + weatherInfo.TimezoneAbbreviation;
        elevationTMP.text = "Elevation: " + weatherInfo.Elevation;
    }
    //Set Row3
    private void SetRow3() 
    {
        currentDayTMP.text = "Today: " + weatherInfo.Days[0];
        currentTempTMP.text = "Current Max Temp: " + weatherInfo.TemperaturesForcastDayMax[0] + "°C";
    }

    //Set Display2
    private void SetDisplay2() 
    {
        GetDisplay2Content();
        SetDisplay2Content();
    }

    //Get Display2 child GameObjects and put them in List<GameObject> display2Content
    private void GetDisplay2Content() 
    {
        GameObject[] contents = GameObject.FindGameObjectsWithTag("Display2Component");
        foreach (var item in contents)
        {
            display2Content.Add(item.gameObject);
        }
    }
    //Set each child in List<GameObject> display2Content with coresponding data from the Reference class
    private void SetDisplay2Content() 
    {
        if (weatherInfo.Days.Count == display2Content.Count && weatherInfo.TemperaturesForcastDayMax.Count == display2Content.Count)
        {
            for (int i = 0; i < weatherInfo.Days.Count; i++)
            {
                Transform contentComponent = display2Content[i].transform;
                int contentChildCount = contentComponent.childCount;
                for (int j = 0; j < contentChildCount; j++)
                {
                    Transform componentChild = contentComponent.GetChild(j);
                    if (componentChild.name == "Date")
                    {
                        componentChild.GetComponent<TextMeshProUGUI>().text = weatherInfo.Days[i];
                    }
                    if (componentChild.name == "Temp")
                    {
                        componentChild.GetComponent<TextMeshProUGUI>().text = weatherInfo.TemperaturesForcastDayMax[i].ToString() + "°C";
                    }
                }
            }
        }
        else
        {
            //Send Snackbar message "Forecast Days & Temp not expected count"
            Debug.Log("Forecast Days & Temp not expected count");
        }
    }

    //Master Method that starts the whole process
    public void SetAllDisplayproperties(string weatherData) 
    {
        DeserializeDataIntoReferenceClass(weatherData);
        SetDisplay1();
        SetDisplay2();
    }

    public void SendToast()                                                                 //Later Implementation: Need to remove this reference, use UIManager instead
    {
        messageManager.EnqueToastMessage("This is the current day weather information");
    }

    public void SendSnackbar()                                                              //Later Implementation: Need to remove this reference, use UIManager instead
    {
        StringBuilder message = new StringBuilder();
        for (int i = 0; i < weatherInfo.Days.Count; i++)
        {
            message.Append($"{weatherInfo.Days[i]}: {weatherInfo.TemperaturesForcastDayMax[i]}°C");
            if (i < weatherInfo.Days.Count - 1)
            {
                message.Append("\r\n");
            }
        }
        messageManager.EnqueSnackbarMessage(message.ToString());
    }
}
