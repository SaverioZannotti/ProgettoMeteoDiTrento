using ModelliMeteoTrento;
using System.ServiceModel;

namespace WSMeteoTrento.MeteoTrentoLogic
{
    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract]
        List<PrevisioneOutput> ricerca(string data);
    }

    public class SoapService : ISoapService
    {
        public List<PrevisioneOutput> ricerca(string data)
        {
            List<PrevisioneOutput> list = new List<PrevisioneOutput>();
            list = ServiziMeteoTrento.LetturaDati.Lettura().Result;
            List<PrevisioneOutput> previsioniGiornoInserito = list.Where(p => p.giorno == data).ToList();
            return previsioniGiornoInserito;
        }
    }
}
