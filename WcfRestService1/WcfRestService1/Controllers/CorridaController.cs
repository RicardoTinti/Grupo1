using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestService1.Controllers
{
    public class CorridaController
    {

        internal static List<corrida> RetornaCorridas()
        {
            webserviceEntities context = new webserviceEntities();
            return (from c in context.corrida select c).ToList<corrida>();
        }

        internal static corrida AdicionaCorrida(corrida instance)
        {
            webserviceEntities context = new webserviceEntities();
            context.AddTocorrida(instance);
            context.SaveChanges();

            return (from c1 in context.corrida
                    where c1.nome == instance.nome
                    select c1).First();
        }

        internal static corrida RetornaCorrida(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorrida = Convert.ToInt32(id);
            return (from c1 in context.corrida
                    where c1.idCorrida == idCorrida
                    select c1).FirstOrDefault();
        }

        internal static corrida AtualizaCorrida(string id, corrida instance)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorrida = Convert.ToInt32(id);
            corrida c = (from c1 in context.corrida
                          where c1.idCorrida == idCorrida
                     select c1).First();

            c.nome = instance.nome;
            c.status = instance.status;
            c.data_corrida = instance.data_corrida;
            c.cidade = instance.cidade;
            c.estado = instance.estado;
            c.valor = instance.valor;
            
            context.SaveChanges();

            return RetornaCorrida(id);
        }

        internal static void ExcluiCorrida(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorrida = Convert.ToInt32(id);
            corrida c = (from c1 in context.corrida
                          where c1.idCorrida == idCorrida
                          select c1).First();

            context.DeleteObject(c);
            context.SaveChanges();
        }

    }

}
