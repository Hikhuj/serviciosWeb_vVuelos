using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vVuelos.Models;

namespace vVuelos.Classes
{
    public class UserVerficication
    {
        public static bool IsAdmin(int id, vVuelosEntities db) {
            user user = db.users.Find(id);
            if (user!=null)
            {
                //Check rol
                if (user.role.name.Equals("Administrador"))
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            return false;
        }
    }
}