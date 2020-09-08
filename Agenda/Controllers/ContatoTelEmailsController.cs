using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class ContatoTelEmailsController : Controller
    {
        private AgendaEntities db = new AgendaEntities();

        // GET: ContatoTelEmails
        public ActionResult Index(string searchString)
        {
            var contatoTelEmails = from s in db.ContatoTelEmail
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                contatoTelEmails = contatoTelEmails.Where(s => s.Contato.Nome_Contato.Contains(searchString));
            }
            else
            {
                contatoTelEmails = db.ContatoTelEmail.Include(c => c.Contato);
            }
            return View(contatoTelEmails.ToList());
        }

        // GET: ContatoTelEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTelEmail contatoTelEmail = db.ContatoTelEmail.Find(id);
            if (contatoTelEmail == null)
            {
                return HttpNotFound();
            }
            return View(contatoTelEmail);
        }

        // GET: ContatoTelEmails/Create
        public ActionResult Create()
        {
            ViewBag.Id_Contato = new SelectList(db.Contato, "Id_Contato", "Nome_Contato");
            return View();
        }

        // POST: ContatoTelEmails/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Contato,Telefone,Email")] ContatoTelEmail contatoTelEmail)
        {
            if (ModelState.IsValid)
            {
                if (!UsuarioDAL.VerificaId(contatoTelEmail.Id))
                { 
                db.ContatoTelEmail.Add(contatoTelEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Id de Usuário já cadastrado.";
                }
            }

            ViewBag.Id_Contato = new SelectList(db.Contato, "Id_Contato", "Nome_Contato", contatoTelEmail.Id_Contato);
            return View(contatoTelEmail);
        }

        // GET: ContatoTelEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTelEmail contatoTelEmail = db.ContatoTelEmail.Find(id);
            if (contatoTelEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Contato = new SelectList(db.Contato, "Id_Contato", "Nome_Contato", contatoTelEmail.Id_Contato);
            return View(contatoTelEmail);
        }

        // POST: ContatoTelEmails/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Contato,Telefone,Email")] ContatoTelEmail contatoTelEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatoTelEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Contato = new SelectList(db.Contato, "Id_Contato", "Nome_Contato", contatoTelEmail.Id_Contato);
            return View(contatoTelEmail);
        }

        // GET: ContatoTelEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTelEmail contatoTelEmail = db.ContatoTelEmail.Find(id);
            if (contatoTelEmail == null)
            {
                return HttpNotFound();
            }
            return View(contatoTelEmail);
        }

        // POST: ContatoTelEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContatoTelEmail contatoTelEmail = db.ContatoTelEmail.Find(id);
            db.ContatoTelEmail.Remove(contatoTelEmail);
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
