# com.dv.message-tools
Unity Package for creating a simple Display & Messaging app.
The scripts in the package are set up to work for a Weather Application, to use their functionality would require for the scripts to be changed.

--Architecture--

Package contains 2 main scripts named "DisplayManager" & "MessagesManager", also imcluded is a Prefab UI setup in the "Samples" folder.

The "DisplayManager" script controls the TextmeshPro fields set up in the Prefab UI.

The "MessagesManager" script holds a Queue which controls the requests to create "Toast" or "Snackbar" messages appear on screan respectively.

The 2 helper scripts "ToastCreator" & "SnackbarCreator", make a message window appear on screen with the message itself provided by the "MessagesManager" script.

--How to use--

First you need to add the package in Unity via the "Package Manager" using the project url: "https://github.com/denisvelinov/com.dv.message-tools.git".
Next you need to setup the Prefab UI in your Unity scene.
The package is also dependant on the package "com.unity.textmeshpro", you need to have it added to your project and to Import TMP Essential Resources.

Each script has references wich need to be set in the Inspector window in Unity (Recomended to use the Prefab UI wherer all references are already set).

To provide data to both the "MessagesManager" & "DisplayManager", they need to be referenced from another script (The "DisplayManager" itself references the "MessagesManager").

The "MessagesManager" takes data using the "EnqueToastMessage(string messageToDisplay)" & "EnqueSnackbarMessage(string messageToDisplay)" methods.
The data has to be of type "string", it's format doesn't need to follow any restrictions (Recomended to keep the lenght of the message short, as it will increase the size of the message window and can cause an undesired result).

The "DisplayManager" takes data using the "SetAllDisplayproperties(string weatherData)" method.
The data has to be of type "string", it's format needs to be in the following format to work properly: "{"Latitude": 46.7225,"Longitude": 21.6777,"Timezone": "Africa/SouthAfrica","TimezoneAbbreviation": "ASA","Elevation": 300,"Days": ["2023-01-30","2023-01-31","2023-02-01","2023-02-02","2023-02-03","2023-02-04","2023-02-05"],"TemperaturesForcastDayMax": [2.1,3.6,5.5,6.4,4,4.8,-0.3]}"
