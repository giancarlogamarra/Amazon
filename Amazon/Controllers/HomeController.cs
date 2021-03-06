﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.Models;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ViewResult RegBookForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RegBookForm(Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.AddResponse(book);
                return View("Thanks", book);
            }
            else
            {
                // Hay un error de validacion y retornamos una vista en blanco. 
                return View();
            }
        } 

        [HttpGet]
        public ViewResult ListResponses()
        {
            //return View(BookRepository.Responses.Where(b => b.Price > 100)); Libros caros
            //return View(BookRepository.Responses.Where(b => b.Price < 100)); Libros baratos
            return View(BookRepository.Books);
        }
    }
}


