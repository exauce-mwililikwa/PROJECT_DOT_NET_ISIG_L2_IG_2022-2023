using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UtilisateurController : Controller
    {
        DAO dao = new DAO();

        // GET: UtilisateurController
        public ActionResult Index()
        {
            //APPELONS NOTRE LISTE
            List<Utilisateur> listeutilisateur = dao.liste_user().ToList();
            return View(listeutilisateur);
        }

        // GET: UtilisateurController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Utilisateur user = dao.select_user_by_id(id);
            if (user == null) {
                return NotFound();
            }

            return View(user);
        }

        // GET: UtilisateurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilisateurController/Create
        [HttpPost]
      
        public ActionResult Create([Bind] Utilisateur user)
        {
            try
            {
                if (ModelState.IsValid) {
                    dao.insert_user(user);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilisateurController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Utilisateur user = dao.select_user_by_id(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UtilisateurController/Edit/5
        [HttpPost]
        
        public ActionResult Edit (int? id,[Bind] Utilisateur user)
        {
            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid) {
                    dao.update_user(user);
                    return RedirectToAction("Index"); }
                return View(dao);
            }
            

            catch
            {
                return View();
            }
            
        }

        // GET: UtilisateurController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) 
            
            { return NotFound(); }
            Utilisateur user = dao.select_user_by_id(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UtilisateurController/Delete/5
        [HttpPost,ActionName("delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                dao.delete_user(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
