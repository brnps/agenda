using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public class UsuarioDAL
    {
        public static bool VerificaId(int id)
        {
            using (AgendaEntities dc = new AgendaEntities())
            {
                var existeid = (from u in dc.ContatoTelEmail
                                   where u.Id == id
                                   select u).FirstOrDefault();
                if (existeid != null)
                    return true;
                else
                    return false;
            }
        }
    }
}