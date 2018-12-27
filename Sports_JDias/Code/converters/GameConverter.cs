using Sports_JDias.Data.Entities;
using Sports_JDias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_JDias.Code.converters
{
    public class GameConverter : dataConverter
    {
        public myEntities toEntity(ViewModels model)
        {
            GameEntity e = new GameEntity();
            GameViewModel m = model as GameViewModel;
            if (m.gameID != -1) e.gameID = m.gameID;
            e.name = m.name;
            e.createDate = m.createDate;
            e.gameDate = m.gameDate;
            return e;
        }

        public ViewModels toModel(myEntities entity)
        {
            GameViewModel m = new GameViewModel();
            GameEntity e = entity as GameEntity;
            m.gameID = e.gameID;
            m.name = e.name;
            m.createDate = e.createDate;
            m.gameDate = e.gameDate;
            return m;
        }
    }
}