namespace PublisherJobInfra.Infra.Entities
{
    public class WeatherReportEntity
    {
        //TODO: colocar tudo para letra maiuscula
        public int? Id { get; set; }
        public string? Cidade { get; set; }
        public string? estado { get; set; }
        public string? atualizado_em { get; set; }
        public List<Climate>? clima { get; set; }
    }

    public class Climate
    {
        public string? data { get; set; }
        public string? condicao { get; set; }
        public string? condicao_desc { get; set; }
        public string? min { get; set; }
        public string? max { get; set; }
        public string? indice_uv { get; set; }
    }
}
