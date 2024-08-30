namespace MeteoTrento.Models
{
    // Modello utilizzato per rappresentare le informazioni di errore all'interno dell'applicazione.
    public class ErrorViewModel
    {
        // Proprietà per memorizzare l'ID della richiesta corrente, utilizzata per tracciare errori specifici.
        public string? RequestId { get; set; }

        // Proprietà calcolata che determina se l'ID della richiesta deve essere visualizzato nella vista.
        // Restituisce true se RequestId non è nullo o vuoto; altrimenti, false.
        public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
    }
}
