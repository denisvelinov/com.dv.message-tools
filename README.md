# com.dv.message-tools
Unity Package for creating a simple Display and Messaging app.

--Architecture--
Package contains 2 main scripts named "DisplayManager" & "MessagesManager",
also imcluded is a Prefab UI setup in the "Samples" folder.

The "DisplayManager" script controls the TextmeshPro fields set up in the Prefab UI.

The "MessagesManager" script holds a Queue which controls the requests to create
"Toast" or "Snackbar" messages appear on screan respectively.

The 2 helper scripts "ToastCreator" & "SnackbarCreator", make a message window 
appear on screen with the message itself provided by the "MessagesManager" script.

--How to use--
First you need to setup the desired UI in a scene in Uity (or use the Prefab UI).

