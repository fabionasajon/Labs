using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Angular_Bootstrap.VM;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;

namespace MVC_Angular_Bootstrap.UI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {

            List<UsuarioVM> us = new List<UsuarioVM>();

            //UsuarioVM u = new UsuarioVM();
            //u.Cpf = "111.555.444-02";
            //u.Nome = "Fábio Souza Mota";
            //u.Telefone = "(21)9999-5555";
            //u.Email = "fabiomotatj@hotmail.com";

            //us.Add(u);

            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

            StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            us = (List<UsuarioVM>)xs.Deserialize(s);

            s.Close();

            //ServiceReference1.Service1Client serv = new UI.ServiceReference1.Service1Client();

            //string ret = serv.RetDados();

            ViewBag.Hora = DateTime.Now.ToString("dd/MM/yyyy H:m");

            return View();
        }

        public JsonResult GetUsuarios()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

            StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            List<UsuarioVM> us = new List<UsuarioVM>();

            us = (List<UsuarioVM>)xs.Deserialize(s);

            s.Close();

            return  Json(us,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetUsuario(string matricula)
        {
            List<UsuarioVM> us = new List<UsuarioVM>();
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

            StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            us = (List<UsuarioVM>)xs.Deserialize(s);

            s.Close();

            UsuarioVM uAux = us.Where(u => u.Matricula == matricula).FirstOrDefault();

            return Json(uAux == null?new UsuarioVM(): uAux, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create(string matricula)
        {
            ViewBag.matricula = matricula;
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioVM usuario)
        {
            try
            {
                if (usuario.Matricula == null)
                    InsUsuario(usuario);
                else
                    UpdUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public string Edit(string usuario)
        {
            try
            {
                // TODO: Add update logic here

                JavaScriptSerializer js = new JavaScriptSerializer();

                UsuarioVM usu = js.Deserialize<UsuarioVM>(usuario);

                return "OK";
            }
            catch
            {
                throw new Exception();
            }
        }

        public void InsUsuario(UsuarioVM usu)
        {
            // TODO: Add insert logic here
            List<UsuarioVM> us = new List<UsuarioVM>();
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

            StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            us = (List<UsuarioVM>)xs.Deserialize(s);

            s.Close();

            UsuarioVM uAux = us.Where(u => (u.Cpf == usu.Cpf || u.Email == usu.Email) && u.Matricula != usu.Matricula).FirstOrDefault();

            if (uAux == null)
            {
                usu.Matricula = DateTime.Now.ToString("yyyyMMddHms");

                us.Add(usu);

                StreamWriter sw = new StreamWriter(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

                xs.Serialize(sw, us);

                sw.Close();
            }
        }

        public void UpdUsuario(UsuarioVM usu)
        {
            // TODO: Add insert logic here
            List<UsuarioVM> us = new List<UsuarioVM>();
            XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

            StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            us = (List<UsuarioVM>)xs.Deserialize(s);

            s.Close();

            us.RemoveAll(u => u.Matricula == usu.Matricula);

            us.Add(usu);

            StreamWriter sw = new StreamWriter(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

            xs.Serialize(sw, us);

            sw.Close();

        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public JsonResult Delete(string matricula)
        {
            try
            {
                List<UsuarioVM> us = new List<UsuarioVM>();
                XmlSerializer xs = new XmlSerializer(typeof(List<UsuarioVM>));

                StreamReader s = new StreamReader(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

                us = (List<UsuarioVM>)xs.Deserialize(s);

                s.Close();

                us.RemoveAll(u => u.Matricula == matricula);

                StreamWriter sw = new StreamWriter(@"C:\Users\y7bi\source\repos\MVC_Angular_Bootstrap\Dados\Usuarios.xml");

                xs.Serialize(sw, us);

                sw.Close();

                return Json(us, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
