using System.Collections.Generic;
using DNP1Assignment1.Models;

namespace DNP1Assignment1.Persistence
{
    public interface IFileContext
    {
        void AddAdult(Adult adult);
        void RemoveAdult(int aId);
        void Update(Adult adult);
        IList<Adult> GetAdults();
        Adult GetAdult(int aId);
    }
}