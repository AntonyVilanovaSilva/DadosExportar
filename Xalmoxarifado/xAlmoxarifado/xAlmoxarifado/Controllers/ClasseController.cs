using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xAlmoxarifado.Models;

namespace xAlmoxarifado.Controllers
{
    public class ClasseController : Controller
    {
        private xalmoxarifadocopiaEntities1 db = new xalmoxarifadocopiaEntities1();

        // GET: Classe
        public ActionResult Index()
        {
            return View(db.Classe.ToList());
        }

        // GET: Classe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: Classe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classe/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLAS,ID_SUB_GRU,NOME_CLA")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Classe.Add(classe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classe);
        }

        // GET: Classe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classe/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLAS,ID_SUB_GRU,NOME_CLA")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classe);
        }

        // GET: Classe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classe classe = db.Classe.Find(id);
            db.Classe.Remove(classe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
