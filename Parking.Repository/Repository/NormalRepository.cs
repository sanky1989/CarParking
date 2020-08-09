using Parking.Core.Helpers;
using Parking.Model;
using Parking.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Repository
{
    public class NormalJsonRepository : INormalRepository
    {
        public async Task<IEnumerable<NormalRates>> SelectAllAsync()
        {
            // Default location for Normal Flat Cases
            var path = "normal.json";
            var retData = FileHelper.Read(FileHelper.FilePath + path); //Rules for Flat rate and max rate 
            var retVal = JsonHelper.Deserialise<IEnumerable<NormalRates>>(retData);

            return retVal;
        }
    }
}
