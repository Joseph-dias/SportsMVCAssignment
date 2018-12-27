using Sports_JDias.Data.Entities;
using Sports_JDias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_JDias.Code.converters
{
    public class statConverter : dataConverter
    {
        public myEntities toEntity(ViewModels model)
        {
            StatEntity e = new StatEntity();
            PlayerGameStatViewModel m = model as PlayerGameStatViewModel;
            if (m.playerGameStatID != -1) e.playerGameStatID = m.playerGameStatID;
            e.gameID = dataHandler.handle.getGames().Where(g => g.name == m.gameName).First().gameID;
            e.playerID = dataHandler.handle.getPlayers().Where(p => p.name == m.playerName).First().playerID;
            e.createDate = m.createDate;
            e.shotsOnGoal = m.shotsOnGoal;
            return e;
        }

        public ViewModels toModel(myEntities entity)
        {
            PlayerGameStatViewModel m = new PlayerGameStatViewModel();
            StatEntity e = entity as StatEntity;
            m.playerGameStatID = e.playerGameStatID;
            m.gameName = dataHandler.handle.getGames().Where(g => g.gameID == e.gameID).First().name;
            m.playerName = dataHandler.handle.getPlayers().Where(p => p.playerID == e.playerID).First().name;
            m.createDate = e.createDate;
            m.shotsOnGoal = e.shotsOnGoal;
            return m;
        }
    }
}