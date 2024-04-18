using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myproject.Models;
using PagedList;

namespace Myproject.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]

    public class ClientesController : Controller
    {

        //List<Interno> internos;

        //// GET: Clientes

        //[HttpGet]

        //public ActionResult HomeClientes()
        //{

        //    ViewBag.hospital = "Hospital Tec";
        //    ViewData["especialidade"] = "Oftamologia";
        //    TempData["especialista"] = "Neves";
        //    internos = new List<Interno> ();
        //    internos.Add(new Interno { Num = 1, Nome = "Mário" });
        //    internos.Add(new Interno { Num = 2, Nome = "José" });
        //    internos.Add(new Interno { Num = 3, Nome = "Dinis" });
        //    internos.Add(new Interno { Num = 4, Nome = "Fernando" });
        //    internos.Add(new Interno { Num = 5, Nome = "Miguel" });
        //    internos.Add(new Interno { Num = 6, Nome = "Ricardo" });


        //    return View(internos);
        //}

        //[HttpPost]
        //public ActionResult HomeClientes (int? estagiario)

        //{

        //    internos = new List<Interno>();
        //    internos.Add(new Interno { Num = 1, Nome = "Mário" });
        //    internos.Add(new Interno { Num = 2, Nome = "José" });
        //    internos.Add(new Interno { Num = 3, Nome = "Dinis" });
        //    internos.Add(new Interno { Num = 4, Nome = "Fernando" });
        //    internos.Add(new Interno { Num = 5, Nome = "Miguel" });
        //    internos.Add(new Interno { Num = 6, Nome = "Ricardo" });

        //    int num = estagiario ?? 1;
        //    ViewBag.resposta = "O estagiario selecionado é " + internos.Where(x => x.Num == num).FirstOrDefault().Nome;
        //    return View(internos);

        //}


        public ActionResult ListarClientes(String msg, string ordem, int? page)
        {
            ViewBag.msg = msg;
            int pagesize = 5;
            int pagina = page ?? 1;
            using (projectEntities db = new projectEntities())
            {
                if (String.IsNullOrEmpty(ordem)) ordem = "nomedesc";
                ViewBag.nome = (ordem == "nomedesc") ? "nomeasc" : "nomedesc";
                ViewBag.ordem = ordem;
                List<clientes> clientes = db.clientes.ToList();

                switch (ordem)
                {
                    case "nomeasc":
                        clientes = clientes.OrderBy(x => x.ncliente).ToList();
                        break;
                    case "nomedesc":
                        clientes = clientes.OrderByDescending(x => x.ncliente).ToList();
                        break;
                    default:
                        clientes = clientes.OrderBy(x => x.idcli).ToList();
                        break;

                }
                return View(clientes.ToPagedList(pagina, pagesize));

            }
        }

        [HttpGet]
        public ActionResult AddCliente()
        {
            try
            {
                clientes novo = new clientes();
                return View(novo);


            }
            catch (Exception erro)
            {

                return RedirectToAction("ListarClientes", "Clientes", new { msg = erro.Message });
            }
        }

        [HttpPost]
        public ActionResult AddCliente(clientes novo, HttpPostedFileBase fich)
        {
            try
            {

                using (projectEntities db = new projectEntities())
                {
                    db.clientes.Add(novo);
                    db.SaveChanges();
                    if (fich != null && fich.ContentLength > 0 && fich.ContentType.Contains("image"))
                    {
                        String path = "~/fotos/" + novo.idcli.ToString() + System.IO.Path.GetExtension(fich.FileName);
                        novo.foto = path;
                        fich.SaveAs(Server.MapPath(path));
                        db.SaveChanges();
                    }
                    return RedirectToAction("ListarClientes", "Clientes", new { msg = "Inserido com Sucesso" });
                }

            }
            catch (Exception erro)
            {

                return RedirectToAction("ListarClientes", "Clientes", new { msg = erro.Message });
            }
        }

        [HttpGet]
        public ActionResult EditCliente(int? id)
        {

            try
            {
                using (projectEntities db = new projectEntities())
                {
                    clientes este = db.clientes.Find(id ?? 0);
                    if (este != null)
                    {
                        return View(este);
                    }
                    else
                    {
                        return RedirectToAction("ListarClientes", "Clientes", new { msg = "Id não existe" });
                    }

                }
            }
            catch (Exception neves)
            {
                return RedirectToAction("ListarClientes", "Clientes", new { msg = neves.Message });

            }
        }


        [HttpPost]
        public ActionResult EditCliente(clientes editado, HttpPostedFileBase fich)
        {
            try
            {
                using (projectEntities db = new projectEntities())
                {
                    clientes este = db.clientes.Find(editado.idcli);
                    if (este != null)
                    {
                        este.ncliente = editado.ncliente;
                        este.datanasC = editado.datanasC;
                        if (fich != null && fich.ContentLength > 0 && fich.ContentType.Contains("image"))
                        {
                            string caminho = "~/fotos/" + este.idcli.ToString() + System.IO.Path.GetExtension(fich.FileName);
                            if (System.IO.File.Exists(Server.MapPath(caminho))) System.IO.File.Delete(Server.MapPath(caminho));
                            fich.SaveAs(Server.MapPath(caminho));
                            este.foto = caminho;

                        }
                        db.SaveChanges();
                        return RedirectToAction("ListarClientes", "Clientes", new { msg = "Ok - Editado com sucesso" });

                    }
                    else
                    {
                        return RedirectToAction("ListarClientes", "Clientes", new { msg = "Cliente não existe" });

                    }
                }
            }
            catch (Exception erro)
            {

                return RedirectToAction("ListarClientes", "Clientes", new { msg = erro.Message });
            }
        }


        [HttpGet]
        public ActionResult DeleteCliente(int? id)
        {
            try
            {
                using (projectEntities db = new projectEntities())
                {
                    clientes este = db.clientes.Find(id ?? 0);
                    if (este != null)
                    {
                        db.clientes.Remove(este);
                        db.SaveChanges();
                        return RedirectToAction("ListarClientes", "Clientes", new { msg = "ok- deletado" });
                    }
                    else return RedirectToAction("ListarClientes", "Clientes", new { msg = "id não existe" });
                }

            }
            catch (Exception erro)
            {
                return RedirectToAction("ListarClientes", "Clientes", new { msg = erro.Message });
            }
        }

    }
}