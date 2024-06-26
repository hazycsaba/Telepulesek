﻿using Telepulesek.Models.Entities;

namespace Telepulesek.Models.DTOs
{
    public static class Conversion
    {
        public static TelepulesListaDTO ToDTO(this Telepules telepules)
        {
            return new TelepulesListaDTO(telepules.megnevezes, telepules.IRSZ, telepules.megye.megye, telepules.nepesseg, telepules.terulet, telepules.lakasok, telepules.telepulesresz);
        }

        public static List<TelepulesListaDTO> ToDTO(this List<Telepules> telepulesek)
        {
            return telepulesek.Select(ToDTO).ToList();
        }
    }
}
