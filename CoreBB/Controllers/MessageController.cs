using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreBB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CoreBB.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private CoreBBContext _dbContext;
        
        public MessageController(CoreBBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);

            var messages = _dbContext.Message.Include("ToUser").Include("FromUser").Where(m => m.ToUserId == user.Id || m.FromUserId == user.Id);

            return View(messages);
        }

        [HttpGet]
        public IActionResult Create(string toUserName)
        {
            var toUser = _dbContext.User.SingleOrDefault(u => u.Name == toUserName);
            if (toUser == null)
            {
                throw new Exception("Not a valid User.");
            }

            var message = new Message { ToUserId = toUser.Id, ToUser = toUser };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Message model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalide messasge information.");
            }
            var fromUser = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            model.FromUserId = fromUser.Id;
            model.SendDateTime = DateTime.Now;
            await _dbContext.Message.AddAsync(model);
            await _dbContext.SaveChangesAsync();
                       
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var message = _dbContext.Message.Include("ToUser").Include("FromUser").SingleOrDefault(m => m.Id == id);
            if (message == null)
            {
                throw new Exception("Message does not exist.");
            }

            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            if (message.ToUserId != user.Id && message.FromUserId != user.Id)
            {
                throw new Exception("Message access denied.");
            }

            if (message.ToUserId == user.Id)
            {
                message.IsRead = true;
            }

            _dbContext.Message.Update(message);
            await _dbContext.SaveChangesAsync();
            
            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var message = _dbContext.Message.Include("ToUser").Include("FromUser").SingleOrDefault(m => m.Id == id);
            if (message == null)
            {
                throw new Exception("Message does not exist.");
            }

            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            if (message.ToUserId != user.Id && message.FromUserId != user.Id)
            {
                throw new Exception("Message access denied.");
            }

            _dbContext.Message.Remove(message);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}