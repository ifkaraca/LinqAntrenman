using LinqAntrenman.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LinqAntrenman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly DbTelefonContext _context;

        public DenemeController(DbTelefonContext context)
        {
            _context = context;
        }

        [HttpGet("find/{id}")]
        public ActionResult<IEnumerable<TelefonTbl>> GetById(int id)
        {
            var result = _context.TelefonTbls.Find(id);
            return Ok(result);
        }

        [HttpGet("sart")]
        public ActionResult<IEnumerable<TelefonTbl>> GetSart()
        {
            var result = _context.TelefonTbls.Where(x => x.SatisAdet > 90).ToList();
            return Ok(result);
        }

        [HttpGet("select")]
        public ActionResult<IEnumerable<TelefonTbl>> GetSelect()
        {
            var result = _context.TelefonTbls.Select(x => new { x.Id, x.Marka, x.SatisAdet });
            return Ok(result);
        }

        [HttpGet("OrderBay")]
        public ActionResult<IEnumerable<TelefonTbl>> GetOrderBy()
        {
            var result = _context.TelefonTbls.OrderBy(x => x.Ucret);
            return Ok(result);
        }

        [HttpGet("OrderByDescending")]
        public ActionResult<IEnumerable<TelefonTbl>> GetOrderByDescending()
        {
            var result = _context.TelefonTbls.OrderByDescending(x => x.Ucret);
            return Ok(result);
        }

        [HttpGet("GrupBy")]
        public ActionResult<IEnumerable<TelefonTbl>> GetGruby()
        {
            var result = _context.TelefonTbls.GroupBy(x=> x.Marka);
            return Ok(result);
        }

        [HttpGet("Sum")]
        public ActionResult<IEnumerable<TelefonTbl>> GetSum()
        {
            var result = _context.TelefonTbls.Sum(x=> x.Ucret);
            return Ok(result);
        }

        [HttpGet("Avarage")]
        public ActionResult<IEnumerable<TelefonTbl>> GetArvarage()
        {
            var result= _context.TelefonTbls.Average(x=> x.Ucret);
            return Ok(result);
        }

        [HttpGet("min")]
        public ActionResult<IEnumerable<TelefonTbl>> GetMin()
        {
            var result = _context.TelefonTbls.Min(x => x.Ucret);
            return Ok(result);
        }

        [HttpGet("max")]
        public ActionResult<IEnumerable<TelefonTbl>> GetMax()
        {
            var result = _context.TelefonTbls.Max(x => x.Ucret);
            return Ok(result);
        }
    }
}
