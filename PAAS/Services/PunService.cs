using PAAS.Entities;
using PAAS.Extensions;
using PAAS.Models;
using Repository.Design;
using System;
using System.Linq;

namespace PAAS.Services
{
    public class PunService : IPunService
    {
        private readonly IRepo<Pun> _punRepo;

        public PunService(IRepoFactory repoFactory)
        {
            _punRepo = repoFactory.Repo<Pun>();
        }

        public PunResponseModel GetPun()
        {
            try
            {
                var pun = _punRepo.GetRandom().FirstOrDefault();
                return pun.MapToPun();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
