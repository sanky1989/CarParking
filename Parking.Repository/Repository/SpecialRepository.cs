using Parking.Core.Helpers;
using Parking.Model;
using Parking.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Repository
{
    public class SpecialRepository : ISpecialRepository
    {
        public async Task<IEnumerable<SpecialRates>> SelectAllAsync()
        {
            // Default location for Special cases like weekend/ After hours
            var path = "special.json";
            var data = FileHelper.Read(FileHelper.FilePath + path); //All the rules set in JSON
            var result = JsonHelper.Deserialise<IEnumerable<SpecialRates>>(data);//Deserialize to Special Model
            return result;
        }
    }
}
