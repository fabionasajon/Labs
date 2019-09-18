using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AspNetCoreMvc.Ent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuApiController : ControllerBase
    {
        public string  caminho = "";
        public UsuApiController(IHostingEnvironment h)
        {
            caminho = h.ContentRootPath + @"\wwwroot\Data\Usuarios.xml";
        }

        // GET: api/UsuApi
        [HttpGet]
        public IEnumerable<UsuarioEnt> Get()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioEnt>));

            StreamReader s = new StreamReader(caminho);

            List<UsuarioEnt> us = (List<UsuarioEnt>)xs.Deserialize(s);

            s.Close();

            return us;
        }

        // GET: api/UsuApi/5
        [HttpGet("{id}", Name = "Get")]
        public UsuarioEnt Get(long id)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioEnt>));

            StreamReader s = new StreamReader(caminho);

            List<UsuarioEnt> us = (List<UsuarioEnt>)xs.Deserialize(s);

            UsuarioEnt u = us.Where(x => x.Matricula == id.ToString()).FirstOrDefault();

            s.Close();

            return u;
        }

        // POST: api/UsuApi
        [HttpPost]
        public string Post([FromForm]UsuarioEnt usu)
        {

            try
            {

                List<UsuarioEnt> us = new List<UsuarioEnt>();
                XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioEnt>));

                usu.Matricula = DateTime.Now.ToString("yyyyMMddHms");

                StreamReader sr = new StreamReader(caminho);

                us = (List<UsuarioEnt>)xs.Deserialize(sr);

                sr.Close();

                sr.Dispose();

                us.Add(usu);

                StreamWriter sw = new StreamWriter(caminho);

                xs.Serialize(sw, us);

                sw.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "ok";
        }

        [HttpPost]
        [Route("[action]")]
        public void postString([FromBody] string value)
        {
            value = "";
        }

        // PUT: api/UsuApi/5
        [HttpPut("{id}")]
        public string Put(long id, [FromForm] UsuarioEnt usu)
        {
            List<UsuarioEnt> us = new List<UsuarioEnt>();
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioEnt>));

            usu.Matricula = DateTime.Now.ToString("yyyyMMddHms");

            StreamReader sr = new StreamReader(caminho);

            us = (List<UsuarioEnt>)xs.Deserialize(sr);

            sr.Close();

            UsuarioEnt u = us.Where(x => x.Matricula == id.ToString()).FirstOrDefault();

            us.Remove(u);

            us.Add(usu);

            StreamWriter sw = new StreamWriter(caminho);

            xs.Serialize(sw, us);

            sw.Close();

            return "ok";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(long id)
        {
            List<UsuarioEnt> us = new List<UsuarioEnt>();
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioEnt>));

            StreamReader sr = new StreamReader(caminho);
            try
            {
                us = (List<UsuarioEnt>)xs.Deserialize(sr);

                sr.Close();

                UsuarioEnt u = us.Where(x => x.Matricula == id.ToString()).FirstOrDefault();

                us.Remove(u);

                StreamWriter sw = new StreamWriter(caminho);

                xs.Serialize(sw, us);

                sw.Close();

                return "ok";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
