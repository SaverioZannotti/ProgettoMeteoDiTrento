# ProgettoMeteoDiTrento

Abbiamo optato per la traccia numero 2 che richiedeva di creare un'applicazione web capace di mostrare il bollettino meteorologico della provincia di Trento.

nella traccia chiedeva:

- Leggere il servizio REST JSON messo a disposizione dalla regione Trentino Alto Adige;

- Visualizzare i dati in una interfaccia web (sfruttando anche immagini fornite dal servizio nell’interfaccia grafica)

- Creare un WS SOAP che faccia da «convertitore», convertendo servizio REST JSON in uno SOAP.

- Far funzionare l’applicativo in un container # Docker

Composizione del gruppo : Filippo Illuminati (119788), Saverio Zannotti (119034), 
Falistocco Michele (119745)

Per far partire il programma :
1) Avvia docker desktop
2) Crea una build dal docker file
3) Ora fai docker run -p 8080:80 nome-immagine
4) Nel browser ora digita localhost/home