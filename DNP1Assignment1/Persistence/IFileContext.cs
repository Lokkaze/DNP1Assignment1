using System.Collections.Generic;
using DNP1Assignment1.Models;

namespace DNP1Assignment1.Persistence
{
    public interface IFileContext
    {
        void AddAdult(Adult adult);
        IList<Adult> GetAdults();
    }
}