namespace PruebaTecnica.WebApi.Core.Interfaces.Tools
{
    public interface IEncriptadorService
    {
        string Encriptar(string textoPlano);

        string Desencriptar(string textoCifrado);
    }
}
