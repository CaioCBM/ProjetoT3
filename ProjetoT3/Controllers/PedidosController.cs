using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoT3.DAL;
using ProjetoT3.Models;

namespace ProjetoT3.Controllers
{
    public class PedidosController : Controller
    {
        private ProjetoContexto db = new ProjetoContexto();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Fornecedor).Include(p => p.Produto);
            return View(pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome");
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataPedido,ValorTotal,Quantidade,FornecedorID,ProdutoID")] Pedido pedido)
        {
            
            if (pedido.ValorTotal < 0)
            {
                ModelState.AddModelError("", "Valor do Pedido deve ser positivo.");
                ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", pedido.FornecedorID);
                ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", pedido.ProdutoID);
                return View(pedido);
            }
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", pedido.FornecedorID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", pedido.ProdutoID);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", pedido.FornecedorID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", pedido.ProdutoID);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataPedido,ValorTotal,Quantidade,FornecedorID,ProdutoID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", pedido.FornecedorID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", pedido.ProdutoID);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
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
