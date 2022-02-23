using System;
using System.Collections.Generic;
using System.Web.Http;


namespace web_api.Controllers
{
    public class CadernosController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Models.Caderno> cadernos = RepositoriesEntity.Caderno.getAll();
            return Ok(cadernos);
        }


        public IHttpActionResult Get(int id)
        {
            Models.Caderno caderno = RepositoriesEntity.Caderno.getById(id);
            return Ok(caderno);
        }

        public IHttpActionResult Post([FromBody] Models.Caderno caderno)
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
                RepositoriesEntity.Caderno.save(caderno);
                return Ok(caderno);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Models.Caderno caderno)
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
                caderno.Id = id;
                RepositoriesEntity.Caderno.update(caderno);
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
                RepositoriesEntity.Caderno.deleteById(id);
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
            List<Models.Caderno> cadernos = RepositoriesEntity.Caderno.getByTitulo(titulo);
            return Ok(cadernos);
        }

    }
}
