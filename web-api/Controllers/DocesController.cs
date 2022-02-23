using System;
using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class DocesController: ApiController
    {
        public IHttpActionResult Get()
        {
            List<Models.Doce> doces = RepositoriesEntity.Doce.getAll();
            return Ok(doces);
        }

        public IHttpActionResult Get(int id)
        {
            Models.Doce doce = RepositoriesEntity.Doce.getById(id);
            return Ok(doce);
        }

        public IHttpActionResult Post([FromBody] Models.Doce doce)
        {
            if (!ModelState.IsValid)
            {
                string error = "Requisição não é válida! Favor verificar as informações " +
                    "ou entrar em contato com a equipe de suporte!";
                Utils.Log.gravar(new Exception(error));
                return BadRequest(error);
            }

            try
            {
                RepositoriesEntity.Doce.save(doce);
                return Ok(doce);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Models.Doce doce)
        {
            if (!ModelState.IsValid)
            {
                string error = "Requisição não é válida! Favor verificar as informações " +
                    "ou entrar em contato com a equipe de suporte!";
                Utils.Log.gravar(new Exception(error));
                return BadRequest(error);
            }

            try
            {
                doce.Id = id;
                RepositoriesEntity.Doce.update(doce);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                RepositoriesEntity.Doce.deleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string descricao)
        {
            List<Models.Doce> doces = RepositoriesEntity.Doce.getByDescricao(descricao);
            return Ok(doces);
        }
    }
}
