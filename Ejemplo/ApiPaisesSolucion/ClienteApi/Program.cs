using ClienteApi;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var ejemploCliente = new ApiCliente();
        await ejemploCliente.EjecutarAsync();
        //await ejemploCliente.ObtenerUsuario(1);

        Console.ReadKey();
    }
}