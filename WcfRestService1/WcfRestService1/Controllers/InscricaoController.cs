using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestService1.Controllers
{
    public class InscricaoController
    {
        internal static List<corredor> RetornaCorredoresDeUmaCorrida(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorrida = Convert.ToInt32(id);

            return (from c in context.inscricao where 
                        c.Corrida_idCorrida == idCorrida
                        select c.corredor).ToList<corredor>();
        }

        internal static List<corrida> RetornaCorridasDeUmCorredor(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredor = Convert.ToInt32(id);

            return (from c in context.inscricao where 
                        c.Corredor_idCorredor == idCorredor
                        select c.corrida).ToList<corrida>();
        }

        internal static List<inscricao> AdicionaInscricao(string id_corredor, corrida corrida)
        {
            webserviceEntities context = new webserviceEntities();
            inscricao nova_inscricao = new inscricao();

            nova_inscricao.corrida = corrida;
            nova_inscricao.corredor = CorredorController.RetornaCorredor(id_corredor);
            context.AddToinscricao(nova_inscricao);
            context.SaveChanges();

            return (from c1 in context.inscricao
                    where c1.Corrida_idCorrida == corrida.idCorrida
                    select c1).ToList<inscricao>();
        }

        internal static inscricao RetornaInscricao(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idInscricao = Convert.ToInt32(id);
            return (from c1 in context.inscricao
                    where c1.idInscricao == idInscricao
                    select c1).FirstOrDefault();
        }

        internal static inscricao AtualizaInscricao(string id, inscricao instance)
        {
            webserviceEntities context = new webserviceEntities();
            int idInscricao = Convert.ToInt32(id);
            inscricao c = (from c1 in context.inscricao
                          where c1.idInscricao == idInscricao
                     select c1).First();

            c.Corredor_idCorredor = instance.Corredor_idCorredor;
            c.Corrida_idCorrida = instance.Corrida_idCorrida;
            c.status_pagamento = instance.status_pagamento;
                        
            context.SaveChanges();

            return RetornaInscricao(id);
        }

        internal static void ExcluiInscricao(string id)
        {
            webserviceEntities context = new webserviceEntities();
            int idInscricao = Convert.ToInt32(id);
            inscricao c = (from c1 in context.inscricao
                          where c1.idInscricao == idInscricao
                          select c1).First();

            context.DeleteObject(c);
            context.SaveChanges();
        }

        internal static inscricao AtualizaInscricao(string idCorredor, string idCorrida, inscricao inscricao)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredorInt = Convert.ToInt32(idCorredor);
            int idCorridaInt = Convert.ToInt32(idCorrida);
            inscricao i = (from insc in context.inscricao
                           where insc.Corredor_idCorredor == idCorredorInt & insc.Corrida_idCorrida == idCorridaInt
                           select insc).First();
            string idString = i.idInscricao.ToString();

            return AtualizaInscricao(idString, inscricao);
        }

        internal static void DeletaInscricaoDoCorredorNaCorrida(string idCorredor, string idCorrida)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredorInt = Convert.ToInt32(idCorredor);
            int idCorridaInt = Convert.ToInt32(idCorrida);
            inscricao i = (from insc in context.inscricao
                           where insc.Corredor_idCorredor == idCorredorInt & insc.Corrida_idCorrida == idCorridaInt
                           select insc).First();

            string idString = i.idInscricao.ToString();

            ExcluiInscricao(idString);
        }

        internal static inscricao RetornaInscricaoDeUmCorredorEmUmaCorrida(string idCorredor, string idCorrida)
        {
            webserviceEntities context = new webserviceEntities();
            int idCorredorInt = Convert.ToInt32(idCorredor);
            int idCorridaInt = Convert.ToInt32(idCorrida);
            inscricao i = (from insc in context.inscricao
                           where insc.Corredor_idCorredor == idCorredorInt & insc.Corrida_idCorrida == idCorridaInt
                           select insc).First();
            return i;
        }

        internal static List<inscricao> RetornaInscricoes()
        {
            webserviceEntities context = new webserviceEntities();

            return (from c in context.inscricao
                    select c).ToList<inscricao>();
        }
    }
    
}