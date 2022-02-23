using System;
using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class GibisController : ApiController
    {

        public IHttpActionResult Get()
        {
            List<Models.Gibi> gibis = RepositoriesEntity.Gibi.getAll();
            return Ok(gibis);
        }

        public IHttpActionResult Get(int id)
        {
            Models.Gibi gibi = RepositoriesEntity.Gibi.getById(id);
            return Ok(gibi);
        }

        public IHttpActionResult Post([FromBody] Models.Gibi gibi)
        {
            if (!ModelState.IsValid)
            {
                string error = "Requisição não é válida! Favor verificar as informações ou " +
                    "entrar em contato com a equipe de suporte!";
                Utils.Log.gravar(new Exception(error));
                return BadRequest(error);
            }

            try
            {
                RepositoriesEntity.Gibi.save(gibi);
                return Ok(gibi);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Models.Gibi gibi)
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
                gibi.Id = id;
                RepositoriesEntity.Gibi.update(gibi);
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
                RepositoriesEntity.Gibi.deleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string titulo)
        {
            List<Models.Gibi> gibis = RepositoriesEntity.Gibi.getByTitulo(titulo);
            return Ok(gibis);
        }
    }
}
