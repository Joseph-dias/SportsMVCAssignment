using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sports_JDias.Data.Entities;
using Sports_JDias.Models;

namespace Sports_JDias.Code
{
    /// <summary>
    /// Used by any class that converts models to entities and vice versa
    /// </summary>
    interface dataConverter
    {
        myEntities toEntity(ViewModels model);
        ViewModels toModel(myEntities entity);
    }
}
