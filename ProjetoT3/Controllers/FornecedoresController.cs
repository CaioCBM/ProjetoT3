using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoT3.DAL;
using ProjetoT3.Models;

namespace ProjetoT3.Controllers
{
    public class FornecedoresController : Controller
    {
        private ProjetoContexto db = new ProjetoContexto();

        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(db.Fornecedores.ToList());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Endereco,Telefone,Email")] Fornecedor fornecedor)
        {

            if (CheckMatchingEmail(fornecedor.Email, 0))
            {
                ModelState.AddModelError("", "Esse e-mail já está sendo utilizado.");
                return View(fornecedor);
            }
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Endereco,Telefone,Email")] Fornecedor fornecedor)
        {

            if (CheckMatchingEmail(fornecedor.Email, fornecedor.ID))
            {
                ModelState.AddModelError("", "Esse e-mail já está sendo utilizado.");
                return View(fornecedor);
            }
            if (ModelState.IsValid)
            {

                db.Fornecedores.AddOrUpdate(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(fornecedor);
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

        public bool CheckMatchingEmail(string email, int id)
        {
            if (db.Clientes.Any(c => c.Email == email))
            {
                Cliente cliente = db.Clientes.Where(c => c.Email == email).First();
                if (cliente.ID != id) return true;
            }

            if (db.Fornecedores.Any(c => c.Email == email))
            {
                Fornecedor fornecedor = db.Fornecedores.Where(c => c.Email == email).First();
                if (fornecedor.ID != id) return true;
            }
            return false;
        }
    }
}
