using Sports_JDias.Data.Entities;
using Sports_JDias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_JDias.Code
{
    /// <summary>
    /// Singleton to handle connection to the database
    /// </summary>
    public class dataHandler
    {
        private static dataHandler instance = null; //Single instance of this class
        private dataHandler()
        {

        }

        /// <summary>
        /// Get the instance of this class
        /// </summary>
        public static dataHandler handle
        {
            get
            {
                if(instance == null)
                {
                    instance = new dataHandler();
                }
                return instance;
            }
        }

        /// <summary>
        /// Add a new player to the database
        /// </summary>
        /// <param name="newModel">View model for the player</param>
        public void newPlayer(PlayerViewModel newModel)
        {
            try
            {
                PlayerEntity newEntity = ConverterFactory.RUN_TO_ENTITY(newModel) as PlayerEntity; //Convert to player entity.
                Data.Database data = new Data.Database();
                data.players.Add(newEntity);
                data.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <param name="newModel">Data to add</param>
        public void newGame(GameViewModel newModel)
        {
            try
            {
                GameEntity newEntity = ConverterFactory.RUN_TO_ENTITY(newModel) as GameEntity;
                Data.Database d = new Data.Database();
                d.games.Add(newEntity);
                d.SaveChanges();
            }catch(Exception)
            {

            }
        }

        /// <summary>
        /// Returns the list of all players as PlayerViewModels
        /// </summary>
        /// <returns>List of players</returns>
        public List<PlayerViewModel> getPlayers()
        {
            List<PlayerViewModel> theList = new List<PlayerViewModel>();
            Data.Database d = new Data.Database();
            foreach (PlayerEntity e in d.players)
            {
                theList.Add(ConverterFactory.RUN_TO_MODEL(e) as PlayerViewModel);
            }
            return theList;
        }

        public List<GameViewModel> getGames()
        {
            List<GameViewModel> theList = new List<GameViewModel>();
            Data.Database d = new Data.Database();
            foreach(GameEntity e in d.games)
            {
                theList.Add(ConverterFactory.RUN_TO_MODEL(e) as GameViewModel);
            }
            return theList;
        }

        /// <summary>
        /// Edit player in the database to the new values in the model
        /// </summary>
        /// <param name="model">Model that contains new values</param>
        public void editPlayer(PlayerViewModel model)
        {
            Data.Database d = new Data.Database();
            foreach(PlayerEntity e in d.players)
            {
                if(e.playerID == model.playerID)
                {
                    e.name = model.name;
                    e.dateOfBirth = model.dob;
                }
            }
            d.SaveChanges();
        }

        public void deletePlayer(int id)
        {
            Data.Database d = new Data.Database();
            PlayerEntity toDelete = null;
            foreach(PlayerEntity e in d.players)
            {
                if (e.playerID == id)
                {
                    toDelete = e;
                    break;
                }
            }
            d.players.Remove(toDelete); //Delete the found entry
            d.SaveChanges();
        }

        /// <summary>
        /// Edit game in the database to the new values in the model
        /// </summary>
        /// <param name="model">Model that contains new values</param>
        public void editGame(GameViewModel model)
        {
            Data.Database d = new Data.Database();
            foreach (GameEntity e in d.games)
            {
                if (e.gameID == model.gameID)
                {
                    e.name = model.name;
                    e.gameDate = model.gameDate;
                }
            }
            d.SaveChanges();
        }

        public void deleteGame(int id)
        {
            Data.Database d = new Data.Database();
            GameEntity toDelete = null;
            foreach (GameEntity e in d.games)
            {
                if (e.gameID == id)
                {
                    toDelete = e;
                    break;
                }
            }
            d.games.Remove(toDelete); //Delete the found entry
            d.SaveChanges();
        }

        /// <summary>
        /// Create a new stat
        /// </summary>
        /// <param name="newModel">Data to add</param>
        public void newStat(PlayerGameStatViewModel newModel)
        {
            try
            {
                StatEntity newEntity = ConverterFactory.RUN_TO_ENTITY(newModel) as StatEntity;
                Data.Database d = new Data.Database();
                d.stats.Add(newEntity);
                d.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Get the list of player game stats!
        /// </summary>
        /// <returns>A list of PlayerGameStatViewModels</returns>
        public List<PlayerGameStatViewModel> getStats()
        {
            List<PlayerGameStatViewModel> theList = new List<PlayerGameStatViewModel>();
            Data.Database d = new Data.Database();
            List<StatEntity> toDelete = null;
            foreach (StatEntity e in d.stats)
            {
                try
                {
                    theList.Add(ConverterFactory.RUN_TO_MODEL(e) as PlayerGameStatViewModel);
                }catch(Exception)
                {
                    if (toDelete == null) toDelete = new List<StatEntity>();
                    toDelete.Add(e);
                }
            }
            if(toDelete != null) //Delete all stats that throw exceptions
            {
                foreach(StatEntity e in toDelete)
                {
                    d.stats.Remove(e);
                }
                d.SaveChanges();
            }
            return theList;
        }

        /// <summary>
        /// Edit stat in the database to the new values in the model
        /// </summary>
        /// <param name="model">Model that contains new values</param>
        public void editStat(PlayerGameStatViewModel model)
        {
            Data.Database d = new Data.Database();
            foreach (StatEntity e in d.stats)
            {
                if (e.playerGameStatID == model.playerGameStatID)
                {
                    e.shotsOnGoal = model.shotsOnGoal;
                }
            }
            d.SaveChanges();
        }

        public void deleteStat(int id)
        {
            Data.Database d = new Data.Database();
            StatEntity toDelete = null;
            foreach (StatEntity e in d.stats)
            {
                if (e.playerGameStatID == id)
                {
                    toDelete = e;
                    break;
                }
            }
            d.stats.Remove(toDelete); //Delete the found entry
            d.SaveChanges();
        }
    }
}