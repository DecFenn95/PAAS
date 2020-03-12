using PAAS.Entities;
using PAAS.Models;

namespace PAAS.Extensions
{
    public static class PunExtensions
    {
        public static PunResponseModel MapToPun(this Pun pun)
        {
            return new PunResponseModel()
            {
                Pun = pun.Content
            };
        }
    }
}
