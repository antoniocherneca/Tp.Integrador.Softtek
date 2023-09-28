using static Tp.Integrador.Softtek.Infrastructure.ApiErrorResponse;

namespace Tp.Integrador.Softtek.Infrastructure
{
    public class ApiSuccessResponse
    {
        public int Status { get; set; }
        public object? Data { get; set; }
    }
}
