﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProjetoT3.DAL;
using ProjetoT3.Models;

namespace ProjetoT3.Controllers
{
    public class ClientesController : Controller
    {
        private ProjetoContexto db = new ProjetoContexto();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Endereco,Telefone,Cpf,Email")] Cliente cliente)
        {
            if (CheckMatchingEmail(cliente.Email, 0))
            {
                ModelState.AddModelError("", "Esse e-mail já está sendo utilizado.");
                return View(cliente);
            }
            if (CheckMatchingCpf(cliente.Cpf, cliente.ID))
            {
                ModelState.AddModelError("", "Esse CPF já está sendo utilizado.");
                return View(cliente);
            }
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Endereco,Telefone,Cpf,Email")] Cliente cliente)
        {

            if (CheckMatchingEmail(cliente.Email, cliente.ID))
            {
                ModelState.AddModelError("", "Esse e-mail já está sendo utilizado.");
                return View(cliente);
            }
            if (CheckMatchingCpf(cliente.Cpf, cliente.ID))
            {
                ModelState.AddModelError("", "Esse CPF já está sendo utilizado.");
                return View(cliente);
            }
            if (ModelState.IsValid)
            {
                db.Clientes.AddOrUpdate(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
        public bool CheckMatchingCpf(string cpf, int id)
        {
            if (db.Clientes.Any(c => c.Cpf == cpf))
            {
                Cliente cliente = db.Clientes.Where(c => c.Cpf == cpf).First();
                if (cliente.ID != id) return true;
            }
            return false;
        }
    }
}
