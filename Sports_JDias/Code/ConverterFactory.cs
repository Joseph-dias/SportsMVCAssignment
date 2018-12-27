using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sports_JDias.Data.Entities;
using Sports_JDias.Models;

namespace Sports_JDias.Code
{
    public static class ConverterFactory
    {
        /// <summary>
        /// Correctly convert the given view model to its entity value
        /// </summary>
        /// <param name="model">Model to convert</param>
        /// <returns>Converted value</returns>
        public static myEntities RUN_TO_ENTITY(ViewModels model)
        {
            dataConverter convert = null;
            // Player model
            if(model is PlayerViewModel)
            {
                convert = new converters.PlayerConverter();
            }else if(model is GameViewModel)
            {
                convert = new converters.GameConverter();
            }else if(model is PlayerGameStatViewModel)
            {
                convert = new converters.statConverter();
            }

            //Return the entity
            if (convert != null) return convert.toEntity(model);
            else throw new Exception("No converter found");
        }

        /// <summary>
        /// Correctly convert the given entity to its view model
        /// </summary>
        /// <param name="entity">Entity to convert</param>
        /// <returns>Converted value</returns>
        public static ViewModels RUN_TO_MODEL(myEntities entity)
        {
            dataConverter convert = null;
            // Player entity
            if (entity is PlayerEntity)
            {
                convert = new converters.PlayerConverter();
            }else if(entity is GameEntity)
            {
                convert = new converters.GameConverter();
            }else if(entity is StatEntity)
            {
                convert = new converters.statConverter();
            }

            //Return the entity
            if (convert != null) return convert.toModel(entity);
            else throw new Exception("No converter found");
        }
    }
}