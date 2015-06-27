using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WcfRestService1.Controllers;

namespace WcfRestService1
{	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WebServiceGrupo1
    {
        
        #region CRUD_Corredor

        [WebGet(UriTemplate = "Corredores/"), OperationContract]
        public List<corredor> GetCollection()
        {
            return CorredorController.RetornaCorredores();
        }

        [WebInvoke(UriTemplate = "Corredores/", Method = "POST"), OperationContract]
        public corredor Create(corredor instance)
        {
            return CorredorController.AdicionaCorredor(instance);
        }

        [WebGet(UriTemplate = "Corredores/{id}"), OperationContract]
        public corredor Get(string id)
        {
            return CorredorController.RetornaCorredor(id);
        }

        [WebInvoke(UriTemplate = "Corredores/{id}", Method = "PUT"), OperationContract]
        public corredor UpdateCorredor(string id, corredor instance)
        {
            return CorredorController.AtualizaCorredor(id, instance);
        }

        [WebInvoke(UriTemplate = "Corredores/{id}", Method = "DELETE"), OperationContract]
        public void Delete(string id)
        {
            CorredorController.ExcluiCorredor(id);
        }
        #endregion

        #region Corridas

        [WebGet(UriTemplate = "Corridas/"), OperationContract]
        public List<corrida> GetCorridas()
        {
            return CorridaController.RetornaCorridas();
        }

        [WebInvoke(UriTemplate = "Corridas/", Method = "POST"), OperationContract]
        public corrida CreateCorrida(corrida instance)
        {
            return CorridaController.AdicionaCorrida(instance);
        }

        [WebGet(UriTemplate = "Corridas/{id}"), OperationContract]
        public corrida GetCorrida(string id)
        {
            return CorridaController.RetornaCorrida(id);
        }

        [WebInvoke(UriTemplate = "Corridas/{id}", Method = "PUT"), OperationContract]
        public corrida Update(string id, corrida instance)
        {
            return CorridaController.AtualizaCorrida(id, instance);
        }

        [WebInvoke(UriTemplate = "Corridas/{id}", Method = "DELETE"), OperationContract]
        public void DeleteCorrida(string id)
        {
            CorridaController.ExcluiCorrida(id);
        }

        #endregion

        #region Inscricoes
        [WebGet(UriTemplate = "Corredores/{id}/Corridas"), OperationContract]
        public List<corrida> GetCorridasDeUmCorredor(string id)
        {
            return InscricaoController.RetornaCorridasDeUmCorredor(id);
        }

        [WebGet(UriTemplate = "Corridas/{id}/Corredores"), OperationContract]
        public List<corredor> GetCorredoresDeUmaCorrida(string id)
        {
            return InscricaoController.RetornaCorredoresDeUmaCorrida(id);
        }

        [WebGet(UriTemplate = "Corridas/{idCorrida}/Corredores/{idCorredor}"), OperationContract]
        public inscricao GetCorredorDeUmaCorrida(string idCorredor, string idCorrida)
        {
            return InscricaoController.RetornaInscricaoDeUmCorredorEmUmaCorrida(idCorredor, idCorrida);
        }

        [WebGet(UriTemplate = "Corredores/{idCorredor}/Corridas/{idCorrida}"), OperationContract]
        public inscricao GetCorridaDeUmCorredor(string idCorredor, string idCorrida)
        {
            return InscricaoController.RetornaInscricaoDeUmCorredorEmUmaCorrida(idCorredor, idCorrida);
        }

        [WebInvoke(UriTemplate = "Corredores/{idCorredor}/Corridas/{idCorrida}", Method = "PUT"), OperationContract]
        public inscricao AtualizaInscricao(string idCorredor, string idCorrida, inscricao instancia)
        {
            return InscricaoController.AtualizaInscricao(idCorredor, idCorrida, instancia);
        }

        [WebInvoke(UriTemplate = "Corredores/{idCorredor}/Corridas/{idCorrida}", Method = "DELETE"), OperationContract]
        public void DeletaInscricao(string idCorredor, string idCorrida)
        {
            InscricaoController.DeletaInscricaoDoCorredorNaCorrida(idCorredor, idCorrida);
        }

        [WebInvoke(UriTemplate = "Inscricoes/{idCorredor}", Method = "POST"), OperationContract]
        public void CriaInscricao(string idCorredor, corrida inst_corrida)
        {
            InscricaoController.AdicionaInscricao(idCorredor, inst_corrida);
        }

        [WebGet(UriTemplate = "Inscricoes/"), OperationContract]
        public List<inscricao> GetInscricoes()
        {
            return InscricaoController.RetornaInscricoes();
        }

        [WebGet(UriTemplate = "Inscricoes/{idInscricao}"), OperationContract]
        public inscricao GetInscricao(string idInscricao)
        {
            return InscricaoController.RetornaInscricao(idInscricao);
        }

        [WebInvoke(UriTemplate = "Inscricoes/{idInscricao}", Method = "DELETE"), OperationContract]
        public void DeletaInscricaoPeloId(string idInscricao)
        {
            InscricaoController.ExcluiInscricao(idInscricao);
        }

        [WebInvoke(UriTemplate = "Inscricoes/{idInscricao}", Method = "PUT"), OperationContract]
        public inscricao AtualizaInscricaoPeloId(string idInscricao, inscricao instancia)
        {
            return InscricaoController.AtualizaInscricao(idInscricao, instancia);
        }

        #endregion
    }
}
