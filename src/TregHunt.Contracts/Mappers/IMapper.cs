using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Mappers
{
    //TODO: make this a generic mapper class
    public interface IMapper
    {
        T Map<T, T1>(T destination, T1 source); 
    }
}
