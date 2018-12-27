using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sports_JDias.Data.Entities;
using Sports_JDias.Models;

namespace Sports_JDias.Code.converters
{
    public class PlayerConverter : dataConverter
    {
        public myEntities toEntity(ViewModels model)
        {
            PlayerEntity e = new PlayerEntity();
            PlayerViewModel m = model as PlayerViewModel;
            if(m.playerID != -1) e.playerID = m.playerID;
            e.name = m.name;
            e.createDate = m.createDate;
            e.dateOfBirth = m.dob;
            return e;
        }

        public ViewModels toModel(myEntities entity)
        {
            PlayerViewModel m = new PlayerViewModel();
            PlayerEntity e = entity as PlayerEntity;
            m.playerID = e.playerID;
            m.name = e.name;
            m.createDate = e.createDate;
            m.dob = e.dateOfBirth;
            return m;
        }
    }
}