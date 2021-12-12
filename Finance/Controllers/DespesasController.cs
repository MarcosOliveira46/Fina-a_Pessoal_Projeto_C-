﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finance.Data;
using Finance.Models;

namespace Finance.Controllers
{
    public class DespesasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Despesas
        public ActionResult Index()
        {
            var despesas = db.Despesas.Include(d => d.TipoDespesas);
            return View(despesas.ToList());
        }

        // GET: Despesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // GET: Despesas/Create
        public ActionResult Create()
        {
            ViewBag.Despesa_Id = new SelectList(db.TipoDespesas, "Id", "Descricao");
            return View();
        }

        // POST: Despesas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Despesa_Id,Data_Despesa,Despesa_Valor")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Despesas.Add(despesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Despesa_Id = new SelectList(db.TipoDespesas, "Id", "Descricao", despesa.Despesa_Id);
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Despesa_Id = new SelectList(db.TipoDespesas, "Id", "Descricao", despesa.Despesa_Id);
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Despesa_Id,Data_Despesa,Despesa_Valor")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Despesa_Id = new SelectList(db.TipoDespesas, "Id", "Descricao", despesa.Despesa_Id);
            return View(despesa);
        }

        // GET: Despesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            db.Despesas.Remove(despesa);
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
