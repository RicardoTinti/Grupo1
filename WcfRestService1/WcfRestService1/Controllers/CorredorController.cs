using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace WcfRestService1.Controllers
{
    public class CorredorController
    {
        
        internal static List<corredor> RetornaCorredores()
        {
            webserviceEntities context = new webserviceEntities();

            string query = @"SELECT VALUE corredor FROM webserviceEntities.corredor";
            return context.CreateQuery<corredor>(query).ToList();

        }

        internal static corredor AdicionaCorredor(corredor instance)
        {
            webserviceEntities context = new webserviceEntities();
            context.AddTocorredor(instance);
            context.SaveChanges();

            return (from c1 in context.corredor
                    where c1.nome == instance.nome
                    select c1).First();
        }

        internal static corredor RetornaCorredor(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredor = Convert.ToInt32(id);
            return (from c1 in context.corredor
                    where c1.idCorredor == idCorredor
                    select c1).FirstOrDefault();
        }

        internal static corredor AtualizaCorredor(string id, corredor instance)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredor = Convert.ToInt32(id);
            corredor c = (from c1 in context.corredor
                          where c1.idCorredor == idCorredor
                     select c1).First();

            c.nome = instance.nome;
            c.status = instance.status;
            c.data_nascimento = instance.data_nascimento;
            c.cidade = instance.cidade;
            c.estado = instance.estado;
            
            context.SaveChanges();

            return RetornaCorredor(id);
        }

        internal static void ExcluiCorredor(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredor = Convert.ToInt32(id);
            corredor c = (from c1 in context.corredor
                          where c1.idCorredor == idCorredor
                          select c1).First();

            context.DeleteObject(c);
            context.SaveChanges();
        }
    }
}