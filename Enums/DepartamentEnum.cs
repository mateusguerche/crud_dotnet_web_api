using System.Text.Json.Serialization;

namespace WebAPI_Projeto01.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentEnum
    {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
