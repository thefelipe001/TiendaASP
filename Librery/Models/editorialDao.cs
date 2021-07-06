using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery.Models
{
    public  class editorialDao 
    {
        //listar
        public static List<editoriales> Mostrar()
        {
            using (var lista=new ApplicationDB())
            {
              return  lista.editoriales.OrderBy(x => x.codigo).ToList();
            }
        }

        public static List<editoriales> TodolasCategoria(editoriales editorial)
        {
            string sql = @"select* from editoriales where nombre like '%" + editorial.nombre + "%'";

            using (var db = new ApplicationDB())
            {
                return db.Database.SqlQuery<editoriales>(sql).ToList();
            }
        }









        //Agregar
        public static bool Agregar(editoriales editoriales)
        {
            bool existo=true;
            try
            {
                using (var data= new ApplicationDB())
                {
                    data.editoriales.Add(editoriales);
                    data.SaveChanges();
                }

            }
            catch (Exception)
            {

                existo = false;
            }
            return existo;
        }
        //Obtener
        public static editoriales Obtener(byte codigo) 
        {
            using (var ob=new ApplicationDB())
            {
                return ob.editoriales.Find(codigo);
            }
        
        }
        public static bool  Eliminar(byte id) 
        {
            bool exito = true;
            using (var data= new ApplicationDB())
            {
              var lis=  data.editoriales.Find(id);
                data.editoriales.Remove(lis);
                data.SaveChanges();
            }
            return exito;
        
        }
    }
}